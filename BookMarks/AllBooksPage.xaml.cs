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
    /// Логика взаимодействия для AllBooksPage.xaml
    /// </summary>
    public partial class AllBooksPage : Page
    {
        List<Book> _books = new List<Book>();

        public AllBooksPage()
        {
            InitializeComponent();
            PutOutData();
            RefreshListBox();
        }
        private void PutOutData()
        {
            using (var fs = new FileStream("books.xml", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                _books= (List<Book>)jsonFormatter.ReadObject(fs);
            }
        }

        private void RefreshListBox()
        {
            allBooksListBox.ItemsSource = null;
            allBooksListBox.ItemsSource = _books;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        private void addNewButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddingPage.xaml", UriKind.Relative));
        }

        private void addMarkButton_Click(object sender, RoutedEventArgs e)
        {
            if (allBooksListBox.SelectedIndex != -1)
            {
                List<Book> _bookmarkers=new List<Book>();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                using (var fs = new FileStream("bookmarkers.xml", FileMode.OpenOrCreate))
                {
                    _bookmarkers = (List<Book>)jsonFormatter.ReadObject(fs);
                }
                _bookmarkers.Add((Book)allBooksListBox.SelectedItem);
                _bookmarkers.Sort(delegate (Book _b1, Book _b2)
                { return _b1.Autor.CompareTo(_b2.Autor); });
                using (var fs = new FileStream("bookmarkers.xml", FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, _bookmarkers);
                }
            }
        }
    }
}
