using DevExpress.XtraGrid.Views.Base.ViewInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.modelo
{
    internal class MProductos
    {

        /*campos de la base*/

        private int pro_id;
        private int pro_fk_tipo;
        private string pro_nombre;
        private double pro_precio;
        private string pro_description;
        private int pro_stock;
        private string pro_estado;



        /*constructor*/

        public MProductos()
        {
            this.Pro_id = 0;
            this.Pro_fk_tipo = 0;
            this.Pro_nombre = "";
            this.Pro_precio = 0;
            this.Pro_description = "";
            this.Pro_stock = 0;
            this.Pro_estado = ""; 
        }

        /*funciones get y set*/

        public int Pro_id { get => pro_id; set => pro_id = value; }
        public string Pro_nombre { get => pro_nombre; set => pro_nombre = value; }
        public double Pro_precio { get => pro_precio; set => pro_precio = value; }
        public string Pro_description { get => pro_description; set => pro_description = value; }
        public int Pro_stock { get => pro_stock; set => pro_stock = value; }
        public string Pro_estado { get => pro_estado; set => pro_estado = value; }
        internal int Pro_fk_tipo { get => pro_fk_tipo; set => pro_fk_tipo = value; }
    }
}
