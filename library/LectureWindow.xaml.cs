using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Логика взаимодействия для LectureWindow.xaml
    /// </summary>
    public partial class LectureWindow : Window
    {

        Entities context = new Entities();

        List<String> textLes = new List<string>();
        List<String> texTest = new List<string>();
        List<String> textTitle = new List<string>();
        List<String> answer1 = new List<string>();
        List<String> answer2 = new List<string>();
        List<String> answer3 = new List<string>();
        List<String> answer4 = new List<string>();
        List<String> correctAnswer = new List<string>();
        List<int> idLecture = new List<int>();

        public TextBlock textBlock;
        public Button button;
        public TextBlock radio;

        public int numTest = 0;
        public LectureWindow()
        {
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textLes.AddRange(context.Lecture.Select(i => i.Text).ToList());
            textTitle.AddRange(context.Lecture.Select(i => i.Topic).ToList());
            
            correctAnswer.AddRange(context.Test.Select(i => i.answerOption_1).ToList());
            idLecture.AddRange(context.Lecture.Select(i => i.idLecture).ToList());


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textBlock != null)
            {
                textBlock.Background = Brushes.Transparent;
            }
            textBlock = (TextBlock)(((StackPanel)(((Button)(sender)).Content)).Children[0]);
            textBlock.Background = Brushes.Gray;

            testBut.Visibility = Visibility.Visible;

            int a = Convert.ToInt32(textBlock.Uid);
            TextLecture.Text = textLes[a - 1].ToString();
            Title.Content = textTitle[a - 1].ToString();

            
            int idCust = context.Customer.Where(i => i.Login == MainViewModel.LoginCust).Select(j => j.idCustomer).FirstOrDefault();
            int idLect = context.Lecture.Where(i => i.Text == TextLecture.Text.ToString()).Select(j => j.idLecture).FirstOrDefault();
            int idTextCust = context.lectureCustomer.Where(i => i.idLecture == idLect).Where(c => c.idCustomer == idCust).Select(j => j.idLecture).FirstOrDefault();

            if (idTextCust == 0)
            {
                context.lectureCustomer.Add(new lectureCustomer()
                {
                    idCustomer = idCust,
                    idLecture = idLect,
                    Passed = 1,
                });
                context.SaveChanges();
            }

        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void testBut_Click(object sender, RoutedEventArgs e)
        {

            if (testBut.Content.ToString() == "ТЕСТ")
            {
                TestVisible();
                ClearLists();
                Tests();
            }
            else if (testBut.Content.ToString() == "ОТМЕНА")
            {
                TextVisible();
                numTest = 0;
            }
        }

        private void ClearLists()
        {
            texTest.Clear();
            answer1.Clear();
            answer2.Clear();
            answer3.Clear();
            answer4.Clear();
        }

        public void TestVisible()
        {
            testBut.Content = "ОТМЕНА";

            textTest.Visibility = Visibility.Visible;
            scrollLecture.Visibility = Visibility.Hidden;
            Title.Visibility = Visibility.Hidden;
            testButtons.Visibility = Visibility.Visible;
            checkAnswer.Visibility = Visibility.Visible;
        }
        public void TextVisible()
        {
            testBut.Content = "ТЕСТ";

            textTest.Visibility = Visibility.Hidden;
            scrollLecture.Visibility = Visibility.Visible;
            Title.Visibility = Visibility.Visible;
            testButtons.Visibility = Visibility.Hidden;
            checkAnswer.Visibility = Visibility.Hidden;
        }

        private void Tests()
        {
            int a = Convert.ToInt32(textBlock.Uid) - 1;
            int b = idLecture[a];

            if (numTest == 0)
            {
                texTest.AddRange(context.Test.Where(j => j.idLecture == b).Select(i => i.Question).ToList());
                answer1.AddRange(context.Test.Where(j => j.idLecture == b).Select(i => i.answerOption_1).ToList());
                answer2.AddRange(context.Test.Where(j => j.idLecture == b).Select(i => i.answerOption_2).ToList());
                answer3.AddRange(context.Test.Where(j => j.idLecture == b).Select(i => i.answerOption_3).ToList());
                answer4.AddRange(context.Test.Where(j => j.idLecture == b).Select(i => i.answerOption_4).ToList());
            }
            if (texTest.Count == numTest)
            {
                numTest = 0;
                TextVisible();
            }
            else
            {
                textTest.Text = texTest[numTest].ToString();
                answerButText1.Text = answer1[numTest].ToString();
                answerButText2.Text = answer2[numTest].ToString();
                answerButText3.Text = answer3[numTest].ToString();
                answerButText4.Text = answer4[numTest].ToString();
            }

        }

        private void checkAnswer_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(textBlock.Uid);

            if(radio != null)
            {
                if (radio.Text.ToString() == correctAnswer[a - 1].ToString())
                {
                    MessageBox.Show("да");

                    numTest++;
                    Tests();
                }
                else
                {
                    MessageBox.Show("нет");

                    numTest++;
                    Tests();
                }

                string que = texTest[numTest];
                int idCust = context.Customer.Where(i => i.Login == MainViewModel.LoginCust).Select(j => j.idCustomer).FirstOrDefault();
                int idtest = context.Test.Where(i => i.Question == que).Select(j => j.idTest).FirstOrDefault();

                int idTestCist = context.testsCustomer.Where(i => i.idTest == idtest).Where(c => c.idCustomer == idCust).Select(j => j.idTest).FirstOrDefault();

                if (idTestCist == 0)
                {
                    context.testsCustomer.Add(new testsCustomer()
                    {
                        idCustomer = idCust,
                        idTest = idtest,
                        Passed = 1,
                    });
                    context.SaveChanges();
                }



            }
            else
            {
                MessageBox.Show("Выбирите вариант ответа!");
            }
                

        }

        private void answer_Checked(object sender, RoutedEventArgs e)
        {
            radio = (TextBlock)((RadioButton)(sender)).Content;
        }

        private void ButMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
        }
    }
}
