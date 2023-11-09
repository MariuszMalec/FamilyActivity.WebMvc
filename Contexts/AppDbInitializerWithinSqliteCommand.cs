using FamilyActivity.WebMvc.Models;
using MySqlConnector;
using Microsoft.Data.Sqlite;
using FamilyActivity.WebMvc.Enums;

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

                    Console.WriteLine("Connection to mysql database");
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
                                    Name = GetName(reader["Name"].ToString()),
                                    Picture = reader["Picture"].ToString(),
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
                        string query = $"INSERT INTO {table}(name,startTime,endTime,description,picture,dayOfWeek,createdAt,modelPersonFamilyId) " +
                            $"VALUES (1,'19:30:00','20:15:00','TATA','https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80',3, CURRENT_TIMESTAMP,1);";
                                      //$"VALUES (1,'19:30:00','20:15:00','TATA','https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80',3, CURRENT_TIMESTAMP,1)," +
                                      //$"(1, '19:30:00', '20:15:00', 'TATA', 'https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80', 6, CURRENT_TIMESTAMP,1)," +
                                      //$"(1, '19:30:00', '20:15:00', 'MAMA', 'https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80', 2, CURRENT_TIMESTAMP,2)," +
                                      //$"(1, '19:30:00', '20:15:00', 'MAMA', 'https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80', 4, CURRENT_TIMESTAMP,2)," +
                                      //$"(5, '19:00:00', '19:30:00', 'TATA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 3, CURRENT_TIMESTAMP,1)," +
                                      //$"(5, '19:00:00', '19:30:00', 'TATA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 5, CURRENT_TIMESTAMP,1)," +
                                      //$"(6, '19:30:00', '20:30:00', 'TATA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 4, CURRENT_TIMESTAMP,1)," +
                                      //$"(5, '19:00:00', '19:30:00', 'MAMA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 2, CURRENT_TIMESTAMP,2)," +
                                      //$"(5, '19:00:00', '19:30:00', 'MAMA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 4, CURRENT_TIMESTAMP,2)," +
                                      //$"(4, '18:30:00', '19:15:00', 'MAMA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 3, CURRENT_TIMESTAMP,2)," +
                                      //$"(4, '18:30:00', '19:15:00', 'MAMA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 5, CURRENT_TIMESTAMP,2)," +
                                      //$"(4, '18:30:00', '19:15:00', 'TATA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 2, CURRENT_TIMESTAMP,1)," +
                                      //$"(4, '18:30:00', '19:15:00', 'TATA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 4, CURRENT_TIMESTAMP,1)," +
                                      //$"(8, '19:00:00', '20:00:00', 'ALL', 'https://images.unsplash.com/photo-1515041219749-89347f83291a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80', 1, CURRENT_TIMESTAMP,0)," +
                                      //$"(8, '19:00:00', '20:00:00', 'ALL', 'https://images.unsplash.com/photo-1515041219749-89347f83291a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80', 7, CURRENT_TIMESTAMP,0)," +
                                      //$"(9, '19:30:00', '20:00:00', 'MAMA', 'https://images.unsplash.com/photo-1558427400-bc691467a8a9?auto=format&fit=crop&q=80&w=1924&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 2, CURRENT_TIMESTAMP,2)," +
                                      //$"(9, '19:30:00', '20:00:00', 'TATA', 'https://images.unsplash.com/photo-1558427400-bc691467a8a9?auto=format&fit=crop&q=80&w=1924&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 3, CURRENT_TIMESTAMP,1)," +
                                      //$"(10, '9:30:00', '17:30:00', 'TATA', 'https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 2, CURRENT_TIMESTAMP,1)," +
                                      //$"(10, '8:00:00', '16:00:00', 'TATA', 'https://images.unsplash.com/photo-1504384308090-c894fdcc538d?auto=format&fit=crop&q=80&w=2070&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D', 3, CURRENT_TIMESTAMP,1)," +
                                      //$"(7,'16:15:00','17:15:00','MAMA','https://images.unsplash.com/photo-1599058917212-d750089bc07e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2069&q=80',5, CURRENT_TIMESTAMP,2);";
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

        public static void SeedMySql(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelActivityDays> allActivties = new List<ModelActivityDays>();

            var provider = configuration.GetConnectionString("Default");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "activiesDays";
                string connString = provider;
    
                Console.WriteLine("Connection to mysql database");
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();
                    MySqlCommand command = new MySqlCommand($"SELECT * FROM {table}", conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("id\tname\t\tstartTime\t\tendTime\t\tdescription\t\tpicture\t\tdayOfWeek\t\tcreatedAt\t\tmodelPersonFamilyId\t");
                        while (reader.Read())
                        {
                            Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6} \t | {7} \t | {8} \t | {9}",
                                reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9]));
                            allActivties.Add(new ModelActivityDays()  
                            {  
                                Id = Convert.ToInt32(reader["id"]),  
                                Name = GetName(reader["Name"].ToString()),
                                StartTime = TimeSpan.Parse(reader["starttime"].ToString()),
                                EndTime = TimeSpan.Parse(reader["endtime"].ToString()),
                                Description = reader["Description"].ToString(),
                                Picture = reader["Picture"].ToString(),
                                DayOfWeek = GetDay(reader["dayofweek"].ToString()),
                                CreatedAt = DateTime.Parse(reader["createdAt"].ToString()),
                                //ModelPersonFamilyId = GetPerson(reader["modelPersonFamily"].ToString())//jak tutaj wcisnac objekt!!!
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

        public static void SeedMySqlData(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ModelActivityDays> allActivties = new List<ModelActivityDays>();

            var provider = configuration.GetConnectionString("Default");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "activiesDays";
                string connString = provider;

                Console.WriteLine("Connection to mysql database");
                using (MySqlConnection cn = new MySqlConnection(connString))
                {
                    try
                    {
                        string query = $"INSERT INTO {table}(id, name,startTime,endTime,description,picture,dayOfWeek,createdAt,modelPersonFamily) " +
                            $"VALUES (1, 1,'16:00:00','17:00:00','rysowanie olowkiem','https://images.unsplash.com/photo-1525278070609-779c7adb7b71?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1147&q=80',1, CURRENT_TIMESTAMP, 1);";
                        cn.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, cn))
                        {
                            if (!context.ActiviesDays.Any())
                                cmd.ExecuteNonQuery();
                        }
                        Console.Clear();
                        cn.Close();
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error in adding mysql row. Error: " + ex.Message);
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
    }
}