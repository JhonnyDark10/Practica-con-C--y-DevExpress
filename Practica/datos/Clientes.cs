using Practica.modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.datos
{
    internal class Clientes
    {

        /*funcion para guardar en la base de datos*/
        public static bool guardar(MCliente c)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "INSERT INTO Sis_Clientes VALUES ('" + c.Cli_cedula + "','"
                                                                  + "','" + c.Cli_nombre
                                                                  + "','" + c.Cli_apellidoPaterno
                                                                  + c.Cli_apellidoMaterno
                                                                  + "','" + c.Cli_direccion
                                                                  + "','" + c.Cli_celular  
                                                                  + "','" + c.Cli_fechanac 
                                                                  + "','" + c.Cli_email 
                                                                  + "','" + c.Cli_estado + "')";
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

        /*funcion para retornar una lista desde la base de datos*/
        public static DataTable listar()
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_Clientes where cli_estado = 'A'";
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
        public static bool editar(MCliente c)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "UPDATE Sis_Clientes SET cli_cedula='" + c.Cli_cedula
                                                + "',cli_nombre='" + c.Cli_nombre
                                                + "',cli_apellidoPaterno='" + c.Cli_apellidoPaterno
                                                + "',cli_apellidoMaterno='" + c.Cli_apellidoMaterno
                                                + "',cli_direccion='" + c.Cli_direccion
                                                + "',cli_celular='" + c.Cli_celular
                                                + "',cli_fechanac='" + c.Cli_fechanac
                                                + "',cli_email='" + c.Cli_email
                                                + "',cli_estado='" + c.Cli_estado
                                                + "' where cli_id =" + c.Cli_id;
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

        /*funcion para recuperar por id informacion en la base de datos*/
        public static MCliente recuperarporid(int id)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_Clientes where cli_id = " + id;
                SqlCommand comando = new SqlCommand(sql, con.conectar());

                SqlDataReader dr = comando.ExecuteReader();

                MCliente c = new MCliente();

                if (dr.Read())
                {
                    c.Cli_cedula = dr["cli_cedula"].ToString();
                    c.Cli_nombre = dr["cli_nombre"].ToString();
                    c.Cli_apellidoPaterno = dr["cli_apellidoPaterno"].ToString();
                    c.Cli_apellidoMaterno = dr["cli_apellidoMaterno"].ToString();
                    c.Cli_direccion = dr["cli_direccion"].ToString();
                    c.Cli_celular = dr["cli_celular"].ToString();
                    c.Cli_fechanac = dr["cli_fechanac"].ToString();
                    c.Cli_email = dr["cli_email"].ToString();
                    c.Cli_estado = dr["cli_estado"].ToString();
                    c.Cli_id = Convert.ToInt32(dr["cli_id"].ToString());


                    con.desconectar();
                    return c;
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

        /*funcion para eliminar en la base de datos*/
        public static bool eliminar(int c)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "UPDATE Sis_Clientes SET cli_estado= 'I' where cli_id =" + c;
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


        public static MCliente recuperarporcedula(string id)
        {
            try
            {
                Conexion con = new Conexion();

                String sql = "SELECT * FROM Sis_Clientes where cli_cedula = " + id;
                SqlCommand comando = new SqlCommand(sql, con.conectar());

                SqlDataReader dr = comando.ExecuteReader();

                MCliente c = new MCliente();

                if (dr.Read())
                {
                    c.Cli_cedula = dr["cli_cedula"].ToString();
                    c.Cli_nombre = dr["cli_nombre"].ToString();
                    c.Cli_apellidoPaterno = dr["cli_apellidoPaterno"].ToString();
                    c.Cli_apellidoMaterno = dr["cli_apellidoMaterno"].ToString();
                    c.Cli_direccion = dr["cli_direccion"].ToString();
                    c.Cli_celular = dr["cli_celular"].ToString();
                    c.Cli_fechanac = dr["cli_fechanac"].ToString();
                    c.Cli_email = dr["cli_email"].ToString();
                    c.Cli_estado = dr["cli_estado"].ToString();
                    c.Cli_id = Convert.ToInt32(dr["cli_id"].ToString());


                    con.desconectar();
                    return c;
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



    }
}
