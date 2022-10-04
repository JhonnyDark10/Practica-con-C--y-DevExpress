using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica.datos;
using Practica.vista.Registros.TipoProductos;
using Practica.vista.Registros.TipoProducto;

namespace Practica.vista.Registros.Clientes
{
    public partial class ListaClientes : DevExpress.XtraEditors.XtraForm
    {
        public ListaClientes()
        {
            InitializeComponent();
        }

        /*inializar formulario*/

        private static ListaClientes ChildInstance = null;
        public static ListaClientes Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new ListaClientes();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para que al iniciar el programa carge una funcion*/
        private void ListaClientes_Load(object sender, EventArgs e)
        {
            cargar();
        }

        /*funcion para que al iniciar el programa carge una lista de la base de datos*/

        public void cargar()
        {

            DataTable datos = Practica.datos.Clientes.listar();

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

        public static string cod_cliente;

        /*funcion para que al seleccionar un fila del gridcontrol capturar el dato escogido*/
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
                // MessageBox.Show(row[0].ToString());
                cod_cliente = row[0].ToString();
            }
        }

        /*funcion para llamar al formulario registro*/
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Registrar frm = Registrar.Instance();

            frm.ShowDialog();
            cargar();
        }

        /*funcion para llamar al formulario editar*/
        private void btneditar_Click(object sender, EventArgs e)
        {
            Editar frm = Editar.Instance();

            frm.ShowDialog();
            cargar();
        }

        /*funcion para eliminar en la base de datos*/
        private void btneliminar_Click(object sender, EventArgs e)
        {

            if (Practica.datos.Clientes.eliminar(Convert.ToInt32(ListaClientes.cod_cliente)))
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