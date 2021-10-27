using Microsoft.EntityFrameworkCore;

namespace team_double_trouble_backend.Models
{
    public class PostsContext : DbContext
    {
        public PostsContext(DbContextOptions<PostsContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}