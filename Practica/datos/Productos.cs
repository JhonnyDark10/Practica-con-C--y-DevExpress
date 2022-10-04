using Practica.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica.datos
{
    internal class Productos
    {

        /*funcion para guardar en la base de datos*/
        public static bool guardar(MProductos p)
        {
            try
            {
                Conexion con = new Conexion();

                MessageBox.Show(p.Pro_precio.ToString());

               

                String sql = "INSERT INTO Sis_Productos VALUES (" + p.Pro_fk_tipo 
                                                                  + ",'" + p.Pro_nombre
                                                                  + "'," + p.Pro_precio.ToString().Replace(',', '.')
                                                                  + "," + p.Pro_stock
                                                                  + ",'" + p.Pro_description
                                                                  + "','" + p.Pro_estado
                                                                  + "')";
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

        /*funcion para retonar una lista desde la base de datos*/
        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_Productos where pro_estado = 'A'";
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
        public static bool editar(MProductos p)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "UPDATE Sis_Productos SET pro_fk_tipo = " + p.Pro_fk_tipo
                                                + " ,pro_nombre='" + p.Pro_nombre
                                                + "',pro_precio=" + p.Pro_precio.ToString().Replace(',', '.')
                                                + ",pro_stock=" + p.Pro_stock
                                                + ",pro_description='" + p.Pro_description
                                                + "',pro_estado='" + p.Pro_estado
                                                + "' where pro_id =" + p.Pro_id;
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
        public static MProductos recuperarporid(int id)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_Productos where pro_id = " + id;
                SqlCommand comando = new SqlCommand(sql, con.conectar());

                SqlDataReader dr = comando.ExecuteReader();

                MProductos p = new MProductos(); 

                if (dr.Read())
                {
                    p.Pro_id = Convert.ToInt32(dr["pro_id"].ToString());
                    p.Pro_fk_tipo = Convert.ToInt32(dr["pro_fk_tipo"].ToString());
                    p.Pro_stock= Convert.ToInt32(dr["pro_stock"].ToString()); 
                    p.Pro_description= dr["pro_description"].ToString();
                    p.Pro_precio = double.Parse(dr["pro_precio"].ToString());
                    p.Pro_nombre = dr["pro_nombre"].ToString();
                    p.Pro_estado = dr["pro_estado"].ToString();

                   


                    con.desconectar();
                    return p;
                }
                else
                {
                    con.desconectar();
                    return null;
                }


            }
            catch (Exception ex)
            {

                return null;
            }

        }

        /*funcion para elimnar en la base de datos*/
        public static bool eliminar(int p)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "UPDATE Sis_Productos SET pro_estado= 'I' where pro_id =" + p;
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
