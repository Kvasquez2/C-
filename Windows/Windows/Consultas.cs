using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Windows
{
    internal class Consultas
    {
        Conexion mconexion;
        public Consultas()
        {
            mconexion = new Conexion();
        }
        public void insertars(int precio, int stock, string proveedor)
        {
            MySqlConnection conexion = mconexion.getConexion();

            string consulta = "INSERT INTO inven (precio, stock, proveedor) VALUE( @precio, @stock, @proveedor )";
            if (mconexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@proveedor", proveedor);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            else
            {
                return;
            }
        }


        public void updates(int id_invent, int precio , int stock, string proveedor)
        {
            MySqlConnection conexion = mconexion.getConexion();

            string consulta = "UPDATE inven SET id_Inventario = id_Inventario, precio = @precio, stock = @stock, proveedor = @proveedor";
            if (mconexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@id_Inventario", id_invent);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@stock", stock);
                    command.Parameters.AddWithValue("@proveedor", proveedor);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            else
            {
                return;
            }
        }

        public void selecion(int idProveedor)
        {
            using (MySqlConnection conexion = mconexion.getConexion())
            {
                if (conexion == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión.");
                    return;
                }

                string consulta = "SELECT id_Inventario, precio, stock, proveedor FROM inven WHERE id_Inventario = @id_Inventario";

                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@id_Inventario", idProveedor);

                    try
                    {
                        conexion.Open();

                        List<string> resultados = new List<string>();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idResultado = reader.GetInt32(0);
                                decimal precioResultado = reader.GetDecimal(1);
                                int stockResultado = reader.GetInt32(2);
                                string proveedorResultado = reader.GetString(3);

                                string resultado = $"ID: {idResultado}, Precio: {precioResultado}, Stock: {stockResultado}, Proveedor: {proveedorResultado}";
                                resultados.Add(resultado);
                            }
                        }

                        string mensaje = resultados.Count > 0
                            ? string.Join(Environment.NewLine, resultados)
                            : "No se encontraron resultados para el proveedor especificado.";

                        MessageBox.Show("Resultados:\n" + mensaje);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
                    }
                }
            }
        }
        //    MySqlConnection conexion = mconexion.getConexion();
        //    MySqlDataReader mySqlDataReader = null;
        //    string consulta = "Select id_Inventario, precio , stock, proveedor FROM inven WHERE @id_Inventario";
        //    if (mconexion.getConexion() != null)
        //    {
        //        using (MySqlCommand command = new MySqlCommand(consulta, conexion))
        //        {
        //            command.Parameters.AddWithValue("@id_Inventario", id_proveedors);

        //            int filasAfectadas = command.ExecuteNonQuery();

        //            try
        //            {
        //                conexion.Open();
        //                MySqlDataReader reader = command.ExecuteReader();

        //                List<string> resultados = new List<string>(); // Lista para almacenar los resultados

        //                // Procesar los resultados y agregarlos a la lista
        //                while (reader.Read())
        //                {
        //                    int idResultado = reader.GetInt32(0); // id_Inventario
        //                    decimal precioResultado = reader.GetDecimal(1); // precio
        //                    int stockResultado = reader.GetInt32(2); // Stock
        //                    string proveedorResultado = reader.GetString(3); // proveedor

        //                    string resultado = $"ID: {idResultado}, Precio: {precioResultado}, Stock: {stockResultado}, Proveedor: {proveedorResultado}";
        //                    resultados.Add(resultado);
        //                }

        //                reader.Close(); // Cerrar el lector de resultados

        //                // Mostrar los resultados en un mensaje
        //                if (resultados.Count > 0)
        //                {
        //                    string mensaje = string.Join(Environment.NewLine, resultados);
        //                    MessageBox.Show("Resultados:\n" + mensaje);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No se encontraron resultados para el proveedor especificado.");
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
        //            }
        //        }
        //        MySqlCommand mySqlCommand = new MySqlCommand(consulta);
        //        mySqlCommand.Connection = mconexion.getConexion();

        //        //while (mySqlDataReader.Read())
        //        //{
        //        //    string resul = mySqlDataReader.GetString("Nombre");
        //        //    int.Parse(id_proveedors.Add(resul));
        //        //}
        //        //mySqlDataReader.Close();
        //        //if (Nombre.Count > 0)
        //        //{
        //        //    string concadenarNombre = string.Join(",", Nombre);
        //        //    MessageBox.Show("Nombres : " + concadenarNombre);
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("No se encontraron los nombres en la base de datos");
        //        //}
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        //public void selecion(int id_proveedors)
        //{

        //    using (MySqlConnection conexion = mconexion.getConexion())
        //    {
        //        if (conexion != null)
        //        {
        //            string consulta = "SELECT id_Inventario FROM inven WHERE id_Inventario = @proveedor";

        //            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
        //            {
        //                comando.Parameters.AddWithValue("@proveedor", id_proveedors);

        //                try
        //                {
        //                    conexion.Open();
        //                    MySqlDataReader reader = comando.ExecuteReader();

        //                    List<string> resultados = new List<string>(); // Lista para almacenar los resultados

        //                    // Procesar los resultados y agregarlos a la lista
        //                    while (reader.Read())
        //                    {
        //                        int idResultado = reader.GetInt32(0); // id_Inventario
        //                        decimal precioResultado = reader.GetDecimal(1); // precio
        //                        int stockResultado = reader.GetInt32(2); // Stock
        //                        string proveedorResultado = reader.GetString(3); // proveedor

        //                        string resultado = $"ID: {idResultado}, Precio: {precioResultado}, Stock: {stockResultado}, Proveedor: {proveedorResultado}";
        //                        resultados.Add(resultado);
        //                    }

        //                    reader.Close(); // Cerrar el lector de resultados

        //                    // Mostrar los resultados en un mensaje
        //                    if (resultados.Count > 0)
        //                    {
        //                        string mensaje = string.Join(Environment.NewLine, resultados);
        //                        MessageBox.Show("Resultados:\n" + mensaje);
        //                    }
        //                    else
        //                    {
        //                        MessageBox.Show("No se encontraron resultados para el proveedor especificado.");
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Error al ejecutar la consulta: " + ex.Message);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error al conectar a la base de datos");
        //        }
        //    }
        //}

        public void Deletes (int id)
        {
            using (MySqlConnection conexion = mconexion.getConexion())
            {
                if (conexion != null)
                {
                    string consulta = $"DELETE FROM inven WHERE `id_Inventario` = @id";

                    using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Hola");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al conectar a la base de datos");
                }
            }
        }
        


        // hi
    }
}
