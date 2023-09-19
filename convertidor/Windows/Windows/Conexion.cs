using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows
{
    internal class Conexion
    {
        private MySqlConnection conexion;
        private string server = "localhost"; // Direccion del servidor de la base de datos (en este caso local).
        private string database = "inventario"; // Nombre de la base de datos a la que se conectara.
        private string user = "root"; // Nombre de usuario de la base de datos
        private string password = ""; // contraseña de la base de datos (en este caso , parece estar vacia ).
        private string cadenaConexion; // Cadena de conexiones que se utilizara para conectarse a la base de datos.

        public Conexion()
        {
            //en el constructor de la clase, se construye la cadena de conexion utilizando los valores definidos anteriormente
            cadenaConexion = "Database=" + database +
                "; DataSource=" + server +
                "; User Id=" + user +
                "; Password=" + password;
        }

        public MySqlConnection getConexion()
        {
            if (conexion == null)
            {
                conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
            }
            return conexion;
        }
    }
}

