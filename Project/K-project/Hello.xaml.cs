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
    /// Interaction logic for Hello.xaml
    /// </summary>
    public partial class Hello : Window
    {
        double lx = 0, ly = 0, d = 0, b = 0;
        int len;
        public Hello(int l)
        {
            InitializeComponent();
            len = l;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(len);
            main.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (len == 1)
            {
                label.Content = "პროგრამა გამიზნულია თბური რეჟიმის \nანგარიშისათვის. გამოთვლა შესაძლებელია\n      განხორციელდეს ორ შემთხვევაში";
                button1.Content = "მოცემულია კონკრეტული\nხელსაწყოს ელექტრული\nპრინციპული სქემა";
                button2.Content = "ცნობილია სამონტაჟო\nფირფიტის გაბარიტული\nზომები";
            }
            else if (len == 2)
            {
                label.Content = "Программа предназначена для расчета\nтеплового режима прибора.\nРасчет можно осществить в друх случаях";
                button1.Content = "Имеется электрическая\nпринципиальная схема\nконкретного прибора";
                button2.Content = "Габаритные размеры\nпечатной платы (ПП) известны";
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            teplorej tep = new teplorej(lx, ly, d, b, len);
            tep.Show();
            Close();
        }
    }
}
