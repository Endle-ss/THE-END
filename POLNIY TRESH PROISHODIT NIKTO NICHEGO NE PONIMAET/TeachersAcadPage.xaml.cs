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

namespace POLNIY_TRESH_PROISHODIT_NIKTO_NICHEGO_NE_PONIMAET
{
    public partial class TeachersAcadPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public TeachersAcadPage()
        {
            InitializeComponent();
            AcadTab.ItemsSource = bd.AcademicYears.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            AcademicYears a = new AcademicYears();
            a.YearStart = DateTime.Parse(TextBX1.Text);
            a.YearEnd = DateTime.Parse(TextBX2.Text);
            bd.AcademicYears.Add(a);
            bd.SaveChanges();
            AcadTab.ItemsSource = bd.AcademicYears.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (AcadTab.SelectedItem != null)
            {
                bd.AcademicYears.Remove(AcadTab.SelectedItem as AcademicYears);
                bd.SaveChanges();
                AcadTab.ItemsSource = bd.AcademicYears.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            var acad = AcadTab.SelectedItem as AcademicYears;
            acad.YearStart = DateTime.Parse(TextBX1.Text);
            acad.YearEnd = DateTime.Parse(TextBX2.Text);
            bd.SaveChanges();
            AcadTab.ItemsSource = bd.AcademicYears.ToList();
        }
    }
}
