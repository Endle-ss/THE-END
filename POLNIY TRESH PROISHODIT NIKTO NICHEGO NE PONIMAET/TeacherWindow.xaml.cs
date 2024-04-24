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

namespace POLNIY_TRESH_PROISHODIT_NIKTO_NICHEGO_NE_PONIMAET
{
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new TeachersAcadPage();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new TeachersEnrPage();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new TeachersCourPage();
        }
    }
}
