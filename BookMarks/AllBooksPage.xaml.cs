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
                XmlSerializer xml = new XmlSerializer(typeof(List<Book>));
                _books= (List<Book>)xml.Deserialize(fs);
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
                string _book = (string)allBooksListBox.SelectedItem;

            }
        }
    }
}
