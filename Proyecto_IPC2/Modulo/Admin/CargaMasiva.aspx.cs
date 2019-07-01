using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo.Admin
{
    public partial class CargaMasiva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (!(Session["rol"].ToString() == "administrador"))
                {
                    Response.Redirect("~/Cuentas/Login.aspx");
                    Session["rol"] = null;
                }
            }
            else
            {
                Session["rol"] = null;
                Response.Redirect("~/Cuentas/Login.aspx");
            }
            
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            if (archCliente.Checked || archEmpleado.Checked)
            {
                if (cargaArchivo.HasFile && (Path.GetExtension(cargaArchivo.FileName) == ".csv"))
                {
                    cargaArchivo.SaveAs(Server.MapPath("~/App_Data/") + Path.GetFileName(cargaArchivo.FileName));
                    Session["rutaArchivo"] = Server.MapPath("~/App_Data/" + Path.GetFileName(cargaArchivo.FileName)).ToString();
                    StreamReader lector = new StreamReader(Session["rutaArchivo"].ToString());
                    TextBox1.Text = lector.ReadToEnd();
                    lector.Close();
                }
                else
                {
                    mensajeAlerta("Archivo seleccionado no válido!");
                }
            }
            else
            {
                mensajeAlerta("Selecciona un tipo de Información");
                archCliente.Focus();
            }
        }

        protected void btnAlmacenarInformacion_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
            string comando;
            if (archCliente.Checked)
            {
                try
                {
                    comando = "bulk insert clienteTemporal from '" + Session["rutaArchivo"] + "' with(CODEPAGE = '65001',firstrow=2,format='csv') " +
                    "insert into cliente(dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave) " +
                    "select * from clienteTemporal; " +
                    "update cliente set estadoCuenta = " + 1 +
                    " where estadoCuenta is null; " +
                    " truncate table clienteTemporal";
                    SqlCommand comandoTrabajador = new SqlCommand(comando, conexion);
                    conexion.Open();
                    comandoTrabajador.ExecuteNonQuery();
                    mensajeAlerta("Datos de Cliente Cargados.");
                }
                catch (Exception)
                {
                    mensajeAlerta("Error, asegúrese que tenga el formato correcto...");
                    TextBox1.Text = "dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave";
                }
                
            }else if (archEmpleado.Checked)
            {
                try
                {
                    comando = "bulk insert trabajadorTemporal from '" + Session["rutaArchivo"] + "' with(CODEPAGE = '65001',firstrow=2,format='csv') " +
                    "insert into trabajador(FK_codTipo,dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave) " +
                    "select * from trabajadorTemporal; " +
                    "update trabajador set estadoCuenta = " + 1 +
                    " where estadoCuenta is null; " +
                    " truncate table trabajadorTemporal";
                    SqlCommand comandoCliente = new SqlCommand(comando, conexion);
                    conexion.Open();
                    comandoCliente.ExecuteNonQuery();
                    conexion.Close();
                    mensajeAlerta("Datos de Trabajador Cargados.");
                }
                catch (Exception)
                {
                    mensajeAlerta("Error, asegúrese que tenga el formato correcto...");
                    TextBox1.Text = "codigoTipoEmpleado,dpi,nombre,apellido,fechaNacimiento,correo,telefono,usuario,contraseña,palabraClave";
                }
            }
            else
            {
                mensajeAlerta("Selecciona un tipo de Información");
                archCliente.Focus();
            }
        }

        public void mensajeAlerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "')</script>");
        }
    }
}