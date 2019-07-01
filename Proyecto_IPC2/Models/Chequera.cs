using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_IPC2.Models
{

    public class Chequera
    {
        public string hora { get; set; }
        public string fecha { get; set; }
        public int idCliente { get; set; }
        public int idTrabajador { get; set; }
        public int idLote { get; set; }
        public int estadoChequera { get; set; }
        public int turno { get; set; }

        public Chequera()
        {
            estadoChequera = 0;
        }
    }
}