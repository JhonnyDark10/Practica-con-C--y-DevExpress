using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Practica.modelo
{
    internal class MDetalle
    {
        /*campos de la base*/

        private int det_id;
        private int det_fk_factura;
        private int det_fk_producto;
        private int det_cantidad;
        private double det_precio;

        /*constructor*/
        public MDetalle()
        {
            this.Det_id = 0;
            this.Det_fk_factura = 0;
            this.Det_fk_producto = 0;
            this.Det_cantidad = 0;
            this.Det_precio = 0;
        }

        /*funciones get y set*/
        public int Det_id { get => det_id; set => det_id = value; }
        public int Det_fk_factura { get => det_fk_factura; set => det_fk_factura = value; }
        public int Det_fk_producto { get => det_fk_producto; set => det_fk_producto = value; }
        public int Det_cantidad { get => det_cantidad; set => det_cantidad = value; }
        public double Det_precio { get => det_precio; set => det_precio = value; }
    }
}
