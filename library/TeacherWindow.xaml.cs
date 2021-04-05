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
    
    public partial class TeacherWindow : Window
    {
        Entities context = new Entities();

        List<Customer> customers = new List<Customer>();
        int CountLector = 0;
        int CountTest = 0;

        int PassedTest = 5;
        public TeacherWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            customers.AddRange(context.Customer.Where(i => i.idRole == 1).ToList());
            CountLector = context.Lecture.Select(i => i.idLecture).Count();
            CountTest = context.Test.Select(i => i.idTest).Count();

            List<View> views = new List<View>();
            for (int i = 0; i < customers.Count; i++)
            {
                int idCust = customers[i].idCustomer;
                View view = new View();
                view.name = customers[i].Name;
                view.surname = customers[i].Surname;
                view.patronymic = customers[i].Patronymic;
                view.progressLector = context.lectureCustomer.Where(c => c.idCustomer == idCust).Select(j => j.Passed).Count();
                view.procentLector = (100 / CountLector) * context.lectureCustomer.Where(c => c.idCustomer == idCust).Select(j => j.Passed).Count();
                view.progressTest = context.testsCustomer.Where(c => c.idCustomer == idCust).Select(j => j.Passed).Count();
                view.procentTest = (100 / CountTest) * context.testsCustomer.Where(c => c.idCustomer == idCust).Select(j => j.Passed).Count();
                views.Add(view);
            }

            listUsers.ItemsSource = views;

        }
        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
