using FamilyActivity.WebMvc.Models;

namespace FamilyActivity.WebMvc.Contexts
{
    public class SeedData
    {
        public static async Task SeedActiviesDays(ApplicationContext context)
        {
            if (context.ActiviesDays.Any())
            {
                return;
            }

            context.Add(new ModelActivityDays()
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = Enums.ActivityName.Czas_do_pracy,
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("9:30:00".ToString()),
                EndTime = TimeSpan.Parse("17:30:00".ToString()),
                Description = "Kurcze",
                Picture = "https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                ModelPersonFamily = context.PersonFamilies.Find(1),
            });
            context.Add(new ModelActivityDays()
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                Name = Enums.ActivityName.Sprzatanie_kuchni,
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Porzadeczki",
                Picture = "https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                ModelPersonFamily = context.PersonFamilies.Find(2),
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedPersonFamilies(ApplicationContext context)
        {
            if (context.PersonFamilies.Any())
            {
                return;
            }

            //context.AddRange(new ModelPersonFamily
            //{
            //    Id = 1,
            //    PersonName = Enums.PersonFamily.TATA,
            //    PersonPicture = "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            //});
            //context.AddRange(new ModelPersonFamily
            //{
            //    Id = 2,
            //    PersonName = Enums.PersonFamily.MAMA,
            //    PersonPicture = "https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            //});

            var personFamilies = new List<ModelPersonFamily>() 
            {
                new ModelPersonFamily(1, Enums.PersonFamily.TATA, "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
                new ModelPersonFamily(2, Enums.PersonFamily.MAMA, "https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"),
                new ModelPersonFamily(3, Enums.PersonFamily.GOSIA, "https://images.unsplash.com/photo-1516627145497-ae6968895b74?q=80&w=2040&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D")
            };

            //context.AddRange(new List<ModelPersonFamily> () { new ModelPersonFamily(1, Enums.PersonFamily.TATA, "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D")
            //                       , new ModelPersonFamily(2, Enums.PersonFamily.MAMA, "https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D")});

            //foreach (var item in personFamilies)
            //{
            //    context.AddRange(item);
            //}

            //context.AddRange(personFamilies);

            context.Add(new ModelPersonFamily(1, Enums.PersonFamily.TATA, "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(2, Enums.PersonFamily.MAMA, "https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(3, Enums.PersonFamily.GOSIA, "https://images.unsplash.com/photo-1516627145497-ae6968895b74?q=80&w=2040&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(4, Enums.PersonFamily.EMILKA, "https://images.unsplash.com/photo-1566004100631-35d015d6a491?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(5, Enums.PersonFamily.ALL, "https://images.unsplash.com/photo-1696446702183-cbd13d78e1e7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));

            await context.SaveChangesAsync();
        }

    }
}
