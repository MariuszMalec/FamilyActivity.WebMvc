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
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("9:30:00".ToString()),
                EndTime = TimeSpan.Parse("17:30:00".ToString()),
                Description = "Kurcze",
                ModelPersonFamily = context.PersonFamilies.Find(1),
                ModelPictureActivity = context.PictureActivities.Find(6)
            });

            context.Add(new ModelActivityDays()
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Porzadeczki",
                ModelPersonFamily = context.PersonFamilies.Find(2),
                ModelPictureActivity = context.PictureActivities.Find(1)
            });

            context.Add(new ModelActivityDays()
            {
                Id = 3,
                CreatedAt = DateTime.Now,
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Wieczorynka",
                ModelPersonFamily = context.PersonFamilies.Where(p=>p.PersonName == Enums.PersonFamily.GOSIA).Select(p=>p).FirstOrDefault(),
                ModelPictureActivity = context.PictureActivities.Where(p=>p.ActivityName == Enums.ActivityName.Bajki).Select(p=>p).FirstOrDefault()
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedPersonFamilies(ApplicationContext context)
        {
            if (context.PersonFamilies.Any())
            {
                return;
            }

            context.Add(new ModelPersonFamily(1, Enums.PersonFamily.TATA, "https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(2, Enums.PersonFamily.MAMA, "https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(3, Enums.PersonFamily.GOSIA, "https://images.unsplash.com/photo-1516627145497-ae6968895b74?q=80&w=2040&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(4, Enums.PersonFamily.EMILKA, "https://images.unsplash.com/photo-1566004100631-35d015d6a491?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPersonFamily(5, Enums.PersonFamily.ALL, "https://images.unsplash.com/photo-1696446702183-cbd13d78e1e7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));

            await context.SaveChangesAsync();
        }

        public static async Task SeedPictureActivities(ApplicationContext context)
        {
            if (context.PictureActivities.Any())
            {
                return;
            }
            context.Add(new ModelPictureActivity(1, Enums.ActivityName.Sprzatanie_lazienki,
            "https://images.unsplash.com/photo-1584622650111-993a426fbf0a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(2, Enums.ActivityName.Basen,
            "https://images.unsplash.com/photo-1575429198097-0414ec08e8cd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80"));
            context.Add(new ModelPictureActivity(3, Enums.ActivityName.Pranie,
            "https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80"));
            context.Add(new ModelPictureActivity(4, Enums.ActivityName.Odrabianie_lekcji,
            "https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80"));
            context.Add(new ModelPictureActivity(5, Enums.ActivityName.Czas_spac,
            "https://images.unsplash.com/photo-1558427400-bc691467a8a9?auto=format&fit=crop&q=80&w=1924&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(6, Enums.ActivityName.Czas_do_pracy,
            "https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(7, Enums.ActivityName.Bajki,
            "https://images.unsplash.com/photo-1515041219749-89347f83291a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80"));
            context.Add(new ModelPictureActivity(8, Enums.ActivityName.Wstazka,
            "https://images.unsplash.com/photo-1599058917212-d750089bc07e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2069&q=80"));
            context.Add(new ModelPictureActivity(10, Enums.ActivityName.Zamiatanie_pokoji,
            "https://images.unsplash.com/photo-1527515637462-cff94eecc1ac?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(11, Enums.ActivityName.Sprzatanie_kuchni,
            "https://images.unsplash.com/photo-1600585152220-90363fe7e115?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));

            await context.SaveChangesAsync();
        }

    }
}
