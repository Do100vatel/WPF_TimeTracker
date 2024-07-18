
using System;

namespace WPF_TimeTracker.Models
{
    public class ReportModel
    {
        public DateTime Date { get; set; }
        public string Category {  get; set; }   
        public TimeSpan Duration { get; set; }
    }
}
