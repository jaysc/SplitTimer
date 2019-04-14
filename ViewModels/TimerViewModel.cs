using SplitTimer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SplitTimer.Commands;
using System.ComponentModel;
using System.Windows.Threading;
using System.Diagnostics;

namespace SplitTimer.ViewModels
{
    internal class TimerViewModel : BaseViewModel
    {
        private TimeSpan TimeSpan = new TimeSpan(0, 0, 0, 0, 10);
        private DispatcherTimer DispatcherTimer = new DispatcherTimer();
        private Stopwatch Stopwatch = new Stopwatch();

        private Timer myTimer;
        public Timer Timer => myTimer;

        public string Time
        {
            get => myTimer.Time;
            set
            {
                myTimer.Time = value;
                NotifyPropertyChanged(nameof(Time));
            }
        }

        public TimerViewModel()
        {
            myTimer = new Timer();
            TextOnClickCommand = new TextOnClickCommand(this);

            DispatcherTimer.Tick += DispatcherTimer_Tick;
            DispatcherTimer.Interval = TimeSpan;
            DispatcherTimer.Start();
            Stopwatch.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Time = Stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }

        public void ToggleTimer()
        {
            if (Stopwatch.IsRunning)
            {
                Stopwatch.Stop();
            }
            else
            {
                Stopwatch.Start();
            }

            Time = Stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }

        public ICommand TextOnClickCommand { get; private set; }

        public bool CanUpdate = true;

        internal void TimerToggle()
        {
            ToggleTimer();
        }
    }
}
