using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace kursovai
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();       
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick+= timer_tick;
            timer.Start();
            Duration duration = new Duration(TimeSpan.FromSeconds(6));
            DoubleAnimation doubleanimation = new DoubleAnimation(200.0, duration);
            progress.BeginAnimation(ProgressBar.ValueProperty, doubleanimation);
        }
        public void timer_tick (object sender, EventArgs e)
        {
            authorization authorization = new authorization();
            authorization.Show();
            this.Close();
            timer.Stop();
        }
    }
}
