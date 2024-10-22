using FamilyActivity.WebMvc.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FamilyActivity.WebMvc.Models
{
    public class ModelActivityDays
    {
        public int Id { get; set; }
        public DateTime CreatedAt  { get; set; } = DateTime.Now;
        [DataType(DataType.Time)]
        public TimeSpan StartTime  { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan EndTime  { get; set; }
        public string? Description  { get; set; }
        public Enums.DayOfWeek DayOfWeek  { get; set; }
        public virtual ModelPersonFamily? ModelPersonFamily { get; set; }
        public virtual ModelPictureActivity? ModelPictureActivity { get; set; }
    }
}