using FamilyActivity.WebMvc.Enums;
using FamilyActivity.WebMvc.Models;
using Newtonsoft.Json;

namespace FamilyActivity.WebMvc.Contexts
{
    public class SeedDataFromJson
    {
        public static async Task SeedActiviesDays(ApplicationContext context)
        {
            if (context.ActiviesDays.Any())
            {
                return;
            }

            string data = GetDataActivity();

            List<ModelActivityDays> modelActivityDays = JsonConvert.DeserializeObject<List<ModelActivityDays>>(data);

            foreach (var item in modelActivityDays)
            {
                var activity = new ModelActivityDays()
                {
                    Id = item.Id,
                    CreatedAt = Convert.ToDateTime(item.CreatedAt),
                    Name = item.Name,
                    StartTime = item.StartTime,//TimeSpan.Parse(item.StartTime.ToString()),
                    EndTime = item.EndTime,
                    Description = item.Description,
                    Picture = item.Picture,
                    DayOfWeek = item.DayOfWeek,
                    ModelPersonFamily = item.ModelPersonFamily
                };
                context.Add(activity);
            }
            await context.SaveChangesAsync();
        }

        private static string GetDataActivity()
        {
            string filePath = @"./DataBase/InitialDataActivity.json";
            using (var r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }

        private static Enums.PersonFamily GetPerson(string person)
        {
            if (person.Contains('1'))
                return Enums.PersonFamily.TATA;
            if (person.Contains('2'))
                return Enums.PersonFamily.MAMA;
            if (person.Contains('3'))
                return Enums.PersonFamily.GOSIA;
            if (person.Contains('4'))
                return Enums.PersonFamily.EMILKA;
            return Enums.PersonFamily.ALL;
        }

        private static Enums.DayOfWeek GetDay(string day)
        {
            if (day.Contains('1'))
                return Enums.DayOfWeek.Monday;
            if (day.Contains('2'))
                return Enums.DayOfWeek.Tuesday;
            if (day.Contains('3'))
                return Enums.DayOfWeek.Wednesday;
            if (day.Contains('4'))
                return Enums.DayOfWeek.Thursday;
            if (day.Contains('5'))
                return Enums.DayOfWeek.Friday;
            if (day.Contains('6'))
                return Enums.DayOfWeek.Saturday;
            if (day.Contains('7'))
                return Enums.DayOfWeek.Sunday;
            return Enums.DayOfWeek.All;
        }

        private static ActivityName GetName(string name)
        {
            if (name.Contains('1'))
                return Enums.ActivityName.Sprzatanie_kuchni;
            if (name.Contains('2'))
                return Enums.ActivityName.Sprzatanie_lazienki;
            if (name.Contains('3'))
                return Enums.ActivityName.Zamiatanie_pokoji;
            if (name.Contains('4'))
                return Enums.ActivityName.Pranie;
            if (name.Contains('5'))
                return Enums.ActivityName.Odrabianie_lekcji;
            if (name.Contains('6'))
                return Enums.ActivityName.Basen;
            if (name.Contains('7'))
                return Enums.ActivityName.Wstazka;
            if (name.Contains('8'))
                return Enums.ActivityName.Bajki;
            if (name.Contains('9'))
                return Enums.ActivityName.Czas_spac;
            if (name.Contains("10"))
                return Enums.ActivityName.Czas_do_pracy;
            return Enums.ActivityName.All;
        }

        public static async Task SeedPersonFamilies(ApplicationContext context)
        {
            if (context.PersonFamilies.Any())
            {
                return;
            }

            string data = GetDataFamily();

            List<ModelPersonFamily> modelPersonFamily = JsonConvert.DeserializeObject<List<ModelPersonFamily>>(data);

            foreach (var item in modelPersonFamily)
            {
                var family = new ModelPersonFamily
                (               
                    item.Id,
                    item.PersonName,
                    item.PersonPicture
                );
                context.Add(family);
            }
            await context.SaveChangesAsync();
        }

        private static string GetDataFamily()
        {
            string filePath = @"./DataBase/InitialDataFamily.json";
            using (var r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                return json;
            }
        }
    }
}
