using System;
using System.Data;
using System.Net.NetworkInformation;

namespace ConsolaLecturasRfid
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ConsultaArcos arcos = new ConsultaArcos();
            int numArcos = arcos.ConsultaNumArcos();

            ConsultaFechasRfid fechasRfid = new ConsultaFechasRfid();
            InsertEstado UpdateEstado = new InsertEstado();
            DataTable fechas = new DataTable();
            int antenaActiva = 1;
            int antenaInactiva = 0;
            int carriles;
            TimeSpan limit = new TimeSpan(0, 8, 00, 00, 000);

            for (int k = 1; k <= numArcos; k++)
            {
                fechas = fechasRfid.ConsultaTablaFechasRfid(k);
                carriles = Convert.ToInt32(fechas.Rows[0][4].ToString());

                for (int i = 0; i < carriles; i++)
                {
                    if (fechas.Rows[0][i].ToString() == "")
                    {
                        UpdateEstado.UpdateEstadoRfid(k, i + 1, antenaInactiva);
                    }

                    else
                    {
                        if ((DateTime.Now - Convert.ToDateTime(fechas.Rows[0][i].ToString())) > limit)
                        {
                            UpdateEstado.UpdateEstadoRfid(k, i + 1, antenaInactiva);
                        }

                        else
                        {
                            UpdateEstado.UpdateEstadoRfid(k, i + 1, antenaActiva);
                        }
                    }

                }
                fechas.Clear();
            }
        }
    }
}
