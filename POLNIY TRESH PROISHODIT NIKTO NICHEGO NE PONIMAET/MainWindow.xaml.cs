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
    
    public partial class MainWindow : Window
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Aut_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTBX.Text;
            string password = PasswordTBX.Password;
            var user = bd.UserAccounts.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                switch (user.UserType)
                {
                    case "Админ":
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        Close();
                        return;
                    case "Преподаватель":
                        TeacherWindow teacherWindow = new TeacherWindow();
                        teacherWindow.Show();
                        Close();
                        return;
                    case "Студент":
                        StudentWindow studentWindow = new StudentWindow();
                        studentWindow.Show();
                        Close();
                        return;
                    default:
                        MessageBox.Show("Неизвестный тип пользователя.");
                        break;
                }
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль. Попробуйте снова.");
            }
        }

    }
}