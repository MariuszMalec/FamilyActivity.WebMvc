using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyActivity.WebMvc.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationContext _context;

        public ActivityService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ModelActivityDays>> GetAll()
        {
            var allActivties = await _context.ActiviesDays
                .Include(x => x.ModelPersonFamily)
                .Include(x => x.ModelPictureActivity)
                .ToListAsync();

            if (!allActivties.Any())
            {
                return new List<ModelActivityDays>() { };
            }
            return allActivties;
        }

        public async Task<ModelActivityDays> GetById(int id)
        {
            var activity = _context.ActiviesDays
                .Include(x => x.ModelPersonFamily)
                .Include(x => x.ModelPictureActivity)
                .ToListAsync().Result.Where(x=>x.Id == id).Select(x=>x).FirstOrDefault();

            if (activity == null)
            {
                return null;
            }
            return activity;
        }

    }
}