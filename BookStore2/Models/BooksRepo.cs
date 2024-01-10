namespace BookStore2.Models
{
    public class BooksRepo: IBooksRepo
    {


            private readonly Appdbcontext context;

            // CRUD
            public BooksRepo(Appdbcontext _context)
            {
                context = _context;
            }



            // create 

            public void AddBook(Books book)
            {



                using (var context = new Appdbcontext())
                {

                    context.Books.Add(book);
                    context.SaveChanges();
                }




            }



            public void DeleteBook(int id)
            {
                var usertodelet = context.Books.FirstOrDefault(x => x.Id == id);
                context.Books.Remove(usertodelet);

                context.SaveChanges();

            }

            public Books getbook(int id)
            {
                var user = context.Books.FirstOrDefault(x => x.Id == id);
                return user;
            }


        

            public List<Books> getAllBooks()
            {



                List<Books> all = context.Books.ToList();
                return all;

            }


        public void updatebook(int id ,Books book)
        {


            var booktoupdate = context.Books.FirstOrDefault(x => x.Id == id);
            if (booktoupdate != null)
            {
                booktoupdate.Name = book.Name;
                if (book.readerid != null)
                {
                    booktoupdate.readerid = book.readerid;
                }

                booktoupdate.Author = book.Author; booktoupdate.Description = book.Description;
                booktoupdate.Price = book.Price;
                booktoupdate.Image = book.Image;
                context.SaveChanges();
            }
        }

        public List<Books> Getbydepartment(int id) { 
        
        
        var lista=context.Books.Where(x=>x.dptid == id).ToList();

            return lista;
        
        }

}
}
