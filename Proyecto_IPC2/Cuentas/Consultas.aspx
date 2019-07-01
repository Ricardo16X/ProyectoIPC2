<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="Proyecto_IPC2.Cuentas.Consultas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Consulta de Estados</title>
    <link rel="stylesheet" href="../Estilos/EstiloGeneral.css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedor">
            <div id="contenido">
                <h2>Consulta de Estados</h2>
                <p>
                    Buscar: 
                    <br />
                    <asp:RadioButton ID="rbtnChequera" Text="Chequeras" runat="server" GroupName="opcion" OnCheckedChanged="rbtnChequera_CheckedChanged" />
                    <br />
                    <asp:RadioButton ID="rbtnTransferencia" Text="Transferencias" runat="server" GroupName="opcion" OnCheckedChanged="rbtnTransferencia_CheckedChanged" />
                </p>
                <asp:Label Text="Código de " runat="server" CssClass="label" /><asp:Label ID="lblOpcion" Text="Opción:" runat="server" CssClass="label" />
                <br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox"></asp:TextBox>
                <br />
                <br />
                <div class="botonOperacion">
                    <asp:Button ID="btnConsulta" runat="server" Text="Consultar Estado" CssClass="boton" OnClick="btnConsulta_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
