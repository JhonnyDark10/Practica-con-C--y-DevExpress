using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.modelo
{
    internal class MCliente
    {
        /*campos de la base de datos*/

        private int cli_id;
        private string cli_cedula;
        private string cli_nombre;
        private string cli_apellidoPaterno;
        private string cli_apellidoMaterno;
        private string cli_direccion;
        private string cli_celular;
        private string cli_fechanac;
        private string cli_email;
        private string cli_estado;

        /*constructor*/
        public MCliente()
        {
            this.Cli_id = 0;
            this.Cli_cedula = "";
            this.Cli_nombre = "";
            this.Cli_apellidoPaterno = "";
            this.Cli_apellidoMaterno = "";
            this.Cli_direccion = "";
            this.Cli_celular = "";
            this.Cli_fechanac = "";
            this.Cli_email = "";
            this.Cli_estado = "";
        }

        /*funciones get y set*/
        public int Cli_id { get => cli_id; set => cli_id = value; }
        public string Cli_cedula { get => cli_cedula; set => cli_cedula = value; }
        public string Cli_nombre { get => cli_nombre; set => cli_nombre = value; }
        public string Cli_apellidoPaterno { get => cli_apellidoPaterno; set => cli_apellidoPaterno = value; }
        public string Cli_apellidoMaterno { get => cli_apellidoMaterno; set => cli_apellidoMaterno = value; }
        public string Cli_direccion { get => cli_direccion; set => cli_direccion = value; }
        public string Cli_celular { get => cli_celular; set => cli_celular = value; }
        public string Cli_fechanac { get => cli_fechanac; set => cli_fechanac = value; }
        public string Cli_email { get => cli_email; set => cli_email = value; }
        public string Cli_estado { get => cli_estado; set => cli_estado = value; }
    }
}
