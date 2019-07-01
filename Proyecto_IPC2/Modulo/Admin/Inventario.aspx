<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Admin.Inventario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inventario de Chequeras</title>
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" media="all" />
    <style type="text/css">
        #contenedor {
            width: 875px;
        }

        #gridview {
            margin: auto;
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
                <h2>Inventario de Chequeras</h2>
                <div id="gridview">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="idLote" DataSourceID="lotes" CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="100%">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="idLote" HeaderText="idLote" InsertVisible="False" ReadOnly="True" SortExpression="idLote" />
                            <asp:BoundField DataField="fechaLote" HeaderText="fechaLote" SortExpression="fechaLote" />
                            <asp:BoundField DataField="cantidadInicial" HeaderText="cantidadInicial" SortExpression="cantidadInicial" />
                            <asp:BoundField DataField="cantidadActual" HeaderText="cantidadActual" SortExpression="cantidadActual" />
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="lotes" runat="server" ConnectionString="Data Source=ORDENADOR\SQLEXPRESS;Initial Catalog=ProyectoIPC2;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="select * from lote
where lote.cantidadActual &gt; 0"></asp:SqlDataSource>
                </div>
                <br />
                <br />
                <h2>Agregar Nuevo Lote</h2>
                <div id="agregarLote">
                    <asp:Label Text="Cantidad Ingresada:" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                <br />
                <div class="botonOperacion">
                    <asp:Button ID="btnOperar" runat="server" Text="Agregar a Inventario" CssClass="boton" OnClick="btnOperar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
