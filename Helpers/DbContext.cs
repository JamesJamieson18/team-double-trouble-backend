using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using team_double_trouble_backend.Entities;

namespace team_double_trouble_backend.Helpers
{
    public class SqliteDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public SqliteDataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("QuackerDatabase"));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}