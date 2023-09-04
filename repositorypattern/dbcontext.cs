using Microsoft.EntityFrameworkCore;
using repositorypattern.Model;

namespace repositorypattern
{
    public class dBContext : DbContext
    {
        public dBContext(DbContextOptions<dBContext> options):base(options)
        {       
        }

        public DbSet<Product> Products { get; set; }
    }
}
