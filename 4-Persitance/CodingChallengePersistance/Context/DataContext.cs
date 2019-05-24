using CodingChallengeBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CodingChallengePersistance.Context
{
    public class DataContext : DbContext
    {
        private string connectionString;
        public DbSet<User> Users { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<PreferredShop> PreferredShops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(string.IsNullOrEmpty(connectionString))
                connectionString=Constants.DefaultConnectionString;
            optionsBuilder.UseSqlite(connectionString);
        }

        public DataContext():base()
        {
            
        }
        public DataContext(string connectionString)
        {
            this.connectionString=connectionString;
        }
    }
}