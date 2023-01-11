using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaLecturasRfid
{
    public class ConsultaFechasRfid
    {
        public ConexionDB conexion1 = new ConexionDB();
        MySqlCommand command1 = new MySqlCommand();
        DataTable fechasRfid = new DataTable();


        public DataTable ConsultaTablaFechasRfid(int arco)
        {

            string query1 = "SELECT CARRIL1, CARRIL2, CARRIL3, CARRIL4, NUMCARRILES FROM rfid_fechas WHERE (ID_ARCO = '" + arco + "')";
            MySqlDataReader rdIps;  

            try
            {
                command1 = new MySqlCommand(query1, conexion1.AbreConexion());
                rdIps = command1.ExecuteReader();
                fechasRfid.Load(rdIps);
                conexion1.CierraConexion();
            }
            catch (Exception ex)
            {
                conexion1.CierraConexion();
                Console.WriteLine(ex.Message);
            }

            return fechasRfid;
        }
    }
}
