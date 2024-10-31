using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using FamilyActivity.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamilyActivity.WebMvc.Controllers
{
    public class PictureActivityController : Controller
    {
        private readonly ApplicationContext _context;
        private PictureService _pictureService;

        public PictureActivityController(ApplicationContext context, PictureService pictureService)
        {
            _context = context;
            _pictureService = pictureService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _pictureService.GetAllPictures();

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

            var model = await _context.PictureActivities.FindAsync(id);

            if (model == null)
            {
                return NotFound("model not found!");
            }
            return View(model);
        }

        //POST: UserController/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ModelPictureActivity>> Edit(int id, ModelPictureActivity model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _pictureService.Update(model);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
            return View();
        }


        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _pictureService.GetById(id);
            if (model == null)
            {
                return NotFound("model not found!");
            }
            return View(model);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelPictureActivity activity)
        {
            await _pictureService.Create(activity);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete")]
        public ActionResult Delete()
        {
            return View();
        }
    }
}
