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
    /// Логика взаимодействия для BeginPage.xaml
    /// </summary>
    public partial class BeginPage : Page
    {
        public BeginPage()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести логин");
                loginTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести пароль");
                passwordTextBox.Focus();
                return;
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
            List<Person> _people= new List<Person>();
            bool _fl = false;
            try
            {
                using (FileStream fs = new FileStream("person.xml", FileMode.OpenOrCreate))
                {
                    {
                        List<Person> _data = new List<Person>();
                        
                        _data = (List<Person>)xml.Deserialize(fs);
                        _people = _data;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                _people.Add(new Person("admin", "1"));
            }
            catch (NullReferenceException)
            {
                _people.Add(new Person("admin", "1"));
            }
            bool _fl2 = false;

            foreach (var person in _people)
            {
                if (person.Login == loginTextBox.Text)
                {
                    if (person.Password == passwordTextBox.Text)
                    {
                        _fl2 = true;
                        break;
                    }
                }
            }

            if (_fl2) NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            else MessageBox.Show("Неверный логин или пароль");
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/RegisterPage.xaml", UriKind.Relative));
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                signInButton_Click(null, null);
        }

    }
}
