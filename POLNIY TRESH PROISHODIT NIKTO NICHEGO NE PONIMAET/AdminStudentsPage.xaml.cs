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
    public partial class AdminStudentsPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public AdminStudentsPage()
        {
            InitializeComponent();
            STDTab.ItemsSource = bd.Students.ToList();
            CombBX.ItemsSource = bd.Students.ToList();
        }


        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Students s = new Students();
            s.FirstName = TextBX1.Text;
            s.LastName = TextBX2.Text;
            s.DateOfBirth = DateTime.Parse(TextBX3.Text);
            s.Gender = (CombBX.SelectedItem as Students).Gender;
            s.Address = TextBX4.Text;
            s.Phone = TextBX5.Text;
            s.Email = TextBX6.Text;
            s.AdmissionDate = DateTime.Parse(TextBX7.Text);
            s.GraduationDate = DateTime.Parse(TextBX8.Text);
            s.Username = TextBX9.Text;
            s.Password = TextBX10.Text;
            s.UserID = int.Parse(TextBX11.Text);

            bd.Students.Add(s);
            bd.SaveChanges();
            STDTab.ItemsSource = bd.Students.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (STDTab.SelectedItem != null)
            {
                bd.Students.Remove(STDTab.SelectedItem as Students);
                bd.SaveChanges();
                STDTab.ItemsSource = bd.Students.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            if (STDTab.SelectedItem != null)
            {
                var selected = STDTab.SelectedItem as Students;
                selected.FirstName = TextBX1.Text;
                selected.LastName = TextBX2.Text;
                selected.DateOfBirth = DateTime.Parse(TextBX3.Text);
                selected.Gender = (CombBX.SelectedItem as Students).Gender;
                selected.Address = TextBX4.Text;
                selected.Phone = TextBX5.Text;
                selected.Email = TextBX6.Text;
                selected.AdmissionDate = DateTime.Parse(TextBX7.Text);
                selected.GraduationDate = DateTime.Parse(TextBX8.Text);
                selected.Username = TextBX9.Text;
                selected.Password = TextBX10.Text;
                selected.UserID = int.Parse(TextBX11.Text);
                bd.SaveChanges();
                STDTab.ItemsSource = bd.Students.ToList();
            }
        }
    }
}
