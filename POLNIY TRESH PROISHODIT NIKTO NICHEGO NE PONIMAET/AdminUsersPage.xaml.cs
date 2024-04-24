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
    public partial class AdminUsersPage : Page
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public AdminUsersPage()
        {
            InitializeComponent();
            UsTab.ItemsSource = bd.UserAccounts.ToList();
            CombBX.ItemsSource = bd.UserAccounts.ToList();
        }

        private void InsertBT_Click(object sender, RoutedEventArgs e)
        {
            UserAccounts u = new UserAccounts();
            u.Username = TextBX1.Text;
            u.Password = TextBX2.Text;
            u.UserType = (CombBX.SelectedItem as UserAccounts).UserType;
            bd.UserAccounts.Add(u);
            bd.SaveChanges();
            UsTab.ItemsSource = bd.UserAccounts.ToList();
        }
        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            if (UsTab.SelectedItem != null)
            {
                bd.UserAccounts.Remove(UsTab.SelectedItem as UserAccounts);
                bd.SaveChanges();
                UsTab.ItemsSource = bd.UserAccounts.ToList();
            }
        }
        private void UpdateBT_Click(object sender, RoutedEventArgs e)
        {
            if (UsTab.SelectedItem != null)
            {
                var u = UsTab.SelectedItem as UserAccounts;
                u.Username = TextBX1.Text;
                u.Password = TextBX2.Text;
                u.UserType = (CombBX.SelectedItem as UserAccounts).UserType;
                bd.SaveChanges();
                UsTab.ItemsSource = bd.UserAccounts.ToList();
            }
        }
    }
}
