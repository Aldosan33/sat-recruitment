using Microsoft.EntityFrameworkCore;
using SatRecruitment.Domain.Entities;

namespace SatRecruitment.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
