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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy window3.xaml
    /// </summary>
    public partial class window3 : Page
    {


        public window3()
        {            
            InitializeComponent();
            //cnter - grubość, s - sila, m-masa, res-opór
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem, a, ad;

            //Odczyt Statystyk Postaci z pliku//
            wzr = Convert.ToDouble(File.ReadLines("data.txt").Skip(1).Take(1).First());
            cnter = Convert.ToDouble(File.ReadLines("data.txt").Skip(2).Take(1).First());
            s = Convert.ToDouble(File.ReadLines("data.txt").Skip(3).Take(1).First());
            maxhp = Convert.ToDouble(File.ReadLines("data.txt").Skip(4).Take(1).First());
            res = Convert.ToDouble(File.ReadLines("data.txt").Skip(5).Take(1).First());
            run = Convert.ToDouble(File.ReadLines("data.txt").Skip(6).Take(1).First());
            vmax = Convert.ToDouble(File.ReadLines("data.txt").Skip(7).Take(1).First());
            bmi = Convert.ToDouble(File.ReadLines("data.txt").Skip(8).Take(1).First());
            m = Convert.ToDouble(File.ReadLines("data.txt").Skip(9).Take(1).First());                    
            skeletm = Convert.ToDouble(File.ReadLines("data.txt").Skip(10).Take(1).First());
            skinm = Convert.ToDouble(File.ReadLines("data.txt").Skip(11).Take(1).First());
            musclem = Convert.ToDouble(File.ReadLines("data.txt").Skip(12).Take(1).First());
            fat = Convert.ToDouble(File.ReadLines("data.txt").Skip(13).Take(1).First());
            bfat = Convert.ToDouble(File.ReadLines("data.txt").Skip(14).Take(1).First());
            a = Convert.ToDouble(File.ReadLines("data.txt").Skip(15).Take(1).First());
            ad = Convert.ToDouble(File.ReadLines("data.txt").Skip(16).Take(1).First());

            //Wyświetlenie statystyk w boxach//
            charHeight.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(1).Take(1).First()), 0).ToString();
            charStrength.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(3).Take(1).First()), 0).ToString();
            charHP.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(4).Take(1).First()), 0).ToString();
            charRes.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(5).Take(1).First()), 0).ToString();
            charRun.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(6).Take(1).First()), 3).ToString();
            charSpeed.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(7).Take(1).First()), 3).ToString();
            charBMI.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(8).Take(1).First()), 2).ToString();
            charMass.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(9).Take(1).First()), 3).ToString();
            charMuscles.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(12).Take(1).First()), 3).ToString();
            charFat.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(13).Take(1).First()), 3).ToString();
            charBFat.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(14).Take(1).First()), 2).ToString();
            charAge.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(15).Take(1).First()), 0).ToString();
            charAgeDays.Text = Math.Round(double.Parse(File.ReadLines("data.txt").Skip(16).Take(1).First()), 0).ToString();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void charName_Loaded(object sender, RoutedEventArgs e)
        {
            string line1 = File.ReadLines("data.txt").First();
            charName.Text = line1;
        }

    }
}
