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
using System.IO;

namespace StrakhFed2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
       static public string path = @"ListName.txt";

        public StartWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbLastName.Text != null && tbLastName.Text != " ")
            {
                if (tbFirstName.Text != null && tbFirstName.Text != " ")
                {
                    if (tbAge.Text != null && tbAge.Text != " ")
                    {
                        MessageBox.Show($"Фамилия: {tbLastName.Text} Имя: {tbFirstName.Text} Возраст: {tbAge.Text}");

                        StreamWriter streamWriter = new StreamWriter(path, true);
                        streamWriter.WriteLine(tbLastName.Text + " " + tbFirstName.Text + " " + tbAge.Text);
                        streamWriter.Close();
                    }
                }
            }

            else
            {
                MessageBox.Show("Введите данные без пробелов");
            }
            
        }

        private void tbAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void tbLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void tbFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (int.TryParse(e.Text, out val))
            {
                e.Handled = true;
            }
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
           // string[] vs = new string[3];
           // StreamReader streamReader = new StreamReader(path);

           //// StreamReader f = new StreamReader("test.txt");
           // while (!streamReader.EndOfStream)
           // {
           //     vs = streamReader.ReadLine().Split(' '); 
                
           //     // что-нибудь делаем с прочитанной строкой s
           // };
            //streamReader.Close();
            SecondWindow secondWindow = new SecondWindow(path);
            secondWindow.ShowDialog();
        }
    }
}
