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
    public partial class StudentGroupPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public StudentGroupPage()
        {
            InitializeComponent();
            GrpTab.ItemsSource = bd.Groups.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Groups g = new Groups();
            g.GroupName = TextBX1.Text;
            g.CourseNumber = int.Parse(TextBX2.Text);
            g.TeacherID = int.Parse(TextBX3.Text);
            bd.Groups.Add(g);
            bd.SaveChanges();
            GrpTab.ItemsSource = bd.Groups.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (GrpTab.SelectedItem != null)
            {
                bd.Groups.Remove(GrpTab.SelectedItem as Groups);
                bd.SaveChanges();
                GrpTab.ItemsSource = bd.Groups.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            var g = GrpTab.SelectedItem as Groups;
            g.GroupName = TextBX1.Text;
            g.CourseNumber = int.Parse(TextBX2.Text);
            g.TeacherID = int.Parse(TextBX3.Text);
            bd.SaveChanges();
            GrpTab.ItemsSource = bd.Enrollments.ToList();
        }
    }
}
