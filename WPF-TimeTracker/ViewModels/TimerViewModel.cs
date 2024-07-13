using System;
using System.ComponentModel;

namespace WPF_TimeTracker.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private TimerModel _currentTimer;

        private DateTime _startTime;
        private TimeSpan _elapsedTime;
        private TimeSpan _duration;
        private bool _isRunning;

        public TimerModel CurrentTimer
        { 
            get { return _currentTimer; }
            set
            {
                if (_currentTimer != value)
                {
                    _currentTimer = value;
                    OnPropertyChanged(nameof(CurrentTimer));
                }
            }
        }

        public TimerViewModel()
        {
            _currentTimer = new TimerModel();
        }
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
            if (CurrentTimer != null)
            {
                CurrentTimer.Start();
                OnPropertyChanged(nameof(CurrentTimer));
            }
        }

        public void StopTimer()
        {
            ElapsedTime = DateTime.Now - StartTime;
            IsRunning = false;

            // Логика для остановки таймера
            if (CurrentTimer != null)
            {
                CurrentTimer.Stop();
                OnPropertyChanged(nameof(CurrentTimer));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
