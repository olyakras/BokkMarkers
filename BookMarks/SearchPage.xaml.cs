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

namespace BookMarks
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(autorTextBox.Text) && string.IsNullOrWhiteSpace(titleBookTextBlock.Text))
            {
                MessageBox.Show("Необходимо ввести хотя бы имя автора или название книги");
                autorTextBox.Clear();
                titleBookTextBox.Clear();
                return;
            }
            StreamWriter sw = new StreamWriter("temporary.txt");
            if (string.IsNullOrWhiteSpace(autorTextBox.Text))
            {
                sw.WriteLine("0");
                sw.Write(titleBookTextBlock.Text);
                sw.Close();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(titleBookTextBlock.Text))
                {
                    sw.WriteLine("1");
                    sw.Write(autorTextBlock.Text);
                    sw.Close();
                }
                else
                {
                    sw.WriteLine("2");
                    sw.WriteLine(autorTextBlock.Text);
                    sw.WriteLine(titleBookTextBlock.Text);
                    sw.Close();
                }
            }
            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
