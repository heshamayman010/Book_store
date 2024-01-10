using Microsoft.AspNetCore.Identity;

namespace BookStore2.Models
{
    public class Appuser : IdentityUser
    {

        public string? Address { get; set; }



    }
}
