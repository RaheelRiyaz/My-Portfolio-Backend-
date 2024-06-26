using Microsoft.EntityFrameworkCore;
using Portfolio.Core.UtilsMehtods;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Persistence.Database
{
    public class RaheelPortfolioDbContext : DbContext
    {
        public RaheelPortfolioDbContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = Guid.NewGuid(),
                   Login = "rahilriyaz27@gmail.com",
                   Password = Utils.HashPassword("rahilriyaz27"),
               }
            );
        }

        #region Models

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<Experience> Experiences { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;

        #endregion Models

    }
}
