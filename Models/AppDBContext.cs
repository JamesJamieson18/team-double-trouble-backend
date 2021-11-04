using Microsoft.EntityFrameworkCore;

namespace team_double_trouble_backend.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}