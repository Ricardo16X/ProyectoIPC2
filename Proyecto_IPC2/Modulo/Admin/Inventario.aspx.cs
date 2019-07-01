using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo.Admin
{
    public partial class Inventario : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (!(Session["rol"].ToString() == "administrador")) { Response.Redirect("~/Cuentas/Login.aspx"); }
            }
            else { Response.Redirect("~/Cuentas/Login.aspx"); }
        }

        protected void btnOperar_Click(object sender, EventArgs e)
        {
            SqlCommand comando = new SqlCommand("INSERT INTO lote values('" +
                String.Format("{0:MM/dd/yyyy}", System.DateTime.Now.Date.ToShortDateString()) + "'," +
                Convert.ToInt32(TextBox1.Text) + "," +
                Convert.ToInt32(TextBox1.Text) + ")", conexion);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
            mensaje("Lote/Chequera agregado a Inventario");
            Response.Redirect("~/Modulo/Admin/Inventario.aspx");
        }

        private void mensaje(string v)
        {
            Response.Write("<script>alert('" + v + "')</script>");
        }
    }
}