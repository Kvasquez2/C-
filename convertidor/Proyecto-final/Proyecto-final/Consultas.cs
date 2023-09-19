using Conexiones;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_final
{
    internal class Consultas
    {
        conexion mconexion;
        Window mWindow;
        public Consultas()
        {
            mconexion = new conexion();
            mWindow = new Window();
        }

        private string Selecionar()
        {
            MySqlDataReader mySqlDataReader = null;
            string consulta = "select * from persona";
            if (mconexion.getConexion() != null)
            {
                List<string> Nombre = new List<string>();

                MySqlCommand mySqlCommand = new MySqlCommand(consulta);
                mySqlCommand.Connection = mconexion.getConexion();

                mySqlDataReader = mySqlCommand.ExecuteReader();

                mySqlDataReader.Close();
                if (Nombre.Count > 0)
                {
                    string concadenarNombre = string.Join(",", Nombre);

                    return concadenarNombre;
                }
                else
                {
                    return "No se encontraron los nombres en la base de datos";
                }
            }
            else
            {
                return "Esteban es un error";
            }
        }
        public void insertars(string nombre, string apellido,string fecha)             
        {
           MySqlConnection conexion = mconexion.getConexion();

            string consulta = "INSERT INTO persona (Nombre, Apellido, Fecha_Nacimiento) VALUE(@Nombre,@Apellido,@fecha)";
            if (mconexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@fecha", fecha);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            else
            {
                return;
            }
        }
        public void updates(int id_person, string nombre, string apellido, string fecha)
        {
            MySqlConnection conexion = mconexion.getConexion();

            string consulta = "UPDATE persona SET id_Persona = id_person, Nombre = @Nombre, Apellido = @Apellido, Fecha_Nacimiento = @fecha";
            if (mconexion.getConexion() != null)
            {
                using (MySqlCommand command = new MySqlCommand(consulta, conexion))
                {
                    command.Parameters.AddWithValue("@id_Persona", id_person);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@Apellido", apellido);
                    command.Parameters.AddWithValue("@fecha", fecha);

                    int filasAfectadas = command.ExecuteNonQuery();
                }
            }
            else
            {
                return;
            }
        }


    }
}
