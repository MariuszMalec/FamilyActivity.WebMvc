using FamilyActivity.WebMvc.Models;
using MySqlConnector;
using Microsoft.Data.Sqlite;
using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Contexts
{
    public class AppDbInitializer
    {

        //sprzatanie kuchni => https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80
        //basen => https://images.unsplash.com/photo-1575429198097-0414ec08e8cd?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80
        //pranie => https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80
        //odrabianie lekcji => https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80

        public static void SeedToSqlLite(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ViewActivityDays> allActivties = new List<ViewActivityDays>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

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
                        Console.WriteLine("Id\tname\t\tstartTime\t\tendTime\t\tdescription\t\tpicture\t\tdayOfWeek\t\tcreatedAt\t");
                        while (reader.Read())
                        {
                            Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6}",
                                reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]));
                            allActivties.Add(new ViewActivityDays()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = GetName(reader["Name"].ToString()),
                                Picture = reader["Picture"].ToString(),
                                Description = reader["Description"].ToString(),
                                StartTime = TimeSpan.Parse(reader["starttime"].ToString()),
                                EndTime = TimeSpan.Parse(reader["endtime"].ToString()),
                                DayOfWeek = GetDay(reader["dayofweek"].ToString())
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

        public static void SeedSqlitelData(IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            List<ViewActivityDays> allActivties = new List<ViewActivityDays>();

            var provider = configuration.GetConnectionString("Sqlite");

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "activiesDays";
                string connString = provider;

                Console.WriteLine("Connection to mysql database");
                using (SqliteConnection cn = new SqliteConnection(connString))
                {
                    try
                    {
                        string query = $"INSERT INTO {table}(name,startTime,endTime,description,picture,dayOfWeek,createdAt) " +
                        $"VALUES (1,'19:30:00','20:15:00','TATA','https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80',3, CURRENT_TIMESTAMP)," +
                        $"(1, '19:30:00', '20:15:00', 'TATA', 'https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80', 6, CURRENT_TIMESTAMP)," +
                        $"(1, '19:30:00', '20:15:00', 'MAMA', 'https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80', 2, CURRENT_TIMESTAMP)," +
                        $"(1, '19:30:00', '20:15:00', 'MAMA', 'https://images.unsplash.com/photo-1600585152220-90363fe7e115?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80', 4, CURRENT_TIMESTAMP)," +
                        $"(5, '19:00:00', '19:30:00', 'TATA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 3, CURRENT_TIMESTAMP)," +
                        $"(5, '19:00:00', '19:30:00', 'TATA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 5, CURRENT_TIMESTAMP)," +
                        $"(6, '19:30:00', '20:30:00', 'TATA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 4, CURRENT_TIMESTAMP)," +
                        $"(5, '19:00:00', '19:30:00', 'MAMA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 2, CURRENT_TIMESTAMP)," +
                        $"(5, '19:00:00', '19:30:00', 'MAMA', 'https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2022&q=80', 4, CURRENT_TIMESTAMP)," +
                        $"(4, '18:30:00', '19:15:00', 'MAMA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 3, CURRENT_TIMESTAMP)," +
                        $"(4, '18:30:00', '19:15:00', 'MAMA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 5, CURRENT_TIMESTAMP)," +
                        $"(4, '18:30:00', '19:15:00', 'TATA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 2, CURRENT_TIMESTAMP)," +
                        $"(4, '18:30:00', '19:15:00', 'TATA', 'https://plus.unsplash.com/premium_photo-1664372899448-05788a69406a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1795&q=80', 4, CURRENT_TIMESTAMP)," +
                        $"(7,'16:15:00','17:15:00','MAMA','https://images.unsplash.com/photo-1599058917212-d750089bc07e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2069&q=80',2, CURRENT_TIMESTAMP);";
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
            List<ViewActivityDays> allActivties = new List<ViewActivityDays>();

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
                        Console.WriteLine("Id\tname\t\tstartTime\t\tendTime\t\tdescription\t\tpicture\t\tdayOfWeek\t\tcreatedAt\t");
                        while (reader.Read())
                        {
                            Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6}",
                                reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]));
                            allActivties.Add(new ViewActivityDays()  
                            {  
                                Id = Convert.ToInt32(reader["Id"]),  
                                Name = GetName(reader["Name"].ToString()),
                                Picture = reader["Picture"].ToString(),
                                Description = reader["Description"].ToString(),
                                StartTime  = TimeSpan.Parse(reader["starttime"].ToString()),
                                EndTime  = TimeSpan.Parse(reader["endtime"].ToString()),
                                DayOfWeek  = GetDay(reader["dayofweek"].ToString())
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
            List<ViewActivityDays> allActivties = new List<ViewActivityDays>();

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
                        string query = $"INSERT INTO {table}(name,startTime,endTime,description,picture,dayOfWeek,createdAt) " +
                            $"VALUES ('rysowanie','16:00:00','17:00:00','rysowanie olowkiem','https://images.unsplash.com/photo-1525278070609-779c7adb7b71?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1147&q=80',1, CURRENT_TIMESTAMP);";
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
                return Enums.ActivityName.Pranie;
            if (name.Contains('4'))
                return Enums.ActivityName.Wstazka;
            if (name.Contains('5'))
                return Enums.ActivityName.Basen;
            if (name.Contains('6'))
                return Enums.ActivityName.Odrabianie_lekcji;
            if (name.Contains('7'))
                return Enums.ActivityName.Zamiatanie_pokoji;
            return Enums.ActivityName.All;
        }

    }
}