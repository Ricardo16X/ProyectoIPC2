using Proyecto_IPC2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo.Agente
{
    public partial class AtenderCliente : System.Web.UI.Page
    {
        List<AtencionCliente> consultaEnCola = new List<AtencionCliente>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "agente")
                {
                    actualizarTurno();
                    lblFecha.Text = String.Format("{0:MM/dd/yyyy}", System.DateTime.Now.Date.ToShortDateString());
                    lblHora.Text = System.DateTime.Now.ToString("HH:mm");
                }
                else
                {
                    Response.Redirect("~/Cuentas/Login.aspx");
                    Session["rol"] = null;
                }
            }
            else
            {
                Response.Redirect("~/Cuentas/Login.aspx");
                Session["rol"] = null;
            }
            
        }

        protected void btnConcluirAtencion_Click(object sender, EventArgs e)
        {
            if (Session["consulta"] != null)
            {
                consultaEnCola = (List<AtencionCliente>)Session["consulta"];
            }
            if (txtDescripcion.Text != "" && txtCodigoCliente.Text != "")
            {
                foreach (var item in consultaEnCola)
                {
                    if (item.turnoAtencion == Convert.ToInt32(Session["turnoActual"]) && item.estadoAtencion == 1)
                    {
                        item.descProblema = txtDescripcion.Text;
                        item.codCliente = Convert.ToInt32(txtCodigoCliente.Text);
                        item.estadoAtencion = 2;
                        item.fecha = String.Format("{0:MM/dd/yyyy}", System.DateTime.Now.Date.ToShortDateString());
                        item.hora = System.DateTime.Now.ToString("HH:mm");
                        item.codEmpleado = Convert.ToInt32(Session["idEmpleado"].ToString());
                        break;
                    }
                }
            }
            txtDescripcion.Text = "";
            txtCodigoCliente.Text = "";
            actualizarTurno();
        }

        private void actualizarTurno()
        {
            bool hayDatos = false;
            if (Session["consulta"] != null)
            {
                consultaEnCola = (List<AtencionCliente>)Session["consulta"];
                foreach (var consulta in consultaEnCola)
                {
                    if (consulta.estadoAtencion == 1)
                    {
                        hayDatos = true;
                        Session["turnoActual"] = consulta.turnoAtencion;
                        lblTurno.Text = "Turno # -- " + consulta.turnoAtencion;
                        break;
                    }
                }
                if (!hayDatos)
                {
                    lblTurno.Text = "No hay solicitudes en cola actualmente.";
                }
            }
            else
            {
                lblTurno.Text = "No hay solicitudes en cola actualmente.";
                btnConcluirAtencion.Enabled = false;
                btnGuardarBD.Enabled = false;
            }
        }

        public void mensajeAlerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "')</script>");
        }

        protected void btnGuardarBD_Click(object sender, EventArgs e)
        {
            if (Session["consulta"] != null)
            {
                consultaEnCola = (List<AtencionCliente>)Session["consulta"];//Capturo todos los datos en la lista si?
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                foreach (var item in consultaEnCola)
                {
                    if (item.estadoAtencion == 2)
                    {
                        SqlCommand comando = new SqlCommand("INSERT INTO atencionCliente(FK_idCliente,FK_idTrabajador,FK_codEstado,fechaConsulta,horaConsulta,descripcionProblema,numeroTurno) values(" +
                        item.codCliente + "," + item.codEmpleado + "," + item.estadoAtencion + ",'" + item.fecha + "','" + item.hora + "','" + item.descProblema + "','" + item.turnoAtencion + "')", conexion);

                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
                mensajeAlerta("Trabajo Guardado");
            }
            else
            {
                mensajeAlerta("No hay información para guardar!");
            }
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            string txtComando = "Select estadoCuenta from cliente where idCliente = " + Convert.ToInt32(txtCodigoCliente.Text) + "and estadoCuenta = " + 1;
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand(txtComando, conexion);
            conexion.Open();
            SqlDataReader llenarTabla = comando.ExecuteReader();

            if (!llenarTabla.Read())
            {
                mensajeAlerta("Código no existente");
                txtCodigoCliente.Text = "";
            }
            conexion.Close();
        }
    }
}