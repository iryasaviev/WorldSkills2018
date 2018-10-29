using Microsoft.EntityFrameworkCore;
using MobileUWP.Database.Entities;

namespace MobileUWP.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Filename=WorldSkillsMobile.db");
        }
    }
}