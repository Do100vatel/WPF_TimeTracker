﻿using System.Collections.ObjectModel;

namespace WPF_TimeTracker.ViewModels
{
    public class ReportsViewModel : BaseViewModel
    {
        public ObservableCollection<TimeEntryModel> TimeEntries { get; set; }

        public ReportsViewModel()
        {
            TimeEntries = new ObservableCollection<TimeEntryModel>();
            // Логика для загрузки данных и создания отчетов
        }
    }
}
