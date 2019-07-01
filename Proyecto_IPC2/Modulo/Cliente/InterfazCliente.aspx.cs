using Proyecto_IPC2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo.Cliente
{
    public partial class InterfazCliente : System.Web.UI.Page
    {
        List<AtencionCliente> conjuntoSolicitud;
        List<Transferencia> solicitudTransferencia;
        List<Chequera> solicitudChequera;
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnAtencion_Click(object sender, EventArgs e)
        {
            conjuntoSolicitud = new List<AtencionCliente>();
            //Gestión de consultas en Cola
            if (Session["consulta"] != null)
            {
                conjuntoSolicitud = (List<AtencionCliente>)Session["consulta"];
            }
            //Gestión de turnos
            if (Session["turnoCola"] != null)
            {
                Session["turnoCola"] = (int)Session["turnoCola"] + 1;
            }
            else
            {
                Session["turnoCola"] = 1;
            }
            AtencionCliente nuevaConsulta = new AtencionCliente();
            nuevaConsulta.turnoAtencion = (int)Session["turnoCola"];
            conjuntoSolicitud.Add(nuevaConsulta);
            Session["consulta"] = conjuntoSolicitud;
        }

        protected void btnTrans_Click(object sender, EventArgs e)
        {
            solicitudTransferencia = new List<Transferencia>();
            //Gestión de consultas en Cola
            if (Session["colaTransferencia"] != null)
            {
                solicitudTransferencia = (List<Transferencia>)Session["colaTransferencia"];
            }
            //Gestión de Turnos
            if (Session["turnoTransferencia"] != null)
            {
                Session["turnoTransferencia"] = (int)Session["turnoTransferencia"] + 1;
            }
            else
            {
                Session["turnoTransferencia"] = 1;
            }
            Transferencia nuevaSolicitudTransferencia = new Transferencia();
            nuevaSolicitudTransferencia.ticket = (int)Session["turnoTransferencia"];
            solicitudTransferencia.Add(nuevaSolicitudTransferencia);
            Session["colaTransferencia"] = solicitudTransferencia;
        }

        protected void btnEstado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cuentas/Consultas.aspx");
        }

        protected void btnChequera_Click(object sender, EventArgs e)
        {
            solicitudChequera = new List<Chequera>();
            if (Session["colaChequera"] != null)
            {
                solicitudChequera = (List<Chequera>)Session["colaChequera"];
            }
            if (Session["turnoChequera"] != null)
            {
                Session["turnoChequera"] = (int)Session["turnoChequera"] + 1;
            }
            else
            {
                Session["turnoChequera"] = 1;
            }
            Chequera soliChequera = new Chequera();
            soliChequera.turno = (int)Session["turnoChequera"];
            solicitudChequera.Add(soliChequera);

            Session["colaChequera"] = solicitudChequera;
        }
    }
}