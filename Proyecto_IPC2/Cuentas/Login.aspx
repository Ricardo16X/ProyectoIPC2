<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_IPC2.Cuentas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio de Sesión</title>
    <link rel="stylesheet" href="../Estilos/EstiloGeneral.css" />
    <style type="text/css">
        .acceso a{
            text-decoration:none;
            color:white;
            width:150px;
            padding:5px;
            height:40px;
            background-color:dodgerblue;
            border-radius:5px;
            border:2px solid black;
            -webkit-transition: 0.3s; /* For Safari 3.1 to 6.0 */
            transition: 0.3s;
        }
        .acceso a:hover{
            background-color:black;
            border-color:dodgerblue;
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="contenido">
                <h2>Inicio de Sesión</h2>
                <br />
                <div class="datos">
                    <asp:Label Text="Usuario:" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label Text="Contraseña:" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
                    <br />
                </div>
                <br />
                <div class="acceso">
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" Height="30px" Width="100px" CssClass="boton" />
                    <br />
                    <br />
                    <a href="RecuperarPassword.aspx">Olvide mi Contraseña</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
