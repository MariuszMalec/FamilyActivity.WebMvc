using FamilyActivity.WebMvc.Models;

namespace FamilyActivity.WebMvc.Contexts
{
    public class SeedActivityOrder
    {
        public static async Task SeedActiviesOrders(WorkOrderDbContext context, ApplicationContext contextActivity)
        {
            //TODO bez sensu kasuje tutaj dane z tabeli aby je wrzucic jako aktualne przy odpaleniu api, inaczej zrobic!
            var itemsToDelete = context.Set<WorkOrder>();
            context.WorkOrders.RemoveRange(itemsToDelete);
            context.SaveChanges();
 
            if (context.WorkOrders.Any())
            {
                return;
            }

            var mondayStart = GetStartHour(contextActivity, Enums.DayOfWeek.Monday, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy);
            var mondayEnd = GetEndHour(contextActivity, Enums.DayOfWeek.Monday, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(mondayStart),//Convert.ToDateTime(DateTime.Now.AddHours(-4).ToString("hh:mm")),
                End = Convert.ToDateTime(mondayEnd),//Convert.ToDateTime(DateTime.Now.AddHours(-3).ToString("hh:mm")),
                Color = "#6aa84f",
                Ordinal = 0,
                Resource = context.Resources.Find(1),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Czas_do_pracy.ToString(),
            });

            mondayStart = GetStartHour(contextActivity, Enums.DayOfWeek.Monday, Enums.PersonFamily.GOSIA, Enums.ActivityName.Bajki);
            mondayEnd = GetEndHour(contextActivity, Enums.DayOfWeek.Monday, Enums.PersonFamily.GOSIA, Enums.ActivityName.Bajki);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(mondayStart),
                End = Convert.ToDateTime(mondayEnd),
                Color = "#EF8C03",
                Ordinal = 0,
                Resource = context.Resources.Find(3),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Bajki.ToString(),
            });

            await context.SaveChangesAsync();
        }

        private static string GetStartHour(ApplicationContext contextActivity,
            Enums.DayOfWeek day,
            Enums.PersonFamily person,
            Enums.ActivityName activity)
        {
            return contextActivity.ActiviesDays.Where(a => a.DayOfWeek == day)
                .Where(f => f.ModelPersonFamily.PersonName == person)
                .Where(f => f.ModelPictureActivity.ActivityName == activity)
                .Select(f => f.StartTime.Hours + ":" + f.StartTime.Minutes)
                .First();
        }

        private static string GetEndHour(ApplicationContext contextActivity,
            Enums.DayOfWeek day,
            Enums.PersonFamily person,
            Enums.ActivityName activity)
        {
            return contextActivity.ActiviesDays.Where(a => a.DayOfWeek == day)
                .Where(f => f.ModelPersonFamily.PersonName == person)
                .Where(f => f.ModelPictureActivity.ActivityName == activity)
                .Select(f => f.EndTime.Hours + ":" + f.EndTime.Minutes)
                .First();
        }
    }
       
}
