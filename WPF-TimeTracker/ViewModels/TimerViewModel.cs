using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.ComponentModel;
using System.Windows.Threading;
using System.ComponentModel;


namespace WPF_TimeTracker.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {

        private DateTime _startTime;
        private TimeSpan _elapsedTime;
        private TimeSpan _duration;
        private bool _isRunning;

        public TimeSpan Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    OnPropertyChanged(nameof(Duration));
                }
            }
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        public TimeSpan ElapsedTime
        {
            get => _elapsedTime;
            set
            {
                if (_elapsedTime != value)
                {
                    _elapsedTime = value;
                    OnPropertyChanged(nameof(ElapsedTime));
                }
            }
        }

        private bool IsRunning
        {
            get => _isRunning;
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    OnPropertyChanged(nameof(IsRunning));
                }
            }
        }

        public void StartTimer()
        {

            StartTime = DateTime.Now;
            IsRunning = true;
            // Логика для запуска таймера 
            /*
            if (_currentTimer != null && !_currentTimer.IsRunning)
            {
                _currentTimer.IsRunning = true;
                _currentTimer.StartTime = DateTime.Now;
                _dispatcherTimer.Start();
            }
            */
        }

        public void StopTimer()
        {
            ElapsedTime = DateTime.Now - StartTime;
            IsRunning = false;
            /* Логика для остановки таймера
            if (_currentTimer != null && _currentTimer.IsRunning)
            {
                _currentTimer.IsRunning = true;
                _currentTimer.StartTime += DateTime.Now - _currentTimer.StartTime;
                _dispatcherTimer.Stop();
            }
            */
        }


        private event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
