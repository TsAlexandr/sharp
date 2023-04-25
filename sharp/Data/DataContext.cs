global using Microsoft.EntityFrameworkCore;

namespace sharp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(@"Host=db.thin.dev;Username=bKzZdeKSsARsZgIhRfqktticJHFbGbrA;Password=dJtGiisKPdbWUkHRHvbxtlkORPmFFgGA;Database=8fbb213d-6f1b-41f2-97c9-629dc4188f78");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostsViewModel>()
                .HasOne(p => p.Blogs)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogId);
                
        }

        public DbSet<BlogsViewModel> BlogsViewModel { get; set; }
        public DbSet<PostsViewModel> PostsViewModel { get; set; }
    }
}

//model creating, ovveride [foreignkey //public blogid]
