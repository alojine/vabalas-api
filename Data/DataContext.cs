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
    }
}
