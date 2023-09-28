using FamilyActivity.WebMvc.Models;
using FamilyActivity.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyActivity.WebMvc.Controllers
{
    public class ActivityStatisticController : Controller
    {
        private readonly IActivityService _activityService;

        public ActivityStatisticController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        public async Task<IActionResult> Index()
        {
            List<ViewActivityDays> events = await _activityService.GetAll();

            if (events.Count() == 0)
            {
                return RedirectToAction("EmptyList");
            }

            var sums = events.GroupBy(x => x.Name.ToString())
                .ToDictionary(x => x.Key, x => x.Select(y => Convert.ToInt32(y.Name)).Sum());

            return View(new ActivityStatisticsView() { ActivitySums = sums });
        }
    }
}