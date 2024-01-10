using BookStore2.Models;
using BookStore2.Models.viewmodels;
using BookStore2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Appuser> manger;
        private readonly SignInManager<Appuser> signinmanger;

        public AccountController(UserManager<Appuser> manger,SignInManager<Appuser> signinmanger)
        {
            this.manger = manger;
            this.signinmanger = signinmanger;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        public async Task< IActionResult> Register(Registerviewmodel model)
        {

            if (ModelState.IsValid == true)
            {

                // the data of the user is correct 

                Appuser user = new Appuser();
                user.Email = model.Email;
                user.UserName = model.Username;
                user.PasswordHash = model.Password;


                var result = await manger.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // this means that the user is created 
                    await signinmanger.SignInAsync(user, false);

                    return RedirectToAction("Index","Home");
                }
                else {

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(model);


                }
            }
            else
            {

                return View(model);

            }


        }

        // now lets apply the login 
        
        
        [HttpGet]
        public IActionResult Login() { 
        
        return View() ;
        
        }

        [HttpPost]
        public async Task <IActionResult> Login(Loginviewmodel model)
        {

            if (ModelState.IsValid)
            {
                // first we need to getback user that is in the data base 

                Appuser userfound = await manger.FindByNameAsync(model.Username);
                if (userfound != null)
                {
                    bool result=await manger.CheckPasswordAsync(userfound, model.Password);
                    if (result == true)
                    {
                        await signinmanger.SignInAsync(userfound, model.RememberMe);

                        return RedirectToAction("Index", "Home");

                    }

                    else { ModelState.AddModelError("", "the password is incorrect"); }

                }
                else { ModelState.AddModelError("", "the user you enterd Not found"); }





            }
            return View();

        }


        public async Task <IActionResult> Logout() {

            await signinmanger.SignOutAsync();
            return RedirectToAction("Login", "Account");
        

        }
    }
}
