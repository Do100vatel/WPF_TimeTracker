using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TimeTracker
{
    public class TimeEntryModel
    {
        public DateTime StartTime { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public TimeSpan Duration { get; set; }
        // public string Notes { get; set; }
    }
}
