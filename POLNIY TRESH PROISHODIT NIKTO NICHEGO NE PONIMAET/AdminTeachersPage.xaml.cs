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
    public partial class AdminTeachersPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public AdminTeachersPage()
        {
            InitializeComponent();
            TeacherTab.ItemsSource = bd.Teachers.ToList();
            CombBX1.ItemsSource = bd.Teachers.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Teachers t = new Teachers();
            t.FirstName = TextBX1.Text;
            t.LastName = TextBX2.Text;
            t.DateOfBirth = DateTime.Parse(TextBX3.Text);
            t.Gender = (CombBX1.SelectedItem as Teachers).Gender;
            t.Address = TextBX4.Text;
            t.Phone = TextBX5.Text;
            t.Email = TextBX6.Text;
            t.HireDate = DateTime.Parse(TextBX3.Text);
            t.Position = TextBX8.Text;
            t.Salary = decimal.Parse(TextBX9.Text);
            t.Username = TextBX10.Text;
            t.Password = TextBX11.Text;
            t.UserID = int.Parse(TextBX12.Text);

            bd.Teachers.Add(t);
            bd.SaveChanges();
            TeacherTab.ItemsSource = bd.Teachers.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if(TeacherTab.SelectedItem != null)
            {
                bd.Teachers.Remove(TeacherTab.SelectedItem as Teachers);
                bd.SaveChanges();
                TeacherTab.ItemsSource = bd.Teachers.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            if (TeacherTab.SelectedItem != null)
            {
                var selected = TeacherTab.SelectedItem as Teachers;
                selected.FirstName = TextBX1.Text;
                selected.LastName = TextBX2.Text;
                selected.DateOfBirth = DateTime.Parse(TextBX3.Text);
                selected.Address = TextBX4.Text;
                selected.Phone = TextBX5.Text;
                selected.Email = TextBX6.Text;
                selected.DateOfBirth = DateTime.Parse(TextBX3.Text);
                selected.Position = TextBX8.Text;
                selected.Salary = decimal.Parse(TextBX9.Text);
                selected.Username = TextBX10.Text;
                selected.Password = TextBX11.Text;
                selected.UserID = int.Parse(TextBX12.Text);
                bd.SaveChanges();
                TeacherTab.ItemsSource = bd.Teachers.ToList();
            }
        }
    }
}
