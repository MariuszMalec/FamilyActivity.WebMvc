using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Enums;
using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

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

    }
}