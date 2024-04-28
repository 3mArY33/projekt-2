using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("window2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                this.NavigationService.Navigate(new Uri("GameWindow.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Brak zapisu");
                this.NavigationService.Navigate(new Uri("window2.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("data.txt"))
            {
                this.NavigationService.Navigate(new Uri("GameWindow.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Brak zapisu");
                this.NavigationService.Navigate(new Uri("window2.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wersja Gry: Beta v.0.6" + Environment.NewLine + "Data Powstania Wersji: 20.04.2023" + Environment.NewLine + "Autorzy: Maciej Broza, Marta Rymarczuk, Piotr Bińkowski.");
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }       
    }
}
