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
    public partial class TeachersCourPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public TeachersCourPage()
        {
            InitializeComponent();
            CourTab.ItemsSource = bd.OnlineCourses.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            OnlineCourses o = new OnlineCourses();
            o.CourseName = TextBX1.Text;
            o.Price = decimal.Parse(TextBX2.Text);
            o.SubjectID = int.Parse(TextBX3.Text);
            bd.OnlineCourses.Add(o);
            bd.SaveChanges();
            CourTab.ItemsSource = bd.OnlineCourses.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (CourTab.SelectedItem != null)
            {
                bd.OnlineCourses.Remove(CourTab.SelectedItem as OnlineCourses);
                bd.SaveChanges();
                CourTab.ItemsSource = bd.OnlineCourses.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            var o = CourTab.SelectedItem as OnlineCourses;
            o.CourseName = TextBX1.Text;
            o.Price = decimal.Parse(TextBX2.Text);
            o.SubjectID = int.Parse(TextBX3.Text);
            bd.SaveChanges();
            CourTab.ItemsSource = bd.OnlineCourses.ToList();
        }
    }
}
