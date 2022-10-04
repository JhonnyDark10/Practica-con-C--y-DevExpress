using DevExpress.XtraEditors;
using Practica.datos;
using Practica.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica.vista.Registros.TipoProductos
{
    public partial class RegistrarTipo : DevExpress.XtraEditors.XtraForm
    {
        public RegistrarTipo()
        {
            InitializeComponent();
        }

        /*inicializar el formulario*/

        private static RegistrarTipo ChildInstance = null;
        public static RegistrarTipo Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new RegistrarTipo();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion load que inicia el formulario*/
        private void RegistrarTipo_Load(object sender, EventArgs e)
        {
            txt_descripcion.Text = "";
            txt_nombre.Text = "";
        }

        /*funcion para abri el formulario de registro desde un boton*/
        private void btn_salir_Click(object sender, EventArgs e)
        {

            RegistrarTipo frm = RegistrarTipo.Instance();

            frm.Close();
        }

        /*funcion para enviar los datos a guardar en la base de datos*/
        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un nombre de tipo de producto");
            }
            else if (txt_descripcion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar una descripcion de tipo de producto");
            }
            else
            {
                try
                {
                    MTipoProductos p = new MTipoProductos();

                    p.Ti_nombre = txt_nombre.Text;
                    p.Ti_description = txt_descripcion.Text;


                    if (Practica.datos.TipoProductos.guardar(p))
                    {
                        MessageBox.Show("Proceso Exitoso");
                        RegistrarTipo frm = RegistrarTipo.Instance();

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
}