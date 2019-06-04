using CodingChallengeBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CodingChallengePersistance.Context
{
    /// <summary>
    /// Dataontext for manage database
    /// </summary>
    public class DataContext : DbContext
    {
        private string connectionString;
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<UserShopPreference> UserShopPreferences { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(connectionString))
                connectionString = Constants.DefaultConnectionString;
            optionsBuilder.UseSqlite(connectionString);
        }

        public DataContext() : base()
        {

        }
        public DataContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Property Configurations
            modelBuilder.Entity<User>(entity =>
            {
                entity.OwnsOne(e => e.Position);
            });
            modelBuilder.Entity<Shop>(entity =>
            {
                entity.OwnsOne(e => e.Position);
            });
        }

        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}