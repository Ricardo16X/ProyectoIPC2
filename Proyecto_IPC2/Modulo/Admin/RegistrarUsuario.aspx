<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Admin.RegistrarUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" />
    <title>Gestión de Usuarios</title>
    <style type="text/css">
        #tipo {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 15px;
            width: 50%;
            float: left;
        }

        #accion {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 15px;
            width: 50%;
            float: right;
        }

        #contenedorRadioButton {
            overflow: auto;
        }

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
                <h2>Gestión de Usuarios</h2>
                <br />
                <div id="contenedorRadioButton">
                    <div id="tipo">
                        <strong><em>Tipo de Trabajador:</em></strong>
                        <br />
                        <asp:RadioButton ID="rbtnCajero" runat="server" Text="Cajero" GroupName="Trabajador" CssClass="radioButton" />
                        <br />
                        <asp:RadioButton ID="rbtnAgente" runat="server" Text="Agente Atención al Cliente" GroupName="Trabajador" CssClass="radioButton" />
                    </div>
                    <div id="accion">
                        <strong><em>Acción a Realizar:</em></strong>
                        <br />
                        <asp:RadioButton ID="Registrar" runat="server" GroupName="Accion" Text="Registrar" OnCheckedChanged="Registrar_CheckedChanged" AutoPostBack="True" CssClass="radioButton" /><br />
                        <asp:RadioButton ID="Modificar" runat="server" GroupName="Accion" Text="Actualizar" AutoPostBack="True" OnCheckedChanged="Modificar_CheckedChanged" CssClass="radioButton" /><br />
                        <asp:RadioButton ID="Eliminar" runat="server" Text="Eliminar" GroupName="Accion" AutoPostBack="True" OnCheckedChanged="Eliminar_CheckedChanged" CssClass="radioButton" />
                    </div>
                </div>
                <br />
                <br />
                <asp:Label Text="Código Trabajador:" runat="server" ID="lblCodigo" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCodigoCliente" runat="server" AutoPostBack="True" OnTextChanged="txtCodigoCliente_TextChanged" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="DPI:     " runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtDPI" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Nombre:  " runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtNombre" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Apellido " runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtApellido" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Fecha Nacimiento" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtFechaNac" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="E-Mail" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtEmail" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Teléfono" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtTel" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Usuario" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtUser" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Contraseña" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtPass" CssClass="textbox" />
                <br />
                <br />
                <asp:Label Text="Palabra Clave" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txtRecovery" CssClass="textbox" />
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button Text="Operación" ID="BotonEnviar" runat="server" OnClick="BotonEnviar_Click" CssClass="boton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
