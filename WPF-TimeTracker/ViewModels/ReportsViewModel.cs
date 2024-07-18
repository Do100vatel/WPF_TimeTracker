
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WPF_TimeTracker.Commands;
using WPF_TimeTracker.Models;

namespace WPF_TimeTracker.ViewModels
{
    public class ReportsViewModel : INotifyPropertyChanged
    {
        private MainViewModel _mainViewModel;

        public ObservableCollection<TimeEntryModel> TimeEntries { get; set; }
        public ObservableCollection<ReportModel> Reports { get; set; }

        public ICommand GenerateReportCommand {get; }
        public ICommand ExportToCSVCommand { get; }

        public ReportsViewModel()
        {
            Reports = new ObservableCollection<ReportModel>();
            GenerateReportCommand = new RelayCommand(GenerateReport);
            TimeEntries = new ObservableCollection<TimeEntryModel>();
            // Логика для загрузки данных и создания отчетов
            ExportToCSVCommand = new RelayCommand<string>(ExportToCSV);
        }

        public ReportsViewModel(MainViewModel mainViewModel) : this()
        {
            _mainViewModel = mainViewModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void GenerateReport()
        {
            var timeEtries = _mainViewModel?.GetTimeEntries();
            if(timeEtries != null)
            {
                Reports.Clear();
                foreach (var entry in timeEtries)
                {
                    Reports.Add(new ReportModel
                    {
                        Date = entry.Date,
                        Category = entry.Category,
                        Duration = entry.Duration
                    });
                }
                OnPropertyChanged(nameof(Reports));
            }
        }

        public void ExportToCSV(string filePath)
        {
            using(var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Date,Category,Duration");
                foreach(var report in Reports)
                {
                    writer.WriteLine($"{report.Date},{report.Category},{report.Duration}");
                }
            }
        }
    }
}
