using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using WPF_TimeTracker.Commands;
using WPF_TimeTracker.Models;

namespace WPF_TimeTracker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;

        public ObservableCollection<TimeEntryModel> TimeEntries { get; set; }
        public RelayCommand MyCommand { get; private set; }

        public TimerViewModel TimerViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        public CategoryViewModel CategoryVM { get; set; }

        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }
        public ICommand AddTimeEntryCommand { get; set; }

        private ICommand _startTimerCommand;
        private ICommand _stopTimerCommand;

        public MainViewModel()
        {
            TimerViewModel = new TimerViewModel();
            CategoryViewModel = new CategoryViewModel();

            TimeEntries = new ObservableCollection<TimeEntryModel>();

            MyCommand = new RelayCommand(MyAction, CanExecuteMyAction); 
            StartTimerCommand = new RelayCommand(StartTimer, CanExecuteStartStop);
            StopTimerCommand = new RelayCommand(StopTimer, CanExecuteStartStop);
            AddTimeEntryCommand = new RelayCommand(AddTimeEntry, CanExecuteAddTimeEntry);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += OnTimerTick;

            CategoryVM = new CategoryViewModel();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            OnPropertyChanged(nameof(ElapsedTime));
        }


        public string ElapsedTime => _elapsedTime.ToString(@"hh\:mm\:ss");

        public ObservableCollection<TimeEntryModel> GetTimeEntries()
        {
            return TimeEntries;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void StartTimer()
        {
            _timer.Start();
        }

        private void StopTimer()
        {
            _timer.Stop();
        }

        private void AddTimeEntry()
        {
            System.Diagnostics.Debug.WriteLine("AddTimeEntry executed");
            var timeEntry = new TimeEntryModel
            {
                StartTime = TimerViewModel.CurrentTimer.StartTime,
                Duration = TimerViewModel.CurrentTimer.ElapsedTime
            };
            CategoryViewModel.AddTimeEntry(timeEntry);
        }

        private bool CanExecuteMyAction()
        {
            return true;
        }

        private bool CanExecuteStartStop()
        {
            return TimerViewModel != null && TimerViewModel.CurrentTimer != null;
        }

        private bool CanExecuteAddTimeEntry()
        {
            return TimerViewModel != null && TimerViewModel.CurrentTimer != null && TimerViewModel.CurrentTimer.IsRunning;
        }


        private void MyAction()
        {
            // Логика для выполнения действия
        }
    }
}
