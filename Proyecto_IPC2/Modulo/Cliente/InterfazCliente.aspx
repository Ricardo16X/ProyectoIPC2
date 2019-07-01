<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterfazCliente.aspx.cs" Inherits="Proyecto_IPC2.Modulo.Cliente.InterfazCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../Estilos/EstiloGeneral.css" />
    <title>Menú de Servicios</title>
    <style type="text/css">
        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }

        #contenedorServicio {
            width: 1000px;
            margin: auto;
        }

        #contenidoServicio {
            padding: 20px;
            font-family: 'Segoe MDL2 Assets' 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

            #contenidoServicio h2,
            #contenidoServicio .botonOperacion {
                text-align: center;
                font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            }

        .servicio {
            display: flex;
            justify-content: space-around;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedorServicio">
            <div id="contenidoServicio">
                <h2>Solicitud de Servicios</h2>
                <br />
                <div class="servicio">
                    <asp:Button ID="btnChequera" runat="server" Text="Chequera" Enabled="True" CssClass="boton" Height="150px" Font-Size="20px" OnClick="btnChequera_Click" />
                    <asp:Button ID="btnTrans" runat="server" Text="Transferencia Interbancaria" OnClick="btnTrans_Click" CssClass="boton" Height="150px" Font-Size="20px" />
                </div>
                <div class="servicio">
                       <asp:Button ID="btnAtencion" runat="server" Text="Atención al Cliente" OnClick="btnAtencion_Click" CssClass="boton" Height="150px" Font-Size="20px" />
                    <asp:Button ID="btnEstado" runat="server" Text="Consulta de Estados" CssClass="boton" Font-Size="20px" Height="150px" OnClick="btnEstado_Click" />
                </div>
              </div>
        </div>
    </form>
</body>
</html>
