using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FamilyActivity.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;


using MySqlConnector;

namespace FamilyActivity.WebMvc.Controllers
{
    [Route("[controller]")]
    public class ActivityDayController : Controller
    {

        public async Task<IActionResult> Index(int? page)
        {
 
            List<ViewActivityDays> allActivties = new List<ViewActivityDays>();  
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
                            DayOfWeek  = (DayOfWeek)reader["dayofweek"]
                        });
                    }
                    Console.WriteLine("Data displayed! Now press enter to move to the next section!");
                    //Console.ReadLine();
                    Console.Clear();
                }
            }

            var sorted = allActivties.OrderByDescending(t=>t.StartTime);

            var pageNumber = page ?? 1;
            var perPage = 2;
            var onePageOfEvents = await sorted.ToPagedListAsync(pageNumber, perPage);

            return View(onePageOfEvents);
        }

        private DateTime GetTime(string time)
        {
            DateTime dateTimeObject = DateTime.Parse(time);
            return dateTimeObject;
        }
        

    }
}