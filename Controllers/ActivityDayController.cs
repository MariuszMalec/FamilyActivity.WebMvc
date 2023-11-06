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
using Microsoft.EntityFrameworkCore;

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
            var allActivties = _context.ActiviesDays.Include(x => x.ModelPersonFamily).ToList();

            var sorted = allActivties
            .Where(t=>(int)t.DayOfWeek == (int)Enums.DayOfWeek.All || t.DayOfWeek.ToString().Contains(DateTime.Now.DayOfWeek.ToString()))          
            .OrderByDescending(t=>DateTime.Now.TimeOfDay >= t.StartTime && DateTime.Now.TimeOfDay <= t.EndTime)
            .ThenBy(t=>DateTime.Now.TimeOfDay > t.EndTime)
            .Take(2)
            ;

            var pageNumber = page ?? 1;
            var perPage = 1;
            var onePageOfEvents = await sorted.ToPagedListAsync(pageNumber, perPage);

            return View(onePageOfEvents);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int? page)
        {
            var allActivties = await _context.ActiviesDays
                .Include(x=>x.ModelPersonFamily)
                .ToListAsync();
            
            if (allActivties == null)
            {
                return NotFound();
            }

            var sorted = allActivties
            .OrderBy(t=>t.DayOfWeek)    
            .ThenBy(t=>t.StartTime)  
            ;

            var pageNumber = page ?? 1;
            var perPage = 3;
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

            var allActivties = new List<ModelActivityDays>();
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
        public async Task<ActionResult<ModelActivityDays>> Edit(int id, ModelActivityDays activity)
        {
            try
            {
                if (ModelState.IsValid)
                {         
                    activity = new ModelActivityDays()
                    {
                        Id = activity.Id,
                        CreatedAt = DateTime.Now,
                        Name = activity.Name,
                        Description = activity.Description,
                        StartTime = activity.StartTime,
                        EndTime = activity.EndTime,
                        Picture = activity.Picture,
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
        public async Task<IActionResult> Create(ModelActivityDays activity)
        {
            if (ModelState.IsValid)
            {
                    activity = new ModelActivityDays()
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

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allActivties = new List<ModelActivityDays>();
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

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ModelActivityDays activity)
        {
            try
            {
                var currentActivity = await _context.ActiviesDays.FindAsync(id);

                if (currentActivity == null)
                {
                    return NotFound();
                }

                _context.ActiviesDays.Remove(currentActivity);
                _context.SaveChanges();

                //_logger.LogWarning("Get({Id}) you deleted uzytkownika from data base! ", user.LastName);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

    }
}