using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.modelo
{
    internal class MFactura
    {

        /*campos de la base*/
        private int fac_id;
        private int fac_fk_cliente;
        private string fac_fecha;
        private double fac_total;
        private string fac_estado;

        /*constructor*/
        public MFactura()
        {
            this.Fac_id = 0;
            this.Fac_fk_cliente = 0;
            this.Fac_fecha = "";
            this.Fac_total = 0;
            this.Fac_estado = "";
        }

        /*funciones get y set*/
        public int Fac_id { get => fac_id; set => fac_id = value; }
        public int Fac_fk_cliente { get => fac_fk_cliente; set => fac_fk_cliente = value; }
        public string Fac_fecha { get => fac_fecha; set => fac_fecha = value; }
        public double Fac_total { get => fac_total; set => fac_total = value; }
        public string Fac_estado { get => fac_estado; set => fac_estado = value; }
    }
}
