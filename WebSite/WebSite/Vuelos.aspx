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
                    <asp:LinkButton runat="server" ID="btnIniciarSesion"
                        Text="Iniciar Sesion" CssClass="nav-link"
                        data-key="btn_inicio" CausesValidation="false"
                        OnClick="btnInicio_Click"></asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="btnMenuAdministrador"
                        Text="Menu Administrador" CssClass="nav-link"
                        data-key="btn_menuAdmin" CausesValidation="false"
                        OnClick="btnMenuAdministrador_Click" Visible ="false" CommandName="Ver Menu Administrador"></asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="btnMenuWebMaster"
                        Text="Menu WebMaster" CssClass="nav-link cerrar"
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
















        <section class="search-section">
            <div class="search-box">
                <h2>Buscar Vuelos</h2>
                <div class="search-fields">
                    <input type="text" class="search-input" placeholder="Origen" />
                    <input type="text" class="search-input" placeholder="Destino" />
                    <input type="date" class="search-input" />
                    <input type="date" class="search-input" />
                    <select class="search-input">
                        <option>1 persona, Económica</option>
                        <option>2 personas, Económica</option>
                        <option>1 persona, Ejecutiva</option>
                    </select>
                    <button type="button" class="search-btn">Buscar</button>
                </div>
            </div>
        </section>
        <section class="destinos-section">
            <h2>Vuelos baratos para los mejores destinos</h2>
            <div class="destinos-grid">
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80" alt="Santiago de Chile" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Santiago de Chile</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$249.911</span>
                    </div>
                </div>
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80" alt="Mendoza" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Mendoza</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$71.726</span>
                    </div>
                </div>
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1502082553048-f009c37129b9?auto=format&fit=crop&w=400&q=80" alt="Salta" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Salta</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$83.073</span>
                    </div>
                </div>
                <div class="destino-card">
                    <img src="https://images.unsplash.com/photo-1465156799763-2c087c332922?auto=format&fit=crop&w=400&q=80" alt="Córdoba" />
                    <div class="destino-info">
                        <span class="destino-label">VUELO</span>
                        <h3>Vuelos a Córdoba</h3>
                        <p>Saliendo desde Buenos Aires</p>
                        <span class="destino-precio">$50.795</span>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
