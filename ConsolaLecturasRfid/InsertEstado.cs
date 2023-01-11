using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaLecturasRfid
{
    public class InsertEstado
    {
        public ConexionDB conexion1 = new ConexionDB();
        MySqlCommand command1 = new MySqlCommand();
        DataTable ips = new DataTable();

        public void UpdateEstadoRfid(int arco, int carril,int estado)
        {

            String insertQuery1 = "UPDATE estado_rfid SET CARRIL" + carril + "=@carril" + carril + " WHERE ID_ESTADO_ARCO = " + arco;
            try
            {
                command1 = new MySqlCommand(insertQuery1, conexion1.AbreConexion());
                command1.Parameters.Add("@carril" + carril + "", MySqlDbType.Int32);
                command1.Parameters["@carril" + carril + ""].Value = estado;
                command1.ExecuteNonQuery();
                conexion1.CierraConexion();
            }
            catch (Exception ex)
            {
                conexion1.CierraConexion();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
