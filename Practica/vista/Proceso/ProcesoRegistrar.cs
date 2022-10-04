using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler.Native;
using Practica.modelo;
using Practica.vista.Registros.Clientes;
using Practica.vista.Registros.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helpers;
using DataHelper = Helpers.DataHelper;
using DevExpress.Data.Filtering.Helpers;
using Practica.vista.Registros.TipoProducto;
using DevExpress.XtraReports.Native;
using Practica.vista.Registros.Reportes;
using DevExpress.XtraReports.UI;

namespace Practica.vista.Proceso
{
    public partial class ProcesoRegistrar : DevExpress.XtraEditors.XtraForm
    {
        public ProcesoRegistrar()
        {
            InitializeComponent();
        }

        /*inicializar el formulario*/
        private static ProcesoRegistrar ChildInstance = null;
        public static ProcesoRegistrar Instance()
        {
            if (ChildInstance == null || ChildInstance.IsDisposed == true)
            {
                ChildInstance = new ProcesoRegistrar();
            }
            ChildInstance.BringToFront();
            return ChildInstance;
        }

        /*funcion para iniciar el formulario*/
        private void ProcesoRegistrar_Load(object sender, EventArgs e)
        {
            cargar();
            txt_cedula.Text = "";
            txt_datos.Text = "";
            txt_cantidad.Text = "";
            txt_datos1.Text = "";
            btngenerar.Enabled = false;
            Date d = new Date();

            // date_info.Text = d.;
            //MessageBox.Show("" + d.);

            txt_total.Text ="0.00";
            txt_subtotal.Text = "0.00";

            DataHelper dh = new DataHelper(DSparametr.simpleDS);
            gridControl2.DataSource = dh.DataSet;
            gridControl2.DataMember = dh.DataMember;
            gridView2.InitNewRow += GridView2_InitNewRow;

        }

        /*funcion para  recuperar datos de los productos*/
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

        private void cbo_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*funcion para buscar un cliente por cedula*/

        public static int clienteid;
        private void btn_buscar_Click(object sender, EventArgs e)
        {


            MCliente c = Practica.datos.Clientes.recuperarporcedula(txt_cedula.Text.ToString());

            if (c == null)
            { 
                MessageBox.Show("No existe cliente registrado");
                txt_datos.Text = "";
                txt_datos1.Text = "";
            }
            else
            {
                clienteid = Convert.ToInt32(c.Cli_id);

                txt_datos.Text = "Cod: "+ c.Cli_id + " " + "Nombres: "+ c.Cli_apellidoPaterno + 
                                  " " + c.Cli_apellidoMaterno + " " + c.Cli_nombre;

                txt_datos1.Text = "Cedula: " + c.Cli_cedula + " " + "Correo: " + c.Cli_email;

            }



        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        /*funcion para seleccionar el codigo de producto*/

        public static string cod_proceso;
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (int i in gridView1.GetSelectedRows())
            {
                DataRow row = gridView1.GetDataRow(i);
               
                cod_proceso = row[0].ToString();
            }
        }

        private void btnenviar_Click(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        
        }

        /*funcion para enviar datos a guardar con las validaciones correspondientes*/

        private void btnenviar_Click(object sender, EventArgs e)
        {
           
            if ((txt_cantidad.Text.Equals(""))){
                MessageBox.Show("Ingrese Cantidad de Producto");
            }
            else{
               
                MProductos p = Practica.datos.Productos.recuperarporid(Convert.ToInt32(cod_proceso));
                if (Convert.ToInt32(txt_cantidad.Text) <= p.Pro_stock)
                {
                    btngenerar.Enabled = true;
                    gridView2.AddNewRow();
                }
                else
                {
                    MessageBox.Show("la cantidad requerida supera al stock del Producto");
                }

                
            }
           

        }

        /*funcion para iniciar el formulario con nuevos valores y asignarlos al otro gridcontrol*/

        double acumulador = 0;
        private void GridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            MProductos p = Practica.datos.Productos.recuperarporid(Convert.ToInt32(cod_proceso));

            double subtotal = p.Pro_precio * Convert.ToDouble(txt_cantidad.Text);

            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns[0], p.Pro_id);
            view.SetRowCellValue(e.RowHandle, view.Columns[1], txt_cantidad.Text);
            view.SetRowCellValue(e.RowHandle, view.Columns[2], p.Pro_precio);
            view.SetRowCellValue(e.RowHandle, view.Columns[3], subtotal);

           
            foreach (var i in gridView2.GetSelectedRows())
            {
               
                 acumulador = acumulador + Convert.ToDouble(gridView2.GetDataRow(i)[3].ToString());

            }
            txt_subtotal.Text = Convert.ToString(acumulador);

            double iva = acumulador * 0.12;
            double total = Convert.ToDouble(txt_subtotal.Text) + iva;
            txt_total.Text = Convert.ToString(total);

            txt_cantidad.Text = "";
        }

        /*funcion para generar los datos y almacenar los detalles y las facturas*/
        private void btngenerar_Click(object sender, EventArgs e)
        {


            //guardar la factura
            if (txt_total.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar productos");
            }
            else if (txt_datos.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar cliente o el cliente consumir final con codigo 1");
            }
            else
            {
                try
                {
                    MFactura f = new MFactura();


                    f.Fac_fk_cliente = clienteid;
                    f.Fac_fecha = date_info.Text;
                    f.Fac_total = Convert.ToDouble(txt_total.Text);
                    f.Fac_estado = "A";

                    int idfacturagenerado = Practica.datos.Factura.guardar(f);


                    if (idfacturagenerado != 0)
                    {
                        
                        MDetalle d = new MDetalle();

                        d.Det_fk_factura = idfacturagenerado;

                        //procedo a guardar detalle factura

                      
                        int totalrows = gridView2.RowCount -1;

                        for (int i = 1; i < totalrows; i++)
                        {

                            d.Det_fk_producto = Convert.ToInt32(gridView2.GetDataRow(i)[0].ToString());
                            d.Det_cantidad = Convert.ToInt32(gridView2.GetDataRow(i)[1].ToString());
                            d.Det_precio = Convert.ToDouble(gridView2.GetDataRow(i)[3].ToString());
                            if (Practica.datos.Detalle.guardar(d))
                            {
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Guardar");
                            }

                            MProductos p = new MProductos();
                            p = Practica.datos.Productos.recuperarporid(Convert.ToInt32(gridView2.GetDataRow(i)[0].ToString()));
                            p.Pro_stock = p.Pro_stock - Convert.ToInt32(gridView2.GetDataRow(i)[1].ToString());
                            Practica.datos.Productos.editar(p);

                        } 

                   
                       foreach (var i in gridView2.GetSelectedRows())
                        {
                        
                            d.Det_fk_producto = Convert.ToInt32(gridView2.GetDataRow(i)[0].ToString());
                            d.Det_cantidad = Convert.ToInt32(gridView2.GetDataRow(i)[1].ToString());
                            d.Det_precio = Convert.ToDouble(gridView2.GetDataRow(i)[3].ToString());
                            if (Practica.datos.Detalle.guardar(d))
                            {
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Guardar");
                            }

                            MProductos p = new MProductos();
                            p = Practica.datos.Productos.recuperarporid(Convert.ToInt32(gridView2.GetDataRow(i)[0].ToString()));
                            p.Pro_stock = p.Pro_stock - Convert.ToInt32(gridView2.GetDataRow(i)[1].ToString());
                            Practica.datos.Productos.editar(p);
                        }

                        MessageBox.Show("Proceso Exitoso");
                        
                        //proceder a restar del stock
                        
                        txt_datos.Text = "";
                        txt_datos1.Text = "";
                        txt_cantidad.Text = "";
                        txt_total.Text = "0.00";
                        txt_subtotal.Text = "0.00";
                        txt_cedula.Text = "";



                        ProcesoRegistrar frm = ProcesoRegistrar.Instance();
                        frm.Close();

                        //generar reporte
                        PruebaReport rep = new PruebaReport();
                        rep.Parameters["idfactura"].Value = idfacturagenerado;
                        ReportPrintTool t = new  ReportPrintTool(rep);
                        
                        t.ShowPreviewDialog();
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

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
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

        /*funcion para cerrar el formulario*/
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            ProcesoRegistrar frm = ProcesoRegistrar.Instance();

            frm.Close();
        }

        /*funcion para buscar con el enter*/
        private void txt_cedula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //
                MCliente c = Practica.datos.Clientes.recuperarporcedula(txt_cedula.Text.ToString());

                if (c == null)
                {
                    MessageBox.Show("No existe cliente registrado");
                    txt_datos.Text = "";
                    txt_datos1.Text = "";
                }
                else
                {
                    clienteid = Convert.ToInt32(c.Cli_id);

                    txt_datos.Text = "Cod: " + c.Cli_id + " " + "Nombres: " + c.Cli_apellidoPaterno +
                                      " " + c.Cli_apellidoMaterno + " " + c.Cli_nombre;

                    txt_datos1.Text = "Cedula: " + c.Cli_cedula + " " + "Correo: " + c.Cli_email;
                }
                    //
                }
        }
    }
}