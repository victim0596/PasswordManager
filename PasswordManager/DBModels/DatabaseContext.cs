using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DBModels
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<PswManager> pswManagers { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PswManagerEntityConfiguration(modelBuilder.Entity<PswManager>());
            new UserEntityConfiguration(modelBuilder.Entity<User>());
        }
    }
}
