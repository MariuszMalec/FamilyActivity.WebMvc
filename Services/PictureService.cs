using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyActivity.WebMvc.Services
{
    public class PictureService
    {
        private readonly ApplicationContext _context;

        public PictureService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<ModelPictureActivity>> GetAllPictures()
        {
            return await _context.PictureActivities.ToListAsync();
        }

        public async Task Update(ModelPictureActivity model)
        {
            _context.PictureActivities.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<ModelPictureActivity> GetById(int id)
        {
            return await _context.PictureActivities.FindAsync(id);
        }
    }
}
