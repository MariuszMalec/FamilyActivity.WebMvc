using FamilyActivity.WebMvc.Models;
using Microsoft.AspNetCore.DataProtection;

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

            //var mondayStart = GetStartHour(contextActivity, Enums.DayOfWeek.Monday, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy);
            //var mondayEnd = GetEndHour(contextActivity, Enums.DayOfWeek.Monday, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy);
            //context.Add(new WorkOrder()
            //{
            //    Start = Convert.ToDateTime(mondayStart),//Convert.ToDateTime(DateTime.Now.AddHours(-4).ToString("hh:mm")),
            //    End = Convert.ToDateTime(mondayEnd),//Convert.ToDateTime(DateTime.Now.AddHours(-3).ToString("hh:mm")),
            //    Color = "#6aa84f",
            //    Ordinal = 0,
            //    Resource = context.Resources.Find(1),
            //    OrdinalPriority = DateTime.Now,
            //    Text = Enums.ActivityName.Czas_do_pracy.ToString(),
            //});

            var startbajkigosia = GetStartHour(contextActivity, today, Enums.PersonFamily.GOSIA, Enums.ActivityName.Bajki);
            var endbajkigosia = GetEndHour(contextActivity, today, Enums.PersonFamily.GOSIA, Enums.ActivityName.Bajki);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(startbajkigosia),
                End = Convert.ToDateTime(endbajkigosia),
                Color = "#EF8C03",
                Ordinal = 0,
                Resource = context.Resources.Find(3),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Bajki.ToString(),
            });
            var startbajkiemisia = GetStartHour(contextActivity, today, Enums.PersonFamily.EMILKA, Enums.ActivityName.Bajki);
            var endbajkiemisia = GetEndHour(contextActivity, today, Enums.PersonFamily.EMILKA, Enums.ActivityName.Bajki);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(startbajkiemisia),
                End = Convert.ToDateTime(endbajkiemisia),
                Color = "#ecb823",
                Ordinal = 0,
                Resource = context.Resources.Find(4),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Bajki.ToString(),
            });

            var startWork = GetStartHour(contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy);
            var endWork = GetEndHour(contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_do_pracy);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(startWork),//Convert.ToDateTime(DateTime.Now.AddHours(-4).ToString("hh:mm")),
                End = Convert.ToDateTime(endWork),//Convert.ToDateTime(DateTime.Now.AddHours(-3).ToString("hh:mm")),
                Color = "#6aa84f",
                Ordinal = 0,
                Resource = context.Resources.Find(1),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Czas_do_pracy.ToString(),
            });

            var startSleep = GetStartHour(contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_spac);
            var endSleep = GetEndHour(contextActivity, today, Enums.PersonFamily.TATA, Enums.ActivityName.Czas_spac);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(startSleep),
                End = Convert.ToDateTime(endSleep),
                Color = "#EF8C03",
                Ordinal = 0,
                Resource = context.Resources.Find(1),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Czas_spac.ToString(),
            });
            var startSleepm = GetStartHour(contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Czas_spac);
            var endSleepm = GetEndHour(contextActivity, today, Enums.PersonFamily.MAMA, Enums.ActivityName.Czas_spac);
            context.Add(new WorkOrder()
            {
                Start = Convert.ToDateTime(startSleepm),
                End = Convert.ToDateTime(endSleepm),
                Color = "#3F85A4",
                Ordinal = 0,
                Resource = context.Resources.Find(2),
                OrdinalPriority = DateTime.Now,
                Text = Enums.ActivityName.Czas_spac.ToString(),
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
