using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;


namespace ConsolaLecturasRfid
{
    public class ConexionDB
    {
        private static string conexionstringBD = "datasource=localhost; port=3306; username=root; password= ;database=rfid_lpr";

        private MySqlConnection conexion = null;

        public MySqlConnection AbreConexion()
        {
            try
            {
                conexion = new MySqlConnection(conexionstringBD);


                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }

                return conexion;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Problemas al abrir conexión a Base de datos: " + ex.Message);
                return conexion;
            }
        }

        public MySqlConnection CierraConexion()
        {
            try
            {
                conexion = new MySqlConnection(conexionstringBD);
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Close();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problemas al cerrar conexión a Base de datos: " + ex.Message);
                return conexion;
            }
        }
    }
}
