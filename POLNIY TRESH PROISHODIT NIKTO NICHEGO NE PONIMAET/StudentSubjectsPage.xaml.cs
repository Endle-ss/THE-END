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
    /// <summary>
    /// Логика взаимодействия для StudentSubjectsPage.xaml
    /// </summary>
    public partial class StudentSubjectsPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public StudentSubjectsPage()
        {
            InitializeComponent();
            SubTab.ItemsSource = bd.Subjects.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            Subjects s = new Subjects();
            s.SubjectName = TextBX1.Text;
            bd.Subjects.Add(s);
            bd.SaveChanges();
            SubTab.ItemsSource = bd.Subjects.ToList();
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (SubTab.SelectedItem != null)
            {
                bd.Subjects.Remove(SubTab.SelectedItem as Subjects);
                bd.SaveChanges();
                SubTab.ItemsSource = bd.Subjects.ToList();
            }
        }

        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            var s = SubTab.SelectedItem as Subjects;
            s.SubjectName = TextBX1.Text;
            bd.SaveChanges();
            SubTab.ItemsSource = bd.Subjects.ToList();
        }
    }
}
