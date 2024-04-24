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
    public partial class TeachersEnrPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public TeachersEnrPage()
        {
            InitializeComponent();
            EnrTab.ItemsSource = bd.Enrollments.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Enrollments en = new Enrollments();
            en.StudentID = int.Parse(TextBX1.Text);
            en.GroupID = int.Parse(TextBX2.Text);
            en.YearID = int.Parse(TextBX3.Text);
            bd.Enrollments.Add(en);
            bd.SaveChanges();
            EnrTab.ItemsSource = bd.Enrollments.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (EnrTab.SelectedItem != null)
            {
                bd.Enrollments.Remove(EnrTab.SelectedItem as Enrollments);
                bd.SaveChanges();
                EnrTab.ItemsSource = bd.Enrollments.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            var enr = EnrTab.SelectedItem as Enrollments;
            enr.StudentID = int.Parse(TextBX1.Text);
            enr.GroupID = int.Parse(TextBX2.Text);
            enr.YearID = int.Parse(TextBX3.Text);
            bd.SaveChanges();
            EnrTab.ItemsSource = bd.Enrollments.ToList();
        }
    }
}
