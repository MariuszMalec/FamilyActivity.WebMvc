using FamilyActivity.WebMvc.Enums;
using FamilyActivity.WebMvc.Models;
using Microsoft.Data.Sqlite;

namespace FamilyActivity.WebMvc.Contexts
{
    public class AppDbInitializerWithinSqliteCommand
    {

        //sprzatanie kuchni => https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80
        //basen => https://images.unsplash.com/photo-1575429198097-0414ec08e8cd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80
        //pranie => https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80
        //odrabianie lekcji => https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80
        //spanie => https://images.unsplash.com/photo-1558427400-bc691467a8a9?auto=format&fit=crop&q=80&w=1924&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D
        //czas do pracy =>https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D
        public static void CreateTableWithSqlLiteActivityDays(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelActivityDays> allActivties = new List<ModelActivityDays>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                if (!context.ActiviesDays.Any())
                {

                    string table = "activiesDays";
                    string connString = provider;

                    Console.WriteLine("Connection to sqlite database");
                    using (SqliteConnection conn = new SqliteConnection())
                    {
                        conn.ConnectionString = connString;
                        conn.Open();
                        SqliteCommand command = new SqliteCommand($"SELECT * FROM {table}", conn);

                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Id\tname\t\tstartTime\t\tendTime\t\tdescription\t\tpicture\t\tdayOfWeek\t\tcreatedAt\t\tmodelPersonFamily\t");
                            while (reader.Read())
                            {
                                Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6} \t | {7} \t | {8} \t | {9}",
                                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9]));
                                allActivties.Add(new ModelActivityDays()
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Description = reader["Description"].ToString(),
                                    StartTime = TimeSpan.Parse(reader["starttime"].ToString()),
                                    EndTime = TimeSpan.Parse(reader["endtime"].ToString()),
                                    DayOfWeek = GetDay(reader["dayofweek"].ToString()),
                                    ModelPersonFamily = new ModelPersonFamily(
                                        Convert.ToInt32(reader["modelPersonFamily"]),
                                        PersonFamily.TATA,
                                        "")//Convert.ToInt32(reader["modelPersonFamilyId"])//GetPerson(reader["personFamily"].ToString()),
                                });
                            }
                            Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                            //Console.ReadLine();
                            Console.Clear();
                            conn.Close();

                            if (!context.ActiviesDays.Any())
                            {
                                context.ActiviesDays.AddRange(allActivties);
                                context.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public static void SeedWithSqliteActivityDays(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelActivityDays> allActivties = new List<ModelActivityDays>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "activiesDays";
                string connString = provider;

                Console.WriteLine("Connection to sqlite database");
                using (SqliteConnection cn = new SqliteConnection(connString))
                {
                    try
                    {
                        string query = $"INSERT INTO {table}(startTime,endTime,description,dayOfWeek,createdAt,modelPersonFamilyId,modelPictureActivityId) " +
                            $"VALUES ('9:30:00', '17:30:00', 'Kurcze', 2, CURRENT_TIMESTAMP,1,10)," +
                            $"('8:00:00', '16:00:00', 'Kurcze', 3, CURRENT_TIMESTAMP,1,10)," +
                            $"('9:30:00', '17:30:00', 'Kurcze', 4, CURRENT_TIMESTAMP,1,10)," +
                            $"('8:00:00', '16:00:00', 'Kurcze', 5, CURRENT_TIMESTAMP,1,10)," +
                            $"('9:30:00', '17:30:00', 'Kurcze', 6, CURRENT_TIMESTAMP,1,10)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 2, CURRENT_TIMESTAMP,1,9)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 3, CURRENT_TIMESTAMP,2,9)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 4, CURRENT_TIMESTAMP,1,9)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 5, CURRENT_TIMESTAMP,2,9)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 6, CURRENT_TIMESTAMP,1,9)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 7, CURRENT_TIMESTAMP,2,9)," +
                            $"('20:00:00', '21:30:00', 'Lulanko', 1, CURRENT_TIMESTAMP,1,9)," +
                            $"('17:30:00', '18:00:00', 'Czas na lekcje', 2, CURRENT_TIMESTAMP,2,5)," +
                            $"('17:30:00', '18:00:00', 'Czas na lekcje', 3, CURRENT_TIMESTAMP,1,5)," +
                            $"('17:30:00', '18:00:00', 'Czas na lekcje', 4, CURRENT_TIMESTAMP,2,5)," +
                            $"('17:30:00', '18:00:00', 'Czas na lekcje', 5, CURRENT_TIMESTAMP,1,5)," +
                            $"('10:30:00', '12:00:00', 'Czas na bajeczki', 7, CURRENT_TIMESTAMP,3,8)," +
                            $"('10:30:00', '11:30:00', 'Czas na bajeczki', 1, CURRENT_TIMESTAMP,4,8)," +
                            $"('21:00:00', '23:00:00', 'Czas dla taty', 4, CURRENT_TIMESTAMP,1,13)," +
                            $"('19:30:00', '21:30:00', 'Czas dla mamy', 5, CURRENT_TIMESTAMP,2,14)," +
                            $"('19:30:00', '21:00:00', 'Na dolinke', 4, CURRENT_TIMESTAMP,1,6)," +
                            $"('12:30:00', '14:00:00', 'Obiad', 7, CURRENT_TIMESTAMP, 1, 12)," +
                            $"('12:30:00', '14:00:00', 'Obiad', 1, CURRENT_TIMESTAMP, 2, 12)," +
                            $"('15:30:00', '16:30:00', 'Pora na spacer', 7, CURRENT_TIMESTAMP, 1, 15)," +
                            $"('15:30:00', '16:30:00', 'Pora na spacer', 1, CURRENT_TIMESTAMP, 2, 15)," +
                            $"('17:00:00', '18:00:00', 'Wspolne zabawy', 7, CURRENT_TIMESTAMP, 5, 16)," +
                            $"('16:15:00','17:15:00','MAMA', 5, CURRENT_TIMESTAMP,2,7);";
                        cn.Open();
                        using (SqliteCommand cmd = new SqliteCommand(query, cn))
                        {
                            if (!context.ActiviesDays.Any())
                                cmd.ExecuteNonQuery();
                        }
                        Console.Clear();
                        cn.Close();
                    }
                    catch (SqliteException ex)
                    {
                        Console.WriteLine("Error in adding sqllite row. Error: " + ex.Message);
                    }
                }
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

        public static void CreateTableWithSqlLitePersonFamilies(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelPersonFamily> allActivties = new List<ModelPersonFamily>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                if (!context.PersonFamilies.Any())
                { 

                    string table = "personFamilies";
                    string connString = provider;

                    Console.WriteLine("Connection to mysql database");
                    using (SqliteConnection conn = new SqliteConnection())
                    {
                        conn.ConnectionString = connString;
                        conn.Open();
                        SqliteCommand command = new SqliteCommand($"SELECT * FROM {table}", conn);

                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("Id\tpersonName\t\tpersonPicture\t");
                            while (reader.Read())
                            {
                                Console.WriteLine(string.Format("{0} \t | {1} \t | {2}}",
                                    reader[0], reader[1], reader[2]));
                                allActivties.Add(new ModelPersonFamily(

                                    Convert.ToInt32(reader["Id"]),
                                    GetPerson(reader["PersonName"].ToString()),
                                    reader["Picture"].ToString()
                                ));
                            }
                            Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                            //Console.ReadLine();
                            Console.Clear();
                            conn.Close();

                            if (!context.PersonFamilies.Any())
                            {
                                context.PersonFamilies.AddRange(allActivties);
                                context.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        public static void SeedWithSqlLitePersonFamilies(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelPersonFamily> allActivties = new List<ModelPersonFamily>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "personFamilies";
                string connString = provider;

                Console.WriteLine("Connection to sqlite database");
                using (SqliteConnection cn = new SqliteConnection(connString))
                {
                    try
                    {
                        string query = $"INSERT INTO {table}(personName,personPicture) " +
                            $"VALUES (1,'https://images.unsplash.com/photo-1516733725897-1aa73b87c8e8?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(2,'https://plus.unsplash.com/premium_photo-1661274027494-1d556441e1c4?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(3,'https://images.unsplash.com/photo-1516627145497-ae6968895b74?q=80&w=2040&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(4,'https://images.unsplash.com/photo-1566004100631-35d015d6a491?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(5,'https://images.unsplash.com/photo-1696446702183-cbd13d78e1e7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDF8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');";
                        cn.Open();
                        using (SqliteCommand cmd = new SqliteCommand(query, cn))
                        {
                            if (!context.PersonFamilies.Any())
                                cmd.ExecuteNonQuery();
                        }
                        Console.Clear();
                        cn.Close();
                    }
                    catch (SqliteException ex)
                    {
                        Console.WriteLine("Error in adding sqllite row. Error: " + ex.Message);
                    }
                }
            }
        }

        internal static void SeedWithSqlLiteAvtivityPictures(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelPictureActivity> allActivties = new List<ModelPictureActivity>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "pictureActivities";
                string connString = provider;

                Console.WriteLine("Connection to sqlite database");
                using (SqliteConnection cn = new SqliteConnection(connString))
                {
                    try
                    {
                        string query = $"INSERT INTO {table}(activityName,picture) " +
                            $"VALUES (1,'https://images.unsplash.com/photo-1600585152220-90363fe7e115?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(2,'https://images.unsplash.com/photo-1584622650111-993a426fbf0a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(3,'https://images.unsplash.com/photo-1527515637462-cff94eecc1ac?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(4,'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80')," +
                                   $"(5,'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80')," +
                                   $"(6,'https://images.unsplash.com/photo-1575429198097-0414ec08e8cd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80')," +
                                   $"(7,'https://images.unsplash.com/photo-1599058917212-d750089bc07e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2069&q=80')," +
                                   $"(8,'https://images.unsplash.com/photo-1515041219749-89347f83291a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80')," +
                                   $"(9,'https://images.unsplash.com/photo-1558427400-bc691467a8a9?auto=format&fit=crop&q=80&w=1924&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(10,'https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(11,'https://plus.unsplash.com/premium_photo-1673514503010-58c013e17aae?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(12,'https://images.unsplash.com/photo-1512058564366-18510be2db19?q=80&w=2072&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(13,'https://images.unsplash.com/photo-1598550476439-6847785fcea6?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(14,'https://images.unsplash.com/photo-1512820790803-83ca734da794?q=80&w=1798&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(15,'https://images.unsplash.com/photo-1606474226448-4aa808468efc?q=80&w=1990&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(16,'https://images.unsplash.com/photo-1606092195730-5d7b9af1efc5?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D')," +
                                   $"(17,'https://images.unsplash.com/photo-1606474226448-4aa808468efc?q=80&w=1990&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D');";
                        cn.Open();
                        using (SqliteCommand cmd = new SqliteCommand(query, cn))
                        {
                            if (!context.PictureActivities.Any())
                                cmd.ExecuteNonQuery();
                        }
                        Console.Clear();
                        cn.Close();
                    }
                    catch (SqliteException ex)
                    {
                        Console.WriteLine("Error in adding sqlite row. Error: " + ex.Message);
                    }
                }
            }
        }
    }
}