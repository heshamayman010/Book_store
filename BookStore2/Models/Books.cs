using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore2.Models
{
    public class Books
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="the name you enterd is over than the allowed")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
       
        [Required]
        public string Image { set; get; }
        [Required]
        [Range(minimum:30,maximum:200,ErrorMessage ="the price is between the rang 30 and 200")]
        public decimal Price { get; set; }

        public int? readerid { get; set; }

        public BookDepartment? thedepartment { set; get; }

        [ForeignKey("thedepartment")]
        public int? dptid { get; set; }


    }
}
