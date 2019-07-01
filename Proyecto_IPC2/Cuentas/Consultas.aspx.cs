using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Cuentas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbtnChequera_CheckedChanged(object sender, EventArgs e)
        {
            lblOpcion.Text = ": Chequera";
        }

        protected void rbtnTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            lblOpcion.Text = ": Transferencia";
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                
                if (rbtnChequera.Checked)
                {
                    //Buscar la Información de la Chequera

                }
                else if (rbtnTransferencia.Checked)
                {
                    //Buscar la Información de la Transferencias

                }
                else
                {
                    mensaje("Escoge primero una opción.");
                }
            }
            else
            {
                mensaje("Código Ingresado no Válido !");
            }
        }

        private void mensaje(string alerta)
        {
            Response.Write("<script>alert('" + alerta + "')</script>");
        }
    }
}