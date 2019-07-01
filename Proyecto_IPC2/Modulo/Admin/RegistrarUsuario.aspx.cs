using Proyecto_IPC2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo.Admin
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["rol"] != null)
                {
                    if (Session["rol"].ToString() == "administrador")
                    {
                        txtFechaNac.Attributes.Add("placeholder", "dd/mm/aaaa");
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
                }
            }
            
        }

        public void BotonEnviar_Click(object sender, EventArgs e)
        {
            string txtComando;
            int codTipo = 0;
            if (rbtnAgente.Checked || rbtnCajero.Checked)
            {
                if (rbtnCajero.Checked) { codTipo = 1; }
                else if (rbtnAgente.Checked) { codTipo = 2; }
                if (Registrar.Checked)
                {
                    GestionTrabajador trabajador = new GestionTrabajador(codTipo, txtDPI.Text, txtNombre.Text, txtApellido.Text, txtFechaNac.Text, txtEmail.Text, txtTel.Text, txtUser.Text, txtPass.Text, txtRecovery.Text);
                    trabajador.escribirInformacion(trabajador);
                    mensajeAlerta("Datos Registrados");
                    LimpiarCampos();
                }
                else if (Modificar.Checked)
                {
                    txtComando = "update trabajador set dpi = '" + txtDPI.Text + "'," +
                            "nombre = '" + txtNombre.Text + "'," +
                            "apellido = '" + txtApellido.Text + "'," +
                            "fechaNacimiento = '" + txtFechaNac.Text + "'," +
                            "correo = '" + txtEmail.Text + "'," +
                            "telefono = '" + txtTel.Text + "'," +
                            "usuario = '" + txtUser.Text + "'," +
                            "contraseña = '" + txtPass.Text + "'," +
                            "palabraClave = '" + txtRecovery.Text + "'" +
                            "where idTrabajador = " + Convert.ToInt32(txtCodigoCliente.Text);
                    SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                    SqlCommand comando = new SqlCommand(txtComando, conexion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    mensajeAlerta("Datos Actualizados");
                    LimpiarCampos();
                }
                else if (Eliminar.Checked)
                {
                    txtComando = "update trabajador set estadoCuenta = " + 0 +
                        " where idTrabajador = " + Convert.ToInt32(txtCodigoCliente.Text);
                    SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                    SqlCommand comando = new SqlCommand(txtComando, conexion);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    mensajeAlerta("Datos Eliminados");
                    LimpiarCampos();
                }
                else
                {
                    mensajeAlerta("Elija una acción a realizar!");
                }
            }
            else
            {
                mensajeAlerta("Elija un tipo de Trabajador");
            }

        }

        public void mensajeAlerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "')</script>");
        }

        protected void Registrar_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarCampos();
            BotonEnviar.Text = "Registrar";
            txtCodigoCliente.Enabled = false;
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand("select max(idCliente) as 'idCliente' from cliente", conexion);
            SqlDataReader lector;
            conexion.Open();
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                try
                {
                    txtCodigoCliente.Text = (Convert.ToInt32(lector["idCliente"].ToString()) + 1).ToString();
                }
                catch (Exception)
                {
                    txtCodigoCliente.Text = "1";
                }
            }
            else
            {
                txtCodigoCliente.Text = "1";
            }
            lector.Close();
            conexion.Close();
        }

        protected void Modificar_CheckedChanged(object sender, EventArgs e)
        {
            BotonEnviar.Text = "Actualizar";
            txtCodigoCliente.Enabled = true;
        }

        protected void Eliminar_CheckedChanged(object sender, EventArgs e)
        {
            BotonEnviar.Text = "Eliminar";
            txtCodigoCliente.Enabled = true;
        }

        protected void txtCodigoCliente_TextChanged(object sender, EventArgs e)
        {
            string txtComando = "Select FK_codTipo,dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave from trabajador where idTrabajador = " + Convert.ToInt32(txtCodigoCliente.Text) + 
                " and estadoCuenta = " + 1;
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand(txtComando, conexion);
            conexion.Open();
            DataTable tablita = new DataTable();
            SqlDataAdapter llenarTabla = new SqlDataAdapter(txtComando, conexion);

            llenarTabla.Fill(tablita);
            //Llenar TextBox con Información
            try
            {
                txtDPI.Text = tablita.Rows[0]["dpi"].ToString();
                txtNombre.Text = tablita.Rows[0]["nombre"].ToString();
                txtApellido.Text = tablita.Rows[0]["apellido"].ToString();
                txtFechaNac.Text = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(tablita.Rows[0]["fechaNacimiento"]));
                txtEmail.Text = tablita.Rows[0]["correo"].ToString();
                txtTel.Text = tablita.Rows[0]["telefono"].ToString();
                txtUser.Text = tablita.Rows[0]["usuario"].ToString();
                txtPass.Text = tablita.Rows[0]["contraseña"].ToString();
                txtRecovery.Text = tablita.Rows[0]["palabraClave"].ToString();

                if (tablita.Rows[0]["FK_codTipo"].ToString() == "1")
                {
                    rbtnAgente.Checked = false;
                    rbtnCajero.Checked = true;
                }else if(tablita.Rows[0]["FK_codTipo"].ToString() == "2")
                {
                    rbtnCajero.Checked = false;
                    rbtnAgente.Checked = true;
                }
            }
            catch (Exception)
            {
                mensajeAlerta("Sin Resultados!");
                LimpiarCampos();
            }
            conexion.Close();
        }

        private void LimpiarCampos()
        {
            rbtnAgente.Checked = false;
            rbtnCajero.Checked = false;
            txtCodigoCliente.Text = "";
            txtDPI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtFechaNac.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtRecovery.Text = "";
        }
    }
}