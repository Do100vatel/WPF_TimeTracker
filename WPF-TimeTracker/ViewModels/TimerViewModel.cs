using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_TimeTracker.Models;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace WPF_TimeTracker.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private TimerModel _currentTimer;
        private DispatcherTimer _dispatcherTimer;


        public TimerViewModel()
        {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        public TimerModel CurrentTimer
        {
            get => _currentTimer;
            set
            {
                _currentTimer = value;
                OnPropertyChanged(nameof(CurrentTimer));
            }
        }

        public void StartTimer()
        {
            if (_currentTimer != null && !_currentTimer.IsRunning)
            {
                _currentTimer
            }

    }
}
