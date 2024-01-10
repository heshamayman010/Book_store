using Microsoft.AspNetCore.Mvc;

namespace BookStore2.Models
{
    public class Readers
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Books> Book { get; set; }
    }
}
