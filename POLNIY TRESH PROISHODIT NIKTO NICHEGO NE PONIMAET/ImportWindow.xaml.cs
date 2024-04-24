using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace POLNIY_TRESH_PROISHODIT_NIKTO_NICHEGO_NE_PONIMAET
{
    /// <summary>
    /// Логика взаимодействия для ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        private TrashDBEntities bd = new TrashDBEntities();
        public ImportWindow()
        {
            InitializeComponent();
            DRG.ItemsSource = bd.Subjects.ToList();
        }
        public static T DeseralizeOdject<T>()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string json = File.ReadAllText(dialog.FileName);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }

        private void Imp_Click(object sender, RoutedEventArgs e)
        {
            List<colourModel> forImport = ImportWindow.DeseralizeOdject<List<colourModel>>();
            foreach (var item in forImport)
            {
                Subjects s = new Subjects();
                s.SubjectName = item.SubjectName;
                bd.Subjects.Add(s);
                bd.SaveChanges();
                DRG.ItemsSource = bd.Subjects.ToList();
            }
            DRG.ItemsSource = null;
            DRG.ItemsSource = bd.Subjects.ToList();
        }
    }
}
