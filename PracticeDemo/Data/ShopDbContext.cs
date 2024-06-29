using Microsoft.EntityFrameworkCore;
using PracticeDemo.Models;

namespace PracticeDemo.Data
{
    public class ShopDbContext:DbContext
    {
        public ShopDbContext(DbContextOptions options ): base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
