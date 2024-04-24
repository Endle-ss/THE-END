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
using System.Xml.Linq;

namespace POLNIY_TRESH_PROISHODIT_NIKTO_NICHEGO_NE_PONIMAET
{
    public partial class AdminShedulePage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public AdminShedulePage()
        {
            InitializeComponent();
            SHEDTab.ItemsSource = bd.Schedule.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Schedule schedule = new Schedule();
            schedule.SubjectID = int.Parse(TextBX1.Text);
            schedule.GroupID = int.Parse(TextBX2.Text);
            schedule.TeacherID = int.Parse(TextBX3.Text);
            schedule.DayOfWeek = TextBX4.Text;
            schedule.StartTime = TimeSpan.Parse(TextBX5.Text);
            schedule.EndTime = TimeSpan.Parse(TextBX6.Text);
            schedule.YearID = int.Parse(TextBX7.Text);
            bd.Schedule.Add(schedule);
            bd.SaveChanges();
            SHEDTab.ItemsSource = bd.Schedule.ToList();
        }
        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            if (SHEDTab.SelectedItem != null)
            {
                var schedule = SHEDTab.SelectedItem as Schedule;
                schedule.SubjectID = int.Parse(TextBX1.Text);
                schedule.GroupID = int.Parse(TextBX2.Text);
                schedule.TeacherID = int.Parse(TextBX3.Text);
                schedule.DayOfWeek = TextBX4.Text;
                schedule.StartTime = TimeSpan.Parse(TextBX5.Text);
                schedule.EndTime = TimeSpan.Parse(TextBX6.Text);
                schedule.YearID = int.Parse(TextBX7.Text);
                bd.SaveChanges();
                SHEDTab.ItemsSource = bd.Schedule.ToList();
            }

        }
        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (SHEDTab.SelectedItem != null)
            {
                bd.Schedule.Remove(SHEDTab.SelectedItem as Schedule);
                bd.SaveChanges();
                SHEDTab.ItemsSource = bd.Schedule.ToList();
            }
        }
    }
}
