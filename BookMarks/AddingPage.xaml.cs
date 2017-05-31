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
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Genres>));
            using (var fs = new FileStream("genres.xml", FileMode.Open))
            {
                _genres = (List<Genres>)jsonFormatter.ReadObject(fs);
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

            List<Book> _books = new List<Book>();
            using (var fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                _books = (List<Book>)jsonFormatter.ReadObject(fs);
            }

            bool fl = false;
            foreach (var book in _books)
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
                _books.Add(_newBook);
                _books.Sort(delegate (Book _b1, Book _b2)
                { return _b1.Autor.CompareTo(_b2.Autor); });

                MessageBox.Show("Книга успешно добавлена");
                using (var fs = new FileStream("students.xml", FileMode.Create))
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                    jsonFormatter.WriteObject(fs, _books);
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
