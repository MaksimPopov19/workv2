using kursovai.Entities;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace kursovai
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        Entities.Entitiesshool Bd;
        DispatcherTimer timerSession = new DispatcherTimer();
        string surname;
        int seconds = 59, id_use;
        public Admin(int id)
        {
            Bd = new Entities.Entitiesshool();
            InitializeComponent();
            conclusion();
            var use = Bd.users.Where(x => x.id_users == id).FirstOrDefault();
            
            id_use = id;
            surname = use.surname.ToString();
            user.Text = "Пользователь: " + surname;
            timers();
        }
        public void timers()
        {
            timerSession.Interval = TimeSpan.FromSeconds(1);
            timerSession.Tick += timer_tick;     
            timerSession.Start();
            
        }
        public void conclusion()
        {
            Entities.Entitiesshool entitiesshool = new Entities.Entitiesshool();
            userDg.ItemsSource = entitiesshool.users.ToList();
        }
        private void redistr_Click(object sender, RoutedEventArgs e)
        {
            registrations registrations = new registrations(id_use);
            registrations.Show();
            registrations.WindowState = this.WindowState;
            timerSession.Stop();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            authorization authorization = new authorization();
            authorization.Show();
            authorization.WindowState = this.WindowState;
            timerSession.Stop();
            this.Close();
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
        private void editorBtn_Click(object sender, RoutedEventArgs e)
        {
            if(userDg.SelectedItem != null) 
            {
                Entities.users users = (Entities.users)userDg.SelectedItem;
                Editor editor = new Editor(users,id_use);
                editor.Show();
                timerSession.Stop();
                this.Close();
            }
          else  MessageBox.Show("Выберите пользователя из списка");
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (userDg.SelectedItem != null)
            { if( MessageBox.Show("Точно вы хотите удалить","",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                 Entities.users users = (Entities.users)userDg.SelectedItem;
                Bd.users.Remove(Bd.users.Find(users.id_users));                   
                Bd.SaveChanges();
                conclusion();
                }                                        
            }
            else  MessageBox.Show("Выберите пользователя из списка");
           
        }
    }
}
