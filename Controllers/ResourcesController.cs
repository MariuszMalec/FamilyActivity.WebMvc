using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FamilyActivity.WebMvc.Models;

namespace FamilyActivity.WebMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly WorkOrderDbContext _context;

        public ResourcesController(WorkOrderDbContext context)
        {
            _context = context;
        }

        // GET: api/Resources
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetResources()
        {
            return await _context.Groups
                .Include(g => g.Resources.OrderBy(e => e.Name))
                .Select(g => new
                {
                    Id = "G" + g.Id, 
                    Expanded = true, 
                    Children = g.Resources, 
                    Name = g.Name,
                    CellsAutoUpdated = true
                })
                .OrderBy(e => e.Name)
                .ToListAsync();
        }

        // GET: api/Resources/Flat
        [HttpGet("Flat")]
        public async Task<ActionResult<IEnumerable>> GetResourcesFlat()
        {
            return await _context.Resources.OrderBy(e => e.Name).ToListAsync();
        }
    }
}

