using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.modelo
{
    internal class MTipoProductos
    {

        /*campos de la base*/

        private int ti_id;
        private string ti_nombre;
        private string ti_description;
        private string ti_estado;

        /*constructor*/
        public MTipoProductos()
        {
            this.ti_id = 0;
            this.ti_nombre = "";
            this.ti_description = "";
            this.ti_estado = "";
        }

        /*funciones get y set*/
        public int Ti_id { get => ti_id; set => ti_id = value; }
        public string Ti_nombre { get => ti_nombre; set => ti_nombre = value; }
        public string Ti_description { get => ti_description; set => ti_description = value; }
        public string Ti_estado { get => ti_estado; set => ti_estado = value; }
    }
}
