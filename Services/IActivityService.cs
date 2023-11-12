using FamilyActivity.WebMvc.Models;

namespace FamilyActivity.WebMvc.Services
{
    public interface IActivityService
    {
        Task<List<ModelActivityDays>> GetAll();

        Task<ModelActivityDays> GetById(int id);
    }
}