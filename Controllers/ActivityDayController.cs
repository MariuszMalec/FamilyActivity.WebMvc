using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using FamilyActivity.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace FamilyActivity.WebMvc.Controllers
{
    [Route("[controller]")]
    public class ActivityDayController : Controller
    {
        private readonly ApplicationContext _context;
        private IActivityService _activityService;
        public ActivityDayController(ApplicationContext context, IActivityService activityService)
        {
            _context = context;
            _activityService = activityService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var allActivties = await _activityService.GetAll();

            var currentTime = (TimeSpan)DateTime.Now.TimeOfDay;

            var sorted = allActivties
            .Where(t=>(int)t.DayOfWeek == (int)Enums.DayOfWeek.All || t.DayOfWeek.ToString().Contains(DateTime.Now.DayOfWeek.ToString()))          
            .Where(t=> currentTime < t.EndTime)
            .OrderBy(t=>t.StartTime)
            .Take(3)
            ;

            var pageNumber = page ?? 1;
            var perPage = 1;
            var onePageOfEvents = await sorted.ToPagedListAsync(pageNumber, perPage);

            return View(onePageOfEvents);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int? page)
        {
            var allActivties = await _activityService.GetAll();
            
            if (allActivties == null)
            {
                return NotFound("Activity not found!");
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
            var model = await _activityService.GetById(id);//await _context.ActiviesDays.FindAsync(id);

            if (model == null)
            {
                return NotFound("model not found!");
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
                return NotFound("model not found!");
            }

            var model = await _activityService.GetById(id);//await _context.ActiviesDays.FindAsync(id);

            if (model == null)
            {
                return NotFound("model not found!");
            }
            return View(model);
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
                    var allPersonalFamily = _context.PersonFamilies.ToList();
                    var modelPersonFamily = allPersonalFamily.Where(x => x.PersonName == activity.ModelPersonFamily.PersonName)
                     .Select(p => p).FirstOrDefault();

                    var allActivitiesPictures = _context.PictureActivities.ToList();
                    var modelPictureActivity =
                        allActivitiesPictures.Where(x => x.ActivityName == activity.ModelPictureActivity.ActivityName)
                     .Select(x => x).FirstOrDefault();

                    activity = new ModelActivityDays()
                    {
                        Id = activity.Id,
                        CreatedAt = DateTime.Now,
                        Description = activity.Description,
                        StartTime = activity.StartTime,
                        EndTime = activity.EndTime,
                        DayOfWeek = activity.DayOfWeek,
                        ModelPersonFamily = modelPersonFamily,
                        ModelPictureActivity = modelPictureActivity
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
                var allActivties = await _activityService.GetAll();

                var id = (allActivties?.Max(m => m.Id) ?? 0) + 1;

                var allActivitiesPictures = _context.PictureActivities.ToList();
                
                var allPersonalFamily = _context.PersonFamilies.ToList();

                var modelPictureActivity =
                    allActivitiesPictures.Where(x => x.ActivityName == activity.ModelPictureActivity.ActivityName)
                 .Select(x => x).FirstOrDefault();

                var personalFamily = allPersonalFamily.Where(x => x.PersonName == activity.ModelPersonFamily.PersonName)
                   .Select(p=>p).FirstOrDefault();                             

                activity = new ModelActivityDays()
                {
                    Id = id,
                    CreatedAt = DateTime.Now,
                    Description = activity.Description,
                    StartTime = activity.StartTime,
                    EndTime = activity.EndTime,
                    DayOfWeek = activity.DayOfWeek, 
                    ModelPersonFamily = personalFamily,
                    ModelPictureActivity = modelPictureActivity
                };

                //validation
                if (activity.StartTime >= activity.EndTime)
                    return Content($"StartTime can't be bigger than EndTime!");

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
                return NotFound("model not found!");
            }
            var model = await _activityService.GetById(id);
            if (model == null)
            {
                return NotFound("model not found!");
            }
            return View(model);
        }

        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ModelActivityDays activity)
        {
            try
            {
                _context.ActiviesDays.Remove(activity);
                _context.SaveChanges();

                //_logger.LogWarning("Get({Id}) you deleted uzytkownika from data base! ", user.LastName);
                return RedirectToAction(nameof(GetAll));
            }
            catch
            {
                return View();
            }
        }
    }
}