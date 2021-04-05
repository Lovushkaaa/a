using System;
using System.Collections.Generic;
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

namespace StrakhFed2
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {

        List<Users> listUsers = new List<Users>();
        


        public SecondWindow(string p)
        {
            string path = p;
            InitializeComponent();
            string[] vs = new string[3];
            StreamReader streamReader = new StreamReader(path);

            // StreamReader f = new StreamReader("test.txt");
            while (!streamReader.EndOfStream)
            {
                vs = streamReader.ReadLine().Split(' ');
                if (vs[0] != "")
                {
                    Users user = new Users();
                    user.Age = Convert.ToInt32(vs[2]);
                    user.FirstName = vs[1];
                    user.LastName = vs[0];
                    listUsers.Add(user);
                }
                // что-нибудь делаем с прочитанной строкой s
            };
            streamReader.Close();


            dgUser.ItemsSource = listUsers;
        }

        private void dgUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
