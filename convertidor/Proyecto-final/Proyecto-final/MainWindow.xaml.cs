using Conexiones;
using MySql.Data.MySqlClient;
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

namespace Proyecto_final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Validate validar;
        Consultas mconsultas;
        public MainWindow()
        {
            InitializeComponent();
            mconsultas = new Consultas();
            validar = new Validate();
            
        }

        //private void btnSelect_Click(object sender, RoutedEventArgs e)
        //{
        //    if(validar.Dato_essit(DataObject.text, mconsultas.valores()){
        //        tiene acceso
        //    }
        //    else
        //    {
        //        nombre tiene acceso
        //    }
        //}

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            mconsultas.insertars(campoNombre.Text, campoApellido.Text, campoFecha.Text);
            MessageBox.Show("Usuario Agregado");
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            mconsultas.updates(int.Parse(campoId.Text), campoNombre.Text, campoApellido.Text, campoFecha.Text)
        }
    }
}
