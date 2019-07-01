<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionChequera.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Cajero.GestionChequera" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" media="all" />
    <title>Gestión de Chequeras</title>
    <style type="text/css">
        #contenedor {
            width: 1000px;
        }

        #separador {
            display: flex;
            justify-content: space-between;
        }

        #opciones,
        #botoncito {
            width: 50%;
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
                <h2>Gestión de Chequeras
                    <br />
                    <asp:Label Text="Turno # " runat="server" ID="lblTurno" CssClass="label" Font-Size="20px" BackColor="Black" ForeColor="White" Height="30px" Width="150px" />
                </h2>
                <div id="separador">
                    <div id="opciones">
                        <strong><em>Acción:</em></strong>
                        <br />
                        <asp:RadioButton Text="   Registrar Solicitud" runat="server" ID="regChequera" CssClass="radioButton" AutoPostBack="True" OnCheckedChanged="regChequera_CheckedChanged" GroupName="opcionChequera" />
                        <br />
                        <asp:RadioButton Text="   Actualizar Solicitud" runat="server" ID="upChequera" CssClass="radioButton" AutoPostBack="True" OnCheckedChanged="upChequera_CheckedChanged" GroupName="opcionChequera" />
                        <br />
                        <asp:RadioButton Text="   Eliminar Solicitud" runat="server" ID="delChequera" CssClass="radioButton" AutoPostBack="True" OnCheckedChanged="delChequera_CheckedChanged" GroupName="opcionChequera" />
                        <br />
                        <asp:RadioButton Text="   Entregar Chequera" runat="server" ID="darChequera" CssClass="radioButton" AutoPostBack="True" OnCheckedChanged="darChequera_CheckedChanged" GroupName="opcionChequera" />
                    </div>
                    <div id="botoncito">
                        <asp:Button ID="Button1" runat="server" Text="Guardar Trabajo" CssClass="boton" Width="150px" OnClick="Button1_Click" />
                    </div>
                </div>
                <br />
                <br />
                <asp:Label Text="Fecha:" runat="server" ID="fechaActual" CssClass="label" />
                <br />
                <asp:Label Text="Hora:" runat="server" ID="horaActual" CssClass="label" />
                <br />
                <br />
                <asp:Label Text="Código de Chequera" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCodChequera" runat="server" CssClass="textbox" OnTextChanged="txtCodChequera_TextChanged" AutoPostBack="True"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="Código Cliente:" runat="server" CssClass="label" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCodClient" runat="server" CssClass="textbox" AutoPostBack="True" OnTextChanged="txtCodClient_TextChanged"></asp:TextBox>
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button ID="btnOperacion" runat="server" Text="Operación" CssClass="boton" OnClick="btnOperacion_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
