using Microsoft.EntityFrameworkCore;
using repositorypattern.Model;

namespace repositorypattern
{
    public class dBcontext : DbContext
    {
        public dBcontext(DbContextOptions<dBcontext> options):base(options)
        {       
        }

        public DbSet<Product> Products { get; set; }
    }
}
