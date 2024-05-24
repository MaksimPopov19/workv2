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

namespace kursovai
{
    /// <summary>
    /// Логика взаимодействия для Editor.xaml
    /// </summary>
    public partial class Editor : Window
    {
        Entities.Entitiesshool Bd;
        Entities.users saveuser;        
        int  id_use;
        public Editor(Entities.users users, int id)
        {
            Bd = new Entities.Entitiesshool();
            var user = Bd.users.Where(x => x.id_users == users.id_users).FirstOrDefault();
            InitializeComponent();
            surname.Text = user.surname;
            name.Text = user.name;
            patronymic.Text = user.patronymic;
            login.Text = user.login;
            Password.Password = user.password;
            password.Text = user.password;
            levels.Text = user.levels;
            saveuser = users;
             
            id_use = id;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin(id_use);
            admin.Show();
            this.Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (surname.Text != string.Empty && name.Text != string.Empty
               && patronymic.Text != string.Empty
              && login.Text != string.Empty &&(password.Text != string.Empty ||
              Password.Password != string.Empty) 
              && levels.SelectedItem != null)
            { 
             var Save = Bd.users.Where(x => x.id_users == saveuser.id_users).FirstOrDefault();
                Save.surname = surname.Text;
                Save.name = name.Text;
                Save.patronymic = patronymic.Text;
                Save.login = login.Text;
                Save.password = password.Text;
                Save.levels = levels.Text;
                Bd.SaveChanges();  
                Admin admin = new Admin(id_use);
                admin.Show();
                this.Close();
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
        private void Button(object sender, RoutedEventArgs e)
        {
            Password.Visibility = Visibility.Hidden;
            password.Visibility = Visibility.Visible;           
            password.Text = Password.Password;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            password.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;
            Password.Password = password.Text;
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
    }
}
