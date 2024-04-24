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

    public partial class StudentGradePage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public StudentGradePage()
        {
            InitializeComponent();
            GraTab.ItemsSource = bd.Grades.ToList();
        }
        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Grades gr = new Grades();
            gr.StudentID = int.Parse(TextBX1.Text);
            gr.ScheduleID = int.Parse(TextBX2.Text);
            gr.Grade = Decimal.Parse(TextBX3.Text);
            bd.Grades.Add(gr);
            bd.SaveChanges();
            GraTab.ItemsSource = bd.Grades.ToList();
        }
        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (GraTab.SelectedItem != null)
            {
                bd.Groups.Remove(GraTab.SelectedItem as Groups);
                bd.SaveChanges();
                GraTab.ItemsSource = bd.Grades.ToList();
            }
        }
        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            var gr = GraTab.SelectedItem as Grades;
            gr.StudentID = int.Parse(TextBX1.Text);
            gr.ScheduleID = int.Parse(TextBX2.Text);
            gr.Grade = Decimal.Parse(TextBX3.Text);
            bd.SaveChanges();
            GraTab.ItemsSource = bd.Grades.ToList();
        }
       
    }
}
