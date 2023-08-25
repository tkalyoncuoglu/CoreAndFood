using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Data.Models
{
    public class CoreAndFoodContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }  

        public DbSet<Admin> Admins { get; set; }
    }
}
