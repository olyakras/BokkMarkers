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
    /// Логика взаимодействия для AddingPage.xaml
    /// </summary>
    public partial class AddingPage : Page
    {
        List<Genres> _genres = new List<Genres>;
        public AddingPage()
        {
            InitializeComponent();
            LoadGenre();
            genreComboBox.ItemsSource = _genres;
        }

        private void LoadGenre()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Genres>));
            using (var fs = new FileStream("genres.xml", FileMode.Open))
            {
                _genres = (List<Genres>)xml.Deserialize(fs);
            }
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.MainPage);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(autorTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести имя автора");
                autorTextBox.Clear();
                autorTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(titleBookTextBox.Text))
            {
                MessageBox.Show("Необходимо ввести название книги");
                titleBookTextBox.Clear();
                titleBookTextBox.Focus();
                return;
            }

            if (genreComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите жанр");
                return;
            }

            Data data = new Data();
            using (var fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                    XmlSerializer xml = new XmlSerializer(typeof(Data));
                    data = (Data)xml.Deserialize(fs);
            }

            bool fl = false;
            foreach (var book in data.Books)
            {
                if (book.Title == titleBookTextBox.Text && book.Autor == autorTextBox.Text)
                {
                    fl = true;
                    break;
                }
            }
            if (fl)
            {
                MessageBox.Show("Книга уже существует");
                titleBookTextBox.Clear();
                autorTextBox.Clear();
                titleBookTextBox.Clear();
            }

            else
            {
                Book _newBook = new Book (autorTextBlock.Text,
                    titleBookTextBlock.Text);
                _newBook.Genre = genreComboBox.SelectedItem as Genres;
                data.Books.Add(_newBook);
                data.Books.Sort(delegate (Book _b1, Book _b2)
                { return _b1.Autor.CompareTo(_b2.Autor); });

                MessageBox.Show("Книга успешно добавлена");
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
                addButton_Click(null, null);
        }
    }
}
