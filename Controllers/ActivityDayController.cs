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
        public ActivityDayController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
              var allActivties = _context.ActiviesDays.ToList();

            var sorted = allActivties
            .Where(t=>(int)t.DayOfWeek == (int)DateTime.Today.DayOfWeek ||
            (int)t.DayOfWeek == (int)Enums.DayOfWeek.All)
            //.Where(t=>(int)t.DayOfWeek == (int)Enums.DayOfWeek.All)
            //.OrderBy(t=>t.StartTime <= DateTime.Now.TimeOfDay)
            .OrderByDescending(t=>DateTime.Now.TimeOfDay >= t.StartTime && DateTime.Now.TimeOfDay <= t.EndTime)
            ;

            var pageNumber = page ?? 1;
            var perPage = 2;
            var onePageOfEvents = await sorted.ToPagedListAsync(pageNumber, perPage);

            return View(onePageOfEvents);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _context.ActiviesDays.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }
            //_logger.LogInformation($"Wybrales gracza {user.FirstName} z bazy danych z mapowanego do widoku");
            return View(model);
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
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ViewActivityDays>> Edit(int id, ViewActivityDays activity)
        {
            try
            {
                if (ModelState.IsValid)
                {         
                    activity = new ViewActivityDays()
                    {
                        Id = activity.Id,
                        CreatedAt = DateTime.Now,
                        Name = activity.Name,
                        Description = activity.Description,
                        StartTime = activity.StartTime,
                        EndTime = activity.EndTime,
                        DayOfWeek = activity.DayOfWeek
                    };           
                    //TODO problem z DayOfWeek all
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                    //_logger.LogInformation($"Uzytkownik {user.LastName} zostal zmodyfikowany");
                    return RedirectToAction(nameof(Index));
                }   
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: UserController/Create
        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewActivityDays activity)
        {
            if (ModelState.IsValid)
            {
                    activity = new ViewActivityDays()
                    {
                        Id = activity.Id,
                        CreatedAt = DateTime.Now,
                        Name = activity.Name,
                        Description = activity.Description,
                        StartTime = activity.StartTime,
                        EndTime = activity.EndTime,
                        DayOfWeek = activity.DayOfWeek, 
                        Picture = activity.Picture
                    };
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

    }
}