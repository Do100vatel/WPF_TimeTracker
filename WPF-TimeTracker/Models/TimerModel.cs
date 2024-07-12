using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TimeTracker
{
    public class TimerModel
    {
        public string Name { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public bool IsRunning { get; set; }
        public DateTime StartTime { get; set; }
    }
}
