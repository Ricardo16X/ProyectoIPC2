<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudTransferencias.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Cajero.SolicitudTransferencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" />
    <title>Transferencias Pendientes</title>
    <style type="text/css">
        #navegacion{
            display:flex;
            justify-content:space-between;
        }
        #contenedor{
            width:1000px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <nav>
                <a href="GestionTransferencia.aspx">Gestión de Transferencias</a>
                <a href="SolicitudTransferencias.aspx">Transferencias Pendientes</a>
                <a href="GestionChequera.aspx">Gestión de Chequeras</a>
                <a href="../../Cuentas/RegistroCliente.aspx" target="_blank">Registrar Clientes</a>
                <a href="../../Cuentas/Login.aspx">Cerrar Sesión</a>
            </nav>
            <div id="contenido">
                <h2>Solicitudes en Espera</h2>
                <asp:Label Text="Código Cliente: " runat="server" /><asp:TextBox ID="txtcodCliente" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnProcesar" runat="server" Text="Procesar" OnClick="btnProcesar_Click" CssClass="boton" Height="30px" Width="100px" />
                <br />
                <asp:Label Text="Banco Destino: " runat="server" /><asp:TextBox ID="txtbancoDestino" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="Monto: " runat="server" /><asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                <br />
                <br />
                <br />
                <br />
                <div id="navegacion">
                    <asp:Button ID="btnAnterior" runat="server" Text="Anterior" OnClick="btnAnterior_Click" CssClass="boton" Height="30px" Width="100px" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" CssClass="boton" Height="30px" Width="100px" />
                </div>
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button ID="btnGuardarTrabajo" runat="server" Text="Guardar Trabajo" OnClick="btnGuardarTrabajo_Click" CssClass="boton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
