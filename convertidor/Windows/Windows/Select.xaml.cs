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
    /// Lógica de interacción para Select.xaml
    /// </summary>
    public partial class Select : Window
    {
        Consultas mconsulta;
        public Select()
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
            mconsulta.selecion(campoProveedor.Text);
            MessageBox.Show("Brayan la cago");
        }
    }
}
