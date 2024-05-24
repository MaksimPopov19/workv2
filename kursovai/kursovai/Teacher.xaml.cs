using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace kursovai
{
    /// <summary>
    /// Логика взаимодействия для Teacher.xaml
    /// </summary>
    public partial class Teacher : Window
    {
        Entities.Entitiesshool Bd;
        DispatcherTimer timerSession = new DispatcherTimer();
        string surname;
        int  seconds = 59, id_use;
        public Teacher(int id)
        {
            Bd = new Entities.Entitiesshool();
            var use = Bd.users.Where(x => x.id_users == id).FirstOrDefault();
            InitializeComponent();
            id_use = id;
            surname = use.surname.ToString();
            user.Text = "Пользователь: " + surname;
            timers();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            authorization authorization = new authorization();
            authorization.Show();
            authorization.WindowState = this.WindowState;
            timerSession.Stop();
            this.Close();
        }
        public void timers()
        {
            timerSession.Interval = TimeSpan.FromSeconds(1);
            timerSession.Tick += timer_tick;           
                timerSession.Start();           
        }
        public void timer_tick(object sender, EventArgs e)
        {
            seans.Text = "Время сеанса 00:00:" + seconds;
            if (seconds == 30)
            {
                MessageBox.Show("Осталось 30 секунд до окончание сеанса");
            }
            if (seconds == 0)
            {
                var bloc = Bd.users.Where(x => x.id_users == id_use).FirstOrDefault();
                bloc.blok = 1;
                Bd.SaveChanges();
                authorization authorization = new authorization();
                authorization.Show();
                this.Close();
                timerSession.Stop();
            }
            seconds--;
        }
      
    }
}
