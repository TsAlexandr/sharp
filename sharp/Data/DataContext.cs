global using Microsoft.EntityFrameworkCore;

namespace sharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Host=db.thin.dev;Username=bKzZdeKSsARsZgIhRfqktticJHFbGbrA;Password=dJtGiisKPdbWUkHRHvbxtlkORPmFFgGA;Database=8fbb213d-6f1b-41f2-97c9-629dc4188f78");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogsViewModel>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Blog)
                .HasForeignKey(e => e.BlogId)
                .HasPrincipalKey(e => e.Id);
        }

        public DbSet<BlogsViewModel> Blogs { get; set; }
        public DbSet<PostsViewModel> Posts { get; set; }
    }
}

//model creating, ovveride [foreignkey //public blogid]
