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
using System.Xml.Serialization;

namespace BookMarks
{
    /// <summary>
    /// Логика взаимодействия для ShowSearchPage.xaml
    /// </summary>
    public partial class ShowSearchPage : Page
    {
        List<Book> _searchBooks = new List<Book>();
        List<Book> _books = new List<Book>();
        public ShowSearchPage()
        {
            InitializeComponent();
            RefreshListBox();
        }

        private void PutOutData()
        {
            using (var fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Book>));
                _books = (List<Book>)xml.Deserialize(fs);
            }
        }

        private void SearchData()
        {
            PutOutData();
            StreamReader sr = new StreamReader("temporary");
            string _num = sr.ReadLine();
            if (_num=="0")
            {
                _num = sr.ReadLine();
                foreach(var _book in _books)
                {
                    if (_num == _book.Title)
                        _searchBooks.Add(_book);
                }
            }
            else
            {
                if (_num == "1")
                {
                    _num = sr.ReadLine();
                    foreach (var _book in _books)
                    {
                        if (_num == _book.Autor)
                            _searchBooks.Add(_book);
                    }
                }
                else
                {
                    _num = sr.ReadLine();
                    string _title = sr.ReadLine();
                    foreach (var _book in _books)
                    {
                        if (_num == _book.Autor && _title== _book.Title)
                            _searchBooks.Add(_book);
                    }
                }
            }
        }

        private void RefreshListBox()
        {
            showResultListBox.ItemsSource = null;
            if (_searchBooks == null)
                MessageBox.Show("Книга отсутствует");
            else
            showResultListBox.ItemsSource = _searchBooks;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
        }


    }
}
