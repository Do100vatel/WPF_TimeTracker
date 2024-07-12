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

    public class CategoryModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentCategoryID { get; set; }// Для вложенных категорий
        // Дополнительные свойства
    }

    public class TimeEntryModel
    {
        public string Id { get; set;}
        public string TimerId{ get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Notes { get; set; }

        // add properties
    } 
}
