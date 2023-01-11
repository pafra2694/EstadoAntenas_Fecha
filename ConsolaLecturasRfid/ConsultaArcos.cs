using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ConsolaLecturasRfid
{
    public class ConsultaArcos
    {
        public ConexionDB conexion1 = new ConexionDB();
        MySqlCommand command1 = new MySqlCommand();
        DataTable numArcosTable = new DataTable();
        int numArcos =0;

        public int ConsultaNumArcos()
        {

            string query1 = "SELECT ID_ARCO FROM rfid_fechas order by ID_ARCO desc limit 1";
            MySqlDataReader rdIps;

            try
            {
                command1 = new MySqlCommand(query1, conexion1.AbreConexion());
                rdIps = command1.ExecuteReader();
                numArcosTable.Load(rdIps);
                conexion1.CierraConexion();
                numArcos = Convert.ToInt32(numArcosTable.Rows[0][0]); 
            }
            catch (Exception ex)
            {
                conexion1.CierraConexion();
                Console.WriteLine(ex.Message);
            }

            return numArcos;
        }


    }
}
