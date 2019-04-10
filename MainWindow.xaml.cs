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

            DispatcherTimer DispatcherTimer = new DispatcherTimer();
            TimeSpan TimeSpan = new TimeSpan(0, 0, 0, 0, 10);

            DispatcherTimer.Tick += DispatcherTimer_Tick;
            DispatcherTimer.Interval = TimeSpan;
            DispatcherTimer.Start();
            Stopwatch.Start();
        }

        public Stopwatch Stopwatch = new Stopwatch();

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            DispatcherTimer dispatcherTimer = (DispatcherTimer)sender;
            txtClock.Text = Stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }

        private void TxtClock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Stopwatch.IsRunning)
            {
                Stopwatch.Stop();
            }
            else
            {
                Stopwatch.Start();
            }


            txtClock.Text = Stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fff");
        }
    }
}
