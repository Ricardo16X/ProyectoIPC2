using Proyecto_IPC2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Proyecto_IPC2.Modulo.Cajero
{
    public partial class GestionChequera : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
        List<Chequera> colaChequera;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rol"] != null)
                {
                    if (Session["rol"].ToString() == "cajero")
                    {
                        horaActual.Text = System.DateTime.Now.ToString("HH:mm");
                        fechaActual.Text = String.Format("{0:MM/dd/yyyy}", System.DateTime.Now.Date.ToShortDateString());

                        txtCodChequera.Enabled = false;
                        //Actualizar Número de Chequera, solamente para dejarlo más accesible a cambios------------------------------------------------
                        if (Session["codChequera"] == null)
                        {
                            SqlCommand comando = new SqlCommand("SELECT max(idChequera) 'idChequera' from chequera", conexion);
                            conexion.Open();
                            SqlDataReader lector = comando.ExecuteReader();
                            if (lector.Read())
                            {
                                try
                                {
                                    Session["codChequera"] = Convert.ToInt32(lector["idChequera"].ToString()) + 1;
                                    txtCodChequera.Text = Session["codChequera"].ToString();
                                }
                                catch (Exception)
                                {
                                    Session["codChequera"] = 1;
                                    txtCodChequera.Text = Session["codChequera"].ToString();
                                }
                            }
                            else
                            {
                                Session["codChequera"] = 1;
                                txtCodChequera.Text = Session["codChequera"].ToString();
                            }
                            lector.Close();
                            conexion.Close();
                        }
                        //---------------------------------------------------------------------------------------------------------------------------
                        actualizarTurno();
                    }
                    else
                    {
                        Response.Redirect("~/Cuentas/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Cuentas/Login.aspx");
                }
            }
        }

        private void actualizarTurno()
        {
            //Solamente para mostrar los turnos en cola.
            bool hayDatos = false;
            if (Session["colaChequera"] != null)
            {
                colaChequera = new List<Chequera>();
                colaChequera = (List<Chequera>)Session["colaChequera"];
                foreach (var item in colaChequera)
                {
                    if (item.estadoChequera == 0)
                    {
                        hayDatos = true;
                        Session["turnoChequeraCola"] = item.turno;
                        lblTurno.Text = "Turno #" + item.turno.ToString();
                        break;
                    }
                }
                if (!hayDatos) { lblTurno.Text = "No hay solicitudes en cola actualmente."; btnOperacion.Enabled = false; limpiar(); }
            }
            else
            {
                lblTurno.Text = "No hay solicitudes en cola actualmente.";
                btnOperacion.Enabled = false;
                limpiar();
            }
        }

        protected void txtCodChequera_TextChanged(object sender, EventArgs e)
        {
            if (delChequera.Checked || upChequera.Checked)
            {
                //Verificar que el estado de la chequera sea Solicitud y que la Chequera Exista
                SqlCommand comando = new SqlCommand("select FK_codEstado,FK_idCliente from chequera where FK_codEstado = " + 1
                    + "and idChequera = " + Convert.ToInt32(txtCodChequera.Text), conexion);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    txtCodClient.Text = lector["FK_idCliente"].ToString();
                }
                else
                {
                    mensaje("No hay ninguna chequera con este código.");
                    txtCodChequera.Text = "";
                    txtCodClient.Text = "";
                }
            }
            else if (darChequera.Checked)
            {
                //Verificar que el estado de la chequera sea IMPRESO y que la Chequera Exista
                SqlCommand comando = new SqlCommand("select FK_codEstado,FK_idCliente from chequera where FK_codEstado = " + 2
                    + "and idChequera = " + Convert.ToInt32(txtCodChequera.Text), conexion);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    txtCodClient.Text = lector["FK_idCliente"].ToString();
                }
                else
                {
                    mensaje("No hay ninguna chequera impresa con este código.");
                    txtCodChequera.Text = "";
                    txtCodClient.Text = "";
                }
            }
        }

        protected void regChequera_CheckedChanged(object sender, EventArgs e)
        {
            btnOperacion.Text = "Crear Solicitud";
            txtCodChequera.Enabled = false;
            if (!(Session["codChequera"] == null))
            {
                txtCodChequera.Text = Session["codChequera"].ToString();
            }
            //Seleccionar el lote más próximo con chequeras disponibles.
            SqlCommand buscarChequeraDisponible = new SqlCommand("select min(idLote) 'idLote', cantidadActual " +
                "from lote where lote.cantidadActual > " + 0 +
                " group by cantidadActual", conexion);
            conexion.Open();
            SqlDataReader lectorChequera = buscarChequeraDisponible.ExecuteReader();
            //Si hay chequeras disponibles en el lote más próximo, entonces tomo el código de LOTE
            if (lectorChequera.Read()) 
            {
                //Si no hay más chequeras disponibles
                if ((int)lectorChequera["cantidadActual"] <= 0)
                {
                    mensaje("No hay chequeras disponibles.");
                    limpiar();
                    btnOperacion.Enabled = false;
                }
                else if ((int)lectorChequera["cantidadActual"] < 10 && (int)lectorChequera["cantidadActual"] > 0) //Si hay pocas chequeras
                {
                    mensaje("Lote No. " + lectorChequera["idLote"].ToString() + " quedandose sin suministros.");
                    try { Session["codLote"] = Convert.ToInt32(lectorChequera["idLote"].ToString()); }
                    catch (Exception)
                    {
                        mensaje("Se han acabado las Chequeras");
                        limpiar();
                        btnOperacion.Enabled = false;
                    }
                }
                else
                {
                    try { Session["codLote"] = Convert.ToInt32(lectorChequera["idLote"].ToString()); }
                    catch (Exception)
                    {
                        mensaje("Se han acabado las Chequeras");
                        limpiar();
                        btnOperacion.Enabled = false;
                    }
                }
            }
            else
            {
                mensaje("No hay chequeras disponibles. \\nComuniquese con el Administrador");
                limpiar();
                btnOperacion.Enabled = false;
            }
            lectorChequera.Close();
            conexion.Close();
        }

        protected void darChequera_CheckedChanged(object sender, EventArgs e) { btnOperacion.Text = "Entregar Chequera"; txtCodChequera.Text = ""; txtCodClient.Text = ""; }

        protected void upChequera_CheckedChanged(object sender, EventArgs e) { btnOperacion.Text = "Actualizar Solicitud"; txtCodChequera.Text = ""; txtCodClient.Text = ""; txtCodChequera.Enabled = true; }

        protected void delChequera_CheckedChanged(object sender, EventArgs e) { btnOperacion.Text = "Eliminar Solicitud"; txtCodChequera.Text = ""; txtCodClient.Text = ""; txtCodChequera.Enabled = true; }

        private void limpiar()
        {
            txtCodChequera.Text = "";
            txtCodClient.Text = "";
            txtCodChequera.Enabled = true;
            regChequera.Checked = false;
            darChequera.Checked = false;
            upChequera.Checked = false;
            delChequera.Checked = false;
        }

        private void mensaje(string alerta) { Response.Write("<script>alert('" + alerta + "')</script>"); }

        protected void btnOperacion_Click(object sender, EventArgs e)
        {
            if (txtCodChequera.Text != "" && txtCodClient.Text != "")
            {
                if (regChequera.Checked)
                {
                    //Registrar Solicitud de Chequera...
                    colaChequera = new List<Chequera>();
                    colaChequera = (List<Chequera>)Session["colaChequera"];

                    foreach (var item in colaChequera)
                    {
                        if (item.turno == (int)Session["turnoChequeraCola"] && item.estadoChequera == 0)
                        {
                            //Si estoy atendiendo al turno actual capturado y su estado de chequera es igual a 0
                            //Y además lo estoy registrando, pasa a estado 1 que es de SOLICITUD
                            //Y si tiene suerte, lo paso a estado 2 que es IMPRESO
                            int random = numRandom();
                            if (random > 0 && random < 5) { item.estadoChequera = 2; }
                            else { item.estadoChequera = 1; }

                            item.idCliente = Convert.ToInt32(txtCodClient.Text);
                            item.fecha = fechaActual.Text;
                            item.hora = horaActual.Text;
                            item.idTrabajador = Convert.ToInt32(Session["idEmpleado"].ToString());
                            item.idLote = (int)Session["codLote"];
                            break;
                        }
                    }
                    limpiar();
                    Session["codChequera"] = (int)Session["codChequera"] + 1;
                    actualizarTurno();
                }
                else if (upChequera.Checked)
                {
                    //Actualizar Solicitud de Chequera...
                    SqlCommand comando = new SqlCommand("UPDATE chequera set FK_idCliente = " + Convert.ToInt32(txtCodClient.Text), conexion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    mensaje("Chequera con datos Actualizada");
                    limpiar();
                }
                else if (delChequera.Checked)
                {
                    //Eliminar Solicitud de Chequera...
                    SqlCommand comando = new SqlCommand("delete from chequera where idChequera = " + Convert.ToInt32(txtCodChequera.Text), conexion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    mensaje("Chequera Eliminada");
                    limpiar();
                }
                else if (darChequera.Checked)
                {
                    //Entregar Chequera...
                    SqlCommand comando = new SqlCommand("UPDATE chequera set FK_codEstado = " + 3 +
                        " where FK_idCliente = " + Convert.ToInt32(txtCodClient.Text) +
                        " and idChequera = " + Convert.ToInt32(txtCodChequera.Text), conexion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    mensaje("Chequera Entregada");
                    limpiar();
                }
                else { mensaje("Escoge primero una acción..."); }
            }
        }

        //Generar un número random para ver si cumple cierto tipo pasa de estado SOLICITUD a IMPRESO
        private int numRandom()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int numero = r.Next(0, 10);
            return numero;
        }

        protected void txtCodClient_TextChanged(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("SELECT idCliente, estadoCuenta FROM cliente WHERE estadoCuenta = " + 1
                + "and idCliente = '" + txtCodClient.Text + "'", conexion);
            conexion.Open();
            SqlDataReader lector = comando.ExecuteReader();
            if (!lector.Read())
            {
                mensaje("Código de Cliente Inexistente.");
                txtCodClient.Text = "";
            }
            lector.Close();
            conexion.Close();
        }

        //Botón para guardar trabajo en base de datos...
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool hayDatos = false;
            if (Session["colaChequera"] != null)
            {
                colaChequera = new List<Chequera>();
                colaChequera = (List<Chequera>)Session["colaChequera"];
                foreach (var item in colaChequera)
                {
                    if (item.estadoChequera != 0 && item.estadoChequera != 3 && item.estadoChequera != 4)
                    {
                        hayDatos = true;
                        SqlCommand comando = new SqlCommand("insert into chequera values(" +
                            item.idCliente + "," +
                            item.idLote + "," +
                            item.idTrabajador + "," +
                            item.estadoChequera + ",'" +
                            item.fecha + "','" +
                            item.hora + "')", conexion);
                        //Este cuatro impedirá que se entre de nuevo, los datos de la lista que ya se encuentren en la BD
                        item.estadoChequera = 4;
                        //Si lo pongo en cero, se volverá a contar el turno :(
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
                if (!hayDatos) { mensaje("No hay solicitudes válidas para Guardar"); }
            }
            else { mensaje("No hay datos que guardar!"); }
            //Elimino toda relación con codChequera al guardar en la BD
            Session["codChequera"] = null;
        }
    }
}
