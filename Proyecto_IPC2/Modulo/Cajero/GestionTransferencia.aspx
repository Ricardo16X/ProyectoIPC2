<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionTransferencia.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Cajero.GestionTransferencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" />
    <title>Gestión de Transferencias</title>
    <style type="text/css">
        #contenedor {
            width: 1000px;
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
                <h2>Gestión de Transferencias Interbancarias</h2>
                <asp:Label Text="# Turno: " runat="server" id="turno" Font-Size="20px"/>
                <br />
                <br />
                <p>
                    <strong>
                        <em>Acción:</em>
                    </strong>
                    <br />
                    <asp:RadioButton ID="rbtnCrear" runat="server" Text="Crear Solicitud" AutoPostBack="True" GroupName="Operacion" OnCheckedChanged="rbtnCrear_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="rbtnModificar" runat="server" Text="Modificar Solicitud" AutoPostBack="True" GroupName="Operacion" OnCheckedChanged="rbtnModificar_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="rbtnEliminar" runat="server" Text="Eliminar Solicitud" AutoPostBack="True" GroupName="Operacion" OnCheckedChanged="rbtnEliminar_CheckedChanged" />
                    <br />
                </p>
                <br />
                <asp:Label Text="Fecha: " runat="server" ID="fechaActual" />
                <br />
                <asp:Label Text="Hora: " runat="server" ID="horaActual" />
                <br />
                <br />
                <asp:Label Text="Código Solicitud Transferencia: " runat="server" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="Código Cliente: " runat="server" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtcodCliente" runat="server" CssClass="textbox" AutoPostBack="True" OnTextChanged="txtcodCliente_TextChanged"></asp:TextBox>
                <br />
                <asp:Label Text="Banco Destino: " runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtbancoDestino" runat="server" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="Monto: " runat="server" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtMonto" runat="server" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <asp:Label Text="Hora Trabajable: " runat="server" />
                <br />
                <br />
                <asp:Label Text="Hora Inicio: " runat="server" />&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtHoraInicio" runat="server" CssClass="textbox"></asp:TextBox>
                <br />
                <asp:Label Text="Hora Final: " runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtHoraFinal" runat="server" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button ID="btnOperacion" runat="server" Text="Operación" OnClick="btnOperacion_Click" CssClass="boton" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
