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
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Security.Cryptography;

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

            List<Person> data = new List<Person>();
            using (var fs = new FileStream("C://Documents//Информатика//person.xml", FileMode.OpenOrCreate))
            {
                    {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));
                        data = (List<Person>)jsonFormatter.ReadObject(fs);
                    }
            }

            bool fl = false;
            foreach (var person in data)
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
                    CalculateHash(passwordTextBlock.Text));
                data.Add(_newPerson);
                data.Sort(delegate (Person _p1, Person _p2)
                { return _p1.Login.CompareTo(_p2.Login); });

                MessageBox.Show("Регистрация прошла успешна");
                using (var fs = new FileStream("students.xml", FileMode.Create))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Person>));
                    jsonFormatter.WriteObject(fs, data);
                }
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                signUpButton_Click(null, null);
        }

    }
}
