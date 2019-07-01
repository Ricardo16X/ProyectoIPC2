using Proyecto_IPC2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo.Cajero
{
    public partial class GestionTransferencia : System.Web.UI.Page
    {
        List<Transferencia> colaTransferencia;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"].ToString() == "cajero")
            {
                if (!IsPostBack)
                {
                    //Dejar entrar
                    actualizarTurno();
                }
                horaActual.Text = System.DateTime.Now.ToString("HH:mm");
                fechaActual.Text = String.Format("{0:MM/dd/yyyy}", System.DateTime.Now.Date.ToShortDateString());
            }
            else
            {
                Response.Redirect("~/Cuentas/Login.aspx");
            }
        }

        private void actualizarTurno()
        {
            //Solamente para mostrar los turnos en cola.
            bool hayDatos = false;
            if (Session["colaTransferencia"] != null)
            {
                //Declararlo como nuevo por si da error.
                colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];
                foreach (var item in colaTransferencia)
                {
                    if (item.estadoTransferencia == 0)
                    {
                        hayDatos = true;
                        Session["turnoTrans"] = item.ticket;
                        turno.Text = "Turno #" + item.ticket.ToString();
                        break;
                    }
                }
                if (!hayDatos)
                {
                    turno.Text = "No hay solicitudes en cola actualmente.";
                }
            }
            else
            {
                turno.Text = "No hay solicitudes en cola actualmente.";
                btnOperacion.Enabled = false;
                limpiar();
            }
        }

        protected void rbtnCrear_CheckedChanged(object sender, EventArgs e)
        {
            limpiar();
            btnOperacion.Text = "Crear Solicitud";
            TextBox1.Enabled = false;
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand("select max(idTransferencia) as 'idTransferencia' from transferencia", conexion);
            SqlDataReader lector;
            conexion.Open();
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                try
                {
                    TextBox1.Text = (Convert.ToInt32(lector["idTransferencia"].ToString()) + 1).ToString();
                }
                catch (Exception)
                {
                    TextBox1.Text = "1";
                }
            }
            else
            {
                TextBox1.Text = "1";
            }
            lector.Close();
            conexion.Close();
        }

        protected void rbtnModificar_CheckedChanged(object sender, EventArgs e)
        {
            btnOperacion.Text = "Modificar Solicitud";
            TextBox1.Enabled = true;
            limpiar();
        }

        protected void rbtnEliminar_CheckedChanged(object sender, EventArgs e)
        {
            btnOperacion.Text = "Eliminar Solicitud";
            TextBox1.Enabled = true;
            limpiar();
        }

        protected void btnOperacion_Click(object sender, EventArgs e)
        {
            colaTransferencia = new List<Transferencia>();
            if (rbtnCrear.Checked)
            {
                if (Session["colaTransferencia"] != null)
                {
                    colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];
                }
                foreach (var item in colaTransferencia)
                {
                    if (item.ticket == (int)Session["turnoTrans"] && item.estadoTransferencia == 0)
                    {
                        item.fecha = fechaActual.Text;
                        item.hora = horaActual.Text;
                        item.bancoDestino = txtbancoDestino.Text;
                        item.idCliente = Convert.ToInt32(txtcodCliente.Text);
                        item.idTrabajador = Convert.ToInt32(Session["idEmpleado"].ToString());
                        item.monto = Convert.ToDouble(txtMonto.Text);
                        item.horaInicio = txtHoraInicio.Text;
                        item.horaFinal = txtHoraFinal.Text;
                        item.estadoTransferencia = 1;
                        break;
                    }
                }
                Session["colaTransferencia"] = colaTransferencia;
                limpiar();
            }
            else if (rbtnModificar.Checked)
            {
                //Actualizar Datos
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                string txtComando = "update transferencia set bancoDestino = '" +
                        "',monto = " + Convert.ToDouble(txtMonto.Text) +
                        ",horaInicio = '" + txtHoraInicio.Text +
                        "',horaFinal = '" + txtHoraFinal.Text +
                        "' where idTransferencia = " + Convert.ToInt32(TextBox1.Text);
                SqlCommand comando = new SqlCommand(txtComando, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                limpiar();
            }
            else if (rbtnEliminar.Checked)
            {
                //Eliminar datos
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                string txtComando = "delete from transferencia where idTransferencia = " + Convert.ToInt32(TextBox1.Text);
                SqlCommand comando = new SqlCommand(txtComando, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
                limpiar();
            }
            else
            {
                Response.Write("<script>alert('Elige una acción...')</script>");
            }
            actualizarTurno();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (rbtnEliminar.Checked || rbtnModificar.Checked)
            {
                if (TextBox1.Text != "")
                {
                    string txtComando = "Select FK_idCliente,bancoDestino,monto,horaInicio,horaFinal from transferencia where idTransferencia = " + Convert.ToInt32(TextBox1.Text);
                    SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                    SqlCommand comando = new SqlCommand(txtComando, conexion);
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();

                    //Llenar TextBox con Información
                    try
                    {
                        if (lector.Read())
                        {
                            txtcodCliente.Text = lector["FK_idCliente"].ToString();
                            txtbancoDestino.Text = lector["bancoDestino"].ToString();
                            txtMonto.Text = lector["monto"].ToString();
                            txtHoraInicio.Text = lector["horaInicio"].ToString();
                            txtHoraFinal.Text = lector["horaFinal"].ToString();
                        }
                        else
                        {
                            Response.Write("<script>alert('Sin Resultados, Transferencia Inexistente')</script>");
                        }
                    }
                    catch (Exception)
                    {
                    }
                    conexion.Close();
                }
                else
                {
                    Response.Write("<script>alert('Escribir Código de Cliente')</script>");
                }
            }
        }

        protected void limpiar()
        {
            TextBox1.Text = "";
            txtcodCliente.Text = "";
            txtbancoDestino.Text = "";
            txtHoraFinal.Text = "";
            txtHoraInicio.Text = "";
            txtMonto.Text = "";
        }

        protected void txtcodCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtcodCliente.Text != "")
            {
                try
                {
                    string txtComando = "Select estadoCuenta from cliente where idCliente = " + Convert.ToInt32(txtcodCliente.Text) + "and estadoCuenta = " + 1;
                    SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                    SqlCommand comando = new SqlCommand(txtComando, conexion);
                    conexion.Open();
                    SqlDataReader llenarTabla = comando.ExecuteReader();

                    if (!llenarTabla.Read())
                    {
                        Response.Write("<script>alert('Código de Cliente no Existe')</script>");
                        txtcodCliente.Text = "";
                    }
                    conexion.Close();
                }
                catch (Exception)
                {
                    txtcodCliente.Text = "";
                    mensaje("Código de Cliente no es Válido");
                }
            }
        }

        public void mensaje(string alerta)
        {
            Response.Write("<script>alert('" + alerta + "')</script>");
        }
    }
}