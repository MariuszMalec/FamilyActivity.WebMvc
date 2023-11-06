using FamilyActivity.WebMvc.Models;

namespace FamilyActivity.WebMvc.Contexts
{
    public class SeedData
    {
        public static void  SeedActiviesDays(ApplicationContext context)
        {
            if (context.ActiviesDays.Any())
            {
                return;
            }

            var activityDay = new ModelActivityDays()
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
            };
            context.AddRange(activityDay);
            context.SaveChanges();
        }

        public static void SeedPersonFamilies(ApplicationContext context)
        {
            if (context.PersonFamilies.Any())
            {
                return;
            }

            var personFamily = new ModelPersonFamily()
            {
                    Id = 1,
                    PersonName = Enums.PersonFamily.TATA,
                    PersonPicture = "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
            };
            context.AddRange(personFamily);
            context.SaveChanges();
        }

    }
}
