using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;
using System.Globalization;
using System.ComponentModel;

namespace SplitTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;
            Timer = new Timer();

            txtClock.DataContext = Timer;
        }

        private Timer Timer;

        private void TxtClock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Timer.TxtClock_MouseLeftButtonUp(sender, e);
        }
    }

    public class Timer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string myClockText;
        public string ClockText
        {
            get => myClockText;
            set
            {
                myClockText = value;
                NotifyPropertyChanged("ClockText");
            }
        }

        public Timer()
        {
            DispatcherTimer.Tick += DispatcherTimer_Tick;
            DispatcherTimer.Interval = TimeSpan;
            DispatcherTimer.Start();
            Stopwatch.Start();
        }

        private TimeSpan TimeSpan = new TimeSpan(0, 0, 0, 0, 10);
        private DispatcherTimer DispatcherTimer = new DispatcherTimer();
        private Stopwatch Stopwatch = new Stopwatch();

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            ClockText = Stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TxtClock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Stopwatch.IsRunning)
            {
                Stopwatch.Stop();
            }
            else
            {
                Stopwatch.Start();
            }


            ClockText = Stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}
