using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BlogUser> BlogUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BlogUser>().ToTable("BlogUsers", schema: "blog");
            mb.Entity<BlogPost>().ToTable("BlogPosts", schema: "blog");

            mb.Entity<BlogPost>()
                .HasOne(p => p.BlogUser)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(p => p.BlogUserId);

        }
    }


}