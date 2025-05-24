using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using startup.Models;

namespace startup.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Comment> Comment { get; set; }

}
