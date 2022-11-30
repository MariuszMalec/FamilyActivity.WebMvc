using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyActivity.WebMvc.Enums;
using FamilyActivity.WebMvc.Models;
using MySqlConnector;

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
                string connString = "Server = 127.0.0.1; uid=root; pwd=Alicja@13; Database=activityDb;";
    
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
                                StartTime  = GetTime(reader["starttime"].ToString()),
                                EndTime  = DateTime.Parse(reader["endtime"].ToString()),
                                DaysOfWeek  = GetDay(reader["dayofweek"].ToString())
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
        private static DaysOfWeek GetDay(string day)
        {
            if (day.Contains('1'))
                return DaysOfWeek.Monday;
            if (day.Contains('2'))
                return DaysOfWeek.Tuesday;
            if (day.Contains('3'))
                return DaysOfWeek.Wednesday;
            if (day.Contains('4'))
                return DaysOfWeek.Thursday;
            if (day.Contains('5'))
                return DaysOfWeek.Friday;
            if (day.Contains('6'))
                return DaysOfWeek.Saturday;
            if (day.Contains('7'))
                return DaysOfWeek.Sunday;
            return DaysOfWeek.All;
        }

        private static DateTime GetTime(string time)
        {
            DateTime dateTimeObject = DateTime.Parse(time);
            return dateTimeObject;
        }
    }
}