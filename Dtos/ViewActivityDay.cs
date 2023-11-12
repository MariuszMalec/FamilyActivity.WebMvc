using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Dtos
{
    public class ViewActivityDay
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ActivityName Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Description { get; set; } = string.Empty;
        public Enums.DayOfWeek DayOfWeek { get; set; }
    }
}
