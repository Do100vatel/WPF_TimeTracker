using System.ComponentModel;
using System;
using System.Windows.Input;
using FirebaseAdmin.Messaging;

namespace WPF_TimeTracker.ViewModels
{
    public class MainViewModel
    {
        public RelayCommand MyCommand { get; private set; }

        public TimerViewModel TimerViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }

        public ICommand StartTimerCommand { get; set; }
        public ICommand StopTimerCommand { get; set; }
        public ICommand AddTimeEntryCommand { get; set; }

        public MainViewModel()
        {
            MyCommand = new RelayCommand(MyAction, CanExecuteMyAction);
            StartTimerCommand = new RelayCommand(StartTimer, CanExecuteStartStop);
            StopTimerCommand = new RelayCommand(StopTimer, CanExecuteStartStop);
            AddTimeEntryCommand = new RelayCommand(AddTimeEntry, CanExecuteAddTimeEntry);
        }

        private void StartTimer()
        {
            TimerViewModel.StartTimer();
        }

        private void StopTimer()
        {
            TimerViewModel.StopTimer();
        }

        private void AddTimeEntry()
        {
            var timeEntry = new TimeEntryModel
            {
                StartTime = TimerViewModel.CurrentTimer.StartTime,
                Duration = TimerViewModel.CurrentTimer.ElapsedTime
            };
            CategoryViewModel.AddTimeEntry(timeEntry);
        }

        private bool CanExecuteMyAction()
        {
            // Добавьте вашу логику для CanExecute
            return true;
        }

        private bool CanExecuteStartStop()
        {
            // Логика для определения, можно ли начать или остановить таймер
            return TimerViewModel != null && TimerViewModel.CurrentTimer != null;
        }

        private bool CanExecuteAddTimeEntry()
        {
            // Логика для определения, можно ли добавить запись времени
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
