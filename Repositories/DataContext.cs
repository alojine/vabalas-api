using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using vabalas_api.Models;

namespace vabalas_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Job> Job { get; set; }
        
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<JobOffer> JobOffers { get; set; }
        
        public DbSet<VabalasUser> VabalasUsers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VabalasUser>(ConfigureVabalasUser);
            modelBuilder.Entity<Job>(ConfigureJob);
            modelBuilder.Entity<JobOffer>(ConfigureJobOffer);
            modelBuilder.Entity<Review>(ConfigureReview);
        }

        private void ConfigureJob(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);

            builder.HasOne(j => j.Owner)
                .WithMany(u => u.Jobs)
                .HasForeignKey(j => j.OwnerId)
                .IsRequired();
        }

        private void ConfigureJobOffer(EntityTypeBuilder<JobOffer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Sender)
                .WithMany()
                .HasForeignKey(o => o.SenderId)
                .IsRequired();
            
            builder.HasOne(o => o.Job)
                .WithMany(j => j.JobOffers)
                .HasForeignKey(o => o.JobId)
                .IsRequired();
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.Author)
                .WithMany()
                .HasForeignKey(r => r.AuthorId)
                .IsRequired();

            builder.HasOne(r => r.Job)
                .WithMany(j => j.Reviews)
                .HasForeignKey(r => r.JobId)
                .IsRequired();
        }
        
        private void ConfigureVabalasUser(EntityTypeBuilder<VabalasUser> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Jobs)
                .WithOne(j => j.Owner)
                .HasForeignKey(j => j.OwnerId);

            builder.HasMany(u => u.JobOffers)
                .WithOne(o => o.Sender)
                .HasForeignKey(o => o.SenderId);

            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.Author)
                .HasForeignKey(r => r.AuthorId);
        }
    }
}
