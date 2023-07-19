using FamilyActivity.WebMvc.Models;
using MySqlConnector;

namespace FamilyActivity.WebMvc.Contexts
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder, IConfiguration configuration)
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
                                Name = reader["Name"].ToString(),
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

        public static void SeedData(IApplicationBuilder applicationBuilder, IConfiguration configuration)
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
    }
}