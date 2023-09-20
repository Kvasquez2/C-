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

namespace Windows
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Update windowsUpdate;
        Delete windowsDalete;
        Insert windowsInsert;
        Select windowsSelect;
       
        public MainWindow()
        {
            InitializeComponent();
            windowsDalete = new Delete();
            windowsInsert = new Insert();
            windowsSelect = new Select();
            windowsUpdate = new Update();
        }


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            windowsInsert.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            windowsDalete.ShowDialog();
        }

        private void btnUpdate_Click(object sender, object e)
        {
            windowsUpdate.ShowDialog();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            windowsSelect.ShowDialog();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
