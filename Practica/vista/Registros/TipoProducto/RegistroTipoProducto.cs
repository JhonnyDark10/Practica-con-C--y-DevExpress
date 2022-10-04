using DevExpress.XtraEditors;
using Practica.datos;
using Practica.modelo;
using Practica.vista.Registros.TipoProducto;
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

namespace Practica.vista
{
    public partial class RegistroTipoProducto : DevExpress.XtraEditors.XtraForm
    {
        public RegistroTipoProducto()
        {
            InitializeComponent();
        }

        /*inicializar el formulario*/

        private static RegistroTipoProducto ChildInstance = null;
        public static RegistroTipoProducto Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed ==  true)
            {
                ChildInstance = new RegistroTipoProducto();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

       
        private void RegistroTipoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        /*funcion para abrir el formulario registro desde un boton*/
        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            RegistrarTipo frm = RegistrarTipo.Instance();
                       
            frm.ShowDialog();
            cargar();
        }

        /*funcion para que al iniciar el programa carge una funcion*/
        private void RegistroTipoProducto_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /*funcion para que al iniciar el programa carge una lista de la base de datos*/
        public void cargar()
        {
            
            DataTable datos = TipoProductos.listar();

            if(datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                gridControl1.DataSource = datos.DefaultView;
                gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            }


        }

        private void gridControl1_Click(object sender, DataGridViewCellEventArgs e) 
        {
           
        }

        /*funcion para que el evento clic del gridcontrol capture el codigo especificado*/

        public static string cod_tipo;
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
               // MessageBox.Show(row[0].ToString());
                cod_tipo = row[0].ToString();
            }

        }

        /*funcion para llamar al formulario de edicion*/
        private void btn_editar_Click(object sender, EventArgs e)
        {
            EditarTipo frm = EditarTipo.Instance();

            frm.ShowDialog();
            cargar();
        }

        /*funcion para enviar a eliminar en la base de datos*/
        private void btn_salir_Click(object sender, EventArgs e)
        {

            if (Practica.datos.TipoProductos.eliminar(Convert.ToInt32(RegistroTipoProducto.cod_tipo)))
            {
                MessageBox.Show("Proceso Exitoso");
                cargar();
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar");
            }

        }
    }
}