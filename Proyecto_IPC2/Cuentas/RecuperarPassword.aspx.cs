using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Cuentas
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){}

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //Verificar que ambos campos tengan texto
            if (txtCodEmpleado.Text != "" && txtPalabraClave.Text != "")
            {
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");

                //Comando para cuentas de Trabajadores..
                string comando = "Select * From trabajador " +
                                "where idTrabajador = '" + txtCodEmpleado.Text + "' " +
                                "and palabraClave = '" + txtPalabraClave.Text + "' " +
                                "and estadoCuenta = " + 1;
                conexion.Open();

                //Lector para Trabajadores
                SqlCommand cmdTrabajador = new SqlCommand(comando, conexion);
                SqlDataReader lector = cmdTrabajador.ExecuteReader();
                if (lector.Read())
                {
                    Session["codEmpleado"] = lector["idTrabajador"].ToString();
                    Panel1.Visible = true;
                    txtCodEmpleado.Enabled = false;
                    txtPalabraClave.Enabled = false;
                    txtCodEmpleado.Text = "";
                    txtPalabraClave.Text = "";
                    Session["encontrarEmpleado"] = true;
                    Session["encontrarCliente"] = false;
                }
                lector.Close();
                conexion.Close();
            }
            else
            {
                mensajeAlerta("Ambo Campos son Obligatorios");
            }
        }

        public void mensajeAlerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "')</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals(txtRepeatPass.Text) && txtPass.Text != "")
            {
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                string comando = "";
                comando = "update trabajador set contraseña = " + "'" + txtPass.Text + "' " +
                                "where idTrabajador = '" + Session["codEmpleado"] + "' ";
                SqlCommand cmd = new SqlCommand(comando, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
                mensajeAlerta("Cambio Realizado");
                Response.Redirect("Login.aspx");
            }
            else
            {
                mensajeAlerta("Las nuevas contraseñas deben de coincidir...");
            }
        }
    }
}