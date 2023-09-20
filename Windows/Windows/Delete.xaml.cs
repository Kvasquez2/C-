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
using System.Windows.Shapes;

namespace Windows
{
    /// <summary>
    /// Lógica de interacción para Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        Consultas mconsulta;
        public Delete()
        {
            InitializeComponent();
            mconsulta = new Consultas();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            int datoID = int.Parse(campoDelete.Text);
            mconsulta.Deletes(datoID);
            MessageBox.Show("Datos Eliminados");
        }
    }
}
