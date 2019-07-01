<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="Proyecto_IPC2.Cuentas.RegistroCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../Estilos/EstiloGeneral.css" />
    <title>Gestión de Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="contenido">
                <h2>Gestión de Clientes</h2>
                <br />
                <p>
                    <strong><em>Acción:</em></strong>
                    <br />
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="GestionCliente" Text="Registrar" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" CssClass="radioButton" />
                    <br />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="GestionCliente" Text="Modificar" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" CssClass="radioButton" />
                    <br />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="GestionCliente" Text="Eliminar" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged" CssClass="radioButton" />

                </p>
                <br />
                <asp:Label Text="Código Cliente" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCodCliente" runat="server" Enabled="False" AutoPostBack="True" OnTextChanged="txtCodCliente_TextChanged" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="DPI" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtDPI" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Nombre" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtNombre" CssClass="textbox" />

                <br />
                <br />
                <asp:Label Text="Apellido" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtApellido" CssClass="textbox" />

                <br />
                <br />
                <asp:Label Text="Fecha Nacimiento" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtFechaNac" CssClass="textbox" />

                <br />
                <br />
                <asp:Label Text="Correo Electrónico" runat="server" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtEmail" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Teléfono" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtTel" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Usuario" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtUser" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Contraseña" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtPass" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Palabra Clave" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtRecovery" CssClass="textbox" />
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button Text="Operación" ID="btnRegistrarCliente" runat="server" OnClick="btnRegistrarCliente_Click" CssClass="boton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
