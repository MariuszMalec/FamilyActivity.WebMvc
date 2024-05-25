using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyActivity.WebMvc.Controllers
{
    public class PictureActivityController : Controller
    {
        private readonly ApplicationContext _context;
        private IActivityService _activityService;

        public PictureActivityController(ApplicationContext context, IActivityService activityService)
        {
            _context = context;
            _activityService = activityService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _activityService.GetAll();

            return View(model);
        }
    }
}
