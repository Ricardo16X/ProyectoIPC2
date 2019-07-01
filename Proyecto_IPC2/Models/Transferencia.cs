using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_IPC2.Models
{
    public class Transferencia
    {
        public string fecha { get; set; }
        public string hora { get; set; }
        public string bancoDestino { get; set; }
        public int idCliente { get; set; }
        public int idTrabajador { get; set; }
        public double monto { get; set; }
        public int estadoTransferencia { get; set; }
        public string horaInicio { get; set; }
        public string horaFinal { get; set; }
        public int ticket { get; set; }

        //Objeto como tal Transferencia...
        public Transferencia()
        {
            this.estadoTransferencia = 0;
        }
    }
}