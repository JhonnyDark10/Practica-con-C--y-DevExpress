using DevExpress.XtraEditors;
using Practica.modelo;
using Practica.vista.Registros.TipoProductos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica.vista.Registros.TipoProducto
{
    public partial class EditarTipo : DevExpress.XtraEditors.XtraForm
    {
        public EditarTipo()
        {
            InitializeComponent();
        }

        /*inicializar el formulario*/

        private static EditarTipo ChildInstance = null;
        public static EditarTipo Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new EditarTipo();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para llamar el formulario editar desde un boton*/

        private void btn_salir_Click(object sender, EventArgs e)
        {
            EditarTipo frm = EditarTipo.Instance();

            frm.Close();
        }

        /*funcion para enviar a guardar datos en la base de datos*/

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

                    p.Ti_id = Convert.ToInt32(RegistroTipoProducto.cod_tipo);
                    p.Ti_nombre = txt_nombre.Text;
                    p.Ti_description = txt_descripcion.Text;
                    p.Ti_estado = "A";

                    if (Practica.datos.TipoProductos.editar(p))
                    {
                        MessageBox.Show("Proceso Exitoso");
                        EditarTipo frm = EditarTipo.Instance();

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

        /*funcion para que al iniciar el programa carge una funcion*/

        private void EditarTipo_Load(object sender, EventArgs e)
        {
           
            recupera_datos(Convert.ToInt32(RegistroTipoProducto.cod_tipo));

        }

        /*funcion para que al iniciar el programa carge una lista de la base de datos*/
        public void recupera_datos(int cod)
        {
            MTipoProductos p = Practica.datos.TipoProductos.recuperarporid(cod);

            if (p == null)
            {
                MessageBox.Show("No se Puede recuperar la informaciòn");
            }
            else
            {
                txt_nombre.Text = p.Ti_nombre;
                txt_descripcion.Text = p.Ti_description;
            }


        }




    }
}