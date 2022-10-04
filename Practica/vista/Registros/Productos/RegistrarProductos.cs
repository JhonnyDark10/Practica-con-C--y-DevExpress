using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica.vista.Registros.Productos
{
    public partial class RegistrarProductos : DevExpress.XtraEditors.XtraForm
    {
        private const char SignoDecimal = ',';
        public RegistrarProductos()
        {
            InitializeComponent();
        }

        /*inicializar el formulario*/

        private static RegistrarProductos ChildInstance = null;
        public static RegistrarProductos Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new RegistrarProductos();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para que al iniciar el programa carge una funcion*/
        private void RegistrarProductos_Load(object sender, EventArgs e)
        {
            cargarTipoProducto();
        }

        /*funcion para que al iniciar el programa carge una lista de la base de datos*/

        public void cargarTipoProducto()
        {

            DataTable datos = Practica.datos.TipoProductos.listar();

            if (datos == null)
            {
                MessageBox.Show("No se logro acceder a los datos");
            }
            else
            {
                
                cbo_tip.DataSource = datos;
                cbo_tip.DisplayMember = "ti_nombre";
                cbo_tip.ValueMember = "ti_id";

            }


        }

        /*funcion para salir del formulario de registro*/
        private void btnsalir_Click(object sender, EventArgs e)
        {
            RegistrarProductos frm = RegistrarProductos.Instance();

            frm.Close();
        }

        /*funcion para enviar a guardar a la base de datos*/
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Trim() == "" || txt_descripcion.Text.Trim() == "")
            {
                MessageBox.Show("Verifique si ingreso nombre y descripcion de producto");
            }
            else if (txt_precio.Text.Trim() == "" || txt_stock.Text.Trim()=="")
            {
                MessageBox.Show("Verifique si ingreso precio y stock del producto");
            }
            else
            {
                try
                {
                    MProductos p = new MProductos();

                    p.Pro_nombre = txt_nombre.Text;
                    p.Pro_precio = Convert.ToDouble(txt_precio.Text);
                    p.Pro_description = txt_descripcion.Text ;
                    p.Pro_stock = Convert.ToInt32(txt_stock.Text);
                    p.Pro_fk_tipo = (int)cbo_tip.SelectedValue;
                    p.Pro_estado = "A";


                    if (Practica.datos.Productos.guardar(p))
                    {
                        MessageBox.Show("Proceso Exitoso");
                        RegistrarProductos frm = RegistrarProductos.Instance();

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

        /*funcion para que solo permita digitar numeros*/
        private void txt_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)
            {
            }
        }

        /*funcion para que solo ingrese numero y la ,*/
        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) // No es dígito
                && !char.IsControl(e.KeyChar) // No es carácter de control (backspace)
                && (e.KeyChar != SignoDecimal // No es signo decimal o es la 1ª posición o ya hay un signo decimal
                    || txt_precio.SelectionStart == 0
                    || txt_precio.Text.Contains(SignoDecimal));
        }
    }
}