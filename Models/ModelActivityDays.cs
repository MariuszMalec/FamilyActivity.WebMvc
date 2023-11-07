using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Models
{
    public class ModelActivityDays
    {
        public int Id { get; set; }
        public DateTime CreatedAt  { get; set; } = DateTime.Now;
        public ActivityName Name { get; set; }
        public TimeSpan StartTime  { get; set; }
        public TimeSpan EndTime  { get; set; }
        public string? Description  { get; set; }
        public string? Picture  { get; set; }
        public Enums.DayOfWeek DayOfWeek  { get; set; }
        public virtual ModelPersonFamily? ModelPersonFamily { get; set; }
    }
}