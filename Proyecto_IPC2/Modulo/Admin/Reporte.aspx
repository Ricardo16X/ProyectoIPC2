<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Generación de Reportes</title>
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" media="all" />
    <style type="text/css">
        #contenedor {
            width: 875px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <nav>
                <a href="RegistrarUsuario.aspx">Gestión de Usuarios</a>
                <a href="../../Cuentas/RegistroCliente.aspx" target="_blank">Gestión de Clientes</a>
                <a href="CargaMasiva.aspx">Carga Masiva</a>
                <a href="Reporte.aspx">Reportes</a>
                <a href="Inventario.aspx">Control de Insumos</a>
                <a href="../../Cuentas/Login.aspx">Cerrar Sesión</a>
            </nav>
            <div id="contenido">
                <h2>Historiales</h2>
                <br />
                <p>
                    Módulo:
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="boton" Width="250px" Height="40px">
                        <asp:ListItem>Historial Transferencias</asp:ListItem>
                        <asp:ListItem>Historial Chequeras</asp:ListItem>
                        <asp:ListItem>Historial Atención al Cliente</asp:ListItem>
                    </asp:DropDownList>
                </p>
                <div class="botonOperacion">
                    <asp:Button Text="Mostrar Historial" runat="server" ID="reporte" CssClass="boton" OnClick="reporte_Click" />
                </div>
            </div>
        </div>
        <div style="margin:auto;width:90%;">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="100%">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Segoe UI" Font-Size="15px" ForeColor="White" HorizontalAlign="Center" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" Font-Names="Segoe UI" Font-Size="12px" ForeColor="#333333" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
        <asp:SqlDataSource ID="AgenteHistorial" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoIPC2ConnectionString %>" SelectCommand="SELECT cliente.idCliente AS [Cod. Cliente], cliente.nombre AS Nombre, cliente.apellido AS Apellido, trabajador.idTrabajador AS [Cod. Empleado], trabajador.nombre AS Nombre, trabajador.apellido AS Apellido, chequera.fechaSolicitudChequera AS Fecha, chequera.horaSolicitudChequera AS Hora, estadoChequera.descripcion AS Estado, chequera.FK_idLote AS [Lote Origen] FROM chequera INNER JOIN cliente ON chequera.FK_idCliente = cliente.idCliente INNER JOIN estadoChequera ON chequera.FK_codEstado = estadoChequera.codEstado INNER JOIN lote ON chequera.FK_idLote = lote.idLote INNER JOIN trabajador ON chequera.FK_idTrabajador = trabajador.idTrabajador"></asp:SqlDataSource>
        
    </form>
</body>
</html>
