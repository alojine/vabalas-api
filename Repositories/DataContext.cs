using System.ComponentModel.DataAnnotations.Schema;
using vabalas_api.Models;

namespace vabalas_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        
        public DbSet<Job> Job { get; set; }
        
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<JobOffer> JobOffers { get; set; }
        
        public DbSet<VabalasUser> VabalasUsers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobOffer>()
                .HasOne(jo => jo.Client)
                .WithMany(u => u.JobOffers)
                .HasForeignKey(jo => jo.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.User)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Author)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
