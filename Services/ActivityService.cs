using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyActivity.WebMvc.Services
{
    public class ActivityService : IActivityService
    {
        private readonly ApplicationContext _context;

        private readonly ILogger<ActivityService> _logger;

        public ActivityService(ApplicationContext context, ILogger<ActivityService> logger)
        {
            _context = context;
            _logger = logger;
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
            _logger.LogInformation($"loading data from database ...");
            return allActivties;
        }

        public async Task<ModelActivityDays> GetById(int id)
        {
            var activity = await _context.ActiviesDays
                .Include(x => x.ModelPersonFamily)
                .Include(x => x.ModelPictureActivity)
                .Where(x=>x.Id == id).Select(x=>x).FirstOrDefaultAsync();

            if (activity == null)
            {
                return null;
            }
            return activity;
        }

        public async Task<bool> Create(ModelActivityDays model)
        {
            if (!_context.ActiviesDays.Any())
                return false ;

            if (model == null)
                return false ;

            if (model.StartTime >= model.EndTime)
            {
                _logger.LogError($"StartTime can't be bigger than EndTime!");
                return false;
            }

            var person = model.ModelPersonFamily.PersonName;
            var activityName = model.ModelPictureActivity.ActivityName;

            var modelExist = _context.ActiviesDays.ToList()
                .Where(x=>x.ModelPersonFamily.PersonName == person)
                .Where(x=>x.ModelPictureActivity.ActivityName == activityName)
                .Where(x=>x.StartTime == model.StartTime)
                .Where(x => x.EndTime == model.EndTime)
                .Where(x=>x.DayOfWeek == model.DayOfWeek)
                .Count()
                ;
            if (modelExist > 0)
            {
                _logger.LogError($"Activity exists yet!");
                return false;
            }

            _context.Add(new ModelActivityDays()
            {
                CreatedAt = DateTime.Now,
                DayOfWeek = model.DayOfWeek,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Description = model.Description,
                ModelPersonFamily = _context.PersonFamilies.Where(p => p.PersonName == person).Select(p => p).FirstOrDefault(),
                ModelPictureActivity = _context.PictureActivities.Where(p => p.ActivityName == activityName).Select(p => p).FirstOrDefault(),
            });

            await _context.SaveChangesAsync();

            return true ;
        }

        public async Task<ModelActivityDays> Edit(int id, ModelActivityDays model)
        {
            if (!_context.ActiviesDays.Any())
                return new ModelActivityDays();

            if (model == null)
                return new ModelActivityDays();

            if (model.StartTime >= model.EndTime)
            {
                _logger.LogError($"StartTime can't be bigger than EndTime!");
                return new ModelActivityDays();
            }

            var getModel = await GetById(id);
            if (getModel == null)
            {
                _logger.LogError($"Activity day doesn't exist!");
                return new ModelActivityDays();
            }

            var modelPersonFamily = _context.PersonFamilies
                .FirstOrDefault(x => x.PersonName == model.ModelPersonFamily.PersonName);

            var modelPictureActivity = _context.PictureActivities
                .FirstOrDefault(x => x.ActivityName == model.ModelPictureActivity.ActivityName);

            // Modyfikujemy obiekt ju¿ œledzony przez EF
            getModel.Description = model.Description;
            getModel.StartTime = model.StartTime;
            getModel.EndTime = model.EndTime;
            getModel.DayOfWeek = model.DayOfWeek;
            getModel.ModelPersonFamily = modelPersonFamily;
            getModel.ModelPictureActivity = modelPictureActivity;

            await _context.SaveChangesAsync();
            return getModel;
        }

    }
}