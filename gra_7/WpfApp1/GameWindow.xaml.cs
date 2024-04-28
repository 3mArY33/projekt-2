using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
    /// Logika interakcji dla klasy GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Page
    {
        public GameWindow() //Okno główne gry + wyświetlanie daty
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            double d, ms, rok;

            //Odczyt daty z pliku
            d = Convert.ToDouble(File.ReadLines("kalendarz.txt").First());
            ms = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(1).Take(1).First());
            rok = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(2).Take(1).First());

            //Odczyt booli z pliku
            eats = Convert.ToDouble(File.ReadLines("bools.txt").First());
            runs = Convert.ToDouble(File.ReadLines("bools.txt").Skip(1).Take(1).First());
            holds = Convert.ToDouble(File.ReadLines("bools.txt").Skip(2).Take(1).First());

            //Wyświetlanie daty
            if ((d < 10) && (ms < 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();

                string dateString = "0" + strd + "/0" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
            if ((d < 10) && (ms >= 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();

                string dateString = "0" + strd + "/" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
            if ((d >= 10) && (ms < 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();

                string dateString = strd + "/0" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
            if ((d >= 10) && (ms >= 10))
            {
                string strd = d.ToString();
                string strms = ms.ToString();
                string strrok = rok.ToString();

                string dateString = strd + "/" + strms + "/" + strrok;
                calendar.Text = dateString;
            }
        }

        //Zmienne sprawdzające czy danego dnia postać jadła i trenowała
        public double eats = 0, holds = 0, runs = 0;


        private void comp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("PrecompWindow.xaml", UriKind.RelativeOrAbsolute));
        }

        private void stat_Click(object sender, RoutedEventArgs e) //Funkcja pokazująca statystyki
        {
            this.NavigationService.Navigate(new Uri("window3.xaml", UriKind.RelativeOrAbsolute));
        }

        public void hold_Click(object sender, RoutedEventArgs e) //Funkcja treningu siłowego
        {
            string i;
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem, a, ad;

            //Odczyt statów
            i = File.ReadLines("data.txt").First();
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

            if (holds == 1)
            {
                MessageBox.Show("Już ćwiczyłeś, jesteś zbyt zmęczony na 2 trening, wróć jutro!");
            }
            if (fat <= m * 0.05)
            {
                MessageBox.Show("Spaliłeś prawie cały tłuszcz! Chcesz się wykończyć!?");
            }
            else
            {
                if(holds == 0 && runs == 0)
                {
                    MessageBox.Show("Wykonałeś trening siłowy!");
                }

                double dm1, dm2;

                Random random = new Random();
                dm1 = random.Next(52);

                dm2 = 0.115 + (dm1 / 1000);

                fat = fat - dm2;

                //Regułka korygująca staty
                m = fat + musclem + skinm + skeletm;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                holds = 1;

                //Zapis statów
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
            }
        }

        public void run_Click(object sender, RoutedEventArgs e) //Funkcja treningu biegowego
        {
            string i;
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem, a, ad;

            //Odczyt statów
            i = File.ReadLines("data.txt").First();
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

            if (runs == 1 && holds == 0)
            {
                MessageBox.Show("Już dziś biegałeś, jesteś zbyt zmęczony na 2 trening, wróć jutro!");
            }
            if (holds == 1 && runs == 0)
            {
                MessageBox.Show("Już ćwiczyłeś na siłce jesteś zbyt zmęczony na bieganie, wróć jutro!");
            }
            if (fat <= m * 0.03)
            {
                MessageBox.Show("Spaliłeś prawie cały tłuszcz! Chcesz się wykończyć!?");
            }

            else
            {
                if(runs == 0 && holds == 0)
                {
                    MessageBox.Show("Wykonałeś trening biegowy!");
                }

                double dm1, dm2;

                Random random = new Random();
                dm1 = random.Next(34);

                dm2 = 0.078 + (dm1 / 1000);

                fat = fat + 0.1;

                //Regułka korygująca staty
                m = fat + musclem + skinm + skeletm;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                runs = 1;

                //Zapis statów
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
            }
        }

        public void eat_Click(object sender, RoutedEventArgs e) //Funkcja jedzenia
        {
            string i;
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem, a, ad;

            if (eats == 1)
            {
                MessageBox.Show("Już się najadłeś!");
            }
            else
            {
                //Odczyt statów
                MessageBox.Show("Smacznego!");
                i = File.ReadLines("data.txt").First();
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

                fat = fat + 0.1;

                //Regułka korygująca staty
                m = fat + musclem + skinm + skeletm;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                eats = 1;

                //Zapis statów
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
            }
        }

        public void nextday_Click(object sender, RoutedEventArgs e) //Funkcja kończy dzień i odświeża okno w celu aktualizacji danych//
        {
            MessageBox.Show("Dzień został zakończony.");

            double d, ms, rok;

            string i;
            double wzr, cnter, maxhp, res, s, run, vmax, bmi, m, fat, bfat, skeletm, skinm, musclem, a, ad;

            double dw, dw1, dw2, dw3, dm3, dm4, dm5, dm6, dm7, dm8, dm9, dm10, ds1, ds2, ds3, ds4, ds, dp1, dp2;

            //Odczyt daty
            d = Convert.ToDouble(File.ReadLines("kalendarz.txt").First());
            ms = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(1).Take(1).First());
            rok = Convert.ToDouble(File.ReadLines("kalendarz.txt").Skip(2).Take(1).First());

            //Odczyt statów
            i = File.ReadLines("data.txt").First();
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

            dw = Convert.ToDouble(File.ReadLines("deltas.txt").First());

            Random random = new Random();
            dw1 = random.Next(32);

            dw2 = 0.0163 + (dw1 / 10000);

            if (a == 12)
            {
                dw3 = dw2 * 1;
                dw = dw + dw3;
            }
            if (a == 13)
            {
                dw3 = dw2 * 1;
                dw = dw + dw3;
            }
            if (a == 14)
            {
                dw3 = dw2 - 0.0054;
                dw = dw + dw3;
            }
            if (a == 15)
            {
                dw3 = dw2 - 0.0061;
                dw = dw + dw3;
            }
            if (a == 16)
            {
                dw3 = dw2 - 0.0127;
                dw = dw + dw3;
            }
            if (a == 17)
            {
                dw3 = dw2 - 0.0141;
                dw = dw + dw3;
            }
            if (a >= 18)
            {
                dw3 = dw2 - dw2;
                dw = dw + dw3;
            }

            if (dw >= 1)
            {
                dw = dw - 1;
                wzr++;
            }

            if (a <= 18)
            {
                Random random2 = new Random();
                dm7 = random2.Next(8);

                dm8 = 0.0017 + (dm7 / 10000);

                skeletm = skeletm + dm8;

                //Regułka korygująca staty
                m = skeletm + skinm + fat + musclem;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                Random random3 = new Random();
                dm9 = random3.Next(11);

                dm10 = 0.00009 + (dm9 / 10000);

                skinm = skinm + dm10;

                //Regułka korygująca staty
                m = skeletm + skinm + fat + musclem;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                Random random4 = new Random();
                dm3 = random4.Next(72);

                dm4 = 0.0058 + (dm3 / 10000);

                fat = fat + dm4;

                //Regułka korygująca staty
                m = fat + musclem + skeletm + skinm;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;
            }
            else
            {
                Random random5 = new Random();
                dm7 = random5.Next(2);

                dm8 = dm7 - dm7;

                skeletm = skeletm + dm8;

                //Regułka korygująca staty
                m = skeletm + skinm + fat + musclem;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                Random random6 = new Random();
                dm9 = random6.Next(2);

                dm10 = dm9 - dm9;

                skinm = skinm + dm10;

                //Regułka korygująca staty
                m = skeletm + skinm + fat + musclem;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;

                Random random7 = new Random();
                dm3 = random7.Next(94);

                dm4 = 0.0073 + (dm3 / 10000);

                fat = fat + dm4;

                //Regułka korygująca staty
                m = fat + musclem + skeletm + skinm;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;
            }
            Random random8 = new Random();
            ds1 = random8.Next(30);

            ds2 = 0.0137 + (ds1 / 10000);

            if ((a == 12) || (a == 13) || (a == 14) || (a == 15))
            {
                ds = ds2 * 1;
                s = s + ds;
                musclem = musclem + ((ds / 10) * 9);
            }
            if (a == 16)
            {
                ds = ds2 - 0.0054;
                s = s + ds;
                musclem = musclem + ((ds / 10) * 9);
            }
            if (a == 17)
            {
                ds = ds2 - 0.0078;
                s = s + ds;
                musclem = musclem + ((ds / 10) * 9);
            }
            if (a == 18)
            {
                ds = ds2 - 0.0102;
                s = s + ds;
                musclem = musclem + ((ds / 10) * 9);
            }
            if (a == 19)
            {
                ds = ds2 - 0.0126;
                s = s + ds;
                musclem = musclem + ((ds / 10) * 9);
            }
            if (a >= 20)
            {
                ds = ds2 - ds2;
                s = s + ds;
                musclem = musclem + ((ds / 10) * 9);
            }

            //Regułka korygująca staty
            m = musclem + fat + skeletm + skinm;
            bfat = (fat / m) * 100;
            bmi = m / ((wzr / 100) * (wzr / 100));
            res = (m / 100) * s;
            maxhp = (wzr / 5) * (m / 2.5);
            vmax = (run / m) * 3.6;

            //Dodanie statów z biegania
            if (runs == 1)
            {
                if (run < 340)
                {
                    Random random9 = new Random();
                    dp1 = random9.Next(79);

                    dp2 = 0.426 + (dp1 / 1000);
                    run = run + dp2;
                }
                if ((run >= 340) || (run <= 350))
                {
                    Random random10 = new Random();
                    dp1 = random10.Next(74);

                    dp2 = 0.388 + (dp1 / 1000);
                    run = run + dp2;
                }
                if ((run >= 350) || (run <= 360))
                {
                    Random random11 = new Random();
                    dp1 = random11.Next(68);

                    dp2 = 0.324 + (dp1 / 1000);
                    run = run + dp2;
                }
                if ((run >= 360) || (run <= 370))
                {
                    Random random12 = new Random();
                    dp1 = random12.Next(61);

                    dp2 = 0.292 + (dp1 / 1000);
                    run = run + dp2;
                }
                if ((run >= 370) || (run <= 380))
                {
                    Random random13 = new Random();
                    dp1 = random13.Next(55);

                    dp2 = 0.263 + (dp1 / 1000);
                    run = run + dp2;
                }
                if ((run >= 380) || (run <= 390))
                {
                    Random random14 = new Random();
                    dp1 = random14.Next(49);

                    dp2 = 0.237 + (dp1 / 1000);
                    run = run + dp2;
                }
                if ((run >= 390) || (run <= 400))
                {
                    Random random15 = new Random();
                    dp1 = random15.Next(45);

                    dp2 = 0.214 + (dp1 / 1000);
                    run = run + dp2;
                }
                if (run > 400)
                {
                    Random random16 = new Random();
                    dp1 = random16.Next(40);

                    dp2 = 0.193 + (dp1 / 1000);
                    run = run + dp2;
                }

                vmax = (run / m) * 3.6;

            }

            //Dodanie statów z siłowni
            if (holds == 1)
            {
                Random random17 = new Random();
                ds3 = random17.Next(47);

                ds4 = 0.0187 + (ds1 / 10000);

                s = s + ds4;

                //Regułka korygująca staty
                m = musclem + fat + skeletm + skinm;
                bfat = (fat / m) * 100;
                bmi = m / ((wzr / 100) * (wzr / 100));
                res = (m / 100) * s;
                maxhp = (wzr / 5) * (m / 2.5);
                vmax = (run / m) * 3.6;
            }

            //Dodanie dnia dacie oraz postaci
            d++;
            ad++;

            //System wymieniający miesiące oraz lata
            if (((ms == 1) || (ms == 3) || (ms == 5) || (ms == 7) || (ms == 8) || (ms == 10) || (ms == 12)) && (d > 31))
            {
                d = d - 31;
                ms++;
            }
            if (((ms == 4) || (ms == 6) || (ms == 9) || (ms == 11)) && (d > 30))
            {
                d = d - 30;
                ms++;
            }
            if ((ms == 2) && (d > 28))
            {
                d = d - 28;
                ms++;
            }
            if (ms > 12)
            {
                ms = 1;
                d = 1;
                rok++;
            }
            if (ad == 365)
            {
                ad = ad - 365;
                a++;
            }

            //Zapis daty
            using (StreamWriter sr = new StreamWriter("kalendarz.txt"))
            {
                sr.WriteLine(d);
                sr.WriteLine(ms);
                sr.WriteLine(rok);
            }

            //Zapis statów
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

            using (StreamWriter sr = new StreamWriter("deltas.txt"))
            {
                sr.WriteLine(dw);
            }

            //Zerowanie booli dziennych
            eats = 0;
            runs = 0;
            holds = 0;

            using (StreamWriter sr = new StreamWriter("bools.txt"))
            {
                sr.WriteLine(eats);
                sr.WriteLine(runs);
                sr.WriteLine(holds);
            }

            //Odświeżenie okna w celu aktualizacji danych
            init();
        }

        private void back_Click(object sender, RoutedEventArgs e) //Funkcja cofająca do menu głównego
        {
            //Zapis booli do pliku ratujący przed bugiem gry
            using (StreamWriter sr = new StreamWriter("bools.txt"))
            {
                sr.WriteLine(eats);
                sr.WriteLine(runs);
                sr.WriteLine(holds);
            }
            this.NavigationService.GoBack(); 
        }
    }
}
