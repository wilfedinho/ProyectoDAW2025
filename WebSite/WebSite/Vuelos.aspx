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
        <nav id="nav1" runat="server" class="navbar">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="btnCambiarClave"
                        Text="Cambiar Clave" CssClass="nav-link"
                        data-key="btn_clave" CausesValidation="false"
                        OnClick="btnCambiarClave_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnMenuAdministrador"
                        Text="Menu Administrador" CssClass="nav-link"
                        data-key="btn_menuAdmin" CausesValidation="false"
                        OnClick="btnMenuAdministrador_Click" Visible="false" CommandName="Ver Menu Administrador"></asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="btnMenuWebMaster"
                        Text="Menu WebMaster" CssClass="nav-link"
                        data-key="btn_menuWeb" CausesValidation="false"
                        OnClick="btnMenuWebMaster_Click" Visible="false" CommandName="Ver Menu WebMaster"></asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="btnCerrarSesion"
                        Text="Cerrar Sesión" CssClass="nav-link cerrar"
                        data-key="btn_cerrarSesion" CausesValidation="false"
                        OnClick="btnCerrarSesion_Click"></asp:LinkButton>
                </li>
                <li style="display: inline-block; margin-left: 40px;">

                    <asp:LinkButton
                        ID="btnES"
                        runat="server"
                        CausesValidation="false"
                        CssClass="nav-link idioma-btn"
                        OnClick="btnES_Click">ES</asp:LinkButton>

                    <span style="margin: 0 8px; color: #888;">|</span>

                    <asp:LinkButton
                        ID="btnEN"
                        runat="server"
                        CausesValidation="false"
                        CssClass="nav-link idioma-btn"
                        OnClick="btnEN_Click">EN</asp:LinkButton>
                </li>
            </ul>
        </nav>

        <section class="destinos-section">

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-indicador"></asp:Label>

            <h2 data-key="opcionesDisponibles" runat="server" id="opcDisponibles">Opciones Disponibles</h2>

            <div class="destinos-grid" runat="server">
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
        <footer class="main-footer">
            <p runat="server" data-key="copyright">&copy; 2025 Sanza Flights | Todos los derechos reservados.</p>
            <p runat="server" data-key="contacto">Contacto: <a href="mailto:soporte@sanzaflights.com">soporte@sanzaflights.com</a></p>
        </footer>
    </form>
</body>
</html>
