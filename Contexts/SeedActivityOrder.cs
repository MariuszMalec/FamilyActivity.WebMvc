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

            var today = (Enums.DayOfWeek)DateTime.Now.DayOfWeek + 1;

            if (context.WorkOrders.Any())
            {
                return;
            }

            SetWork(context, contextActivity, today, Enums.PersonFamily.GOSIA, Enums.ActivityName.Bajki, "#EF8C03");
            SetWork(context, contextActivity, today, Enums.PersonFamily.EMILKA, Enums.ActivityName.Bajki, "#ecb823");
            SetWork(context, contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy, "#6aa84f");
            SetWork(context, contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Czas_do_pracy, "#3F85A4");
            SetWork(context, contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_spac, "#6aa84f");
            SetWork(context, contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_tylko_taty, "#6aa84f");
            SetWork(context, contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Odrabianie_lekcji, "#6aa84f");
            SetWork(context, contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Sprzatanie_kuchni, "#6aa84f");
            SetWork(context, contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Sprzatanie_lazienki, "#6aa84f");
            SetWork(context, contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Czas_spac, "#3F85A4");
            SetWork(context, contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Czas_tylko_mamy, "#3F85A4");
            SetWork(context, contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Odrabianie_lekcji, "#3F85A4");
            SetWork(context, contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Sprzatanie_kuchni, "#3F85A4");
            SetWork(context, contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Sprzatanie_lazienki, "#3F85A4");
            SetWork(context, contextActivity, today, Enums.PersonFamily.GOSIA, Enums.ActivityName.Basen, "#EF8C03");
            await context.SaveChangesAsync();
        }

        private static void SetWork(WorkOrderDbContext context,
            ApplicationContext contextActivity,
            Enums.DayOfWeek today,
            Enums.PersonFamily person,
            Enums.ActivityName activity,
            string color)
        {
            var startWork = GetStartHour(contextActivity, today, person, activity);
            var endWork = GetEndHour(contextActivity, today, person, activity);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(startWork),//Convert.ToDateTime(DateTime.Now.AddHours(-4).ToString("hh:mm")),
                End = Convert.ToDateTime(endWork),//Convert.ToDateTime(DateTime.Now.AddHours(-3).ToString("hh:mm")),
                Color = color,
                Ordinal = 0,
                Resource = context.Resources.Find((int)person),
                OrdinalPriority = DateTime.Now,
                Text = activity.ToString(),
            });
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
                .FirstOrDefault();
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
                .FirstOrDefault();
        }
    }
       
}
