using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.DataContext
{
    public class AuthDataContext : DbContext
    {
     
        public AuthDataContext(DbContextOptions<AuthDataContext> options)
             : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Connection String")
                    .EnableSensitiveDataLogging(false)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }

            base.OnConfiguring(optionsBuilder);
        }

    }
}
