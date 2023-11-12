using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Models
{
    public class ModelPictureActivity
    {
        public int Id { get; set; }
        public ActivityName ActivityName { get; set; }
        public string? Picture { get; set; }

        public ModelPictureActivity()
        {
            
        }
        public ModelPictureActivity(int id, ActivityName activityName, string? picture)
        {
            Id = id;
            ActivityName = activityName;
            Picture = picture;
        }
    }
}
