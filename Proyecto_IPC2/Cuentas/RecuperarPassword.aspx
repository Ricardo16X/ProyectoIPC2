<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="Proyecto_IPC2.Cuentas.RecuperarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Estilos/EstiloGeneral.css" />
    <title>Recuperar Contraseña</title>

</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="contenido">
                <h2>Reestablecer Contraseña</h2>
                <br />
                <div class="datos">
                    <asp:Label Text="Código de Usuario:" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCodEmpleado" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label Text="Palabra Clave:" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPalabraClave" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Habilitar Cambio" OnClick="btnEntrar_Click" CssClass="boton" />
                </div>
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    <h2>Nueva Contraseña</h2>
                    <br />
                    <div class="datos">
                        <asp:Label Text="Nueva Contraseña" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label Text="Verificar Contraseña" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtRepeatPass" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Guardar Cambios" OnClick="Button1_Click" CssClass="boton" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
