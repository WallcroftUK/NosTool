using Microsoft.EntityFrameworkCore;
using NosTool.DataAccess.MSSQL.Entities;
using NosTool.DataAccess.MSSQL.Helpers;

namespace NosTool.DataAccess.MSSQL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ShopEntity> Shop { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for ShopEntity
            modelBuilder.Entity<ShopEntity>().HasKey(x => x.ShopId);

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set the connection string
            optionsBuilder.UseSqlServer(DataAccessHelper.GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }
    }
}