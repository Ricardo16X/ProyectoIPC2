using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Cuentas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["rol"] = null;
                Session["idEmpleado"] = null;
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //Primero verificaré, que los datos ingresados correspondan a un trabajador.
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            string comando = "Select idTrabajador, FK_codTipo, estadoCuenta from trabajador " +
                            "where usuario = '" + txtUsuario.Text + "' " +
                            "and contraseña = '" + txtPass.Text + "' " +
                            "and estadoCuenta = " + 1;
            //Datos para un cliente
            string comandoClient = "Select nombre, estadoCuenta from cliente " +
                            "where (usuario = '" + txtUsuario.Text + "' " +
                            "and contraseña = '" + txtPass.Text + "') " +
                            "and estadoCuenta = " + 1;
            conexion.Open();
            SqlCommand cmd = new SqlCommand(comando, conexion);
            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                //Redirección a la página de Administrador
                if (lector["FK_codTipo"].ToString() == "3" && lector["estadoCuenta"].ToString() == "True")
                {
                    Session["idEmpleado"] = lector["idTrabajador"].ToString();
                    Session["rol"] = "administrador";
                    Response.Redirect("~/Modulo/Admin/RegistrarUsuario.aspx");
                }
                //Redirección a la página de Cajero
                else if (lector["FK_codTipo"].ToString() == "1" && lector["estadoCuenta"].ToString() == "True")
                {
                    Session["idEmpleado"] = lector["idTrabajador"].ToString();
                    Session["rol"] = "cajero";
                    Response.Redirect("~/Modulo/Cajero/GestionTransferencia.aspx");
                }
                //Redirección a la página de Atención al Cliente
                else if (lector["FK_codTipo"].ToString() == "2" && lector["estadoCuenta"].ToString() == "True")
                {
                    Session["idEmpleado"] = lector["idTrabajador"].ToString();
                    Session["rol"] = "agente";
                    Response.Redirect("~/Modulo/Agente/AtenderCliente.aspx");
                }
                
                lector.Close();
            }
            else
            {
                lector.Close();
                SqlCommand comandClient = new SqlCommand(comandoClient, conexion);
                SqlDataReader lectorC = comandClient.ExecuteReader();
                if (lectorC.Read())
                {
                    if (lectorC["estadoCuenta"].ToString() == "True")
                    {
                        mensajeAlerta("Bienvenido Cliente: " + lectorC["nombre"]);
                    }
                    else
                    {
                        mensajeAlerta("Usuario o Contraseña Incorrectos");
                    }
                }
                else
                {
                    mensajeAlerta("Usuario o Contraseña Incorrectos");
                }
            }
            conexion.Close();
        }

        public void mensajeAlerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "')</script>");
        }
    }
}