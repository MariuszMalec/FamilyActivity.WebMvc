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
using FamilyActivity.WebMvc.Enums;
using System.Net.Sockets;
using FamilyActivity.WebMvc.Contexts;

namespace FamilyActivity.WebMvc.Controllers
{
    [Route("[controller]")]
    public class ActivityDayController : Controller
    {
        private readonly ApplicationContext _context;

        public ActivityDayController(ApplicationContext context = null)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
  
            // string table = "activiesDays";
            // string connString = "Server = 127.0.0.1; uid=root; pwd=Alicja@13; Database=activityDb;";
   
            // Console.WriteLine("Connection to mysql database");
            // using (MySqlConnection conn = new MySqlConnection())
            // {
            //     conn.ConnectionString = connString;
            //     conn.Open();
            //     MySqlCommand command = new MySqlCommand($"SELECT * FROM {table}", conn);

            //     using (MySqlDataReader reader = command.ExecuteReader())
            //     {
            //         Console.WriteLine("Id\tname\t\tstartTime\t\tendTime\t\tdescription\t\tpicture\t\tdayOfWeek\t\tcreatedAt\t");
            //         while (reader.Read())
            //         {
            //             Console.WriteLine(string.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4} \t | {5} \t | {6}",
            //                 reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]));
            //             allActivties.Add(new ViewActivityDays()  
            //             {  
            //                 Id = Convert.ToInt32(reader["Id"]),  
            //                 Name = reader["Name"].ToString(),
            //                 Picture = reader["Picture"].ToString(),
            //                 Description = reader["Description"].ToString(),
            //                 StartTime  = GetTime(reader["starttime"].ToString()),
            //                 EndTime  = DateTime.Parse(reader["endtime"].ToString()),
            //                 DaysOfWeek  = GetDay(reader["dayofweek"].ToString())
            //             });
            //         }
            //         Console.WriteLine("Data displayed! Now press enter to move to the next section!");
            //         //Console.ReadLine();
            //         Console.Clear();
            //         conn.Close();
            //     }
            // }

            var allActivties = _context.ActiviesDays.ToList();

            var sorted = allActivties
            //.Where(t=>t.DaysOfWeek == DateTime.Today.DayOfWeek)
            .OrderBy(t=>t.StartTime <= DateTime.Now.TimeOfDay)
            ;

            var pageNumber = page ?? 1;
            var perPage = 2;
            var onePageOfEvents = await sorted.ToPagedListAsync(pageNumber, perPage);

            return View(onePageOfEvents);
        }

        // private DaysOfWeek GetDay(string day)
        // {
        //     if (day.Contains('1'))
        //         return DaysOfWeek.Monday;
        //     if (day.Contains('2'))
        //         return DaysOfWeek.Tuesday;
        //     if (day.Contains('3'))
        //         return DaysOfWeek.Wednesday;
        //     if (day.Contains('4'))
        //         return DaysOfWeek.Thursday;
        //     if (day.Contains('5'))
        //         return DaysOfWeek.Friday;
        //     if (day.Contains('6'))
        //         return DaysOfWeek.Saturday;
        //     if (day.Contains('7'))
        //         return DaysOfWeek.Sunday;
        //     return DaysOfWeek.All;
        // }

        private DateTime GetTime(string time)
        {
            DateTime dateTimeObject = DateTime.Parse(time);
            return dateTimeObject;
        }
                
        // GET: UserController/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allActivties = new List<ViewActivityDays>();
            if (_context.ActiviesDays.Any())
            {
                allActivties = await _context.ActiviesDays.ToListAsync();
            }

            var activity = allActivties.Where(a=>a.Id == id).FirstOrDefault();
            if (activity == null) 
            {
                return NotFound();
            }
            return View(activity);
        }

        //POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ViewActivityDays activity)
        {
            try
            {
                if (ModelState.IsValid)
                {                    
                    return RedirectToAction(nameof(Index));
                }   
            }
            catch
            {
                return View();
            }
            return View();
        }

        // [HttpPost("{id}")]
        // public IActionResult Edit(ViewActivityDays activityDays, int id)
        // {
        //     if (activityDays == null)
        //         return BadRequest($"Brak aktywnosci!");

        //     string table = "activiesDays";
        //     string connString = "Server = 127.0.0.1; uid=root; pwd=Alicja@13; Database=activityDb;";

        //     Console.WriteLine("Connection to mysql database");

        //     var editActivity = new ViewActivityDays(){
        //         Id = id,
        //         Name = "",
        //         CreatedAt = DateTime.Now,
        //         StartTime = DateTime.Now,
        //         EndTime = DateTime.Now.AddHours(1),
        //         Description = "Spanie",
        //         DaysOfWeek = DaysOfWeek.All
        //     };

        //     using (MySqlConnection conn = new MySqlConnection())
        //     {
        //         conn.ConnectionString = connString;
        //         conn.Open();
        //         MySqlCommand command = new MySqlCommand($"UPDATE {table} SET DayOfWeek = 0 WHERE Id = {id}", conn);
        //     }
        //     return Ok($"Activity with id {activityDays.Id} edited");
        // }

    }
}