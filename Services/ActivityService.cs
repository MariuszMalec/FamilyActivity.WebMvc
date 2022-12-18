using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using X.PagedList;

namespace FamilyActivity.WebMvc.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationContext _context;

        public ActivityService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ViewActivityDays>> GetAll()
        {
            var allActivties = await _context.ActiviesDays.ToListAsync();
            if (!allActivties.Any())
            {
                return new List<ViewActivityDays>() { };
            }
            return allActivties;
        }

    }
}
