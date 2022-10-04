using Practica.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica.datos
{
    internal class TipoProductos
    {
        /*funcion para guardar en la base de datos*/
        public static bool guardar(MTipoProductos t)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "INSERT INTO Sis_TipoProductos VALUES ('"+ t.Ti_nombre +"','"+ t.Ti_description +"','A')";
                SqlCommand comando = new SqlCommand(sql,con.conectar());

                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    con.desconectar();
                    return true;
                }
                else {
                    con.desconectar();
                    return false;
                }   

            }catch(Exception ex)
            {
                return false;
            }


        }

        /*funcion para retornar una lista desde la base de datos*/
        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_TipoProductos where ti_estado = 'A'";
                SqlCommand comando = new SqlCommand(sql, con.conectar());

                SqlDataReader dr = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(dr);

                con.desconectar();

                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /*funcion para editar en la base de datos*/
        public static bool editar(MTipoProductos t)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "UPDATE Sis_TipoProductos SET ti_nombre='" + t.Ti_nombre + "',ti_description='" + t.Ti_description + "' where ti_id =" + t.Ti_id;
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

        /*funcion para recuperar por id desde la base de datos*/
        public static MTipoProductos recuperarporid(int id)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_TipoProductos where ti_id = " + id;
                SqlCommand comando = new SqlCommand(sql, con.conectar());

                SqlDataReader dr = comando.ExecuteReader();
               
                MTipoProductos em = new MTipoProductos();

                if (dr.Read()){
                    em.Ti_id = Convert.ToInt32(dr["ti_id"].ToString());
                    em.Ti_nombre = dr["ti_nombre"].ToString();
                    em.Ti_description = dr["ti_description"].ToString();
                    em.Ti_estado = dr["ti_estado"].ToString();
                    con.desconectar();
                    return em;
                }
                else
                {
                    con.desconectar();
                    return null;
                }

                
            }
            catch(Exception ex)
            {
                
                return null;
            }
             
        }

        /*funcion para eliminar en la base de datos*/
        public static bool eliminar(int t)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "UPDATE Sis_TipoProductos SET ti_estado= 'I' where ti_id =" + t;
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
