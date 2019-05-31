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
    /// Interaction logic for Hello0.xaml
    /// </summary>
    public partial class Hello0 : Window
    {
        int len;
        public Hello0()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            len = 1;
            Hello hello = new Hello(len);
            hello.Show();
            Close();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            len = 2;
            Hello hello = new Hello(len);
            hello.Show();
            Close();
        }

    }
}
