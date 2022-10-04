using Practica.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica.datos
{
    internal class Factura
    {
        /*funcion para guardar en la base de datos*/
        public static int guardar(MFactura f)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "INSERT INTO Sis_Facturas VALUES (" + f.Fac_fk_cliente 
                                                                  + ",'" + f.Fac_fecha
                                                                  + "'," + f.Fac_total.ToString().Replace(',', '.')
                                                                  + ",'" + f.Fac_estado + "')";
                SqlCommand comando = new SqlCommand(sql, con.conectar());



                int cantidad = comando.ExecuteNonQuery();

                comando.CommandText = "SELECT @@IDENTITY";
                int id = Convert.ToInt32(comando.ExecuteScalar());
                MessageBox.Show("este es el id de la factura: " + id );

                if (cantidad == 1)
                {
                    con.desconectar();
                    return id;
                }
                else
                {
                    con.desconectar();
                    return 0;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }


        }




    }
}
