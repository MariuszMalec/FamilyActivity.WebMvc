using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyActivity.WebMvc.Models
{
    public class ViewActivityDays
    {
        public int Id { get; set; }
        public DateTime CreatedAt  { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartTime  { get; set; }
        public DateTime EndTime  { get; set; }
        public string? Description  { get; set; }
        public string? Picture  { get; set; }
        public DayOfWeek DayOfWeek  { get; set; }
    }
}