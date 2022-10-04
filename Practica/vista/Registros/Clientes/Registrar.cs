using DevExpress.XtraEditors;
using Practica.modelo;
using Practica.vista.Registros.TipoProductos;
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
    public partial class Registrar : DevExpress.XtraEditors.XtraForm
    {
        public Registrar()
        {
            InitializeComponent();
        }

        /*inicializar formulario*/

        private static Registrar ChildInstance = null;
        public static Registrar Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new Registrar();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para iniciar el formulario*/
        private void Registrar_Load(object sender, EventArgs e)
        {
            txt_cedula.Text = "";
            txt_celular.Text = "";
            txt_correo.Text = "";
            txt_direccion.Text = "";
            txt_materno.Text = "";
            txt_nombres.Text = "";
            txt_paterno.Text = "";
            dta_fecha.Text = "";

        }

        /*funcion para salir del formulario registro*/

        private void btnsalir_Click(object sender, EventArgs e)
        {
            Registrar frm = Registrar.Instance();

            frm.Close();
        }

        /*funcion envia a guardar a la base de datos*/
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


                        if (Practica.datos.Clientes.guardar(c))
                        {
                            MessageBox.Show("Proceso Exitoso");
                            Registrar frm = Registrar.Instance();

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
                else
                {
                    MessageBox.Show("Verifique formato de correo");
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