using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.datos
{
    internal class Conexion
    {
        SqlConnection con;

        /*funcion para realizar la cadena de conexion*/
        public Conexion() { 
        
        con = new SqlConnection("Server=BARCELONA;Database=Sistema_Facturacion;integrated security=true");
        }

        /*funcion para conectar en la base de datos*/
        public SqlConnection conectar() {

            try
            {
                con.Open();
                return con;
            }
            catch (Exception e) {
            
                return null;
            }
  
        }

        /*funcion para desconectar en la base de datos*/
        public bool desconectar()
        {

            try
            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }
    }
}
