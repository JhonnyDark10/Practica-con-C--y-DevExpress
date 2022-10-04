using DevExpress.XtraEditors;
using Practica.vista.Registros.Clientes;
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

namespace Practica.vista.Registros.Productos
{
    public partial class ListaProductos : DevExpress.XtraEditors.XtraForm
    {
        public ListaProductos()
        {
            InitializeComponent();
        }

        /*inicializar formulario*/

        private static ListaProductos ChildInstance = null;
        public static ListaProductos Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new ListaProductos();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para que al iniciar el programa cargeuna funcion*/
        private void ListaProductos_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /*funcion para que al iniciar el programa carge una lista de la base de datos*/
        public void cargar()
        {

            DataTable datos = Practica.datos.Productos.listar();

            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                gridControl1.DataSource = datos.DefaultView;
                gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            }


        }

        /*funcion para que seleccionar un fila de gridcontrol capturar el dato escogido*/

        public static string cod_producto;
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
                // MessageBox.Show(row[0].ToString());
                cod_producto = row[0].ToString();
            }
        }

        /*funcion para eliminar en la base de datos*/

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Practica.datos.Productos.eliminar(Convert.ToInt32(ListaProductos.cod_producto)))
            {
                MessageBox.Show("Proceso Exitoso");
                cargar();
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar");
            }
        }

        /*funcion para llamar al formulario de registro*/

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            RegistrarProductos frm = RegistrarProductos.Instance();

            frm.ShowDialog();
            cargar();
        }

        /*funcion para llamar al formulario de edicion*/

        private void btneditar_Click(object sender, EventArgs e)
        {
            EditarProductos frm = EditarProductos.Instance();

            frm.ShowDialog();
            cargar();
        }
    }
}