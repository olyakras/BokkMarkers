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

namespace BookMarks
{
    /// <summary>
    /// Логика взаимодействия для MarkersPage.xaml
    /// </summary>
    public partial class MarkersPage : Page
    {
        List<Book> _bookmarkers = new List<Book>();
        public MarkersPage()
        {
            InitializeComponent();
            PutOutData();
            RefreshListBox();
        }

        private void PutOutData()
        {
            using (var fs = new FileStream("bookmarkers.xml", FileMode.OpenOrCreate))
            {
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                _bookmarkers = (List<Book>)jsonFormatter.ReadObject(fs);
            }
        }

        private void RefreshListBox()
        {
            markBooksListBox.ItemsSource = null;
            markBooksListBox.ItemsSource = _bookmarkers;
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void addMarkButton_Click(object sender, RoutedEventArgs e)
        {
            if (markBooksListBox.SelectedIndex != -1)
            {
                List<Book> _bookmarkers = new List<Book>();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                using (var fs = new FileStream("bookmarkers.xml", FileMode.OpenOrCreate))
                {
                    _bookmarkers = (List<Book>)jsonFormatter.ReadObject(fs);
                }
                _bookmarkers.Add((Book)markBooksListBox.SelectedItem);
                _bookmarkers.Sort(delegate (Book _b1, Book _b2)
                { return _b1.Autor.CompareTo(_b2.Autor); });
                using (var fs = new FileStream("bookmarkers.xml", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, _bookmarkers);
                }
            }
        }

        private void deleteMarkButton_Click(object sender, RoutedEventArgs e)
        {
            if (markBooksListBox.SelectedIndex != -1)
            {
                List<Book> _bookmarkers = new List<Book>();
                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Book>));
                using (var fs = new FileStream("bookmarkers.xml", FileMode.OpenOrCreate))
                {
                    _bookmarkers = (List<Book>)jsonFormatter.ReadObject(fs);
                }
                _bookmarkers.Remove((Book)markBooksListBox.SelectedItem);
                using (var fs = new FileStream("bookmarkers.xml", FileMode.Create))
                {
                    jsonFormatter.WriteObject(fs, _bookmarkers);
                }
            }
        }
    }
}
