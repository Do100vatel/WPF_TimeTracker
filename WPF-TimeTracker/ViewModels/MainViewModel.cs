using System.ComponentModel;
using System.Windows.Input;
using WPF_TimeTracker.Commands;

namespace WPF_TimeTracker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public RelayCommand MyCommand { get; private set; }

        public TimerViewModel TimerViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }
        public ICommand AddTimeEntryCommand { get; set; }

        public MainViewModel()
        {
            TimerViewModel = new TimerViewModel();
            CategoryViewModel = new CategoryViewModel();

            MyCommand = new RelayCommand(MyAction, CanExecuteMyAction);
            StartTimerCommand = new RelayCommand(StartTimer, CanExecuteStartStop);
            StopTimerCommand = new RelayCommand(StopTimer, CanExecuteStartStop);
            AddTimeEntryCommand = new RelayCommand(AddTimeEntry, CanExecuteAddTimeEntry);
        }

        private void StartTimer()
        {
            System.Diagnostics.Debug.WriteLine("StartTimer executed");
            TimerViewModel.StartTimer();
        }

        private void StopTimer()
        {
            System.Diagnostics.Debug.WriteLine("StopTimer executed");
            TimerViewModel.StopTimer();
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void MyAction()
        {
            // Логика для выполнения действия
        }
    }
}
