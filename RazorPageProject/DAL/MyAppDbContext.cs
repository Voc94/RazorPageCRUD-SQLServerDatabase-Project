using Microsoft.EntityFrameworkCore;
using RazorPageProject.Models;

namespace RazorPageProject.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options) {

        }
        public virtual DbSet<Product> Products{ get; set;}
    }
}
