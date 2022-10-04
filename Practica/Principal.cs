using Practica.vista;
using Practica.vista.Proceso;
using Practica.vista.Registros.Clientes;
using Practica.vista.Registros.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Practica
{
    public partial class Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Principal()
        {
            InitializeComponent();
        }

       

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void btn_tipos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RegistroTipoProducto frm = RegistroTipoProducto.Instance();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btn_clientes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListaClientes frm = ListaClientes.Instance();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();

        }

        private void btn_productos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ListaProductos frm = ListaProductos.Instance();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void btn_facturacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcesoRegistrar frm = ProcesoRegistrar.Instance();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
