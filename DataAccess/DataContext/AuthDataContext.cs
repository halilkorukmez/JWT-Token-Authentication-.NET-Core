using DataAccess.Mapping;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.DataContext
{
    public class AuthDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=DESKTOP-147B76S;Database=Test1;Trusted_Connection=True");
        }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
         
        }



        
        


    }
}
