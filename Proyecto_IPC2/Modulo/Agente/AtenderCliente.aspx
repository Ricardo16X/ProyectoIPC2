<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtenderCliente.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Agente.AtenderCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" />
    <title>Atención al Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <nav>
                <a href="../../Cuentas/RegistroCliente.aspx" target="_blank">Registrar a Cliente</a>
                <a href="../../Cuentas/Consultas.aspx" >Consulta de Estados</a>
                <a href="../../Cuentas/Login.aspx">Cerrar Sesión</a>
            </nav>
            <div id="contenido">
                <h2>Atención al Cliente</h2>
                <br />
                <asp:Label Text="" runat="server" ID="lblFecha" />
                <br />
                <asp:Label Text="" runat="server" ID="lblHora" />
                <br />
                <br />
                <asp:Label Text="Turno #:" runat="server" ID="lblTurno" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label Text="" runat="server" ID="lblInfodeCola" />
                <br />
                <br />
                <asp:Label Text="Código Cliente:" runat="server" />&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCodigoCliente" runat="server" AutoPostBack="True" OnTextChanged="txtCodigoCliente_TextChanged" CssClass="label"></asp:TextBox>
                <br />
                <br />
                <br />
                <asp:Label Text="Descripción de Problema:" runat="server" />&nbsp;&nbsp;&nbsp;<br />
                <asp:TextBox ID="txtDescripcion" runat="server" Height="100px" TextMode="MultiLine" Width="600px"></asp:TextBox>
                <br />
                <br />
                <div class="datos">
                    <asp:Button ID="btnConcluirAtencion" runat="server" Text="Terminar Solicitud" OnClick="btnConcluirAtencion_Click" CssClass="boton" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGuardarBD" runat="server" Text="Guardar Trabajo Realizado" OnClick="btnGuardarBD_Click" CssClass="boton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
