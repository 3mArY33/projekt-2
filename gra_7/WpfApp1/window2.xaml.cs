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
using System.Windows.Shapes;
using System.IO;
using System.Runtime.InteropServices;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy window2.xaml
    /// </summary>
    public partial class window2 : Page
    {
        public window2()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            string i;
            int a, ad;
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem;
            
            i = Convert.ToString(charName.Text);
            wzr = Convert.ToDouble(charHeight.Text);
            cnter = Convert.ToDouble(charBodyType.Text);

            if (wzr <= 175 && wzr >= 135 && cnter >= 1 && cnter <= 20)
            {

                //Przeliczenie podanych zmiennych na stastyki WSTĘPNE//
                s = wzr / 4.95;
                run = s * 10;
                bmi = 14 + cnter;
                m = bmi * (wzr / 100 * wzr / 100);
                vmax = run / m * 3.6;
                res = m / 100 * s;
                maxhp = wzr / 5 * m / 2.5;
                skeletm = 1.2 * ((wzr / 100) * (wzr / 100));
                skinm = m * 0.08;
                musclem = (s / 10) * 9;
                fat = m - skeletm - skinm - musclem;
                bfat = (fat / m) * 100;
                a = 12;
                ad = 0;


                //Zapis utworzonych statystyk do pliku data.txt//
                using (StreamWriter sr = new StreamWriter("data.txt"))
                {
                    sr.WriteLine(i);
                    sr.WriteLine(wzr);
                    sr.WriteLine(cnter);
                    sr.WriteLine(s);
                    sr.WriteLine(maxhp);
                    sr.WriteLine(res);
                    sr.WriteLine(run);
                    sr.WriteLine(vmax);
                    sr.WriteLine(bmi);
                    sr.WriteLine(m);
                    sr.WriteLine(skeletm);
                    sr.WriteLine(skinm);
                    sr.WriteLine(musclem);
                    sr.WriteLine(fat);
                    sr.WriteLine(bfat);
                    sr.WriteLine(a);
                    sr.WriteLine(ad);
                }
                
                //Przejście do okna gry, aby wyświetlić statystyki wciśnij w nim przycisk Statystyki//
                this.NavigationService.Navigate(new Uri("GameWindow.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("Wprowadzono nieprawidłowe dane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
