using FamilyActivity.WebMvc.Models;

namespace FamilyActivity.WebMvc.Services
{
    public interface IActivityService
    {
        Task<List<ViewActivityDays>> GetAll();
    }
}