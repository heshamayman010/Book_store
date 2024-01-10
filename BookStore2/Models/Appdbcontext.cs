using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookStore2.Models
{
    public class Appdbcontext : IdentityDbContext<Appuser>

    {


        public DbSet<BookDepartment> BookDepartment { get; set; }

        public DbSet<Books> Books { get; set; }
        public DbSet<Readers> Readers { get; set; }
        public Appdbcontext()
        {

        }

        public Appdbcontext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);

            options.UseSqlServer("Server = .\\SQLEXPRESS; Database = TheBookStore; Integrated Security = SSPI; TrustServerCertificate = True;");

        }
    }
}
