using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using FamilyActivity.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyActivity.WebMvc.Controllers
{
    [Route("[controller]")]
    public class ActivityDayScrollingController : Controller
    {
        private readonly ApplicationContext _context;
        private IActivityService _activityService;
        public ActivityDayScrollingController(ApplicationContext context, IActivityService activityService)
        {
            _context = context;
            _activityService = activityService;
        }

        public async Task<IActionResult> Index()
        {
            var allActivties = await _activityService.GetAll();
            return View(allActivties);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _activityService.GetById(id);

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

            var activity = allActivties.Where(a => a.Id == id).FirstOrDefault();
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

            var activity = allActivties.Where(a => a.Id == id).FirstOrDefault();
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