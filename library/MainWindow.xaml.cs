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

namespace library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities context = new Entities();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            string logintext = logText.Text.ToString();
            string passwordText = pasText.Text.ToString();

            string loginBD = context.Customer.Where(i => i.Login == logintext).Select(h => h.Login).FirstOrDefault();
            if (loginBD != null)
            {
                string passwoedBD = context.Customer.Where(i => i.Login == logintext).Select(h => h.Password).FirstOrDefault();
                if(passwoedBD == passwordText)
                {
                    MainViewModel.LoginCust = loginBD;
                    int idROLE = context.Customer.Where(i => i.Login == logintext).Select(j => j.idRole).FirstOrDefault();
                    if (idROLE == 1)
                    { 
                        LectureWindow lectureWindow = new LectureWindow();
                        lectureWindow.Show();
                        this.Close();
                    }
                    if (idROLE == 2)
                    {
                        TeacherWindow teacherWindow = new TeacherWindow();
                        teacherWindow.Show();
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();   
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void logText_GotFocus(object sender, RoutedEventArgs e)
        {
            if(logText.Text.ToString() == " Логин...")
            {
                logText.Text = "";
                logText.Foreground = Brushes.Black;
            }
        }

        private void logText_LostFocus(object sender, RoutedEventArgs e)
        {
            if(logText.Text.ToString() == "")
            {
                logText.Text = " Логин...";
                logText.Foreground = Brushes.Gray;
            }
        }

        private void pasText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (pasText.Text.ToString() == " Пароль...")
            {
                pasText.Text = "";
                pasText.Foreground = Brushes.Black;
            }
        }

        private void pasText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pasText.Text.ToString() == "")
            {
                pasText.Text = " Пароль...";
                pasText.Foreground = Brushes.Gray;
            }
        }

        private void g_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вам на почту выслана инструкция по восстановлению пароля", "Восстановление пароля");
        }
    }
}
