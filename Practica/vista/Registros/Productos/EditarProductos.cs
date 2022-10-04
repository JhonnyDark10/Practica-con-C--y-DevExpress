using DevExpress.XtraEditors;
using Practica.modelo;
using Practica.vista.Registros.Clientes;
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
    public partial class EditarProductos : DevExpress.XtraEditors.XtraForm
    {
        private const char SignoDecimal = ',';
        public EditarProductos()
        {
            InitializeComponent();
        }

        /*inicializar formulario*/

        private static EditarProductos ChildInstance = null;
        public static EditarProductos Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new EditarProductos();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para que al iniciar el programa cargeuna funcion*/
        private void EditarProductos_Load(object sender, EventArgs e)
        {
            cargarTipoProducto();
            recupera_datos(Convert.ToInt32(ListaProductos.cod_producto));
        }

        /*funcion para recuperar por id una lista de la base de datos*/
        public void recupera_datos(int cod)
        {
            MProductos p = Practica.datos.Productos.recuperarporid(cod);

            if (p == null)
            {
                MessageBox.Show("No se Puede recuperar la informaciòn");
            }
            else
            {
                txt_nombre.Text = p.Pro_nombre;
                txt_descripcion.Text = p.Pro_description;
                txt_precio.Text = Convert.ToString(p.Pro_precio);
                txt_stock.Text = Convert.ToString(p.Pro_stock);
                
                cbo_tipo.SelectedValue = p.Pro_fk_tipo;
            }


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

                //lue_combo.Properties.DataSource = datos.Columns[2] ;
                //lue_combo.Properties.DisplayMember = "ti_nombre";
                //lue_combo.Properties.ValueMember = "ti_id";

                cbo_tipo.DataSource = datos;
                cbo_tipo.DisplayMember = "ti_nombre";
                cbo_tipo.ValueMember = "ti_id";

            }


        }

        /*funcion para salir del formulario*/
        private void btn_salir_Click(object sender, EventArgs e)
        {
            EditarProductos frm = EditarProductos.Instance();

            frm.Close();
        }

        /*funcion para enviar a editar a la base de datos*/
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text.Trim() == "" || txt_descripcion.Text.Trim() == "")
            {
                MessageBox.Show("Verifique si ingreso nombre y descripcion de producto");
            }
            else if (txt_precio.Text.Trim() == "" || txt_stock.Text.Trim() == "")
            {
                MessageBox.Show("Verifique si ingreso precio y stock del producto");
            }
            else
            {
                try
                {
                    MProductos p = new MProductos();



                    p.Pro_id = Convert.ToInt32(ListaProductos.cod_producto);
                    p.Pro_nombre = txt_nombre.Text;
                    p.Pro_precio = Convert.ToDouble(txt_precio.Text);
                    p.Pro_description = txt_descripcion.Text;
                    p.Pro_stock = Convert.ToInt32(txt_stock.Text);
                    p.Pro_fk_tipo = (int)cbo_tipo.SelectedValue;
                    p.Pro_estado = "A";


                    if (Practica.datos.Productos.editar(p))
                    {
                        MessageBox.Show("Proceso Exitoso");
                        EditarProductos frm = EditarProductos.Instance();

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