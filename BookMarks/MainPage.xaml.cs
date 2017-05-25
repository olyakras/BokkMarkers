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

namespace BookMarks
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SearchPage.xaml", UriKind.Relative));
        }

        private void showAllButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AllBooksPage.xaml", UriKind.Relative));
        }

        private void showMarksButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MarkersPage.xaml", UriKind.Relative));
        }

    }
}
