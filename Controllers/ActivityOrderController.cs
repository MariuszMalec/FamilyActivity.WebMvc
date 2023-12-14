using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyActivity.WebMvc.Controllers
{
    public class ActivityOrderController : Controller
    {
        private readonly ApplicationContext _dataContext;
        private readonly WorkOrderDbContext _dayPilotContext;

        public ActivityOrderController(ApplicationContext dataContext, WorkOrderDbContext dayPilotContext)
        {
            _dataContext = dataContext;
            _dayPilotContext = dayPilotContext;
        }

        public async Task<IActionResult> Index()
        {
            await SeedActivityOrder.SeedActiviesOrders(_dayPilotContext, _dataContext);
            return View();
        }
    }
}
