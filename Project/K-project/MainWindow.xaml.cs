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

namespace K_project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lmx = 0, lmy = 0, tx = 0, ty = 0, lx = 0, ly = 0, Y1 = 0, Y2 = 0, x1 = 0, x2, b = 0, d = 0;
        int i = 1, sr = 0, nx, ny, len;
        int n;
        int[] u = new int[100];

        public MainWindow(int l)
        {
            InitializeComponent();
            len = l;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (len == 1)
            {

            }
            else if (len == 2)
            {
                gabm.Content = "Габаритные размеры\n     микросхем (МС), м";
                kolm.Content = "Кол-во микросхем";
                koln.Content = "Введите кол-во\nзадействованых\nножек в МС\n№";
                shag.Content = "Шаг установки МС, м";
                kolms.Content = "Кол-во МС в ряду";
                ustp.Content = "Введите установочные\n    поля, м";
                bras.Content = "Расчитать";
                gabpp.Content = "Габаритные размеры\n Печатной платы, м";
                dalee.Content = "Далее";
                restart.Content = "Перезагрузка";
                exit.Content = "Выход";
                bp.Content = "	   Боковые поля";
                usp.Content = "Установочные поля для разъемов";
                Title = "Расчет габаритных размеров ПП";


            }
            
            panU.Visibility = Visibility.Hidden;
            panXY.Visibility = Visibility.Hidden;
            panNX.Visibility = Visibility.Hidden;
            panT.Visibility = Visibility.Hidden;
            panlast.Visibility = Visibility.Hidden;
            bras.Visibility = Visibility.Hidden;
            dalee.Visibility = Visibility.Hidden;
        }
        
        
            /*
            
                ttx.Text = Convert.ToString(tx);
                tty.Text = Convert.ToString(ty);
                tlx.Text = Convert.ToString(lx);
                tly.Text = Convert.ToString(ly);
                tLx.Text = Convert.ToString(Lx);
                tLy.Text = Convert.ToString(Ly);
                tLz.Text = Convert.ToString(Lz);
                tlmx.Text = Convert.ToString(lmx);
                tlmy.Text = Convert.ToString(lmy);
                tx1.Text = Convert.ToString(x);
                ty1.Text = Convert.ToString(Y1);
                ty2.Text = Convert.ToString(Y2);
                td.Text = Convert.ToString(d);
                tb.Text = Convert.ToString(b);
            */
        
        private void ok1_Click(object sender, RoutedEventArgs e)
        {
            panU.Visibility = Visibility.Visible;
            lmx = Convert.ToDouble(tlmx.Text);
            lmy = Convert.ToDouble(tlmy.Text);
            n = Convert.ToInt16(tn.Text);

            ny = Convert.ToInt16(Math.Sqrt(n));
            nx = n - ny;

            tnx.Text = Convert.ToString(nx);
            tny.Text = Convert.ToString(ny);

        }
        private void ok2_Click(object sender, RoutedEventArgs e)
        {
            numU.Content = Convert.ToString(i+1);
            sr += Convert.ToInt16(tu.Text);
            lU.Items.Add(tu.Text);
            tu.Text = "";
            i++;
            if (i == n+1 )
            {
                numU.Content = Convert.ToString(i-1);
                tu.Visibility = Visibility.Hidden;
                ok2.Visibility = Visibility.Hidden;

                sr/=n;
                if (sr % n != 0) { sr++; }

                //tipi
                if(lmx==0.0195 && lmy == 0.0145)
                {
                         if (sr <= 8)  { tx = 22.5; ty = 15; }
                    else if (sr <= 9)  { tx = 22.5; ty = 17.5; }
                    else if (sr <= 11) { tx = 25; ty = 17.5; }
                    else if (sr <= 12) { tx = 25; ty = 20; }
                    else if (sr <= 14) { tx = 27.5; ty = 22; }
                }
                else if (lmx == 0.0195 && lmy == 0.0220)
                {
                    if (sr <= 8) { tx = 22.5; ty = 25; }
                    else if (sr <= 10) { tx = 25; ty = 25; }
                    else if (sr <= 12) { tx = 27; ty = 25; }
                    else if (sr <= 14) { tx = 29; ty = 25; }
                }

                else if (lmx == 0.0195 && lmy == 0.0295)
                {
                    if (sr <= 8) { tx = 22.5; ty = 32.5; }
                    else if (sr <= 10) { tx = 25; ty = 35; }
                    else if (sr <= 12) { tx = 27.5; ty = 37; }
                    else if (sr <= 14) { tx = 29; ty = 39; }
                }
                else if (lmx == 0.037 && lmy == 0.0295)
                {
                         if (sr <= 13) { tx = 42.5; ty = 32.5; }
                    else if (sr <= 20) { tx = 47.5; ty = 32.5; }
                    else if (sr <= 22) { tx = 50; ty = 32.5; }
                    else if (sr <= 24) { tx = 52.5; ty = 32.5; }
                    else if (sr <= 26) { tx = 55; ty = 32.5; }
                    else if (sr <= 28) { tx = 57.5; ty = 32.5; }
                }
                else if (lmx == 0.0195 && lmy == 0.0075)
                {
                         if (sr <= 8) { tx = 22.5; ty = 12.525; }
                    else if (sr <= 11) { tx = 25; ty = 15; }
                    else if (sr <= 14) { tx = 27.5; ty = 17.5; }
                }
                else if (lmx == 0.0322 && lmy == 0.0175)
                {
                         if (sr <= 18) { tx = 45.5; ty = 22.5; }
                    else if (sr <= 20) { tx = 47.5; ty = 22.5; }
                    else if (sr <= 22) { tx = 47.5; ty = 25.0; }
                    else if (sr <= 24) { tx = 50.0; ty = 25.0; }
                }
                else if (lmx == 0.03325 && lmy == 0.0205)
                {
                    if (sr <= 30) { tx = 50.0; ty = 40.0; }
                    else if (sr <= 38) { tx = 60.0; ty = 40.0; }
                    else if (sr <= 44) { tx = 67.0; ty = 47.5; }
                    else if (sr <= 48) { tx = 70.0; ty = 47.5; }
                }
                else if (lmx == 0.0095 && lmy == 0.0135)
                {
                         if (sr <= 10) { tx = 12.5; ty = 15.0; }
                    else if (sr <= 11) { tx = 12.5; ty = 17.5; }
                    else if (sr <= 12) { tx = 15.5; ty = 17.5; }
                    else if (sr <= 14) { tx = 15.0; ty = 20.0; }
                }
                else if (lmx == 0.01075 && lmy == 0.0135)
                {
                         if (sr <= 14) { tx = 12.5; ty = 20.0; }
                    else if (sr <= 16) { tx = 17.5; ty = 20.0; }
                }

                tx /= 1000;
                ty /= 1000;

                ttx.Text = Convert.ToString(tx);
                tty.Text = Convert.ToString(ty);
                panT.Visibility = Visibility.Visible;
                panXY.Visibility = Visibility.Visible;
                panNX.Visibility = Visibility.Visible;
                bras.Visibility = Visibility.Visible;
                
            }

        }

        private void bras_Click(object sender, RoutedEventArgs e)
        {
            x1 = Convert.ToDouble(tx1.Text);
            x2 = Convert.ToDouble(tx2.Text);
            Y1 = Convert.ToDouble(ty1.Text);
            Y2 = Convert.ToDouble(ty2.Text);
            tx = Convert.ToDouble(ttx.Text);
            ty = Convert.ToDouble(tty.Text);
            nx = Convert.ToInt16(tnx.Text);
            ny = Convert.ToInt16(tny.Text);



            lx = (nx - 1) * tx + ((x1 + x2) - lmx);
            ly = (ny - 1) * ty + ((Y1 + Y2) - lmy);
            

            tlx.Text = Convert.ToString(lx);
            tly.Text = Convert.ToString(ly);
           

            panlast.Visibility = Visibility.Visible;
            dalee.Visibility = Visibility.Visible;
        }
    
    
        private void teprej_Click(object sender, RoutedEventArgs e)
        {
            teplorej teplorej = new teplorej(lx, ly, d, b, len);
            teplorej.Show();
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }

    }