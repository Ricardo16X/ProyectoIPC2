using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_IPC2.Models
{
    public class AtencionCliente
    {
        //Aqui creo mi objeto tipo de Atencion de Cliente con sus datos y todo
        public string fecha { get; set; }
        public string hora { get; set; }
        public string descProblema { get; set; }
        public int codCliente { get; set; }
        public int turnoAtencion { get; set; }
        public int codEmpleado { get; set; }
        public int estadoAtencion { get; set; }

        public AtencionCliente()
        {
            estadoAtencion = 1;
        }
    }
}