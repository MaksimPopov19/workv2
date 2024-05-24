using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для registrations.xaml
    /// </summary>
    public partial class registrations : Window
    {
        Entities.Entitiesshool Bd;
        int minute = 2;
        int seconds = 0;
        int id_use;
        DispatcherTimer timer = new DispatcherTimer();
        public registrations( int id)
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_tick;
            timer.Start();
            Bd = new Entities.Entitiesshool();
            id_use = id;         
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {

            if (surname.Text != string.Empty && name.Text != string.Empty
                && patronymic.Text != string.Empty
               && login.Text != string.Empty && (Password.Password != string.Empty 
               || password.Text != string.Empty)
               && levels.SelectedItem != null && 
               (Povtorpassword.Password != string.Empty || 
               pavtorpassword.Text != string.Empty))
            {
                if(Bd.users.Any(x => x.login != login.Text))
                    {
                 password.Text = Password.Password;
                    pavtorpassword.Text = Povtorpassword.Password;
                if (Regex.IsMatch(password.Text, "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
                    && password.Text == pavtorpassword.Text)
                {
                       
                    Entities.users user = new Entities.users
                    {
                        surname = surname.Text,
                        name = name.Text,
                        patronymic = patronymic.Text,
                        login = login.Text,
                        password = password.Text,
                        levels = ((ComboBoxItem)levels.SelectedItem).Content.ToString(),
                    };
                    Bd.users.Add(user);
                    Bd.SaveChanges();
                    Admin admin = new Admin(id_use);
                    admin.Show();
                    admin.WindowState = this.WindowState;
                    this.Close();
                        timer.Stop();
                    }
                else
                {
                    MessageBox.Show("Пароль не совпадает");
                }
                }
                else MessageBox.Show("Пользователь уже существует");
            }
            else MessageBox.Show("Введите данные");

        }


        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (password.Text == string.Empty)
            {
                Password.Background = Brushes.White;
                password.Background = Brushes.White;
                soobchenia.Text = string.Empty;
            }
            else if (password.Text.Length <= 8)
            {
                password.Background = Brushes.Red;
                Password.Background = Brushes.Red;
                soobchenia.Text = string.Empty;
                soobchenia.Text = "Пароль должен содержать минимум 8 символов и заглавные и прописные латинские буквы";
                soobchenia.Foreground = Brushes.Red;
            }

            else if (Regex.IsMatch(password.Text, "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                password.Background = Brushes.LawnGreen;
                Password.Background = Brushes.LawnGreen;
                soobchenia.Text = string.Empty;
           
            }
            else if (Regex.IsMatch(password.Text, "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,}$"))
            {
                password.Background = Brushes.Orange;
                Password.Background = Brushes.Orange;
                soobchenia.Text = string.Empty;
                soobchenia.Text = "Пароль должен содержать спец символы и хотя бы одну цифру";
                soobchenia.Foreground = Brushes.Orange;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin(id_use);
            admin.Show();
            admin.WindowState = this.WindowState;
            timer.Stop();
            this.Close();
        }
        private void Button(object sender, RoutedEventArgs e)
        {
            Password.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Visible;
            pavtorpassword.Visibility = Visibility.Visible;
            Povtorpassword.Visibility = Visibility.Hidden;
            pavtorpassword.Text = Povtorpassword.Password;
            password.Text = Password.Password;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            pavtorpassword.Visibility = Visibility.Hidden;
            Povtorpassword.Visibility = Visibility.Visible;
            password.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
            Password.Password = password.Text;
            Povtorpassword.Password = pavtorpassword.Text;

        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Password.Password == string.Empty)
            {
                Password.Background = Brushes.White;
                password.Background = Brushes.White;
                soobchenia.Text = string.Empty;
            }
            else if (Password.Password.Length <= 8)
            {
                password.Background = Brushes.Red;
                Password.Background = Brushes.Red;
                soobchenia.Text = string.Empty;
                soobchenia.Text = "Пароль должен содержать минимум 8 символов и заглавные и прописные латинские буквы";
                soobchenia.Foreground = Brushes.Red;
            }

            else if (Regex.IsMatch(Password.Password, "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                password.Background = Brushes.LawnGreen;
                Password.Background = Brushes.LawnGreen;
                soobchenia.Text = string.Empty;
            }
            else if (Regex.IsMatch(Password.Password, "^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{8,}$"))
            {
                password.Background = Brushes.Orange;
                Password.Background = Brushes.Orange;
                soobchenia.Text = string.Empty;
                soobchenia.Text = "Пароль должен содержать спец символы и хотя бы одну цифру";
                soobchenia.Foreground = Brushes.Orange;
            }
        }
        public void timer_tick(object sender, EventArgs e)
        {
            
            if (seconds == 30 && minute == 0)
            {

                MessageBox.Show("Осталось 30 секунд до окончание сеанса");

            }

            if (seconds == 0 && minute == 0)
            {
               var bloc = Bd.users.Where(x => x.id_users == id_use ).FirstOrDefault();
                bloc.blok = 1;
                Bd.SaveChanges();
                authorization authorization = new authorization();
                authorization.Show();
                this.Close();
                timer.Stop();
            }
            
            if(seconds == 0 && minute > 0)
            {
                minute--;
                seconds = 59;
            }
            seans.Text = "Время сеанса 00:" + minute + ":" + seconds;
            seconds--;
            
        }
    }

}
