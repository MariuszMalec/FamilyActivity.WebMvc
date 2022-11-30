using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyActivity.WebMvc.Enums;

namespace FamilyActivity.WebMvc.Models
{
    public class ViewActivityDays
    {
        public int Id { get; set; }
        public DateTime CreatedAt  { get; set; }
        public string Name { get; set; } = string.Empty;
        public TimeSpan StartTime  { get; set; }
        public TimeSpan EndTime  { get; set; }
        public string? Description  { get; set; }
        public string? Picture  { get; set; }
        public Enums.DayOfWeek DayOfWeek  { get; set; }
    }
}