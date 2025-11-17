<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vuelos.aspx.cs" Inherits="Vuelos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Buscador de Vuelos</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Vuelos.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="navbarPrincipal" runat="server" class="navbar">
            <asp:Button CssClass="nav-item" ID="btnCambiarClave" runat="server" Text="Cambiar Clave" OnClick="btnCambiarClave_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnIniciarSesion" runat="server" Text="Iniciar Sesion" OnClick="btnInicio_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnMenuAdministrador" runat="server" Text="Menu Administrador" OnClick="btnMenuAdministrador_Click" CausesValidation="false" Visible="false" CommandName="Ver Menu Administrador" />
            <asp:Button CssClass="nav-item" ID="btnMenuWebMaster" runat="server" Text="Menu WebMaster" OnClick="btnMenuWebMaster_Click" CausesValidation="false" Visible="false" CommandName="Ver Menu WebMaster" />
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
        </div>
        <section class="destinos-section">
            <h2>Opciones Disponibles</h2>

            <div class="destinos-grid">
                <asp:Repeater ID="repVuelos" runat="server">
                    <ItemTemplate>
                        <div class="destino-card"
                            onclick="window.location.href='<%# Eval("Url") %>'">

                            <img src="<%# Eval("Imagen") %>" alt="<%# Eval("Titulo") %>" />

                            <div class="destino-info">
                                <h3><%# Eval("Titulo") %></h3>
                                <p><%# Eval("Descripcion") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </section>

    </form>
</body>
</html>
