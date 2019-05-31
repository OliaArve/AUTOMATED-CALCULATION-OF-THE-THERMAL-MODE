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

namespace K_project
{
    /// <summary>
    /// Логика взаимодействия для teplorej.xaml
    /// </summary>
    public partial class teplorej : Window
    {
        double lx=0, ly=0, lz=0, Lx=0, Ly=0, Lz=0, d=0, b=0, T=0, t1=0, t2=0, t3=0, s1=0, s2=0, s3=0, s4=0, sp=0, srp=0;
        int N, i=1, len;
        double C, A;
        double[] pp = new double[100];
        double[] kp = new double[100];
        double[] st = new double[100];
        
        
    public teplorej(double llx, double lly, double ld, double lb, int l)
    {
        InitializeComponent();
        lx = llx;
        ly = lly;
        d = ld;
        b = lb;
        len = l;
    }
    

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tlx.Text = Convert.ToString(lx);
            tly.Text = Convert.ToString(ly);
            tLx.Text = Convert.ToString(Lx);
            tLy.Text = Convert.ToString(Ly);
            tLz.Text = Convert.ToString(Lz);
            td.Text = Convert.ToString(d);
            ttb.Text = Convert.ToString(b);
            panP.Visibility = Visibility.Hidden;
            all.Visibility = Visibility.Hidden;
            rasch.Visibility = Visibility.Hidden;
            panlast2.Visibility = Visibility.Hidden;

            if (len == 1) //GEO
            {

            }
            else if(len==2)//RU
            {
                restart.Content = "Перезагрузка";
                exit.Content = "Выход";
                ld.Content = "d, м";
                lb.Content = "b, м";
                gabpp.Content = "Габаритные размеры\n Печатной платы, м";
                gabk.Content = "Габаритные размеры\n           корпуса, м";
                vd.Content = "Введите толщину ПП с \nустановленными элементами";
                vb.Content = "Введите расстояние \nмежду ПП";
                temp.Content = "Введите температуру\nокружающей среды";
                kolp.Content = "Введите кол-во ПП";
                rasm.Content = "Введите рессеиваемую\nмощность для ПП №\nP, Вт";
                rasch.Content = "Расчитать";
                ts5.Content = "Внутреняя площадь нагретой зоны\nв которой движется воздух";
                ts6.Content = "Внешняя площадь нагретой зоны";
                ts7.Content = "Площадь излучающей \nповерхности нагретой зоны";
                ts8.Content = "Площадь корпуса";
                tt4.Content = "Средняя температура корпуса";
                tt5.Content = "Средняя температура\nнагретой зоны";
                tt6.Content = "Средняя температура воздуха";
                koef.Content = "Коэф. неравномерного\nраспределения мощности";
                stem.Content = "Средняя\nтемпература ПП\nt,";
                m1.Content = "M";
                m2.Content = "M";
                m3.Content = "M";
                m4.Content = "M";
                Title = "Расчет теплового режима прибора";

            }
        }

        private void ok1_Click(object sender, RoutedEventArgs e)
        {
            N = Convert.ToInt16(tN.Text);
            T = Convert.ToInt16(tT.Text);
            b = Convert.ToDouble(ttb.Text);
            d = Convert.ToDouble(td.Text);
            lx = Convert.ToDouble(tlx.Text);
            ly = Convert.ToDouble(tly.Text);
            Lx = Convert.ToDouble(tLx.Text);
            Ly = Convert.ToDouble(tLy.Text);
            Lz = Convert.ToDouble(tLz.Text);
            panP.Visibility = Visibility.Visible;
            panlast2.Visibility = Visibility.Visible;

            Lx = lx + d * 2;
            Ly = ly + d * 2;
            Lz = N * d + (N - 1) * b + 3 * b;

            tLx.Text = Convert.ToString(Lx);
            tLy.Text = Convert.ToString(Ly);
            tLz.Text = Convert.ToString(Lz);

        }

        private void okp_Click(object sender, RoutedEventArgs e)
        {
            numU.Content = Convert.ToString(i + 1);
            sp += Convert.ToDouble(tp.Text);
            pp[i-1]=Convert.ToDouble(tp.Text);
            lP.Items.Add(tp.Text);
            tp.Text = "";
            i++;
            if (i == N + 1)
            {
                numU.Content = Convert.ToString(i - 1);
                tp.Visibility = Visibility.Hidden;
                okp.Visibility = Visibility.Hidden;
                rasch.Visibility = Visibility.Visible;
            }
        }

        private void bras_Click(object sender, RoutedEventArgs e)
        {
            all.Visibility = Visibility.Visible;
            if (d>=0.005)
            {
                C = 1.36;
                A = 1.085;
            }
            else
            {
                C = 1.37;
                A = 1.043;
            }

            s1 = (2 * (N - 1) * lx * ly);
            s2 = (2 * lx * ly + 2 * N * d * (lx + ly));
            lz = (N * d + (N - 1) * b);
            s3 = (2 * (lx * ly + lx * lz + lz * ly));
            s4 = (2 * (Lx * Ly + Lx * Lz + Ly * Lz));
            t1 = T + (sp / (9 * s4));
            t2 = T + (t1 - T) * (1 + C * A);
            t3 = T + (t1 - T) * (1 + C);
            srp = sp / N;

            for(int j=0; j<N; j++)
            {
                kp[j] = pp[j] / srp;
                st[j] = T + (t2 - T) * (0.88 + 0.12 * kp[j]);
                lK.Items.Add(Math.Round(kp[j], 3));
                lst.Items.Add(Math.Round(st[j], 3));
            }

            ts1.Text = Convert.ToString(Math.Round(s1, 3));
            ts2.Text = Convert.ToString(Math.Round(s2, 3));
            ts3.Text = Convert.ToString(Math.Round(s3, 3));
            ts4.Text = Convert.ToString(Math.Round(s4, 3));
            tt1.Text = Convert.ToString(Math.Round(t1, 3));
            tt2.Text = Convert.ToString(Math.Round(t2, 3));
            tt3.Text = Convert.ToString(Math.Round(t3, 3));

            for(int i=1; i<=N; i++)
            {
                num1.Items.Add(i);
                num2.Items.Add(i);
               
            }
            bool w = false;
            for (int i = 1; i < N-1; i++)
            {
                if (st[i] >= 85)
                {
                    w = true;
                }
            }
            if (w == false && len==2)
            {
                MessageBoxResult result = MessageBox.Show(this, "Тепловой режим обеспечен", "Отчёт", MessageBoxButton.OK, MessageBoxImage.Information);
                inf.Content = "Тепловой режим обеспечен";
            }
            else if (w == true && len == 2)
            {
                MessageBoxResult result = MessageBox.Show(this, "Теловой режим нарушен", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                inf.Content = "Теловой режим нарушен";
            }

            else if (w == false && len == 1)
            {
                MessageBoxResult result = MessageBox.Show(this, "თბური რეჟიმი უზრუნველყოფილია", "შედეგი", MessageBoxButton.OK, MessageBoxImage.Information);
                inf.Content = "თბური რეჟიმი უზრუნველყოფილია";
            }
            else if (w == true && len == 1)
            {
                MessageBoxResult result = MessageBox.Show(this, "თბური რეჟიმი დარღვეულია", "გაფრთხილება", MessageBoxButton.OK, MessageBoxImage.Warning);
                inf.Content = "თბური რეჟიმი დარღვეულია";
            }

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
