using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FamilyActivity.WebMvc.Models
{
    public class WorkOrder
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [JsonPropertyName("resource")]
        public int? ResourceId { get; set; }

        [JsonIgnore]
        public Resource? Resource { get; set; }

        public int Ordinal { get; set; }

        public DateTime OrdinalPriority { get; set; }

        public string? Color { get; set; }
    }

    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [JsonIgnore]
        public Group Group { get; set; }

        [JsonIgnore]
        public int GroupId { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("children")]
        public ICollection<Resource> Resources { get; set; }
    }


    public class WorkOrderDbContext : DbContext
    {
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public WorkOrderDbContext(DbContextOptions<WorkOrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().HasData(new Group { Id = 1, Name = "Group 1" });
            modelBuilder.Entity<Group>().HasData(new Group { Id = 2, Name = "Group 2" });
            modelBuilder.Entity<Group>().HasData(new Group { Id = 3, Name = "Group 3" });

            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 1, Name = "Person A", GroupId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 2, Name = "Person B", GroupId = 1 });
            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 3, Name = "Person C", GroupId = 1 });

            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 4, Name = "Person D", GroupId = 2 });
            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 5, Name = "Person E", GroupId = 2 });
            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 6, Name = "Person F", GroupId = 2 });

            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 7, Name = "Person G", GroupId = 3 });
            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 8, Name = "Person H", GroupId = 3 });

        }
    }
}
