using Proyecto_IPC2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Cuentas
{
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtFechaNac.Attributes.Add("placeholder", "dd/mm/aaaa");
        }

        protected void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                GestionTrabajador cliente = new GestionTrabajador(txtDPI.Text, txtNombre.Text, txtApellido.Text, txtFechaNac.Text, txtEmail.Text, txtTel.Text, txtUser.Text, txtPass.Text, txtRecovery.Text);
                cliente.registrarCliente(cliente);
                limpiarCampos();
                Response.Write("<script>alert('Operación Realizada con Éxito')</script>");
            }
            else if (RadioButton2.Checked)
            {
                GestionTrabajador modCliente = new GestionTrabajador();
                modCliente.actualizarCliente(Convert.ToInt32(txtCodCliente.Text), txtDPI.Text, txtNombre.Text, txtApellido.Text, txtFechaNac.Text, txtEmail.Text, txtTel.Text, txtUser.Text, txtPass.Text, txtRecovery.Text);
                limpiarCampos();
                Response.Write("<script>alert('Operación Realizada con Éxito')</script>");
            }
            else if (RadioButton3.Checked)
            {
                GestionTrabajador eliminarCliente = new GestionTrabajador();
                eliminarCliente.eliminarCliente(Convert.ToInt32(txtCodCliente.Text));
                limpiarCampos();
                Response.Write("<script>alert('Operación Realizada con Éxito')</script>");
            }
            else
            {
                Response.Write("<script>alert('Ha ocurrido un error, verifique los campos ingresados')</script>");
            }
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btnRegistrarCliente.Text = "Registrar";
            txtCodCliente.Enabled = false;
            limpiarCampos();
            txtPass.Text = PassWord();
            txtUser.Text = (PassWord()).Substring(0,3);
            try
            {
                SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
                SqlCommand comando = new SqlCommand("select max(idCliente) as 'idCliente' from cliente", conexion);
                SqlDataReader lector;
                conexion.Open();
                lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    try
                    {
                        txtCodCliente.Text = (Convert.ToInt32(lector["idCliente"].ToString()) + 1).ToString();
                    }
                    catch (Exception)
                    {
                        txtCodCliente.Text = "1";
                    }
                }
                else
                {
                    txtCodCliente.Text = "1";
                }
                lector.Close();
                conexion.Close();
            }
            catch (Exception)
            {
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btnRegistrarCliente.Text = "Modificar";
            limpiarCampos();
            txtCodCliente.Enabled = true;
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            btnRegistrarCliente.Text = "Eliminar";
            limpiarCampos();
            txtCodCliente.Enabled = true;
        }

        private void limpiarCampos()
        { 
            txtCodCliente.Text = "";
            txtDPI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTel.Text = "";
            txtEmail.Text = "";
            txtFechaNac.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            txtRecovery.Text = "";
        }

        private string PassWord()
        {
            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 8;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
            }
            return contraseniaAleatoria;
        }

        protected void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            string txtComando = "Select dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave from cliente where idCliente = " + Convert.ToInt32(txtCodCliente.Text) + "and estadoCuenta = " + 1;
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            SqlCommand comando = new SqlCommand(txtComando, conexion);
            conexion.Open();
            SqlDataReader llenarTabla = comando.ExecuteReader();

            if (llenarTabla.Read())
            {
                txtDPI.Text = llenarTabla["dpi"].ToString();
                txtNombre.Text = llenarTabla["nombre"].ToString();
                txtApellido.Text = llenarTabla["apellido"].ToString();
                txtFechaNac.Text = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(llenarTabla["fechaNacimiento"]));
                txtEmail.Text = llenarTabla["correo"].ToString();
                txtTel.Text = llenarTabla["telefono"].ToString();
                txtUser.Text = llenarTabla["usuario"].ToString();
                txtPass.Text = llenarTabla["contraseña"].ToString();
                txtRecovery.Text = llenarTabla["palabraClave"].ToString();
            }
            else
            {
                txtCodCliente.Text = "";
            }
            conexion.Close();
        }
    }
}