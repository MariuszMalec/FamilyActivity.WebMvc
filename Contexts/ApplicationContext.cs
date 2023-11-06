using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FamilyActivity.WebMvc.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ModelActivityDays> ActiviesDays { get; set; }

        public DbSet<ModelPersonFamily> PersonFamilies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("Server = 127.0.0.1; uid=root; pwd=Alicja@13; Database=activityDb;");//TODO to samo w appsettings.json jest

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelActivityDays>().ToTable("activiesDays");
            modelBuilder.Entity<ModelPersonFamily>().ToTable("personFamilies");
            modelBuilder.Entity<ModelPersonFamily>().HasData(new ModelPersonFamily { Id = 1,
                PersonName = Enums.PersonFamily.TATA,
                PersonPicture = "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}