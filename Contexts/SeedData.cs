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
                DayOfWeek = Enums.DayOfWeek.Sunday,
                StartTime = TimeSpan.Parse("16:00:00".ToString()),
                EndTime = TimeSpan.Parse("17:00:00".ToString()),
                Description = "Rysowanie",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Rysowanie)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Wednesday,
                StartTime = TimeSpan.Parse("19:00:00".ToString()),
                EndTime = TimeSpan.Parse("20:30:00".ToString()),
                Description = "Na dolinke",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.GOSIA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Basen)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("16:15:00".ToString()),
                EndTime = TimeSpan.Parse("17:15:00".ToString()),
                Description = "Do brodwaya",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.GOSIA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Wstazka)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Wieczorynka",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.GOSIA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Bajki)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Tuesday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Wieczorynka",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.EMILKA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Bajki)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Sunday,
                StartTime = TimeSpan.Parse("19:00:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Bajka fabularna dla wszystkich",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.ALL),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Bajki)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("9:30:00".ToString()),
                EndTime = TimeSpan.Parse("17:30:00".ToString()),
                Description = "Kurcze, nie lubie poniedzialkow",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_do_pracy)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Tuesday,
                StartTime = TimeSpan.Parse("8:00:00".ToString()),
                EndTime = TimeSpan.Parse("16:00:00".ToString()),
                Description = "Kurcze",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_do_pracy)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Wednesday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Kurcze",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_do_pracy)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("8:00:00".ToString()),
                EndTime = TimeSpan.Parse("16:00:00".ToString()),
                Description = "Kurcze",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_do_pracy)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Friday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("20:00:00".ToString()),
                Description = "Kurcze",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_do_pracy)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Tuesday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Wednesday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Friday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Saturday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Sunday,
                StartTime = TimeSpan.Parse("20:00:00".ToString()),
                EndTime = TimeSpan.Parse("22:30:00".ToString()),
                Description = "Czas spac",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.ALL),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_spac)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Wednesday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Friday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Saturday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Sunday,
                StartTime = TimeSpan.Parse("18:30:00".ToString()),
                EndTime = TimeSpan.Parse("19:00:00".ToString()),
                Description = "Porzadki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_kuchni)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Monday,
                StartTime = TimeSpan.Parse("17:30:00".ToString()),
                EndTime = TimeSpan.Parse("18:00:00".ToString()),
                Description = "Lekcje",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Odrabianie_lekcji)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("17:30:00".ToString()),
                EndTime = TimeSpan.Parse("18:00:00".ToString()),
                Description = "Lekcje",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Odrabianie_lekcji)
            });
            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Wednesday,
                StartTime = TimeSpan.Parse("17:30:00".ToString()),
                EndTime = TimeSpan.Parse("18:00:00".ToString()),
                Description = "Lekcje",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Odrabianie_lekcji)
            });
            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("17:30:00".ToString()),
                EndTime = TimeSpan.Parse("18:00:00".ToString()),
                Description = "Lekcje",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Odrabianie_lekcji)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Tuesday,
                StartTime = TimeSpan.Parse("17:30:00".ToString()),
                EndTime = TimeSpan.Parse("21:00:00".ToString()),
                Description = "Ciuszki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Pranie)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Friday,
                StartTime = TimeSpan.Parse("17:30:00".ToString()),
                EndTime = TimeSpan.Parse("21:00:00".ToString()),
                Description = "Ciuszki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Pranie)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Sunday,
                StartTime = TimeSpan.Parse("10:30:00".ToString()),
                EndTime = TimeSpan.Parse("12:30:00".ToString()),
                Description = "Ciuszki",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Pranie)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Saturday,
                StartTime = TimeSpan.Parse("12:30:00".ToString()),
                EndTime = TimeSpan.Parse("14:30:00".ToString()),
                Description = "Czas na obiadek",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Obiad)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Sunday,
                StartTime = TimeSpan.Parse("12:30:00".ToString()),
                EndTime = TimeSpan.Parse("14:30:00".ToString()),
                Description = "Czas na obiadek",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Obiad)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Saturday,
                StartTime = TimeSpan.Parse("15:30:00".ToString()),
                EndTime = TimeSpan.Parse("16:00:00".ToString()),
                Description = "Kibelek",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Sprzatanie_lazienki)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Wednesday,
                StartTime = TimeSpan.Parse("19:30:00".ToString()),
                EndTime = TimeSpan.Parse("21:30:00".ToString()),
                Description = "Czas na relaks",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.MAMA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_tylko_mamy)
            });

            context.Add(new ModelActivityDays()
            {
                DayOfWeek = Enums.DayOfWeek.Thursday,
                StartTime = TimeSpan.Parse("21:00:00".ToString()),
                EndTime = TimeSpan.Parse("23:00:00".ToString()),
                Description = "Laptopik czeka",
                ModelPersonFamily = AddModelPersonFamily(context, Enums.PersonFamily.TATA),
                ModelPictureActivity = AddModelPictureActivity(context, Enums.ActivityName.Czas_tylko_taty)
            });


            await context.SaveChangesAsync();
        }

        private static ModelPictureActivity? AddModelPictureActivity(ApplicationContext context, Enums.ActivityName activityName)
        {
            return context.PictureActivities.Where(p => p.ActivityName == activityName).Select(p => p).FirstOrDefault();
        }

        private static ModelPersonFamily? AddModelPersonFamily(ApplicationContext context, Enums.PersonFamily person)
        {
            return context.PersonFamilies.Where(p => p.PersonName == person).Select(p => p).FirstOrDefault();
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
            context.Add(new ModelPictureActivity(12, Enums.ActivityName.Rysowanie,
            "https://plus.unsplash.com/premium_photo-1673514503010-58c013e17aae?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(13, Enums.ActivityName.Obiad,
             "https://images.unsplash.com/photo-1512058564366-18510be2db19?q=80&w=2072&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(14, Enums.ActivityName.Czas_tylko_taty,
             "https://images.unsplash.com/photo-1598550476439-6847785fcea6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));
            context.Add(new ModelPictureActivity(15, Enums.ActivityName.Czas_tylko_mamy,
             "https://images.unsplash.com/photo-1512820790803-83ca734da794?q=80&w=1798&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"));

            await context.SaveChangesAsync();
        }

    }
}
