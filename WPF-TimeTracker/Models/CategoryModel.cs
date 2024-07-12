using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TimeTracker
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public List<TimeEntryModel> TimeEntries { get; set; } = new List<TimeEntryModel>();

        public CategoryModel()
        {
            TimeEntries = new List<TimeEntryModel>();
        }
    }
}
