<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargaMasiva.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Admin.CargaMasiva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" />
    <title>Carga Masiva</title>
    <style type="text/css">
        #contenedor{
            width:875px;
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
                <br />
                <h2>Carga Masiva de Datos</h2>
                <br />
                <p>
                    Tipo de Información:
                    <br />
                    <asp:RadioButton ID="archCliente" runat="server" GroupName="tipoArchivo" Text="Clientes" /><br />
                    <asp:RadioButton ID="archEmpleado" runat="server" GroupName="tipoArchivo" Text="Empleados" /><br />
                </p>
                <br />
                <asp:FileUpload ID="cargaArchivo" runat="server" ToolTip="Carga un archivo .CSV" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Font-Names="Segoe UI" Font-Size="12px" ForeColor="Black" Width="400px" Height="30px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSubir" runat="server" Text="Ver Archivo" OnClick="btnSubir_Click" BackColor="DodgerBlue" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Names="Segoe UI" Font-Size="12px" ForeColor="White" Width="100px" Height="30px" />
                <br />
                <br />
                <asp:TextBox ID="TextBox1" runat="server" Height="200px" TextMode="MultiLine" Width="655px" Wrap="False" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button ID="btnAlmacenarInformacion" runat="server" Text="Almacenar Información" OnClick="btnAlmacenarInformacion_Click" CssClass="boton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
