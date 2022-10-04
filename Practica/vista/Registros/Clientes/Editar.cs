using DevExpress.XtraEditors;
using Practica.modelo;
using Practica.vista.Registros.TipoProducto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica.vista.Registros.Clientes
{
    public partial class Editar : DevExpress.XtraEditors.XtraForm
    {
        public Editar()
        {
            InitializeComponent();
        }

        /*inicializar el formulario*/

        private static Editar ChildInstance = null;
        public static Editar Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new Editar();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para iniciar el formulario con recuperar datos por id*/
        private void Editar_Load(object sender, EventArgs e)
        {
            recupera_datos(Convert.ToInt32(ListaClientes.cod_cliente));
        }

        /*funcion para recuperar datos desde la base de datos*/
        public void recupera_datos(int cod)
        {
            MCliente c = Practica.datos.Clientes.recuperarporid(cod);

            if (c == null)
            {
                MessageBox.Show("No se Puede recuperar la informaciòn");
            }
            else
            {
                txt_cedula.Text = c.Cli_cedula;
                txt_celular.Text = c.Cli_celular;
                txt_correo.Text = c.Cli_email;
                txt_direccion.Text = c.Cli_direccion;
                txt_materno.Text = c.Cli_apellidoMaterno;
                txt_nombres.Text = c.Cli_nombre;
                txt_paterno.Text = c.Cli_apellidoPaterno;
                dta_fecha.Text = c.Cli_fechanac;

            }


        }

        /*funcion para cerrar el formulario */
        private void btnsalir_Click(object sender, EventArgs e)
        {
            Editar frm = Editar.Instance();

            frm.Close();
        }

        /*funcion enviar a editar en la base de datos*/

        private void btnguardar_Click(object sender, EventArgs e)
        {

            if (txt_cedula.Text.Trim() == "" || txt_nombres.Text.Trim() == "" || txt_paterno.Text.Trim() == "" || txt_materno.Text.Trim() == "")
            {
                MessageBox.Show("Verifique datos de cedula,nombre o apellidos no esten  vacios");
            }
            else if (txt_celular.Text.Trim() == "" || txt_direccion.Text.Trim() == "")
            {
                MessageBox.Show("Verifique datos de ceular o direccion no esten  vacios");
            }
            else
            {
                if (validateEmail(txt_correo.Text.Trim()))
                {
                    try
                    {
                        MCliente c = new MCliente();



                        c.Cli_id = Convert.ToInt32(ListaClientes.cod_cliente);
                        c.Cli_fechanac = dta_fecha.Text;
                        c.Cli_email = txt_correo.Text;
                        c.Cli_celular = txt_celular.Text;
                        c.Cli_cedula = txt_cedula.Text;
                        c.Cli_direccion = txt_direccion.Text;
                        c.Cli_apellidoMaterno = txt_materno.Text;
                        c.Cli_apellidoPaterno = txt_paterno.Text;
                        c.Cli_nombre = txt_nombres.Text;
                        c.Cli_estado = "A";


                        if (Practica.datos.Clientes.editar(c))
                        {
                            MessageBox.Show("Proceso Exitoso");
                            Editar frm = Editar.Instance();

                            frm.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Guardar");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                   

            }
        }

        /*funcion para validar correo*/
        static bool validateEmail(string email)
        {
            if (email.Equals(""))
            {
                return false;
            }
            else
            {
                if (new EmailAddressAttribute().IsValid(email))
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }


        }
    }
}