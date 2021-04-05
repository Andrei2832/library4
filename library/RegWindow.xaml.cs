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

namespace library
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        Entities context = new Entities();
        public RegWindow()
        {
            InitializeComponent();
        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            string logBD = context.Customer.Where(i => i.Login == login.Text.ToString()).Select(j => j.Login).FirstOrDefault();

            if(surname.Text == "" || name.Text == "" || patronymic.Text == "" || login.Text == "" || password.Text == "" || repeatPassword.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else if (logBD != null)
            {
                MessageBox.Show("Логин уже используется!");
            }
            else if (password.Text != repeatPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
            }
            else {

                MessageBoxResult result = MessageBox.Show(
                    surname.Text + " " +
                    name.Text + "\n" +
                    patronymic.Text + "\n\n" +
                    "Логин:  " + login.Text + "\n" +
                    "Пароль:  " + password.Text + "\n", "Создать пользователя:", MessageBoxButton.YesNo);

                if(result == MessageBoxResult.Yes)
                {
                    context.Customer.Add(new Customer()
                    {
                        Login = login.Text.ToString(),
                        Password = password.Text.ToString(),
                        Surname = surname.Text.ToString(),
                        Name = name.Text.ToString(),
                        Patronymic = patronymic.Text.ToString(),
                        idRole = 1,
                    });
                    context.SaveChanges();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                
                
               
            }
            
        }
        private void repeatPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (password.Text != repeatPassword.Text)
            {
                repeatPassword.BorderBrush = Brushes.Red;
                repeatPassword.BorderThickness = new Thickness(4);
            }
            else
            {
                repeatPassword.BorderBrush = Brushes.Green;
                repeatPassword.BorderThickness = new Thickness(4);
            }
        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


    }
}
