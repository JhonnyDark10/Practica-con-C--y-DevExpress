using Practica.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.datos
{
    internal class Detalle
    {
        /*funcion para guardar en la base de datos*/
        public static bool guardar(MDetalle d)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "INSERT INTO Sis_Detalle_Facturas VALUES (" + d.Det_fk_factura 
                                                                          + "," + d.Det_fk_producto
                                                                          + "," + d.Det_cantidad
                                                                          + "," + d.Det_precio.ToString().Replace(',', '.') + ")";
                SqlCommand comando = new SqlCommand(sql, con.conectar());

                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else
                {
                    con.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }


        }

    }
}
