using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyActivity.WebMvc.Enums;
using FamilyActivity.WebMvc.Models;
using MySqlConnector;
using Npgsql;

namespace FamilyActivity.WebMvc.Contexts
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            List<ViewActivityDays> allActivties = new List<ViewActivityDays>();

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                context.Database.EnsureCreated();

                string table = "activiesDays";
                string connString = "Server = localhost; Port=5432; User Id=postgres; Password=Alicja13a; Database=activityDb;";
    
                Console.WriteLine("Connection to postgressql database");

                using (NpgsqlConnection conn = new NpgsqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();
                    NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM \"{table}\";", conn);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
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