using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_IPC2.Modulo
{
    public partial class Reporte : System.Web.UI.Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=ORDENADOR\\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True");
        SqlDataAdapter dataAdapter;
        protected void Page_Load(object sender, EventArgs e) { }

        protected void reporte_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            if (DropDownList1.SelectedItem.Text == "Historial Transferencias")
            {
                //Datos de las Transferencias Realizadas.
                dataAdapter = new SqlDataAdapter("SELECT transferencia.FK_idCliente AS [Cod. Cliente], cliente.nombre AS Nombre, cliente.apellido AS Apellido, transferencia.FK_idTrabajador AS [Cod. Empleado], trabajador.nombre AS Nombre, trabajador.apellido AS Apellido, transferencia.hora AS Hora, transferencia.fecha AS Fecha, transferencia.monto AS Monto, transferencia.bancoDestino AS Destino, estadoTransferencia.descripcion AS Estado FROM transferencia INNER JOIN trabajador ON transferencia.FK_idTrabajador = trabajador.idTrabajador INNER JOIN estadoTransferencia ON transferencia.FK_codEstado = estadoTransferencia.codEstado INNER JOIN cliente ON transferencia.FK_idCliente = cliente.idCliente", conexion);
                dataAdapter.Fill(tabla);
                GridView1.DataSource = tabla;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedItem.Text == "Historial Chequeras")
            {
                //Datos de las Chequeras Entregadas.
                dataAdapter = new SqlDataAdapter("SELECT cliente.idCliente AS [Cod. Cliente], cliente.nombre AS Nombre, cliente.apellido AS Apellido, trabajador.idTrabajador AS [Cod. Empleado], trabajador.nombre AS Nombre, trabajador.apellido AS Apellido, chequera.fechaSolicitudChequera AS Fecha, chequera.horaSolicitudChequera AS Hora, estadoChequera.descripcion AS Estado, chequera.FK_idLote AS [Lote Origen] FROM chequera INNER JOIN cliente ON chequera.FK_idCliente = cliente.idCliente INNER JOIN estadoChequera ON chequera.FK_codEstado = estadoChequera.codEstado INNER JOIN lote ON chequera.FK_idLote = lote.idLote INNER JOIN trabajador ON chequera.FK_idTrabajador = trabajador.idTrabajador", conexion);
                dataAdapter.Fill(tabla);
                GridView1.DataSource = tabla;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedItem.Text == "Historial Atención al Cliente")
            {
                //Datos de la Atención al Cliente proporcionada.
                dataAdapter = new SqlDataAdapter("SELECT atencionCliente.FK_idCliente AS [Cod. Cliente], cliente.nombre AS [Nombre Cliente], cliente.apellido AS [Apellido Cliente], atencionCliente.FK_idTrabajador AS [Cod. Empleado], trabajador.nombre AS Nombre, trabajador.apellido AS Apellido, atencionCliente.horaConsulta AS Hora, atencionCliente.fechaConsulta AS Fecha, atencionCliente.descripcionProblema AS Problema, atencionCliente.numeroTurno AS Turno, estadoAtencion.descripcion AS Estado FROM atencionCliente INNER JOIN cliente ON atencionCliente.FK_idCliente = cliente.idCliente INNER JOIN estadoAtencion ON atencionCliente.FK_codEstado = estadoAtencion.codEstado INNER JOIN trabajador ON atencionCliente.FK_idTrabajador = trabajador.idTrabajador", conexion);
                dataAdapter.Fill(tabla);
                GridView1.DataSource = tabla;
                GridView1.DataBind();
            }
            else
            {
                mensajeAlerta("No ha seleccionado ningún módulo...");
            }
        }

        public void mensajeAlerta(string mensaje)
        {
            Response.Write("<script>alert('" + mensaje + "')</script>");
        }
    }
}