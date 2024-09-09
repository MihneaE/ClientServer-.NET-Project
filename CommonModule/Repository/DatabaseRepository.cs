using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Model;
using Microsoft.EntityFrameworkCore;

namespace CommonModule.Repository
{
    public class DatabaseRepository : DbContext
    {
        public DbSet<Man> Men { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = @"D:\MPP\C#\ClientServerApp\ClientServerApp\CommonModule\concursDB.db";
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Man>().ToTable("Men");
            modelBuilder.Entity<Competition>().ToTable("Competitions");
            modelBuilder.Entity<User>().ToTable("Users");
        }

        public void AddMan(Man newMan)
        {
            try
            {
                Men.Add(newMan);
                SaveChanges(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding new Man: " + ex.Message);
                throw; 
            }
        }
    }
}
