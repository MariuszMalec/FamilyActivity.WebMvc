using Microsoft.AspNetCore.Mvc;

namespace FamilyActivity.WebMvc.Controllers
{
    public class ActivityOrder : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
