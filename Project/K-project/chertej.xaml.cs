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
    /// Логика взаимодействия для chertej.xaml
    /// </summary>
    public partial class chertej : Window
    {
        double ly, lx, lmx, lmy,x,y1,y2;
            
            /*
        public chertej(double tly,double tlx, double tlmx,double tlmy)
        {
            InitializeComponent();
            ly = tly;
            lx = tlx;
            lmx = tlmx;
            lmy = tlmy;
        }
        */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lx = 0.0455;
            ly = 0.033;
            lmx = 0.0195;
            lmy = 0.0145;
            x = 0.01 * 1000;
            y1 = 0.025 * 1000;
            pp.Width = lx * 10000;
            pp.Height = ly * 10000;
            ms.Width = lmx * 10000;
            ms.Height = lmy * 10000;
            ms.Margin= new Thickness(50+x, 50+y1, 0, 0);
            
        }


    }
}
