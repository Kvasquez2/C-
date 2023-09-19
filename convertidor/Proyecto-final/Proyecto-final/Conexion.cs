using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexiones
{
    internal class conexion
    {
        private MySqlConnection conexions;
        private string server = "localhost"; // Direccion del servidor de la base de datos (en este caso local).
        private string database = "conexion"; // Nombre de la base de datos a la que se conectara.
        private string user = "root"; // Nombre de usuario de la base de datos
        private string password = ""; // contraseña de la base de datos (en este caso , parece estar vacia ).
        private string cadenaConexion; // Cadena de conexiones que se utilizara para conectarse a la base de datos.


        public conexion()
        {
            //en el constructor de la clase, se construye la cadena de conexion utilizando los valores definidos anteriormente
            cadenaConexion = "Database=" + database +
                "; DataSource=" + server +
                "; User Id=" + user +
                "; Password=" + password;
        }

        public MySqlConnection getConexion()
        {
            if (conexions == null)
            {
                conexions = new MySqlConnection(cadenaConexion);
                conexions.Open();
            }
            return conexions;

        }

    }


}
