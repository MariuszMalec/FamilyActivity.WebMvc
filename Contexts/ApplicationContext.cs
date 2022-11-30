using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyActivity.WebMvc.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ViewActivityDays> ActiviesDays { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=C:\\Temp\\Databases\\Movies.db");//TODO to samo w appsettings.json jest

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewActivityDays>().ToTable("activiesDays");
            base.OnModelCreating(modelBuilder);
        }

    }
}