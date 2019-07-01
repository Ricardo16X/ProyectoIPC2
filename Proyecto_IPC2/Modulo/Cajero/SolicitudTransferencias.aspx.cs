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
    public partial class SolicitudTransferencias : System.Web.UI.Page
    {
        List<Transferencia> colaTransferencia = new List<Transferencia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["rol"].ToString() == "cajero"))
            {
                Response.Redirect("~/Cuentas/Login.aspx");
            }
            if (!IsPostBack)
            {
                actualizarLista();
            }
            
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (Session["colaTransferencia"] != null && (int)Session["ultimo"] > 0)
            {
                int matchActual = (int)Session["actual"];
                int ultimo = (int)Session["ultimo"];
                int primero = (int)Session["primero"];

                colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];

                //Si Actual es igual a Primero entonces Buscaré al último disponible...
                if (matchActual == primero)
                {
                    foreach (var item in colaTransferencia)
                    {
                        if (item.estadoTransferencia == 1)
                        {
                            if (matchActual == ultimo)
                            {
                                txtMonto.Text = item.monto.ToString();
                                txtbancoDestino.Text = item.bancoDestino;
                                txtcodCliente.Text = item.idCliente.ToString();
                                Session["actual"] = matchActual;
                                break;
                            }
                            else
                            {
                                matchActual++;
                            }
                        }
                    }
                }
                else
                {
                    int actual = 1;
                    foreach (var item in colaTransferencia)
                    {
                        if (item.estadoTransferencia == 1)
                        {
                            if (actual == (matchActual - 1))
                            {
                                txtMonto.Text = item.monto.ToString();
                                txtbancoDestino.Text = item.bancoDestino;
                                txtcodCliente.Text = item.idCliente.ToString();
                                Session["actual"] = actual;
                                break;
                            }
                            else
                            {
                                actual++;
                            }
                        }
                    }
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Session["colaTransferencia"] != null && (int)Session["ultimo"] > 0)
            {
                int matchActual = (int)Session["actual"];
                int ultimo = (int)Session["ultimo"];
                int primero = (int)Session["primero"];

                colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];

                //Si Actual es igual a Primero entonces Buscaré al último disponible...
                if (matchActual == ultimo)
                {
                    matchActual = 1;
                    foreach (var item in colaTransferencia)
                    {
                        if (item.estadoTransferencia == 1)
                        {
                            if (matchActual == primero)
                            {
                                txtMonto.Text = item.monto.ToString();
                                txtbancoDestino.Text = item.bancoDestino;
                                txtcodCliente.Text = item.idCliente.ToString();
                                Session["actual"] = matchActual;
                                break;
                            }
                            else
                            {
                                matchActual++;
                            }
                        }
                    }
                }
                else
                {
                    int actual = 1;
                    foreach (var item in colaTransferencia)
                    {
                        if (item.estadoTransferencia == 1)
                        {
                            if (actual == (matchActual + 1))
                            {
                                txtMonto.Text = item.monto.ToString();
                                txtbancoDestino.Text = item.bancoDestino;
                                txtcodCliente.Text = item.idCliente.ToString();
                                Session["actual"] = actual;
                                break;
                            }
                            else
                            {
                                actual++;
                            }
                        }
                    }
                }
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            //Instrucciones de procesar actual
            if (Session["colaTransferencia"] != null)
            {
                colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];
                int match = 1;
                int actual = (int)Session["actual"];
                foreach (var item in colaTransferencia)
                {
                    if (match == actual)
                    {
                        if (item.estadoTransferencia == 1)
                        {
                            item.estadoTransferencia = 2;
                            break;
                        }
                    }
                    else
                    {
                        match++;
                    }
                }
            }
            //Actualizacion de solicitudes pendientes
            actualizarLista();
        }

        protected void btnGuardarTrabajo_Click(object sender, EventArgs e)
        {
            //Instrucciones para el guardado en la BD
            if (Session["colaTransferencia"] != null)
            {
                colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");

                foreach (var item in colaTransferencia)
                {
                    SqlCommand comando = new SqlCommand("INSERT INTO transferencia(FK_idCliente,FK_idTrabajador,FK_estado,bancoDestino,fecha,hora,monto,horaInicio,horaFinal) " +
                        "values(" + item.idCliente + ","
                                  + item.idTrabajador + ","
                                  + item.estadoTransferencia + ",'"
                                  + item.bancoDestino + "','"
                                  + item.fecha + "','"
                                  + item.hora + "',"
                                  + item.monto + ",'" 
                                  + item.horaInicio + "','" 
                                  + item.horaFinal + "')", conexion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                //Borrar la memoria???
                colaTransferencia.Clear();
                Session["colaTransferencia"] = colaTransferencia;
            }

        }

        public void actualizarLista()
        {
            if (Session["colaTransferencia"] != null)
            {
                bool primero = false;
                int matchActual = 1;
                int ultimo = 0;
                int primer = 0;
                colaTransferencia = (List<Transferencia>)Session["colaTransferencia"];

                if (colaTransferencia.Count > 1)
                {
                    foreach (var item in colaTransferencia)
                    {
                        if (item.estadoTransferencia == 1)
                        {
                            if (primero == false)
                            {
                                Session["primero"] = matchActual;
                                //Solo para pruebas
                                primer = matchActual;
                                //
                                txtcodCliente.Text = item.idCliente.ToString();
                                txtbancoDestino.Text = item.bancoDestino.ToString();
                                txtMonto.Text = item.monto.ToString();
                                primero = true;
                                btnAnterior.Enabled = true;
                                btnSiguiente.Enabled = true;
                                btnProcesar.Enabled = true;
                            }
                            else
                            {
                                matchActual++;
                                ultimo = matchActual;
                            }
                        }
                    }
                    //Al finalizar de cargar todas las solicitudes pendientes siempre va a empezar desde (PRIMERO) que esté disponible.
                    if (primero)
                    {
                        Session["actual"] = primer;
                        Session["ultimo"] = ultimo;
                    }
                    else
                    {
                        Response.Write("<script>alert('No hay solicitudes pendientes para trabajar!!!')</script>");
                        txtbancoDestino.Text = "";
                        txtcodCliente.Text = "";
                        txtMonto.Text = "";
                        btnAnterior.Enabled = false;
                        btnSiguiente.Enabled = false;
                        btnProcesar.Enabled = false;
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('No hay solicitudes pendientes para trabajar!!!')</script>");
            }
        }
    }
}