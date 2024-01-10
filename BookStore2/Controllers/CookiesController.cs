using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class CookiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult setcookies() {

            int age = 25;
            string name = "hesham";

            CookieOptions options=new CookieOptions();
            options.Secure = true;
            options.Expires = DateTimeOffset.Now.AddDays(15);

            Response.Cookies.Append("age", "25",options);
            Response.Cookies.Append("name", "hesham",options);
            return Content("the cookies is saved");


        }
        public IActionResult getcookies()

        { 
        
        var resp = Request.Cookies["name"];
            var resp2 = Request.Cookies["age"];

            return Content(resp);
        
        
        }


        public IActionResult Setsession()
        {

            HttpContext.Session.SetString("name", "hesham");
            HttpContext.Session.SetInt32("age", 30);

            var sessionv    = HttpContext.Session.GetString("name");
            return Content(sessionv);
        }


    }
}
