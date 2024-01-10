using BookStore2.Migrations;
using BookStore2.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBooksRepo repo;

        public LibraryController(IBooksRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Addbook() { 
        
        return View();
        
        }
        [HttpPost]
        public IActionResult Addbook(Books book)
        {
            if (ModelState.IsValid)
            {
                Books neww = new Books();
                neww.Author = book.Author;
                neww.Price = book.Price;


                neww.Description = book.Description;
                neww.Name = book.Name;
                neww.Image = book.Image;
                neww.Author = book.Author;
                if (book.readerid != 0)
                {
                    neww.readerid = book.readerid;
                }

                repo.AddBook(neww);
            
            }


            return RedirectToAction("Index","Home");

        }


        public IActionResult getallbooks() { 
        
        var lista=repo.getAllBooks();
            return View(lista);
        
        
        }

        public IActionResult getbook(int id)
        {
            
     var booktoread=   repo.getbook(id);
            return View(booktoread);



        }

        public IActionResult getbook2(int id)
        {

            var context = new Appdbcontext();
            var lista=context.Books.Where(x=>x.dptid==id).ToList();
            return Json(lista);



        }


        public IActionResult Alldepartments() {
            var context = new Appdbcontext();
            var listofdepartments=context.BookDepartment.ToList();


            return View(listofdepartments);
        
        
        
        
        }
    public IActionResult Getallwithdeptid(int dd)
        {

            var context = new Appdbcontext();
            var listaa=context.Books.Where(x=>x.dptid==dd).ToList();
            return View(listaa);


        }

    
    
    }
}
