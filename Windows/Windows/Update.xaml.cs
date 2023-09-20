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
    /// Lógica de interacción para Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        Consultas mconsulta;
        public Update()
        {
            InitializeComponent();
            mconsulta = new Consultas();
        }

        private void btnUpdates_Click(object sender, RoutedEventArgs e)
        {
            int datoPrecio = int.Parse(campoPrecio.Text);
            int datoStock = int.Parse(campoStock.Text);
            int datoIdInventario = int.Parse(campoIdInvent.Text);
            mconsulta.updates(datoIdInventario, datoPrecio, datoStock, campoProveedor.Text);
            MessageBox.Show("Los datos se han actualizado correctamente");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
