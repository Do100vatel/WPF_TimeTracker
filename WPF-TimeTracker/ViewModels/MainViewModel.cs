using System.ComponentModel;
using System.Windows.Input;

namespace WPF_TimeTracker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public TimerViewModel TimerViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }
        public ICommand AddTimeEntryCommand { get; set; }

        public MainViewModel()
        {
            TimerViewModel = new TimerViewModel();
            CategoryViewModel = new CategoryViewModel();

            StartTimerCommand = new RelayCommand(StartTimer);
            StopTimerCommand = new RelayCommand(StopTimer);
            AddTimeEntryCommand = new RelayCommand(AddTimeEntry);
        }

        private void StartTimer()
        {
            TimerViewModel.StartTimer();
        }

        private void StopTimer()
        {
            TimerViewModel.StopTimer();
        }

        private void AddTimeEntry() {
            var timeEntry = new TimerViewModel
            {
                StartTime = TimerViewModel.CurrentTimer.StartTime,
                Duration = TimerViewModel.CurrentTimer.ElapsedTime
            };
            CategoryViewModel.AddTimeEntry(timeEntry);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
