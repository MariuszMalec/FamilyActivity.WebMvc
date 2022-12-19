using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyActivity.WebMvc.Models
{
    public class ActivityStatisticsView
    {
        public Dictionary<string, int>? ActivitySums { get; set; }
    }
}