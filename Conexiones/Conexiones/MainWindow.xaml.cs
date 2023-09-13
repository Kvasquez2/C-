using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Conexiones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private conexions mConexion;
        public MainWindow()
        {
            InitializeComponent();
            mConexion = new conexions();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           MySqlDataReader mySqlDataReader = null;
            string consulta = "select * from usuarios";
            if (mConexion.getConexion()  != null)
            {
                List<string> Nombre = new List<string>(); 

                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();

                mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    string resul = mySqlDataReader.GetString("Nombre");
                    Nombre.Add(resul);
                }
                mySqlDataReader.Close();
                if(Nombre.Count > 0)
                {
                    string concadenarNombre = string.Join(",", Nombre);
                    MessageBox.Show("Nombres : " + concadenarNombre);
                }
                else
                {
                    MessageBox.Show("No se encontraron los nombres en la base de datos");
                }
            }
            else
            {
                MessageBox.Show("Esteban es un error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MySqlDataReader mySqlDataReader = null;
            string consulta = "select * from facturas";
            if (mConexion.getConexion() != null)
            {
                List<string> Fecha = new List<string>();

                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mConexion.getConexion();

                mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    string resul = mySqlDataReader.GetString("Fecha");
                    Fecha.Add(resul);
                }
                mySqlDataReader.Close();
                if (Fecha.Count > 0)
                {
                    string concadenarFecha = string.Join(",", Fecha);
                    MessageBox.Show("Fecha : " + concadenarFecha);
                }
                else
                {
                    MessageBox.Show("No se encontraron los Fecha en la base de datos");
                }
            }
            else
            {
                MessageBox.Show("error al conectar a la bd");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            string Nombre = campoNombre.Text;
            string Apellido = campoApellido.Text;
            int edad = int.Parse(campoEdad.Text);

            MySqlConnection conexion = mConexion.getConexion();

            string consulta = "INSERT INTO usuarios (Nombre, Apellido, Edad) VALUE(@Nombre,@Apellido,@edad)";
            if (mConexion.getConexion() != null)
            {
                using(MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@edad", edad);

                    int filasAfectadas = command.ExecuteNonQuery();
                
                }
            }
            this.borrar("usuario agregado");
            
        }  
        private void borrar(string valor)
        {
            campoNombre.Text = "";
            campoApellido.Text = "";
            campoEdad.Text = "";
            MessageBox.Show(valor);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Nombre = campoNombre.Text;
            string Apellido = campoApellido.Text;
            int edad = int.Parse(campoEdad.Text);

            MySqlConnection conexion = mConexion.getConexion();

            string consulta = "UPDATE usuarios SET Nombre = @Nombre, Apellido = @Apellido , edad = @Edad WHERE Id = 2;";
            if (mConexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@edad", edad);

                    int filasAfectadas = command.ExecuteNonQuery();

                }
            }
            this.borrar("Datos Actualizados");
        }

        private void btnDelate_Click(object sender, RoutedEventArgs e)
        {
            string Nombre = campoNombre.Text;
            MySqlConnection conexion = mConexion.getConexion();

            string consulta = "DELETE FROM `usuarios` WHERE `usuarios`.`Nombre` = @Nombre";
            if (mConexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            this.borrar("Datos Eliminados ");
        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
