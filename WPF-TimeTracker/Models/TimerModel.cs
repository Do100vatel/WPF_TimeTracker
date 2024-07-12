using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TimeTracker
{
    public class TimerModel
    {
        public string Name { get; set; }
        public bool _isRunning;
        // public DateTime StartTime { get; set; }

        private DateTime _startTime;
        private TimeSpan _elapsedTime;

        public DateTime StartTime
        {
            get { return _startTime; }  
            private set { _startTime = value; }
        }

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            private set { _elapsedTime = value; }
        }

        public bool IsRunning
        {
            get { return _isRunning; }
            private set { _isRunning = value; }
        }

        public void Start()
        {
            if (!_isRunning)
            {
                _startTime = DateTime.Now;
                _isRunning = true;
            }
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                _elapsedTime += DateTime.Now - _startTime;
                _isRunning = false;
            }
        }

    }
}
