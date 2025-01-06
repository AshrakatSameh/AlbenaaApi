using AlbenaaAPi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlbenaaAPi.Context
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Courses> Courses { get; set; }

    }
}
