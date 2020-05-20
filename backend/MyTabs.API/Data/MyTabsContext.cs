using Microsoft.EntityFrameworkCore;
using MyTabs.API.Model;

namespace MyTabs.API.Data
{
    public class MyTabsContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MyTabsContext(DbContextOptions<MyTabsContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
        }
    }
}