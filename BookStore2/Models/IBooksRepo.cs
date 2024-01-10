using BookStore2.Models;

namespace BookStore2.Models
{
    public interface IBooksRepo
    {

        // create 

        void AddBook(Books book);

         void DeleteBook(int id);

         Books getbook(int id);


        List<Books> getAllBooks();
        void updatebook(int id, Books book);

        List<Books> Getbydepartment(int id);
    }
}




