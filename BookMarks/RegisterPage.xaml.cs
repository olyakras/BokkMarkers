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
using System.Xml.Serialization;
using System.IO;

namespace BookMarks
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BeginPage.xaml", UriKind.Relative));
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести логин");
                loginTextBox.Clear();
                loginTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести пароль");
                passwordTextBox.Clear();
                passwordTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text) != string.IsNullOrWhiteSpace(repeatPasTextBox.Text))
            {
                MessageBox.Show("Пароли не совпадают");
                repeatPasTextBox.Clear();
                repeatPasTextBox.Focus();
                return;
            }

            DataPeople data= new DataPeople();
            using (var fs = new FileStream("C://Documents//Информатика//person.xml", FileMode.OpenOrCreate))
            {
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(Data));
                        data = (DataPeople)xml.Deserialize(fs);
                    }
            }

            bool fl = false;
            foreach (var person in data.People)
            {
                if (person.Login == loginTextBox.Text)
                {
                    fl = true;
                    break;
                }
            }
            if (fl)
            {
                MessageBox.Show("Логин занят");
                loginTextBox.Clear();
                loginTextBox.Focus();
            }

            else
            {
                Person _newPerson = new Person(loginTextBlock.Text,
                    passwordTextBlock.Text);
                data.People.Add(_newPerson);
                data.People.Sort(delegate (Person _p1, Person _p2)
                { return _p1.Login.CompareTo(_p2.Login); });

                MessageBox.Show("Регистрация прошла успешна");
                using (var fs = new FileStream("students.xml", FileMode.Create))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Data));
                    xml.Serialize(fs, data);
                }
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                signUpButton_Click(null, null);
        }

    }
}
