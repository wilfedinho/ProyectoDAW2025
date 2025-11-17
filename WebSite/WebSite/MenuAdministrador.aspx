<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuAdministrador.aspx.cs" Inherits="MenuAdministrador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Panel Administrador</title>
    <link href="EstilosPaginas/MenuWebMaster.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">

        <nav id="navbarPrincipal" runat="server" class="navbar">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="btnInicio"
                        Text="Inicio" CssClass="nav-link"
                        data-key="btn_inicio" CausesValidation="false"
                        OnClick="btnInicio_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnUsuarios"
                        Text="Gestión Usuarios" CssClass="nav-link"
                        data-key="btn_usuarios" CausesValidation="false"
                        OnClick="btnUsuarios_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnPermisos"
                        Text="Gestión Permisos" CssClass="nav-link"
                        data-key="btn_permisos" CausesValidation="false"
                        OnClick="btnPermisos_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnBeneficios"
                        Text="Gestión Beneficios" CssClass="nav-link"
                        data-key="btn_beneficios" CausesValidation="false"
                        OnClick="btnBeneficios_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnBoletos"
                        Text="Gestión Boletos" CssClass="nav-link"
                        data-key="btn_boletos" CausesValidation="false"
                        OnClick="btnBoletos_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnClave"
                        Text="Cambiar Clave" CssClass="nav-link"
                        data-key="btn_clave" CausesValidation="false"
                        OnClick="btnClave_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnVuelos"
                        Text="Vuelos" CssClass="nav-link"
                        data-key="btn_vuelos" CausesValidation="false"
                        OnClick="btnVuelos_Click"></asp:LinkButton>
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
                        CssClass="nav-link idioma-btn"
                        OnClick="btnES_Click">ES</asp:LinkButton>

                    <span style="margin: 0 8px; color: #888;">|</span>

                    <asp:LinkButton
                        ID="btnEN"
                        runat="server"
                        CssClass="nav-link idioma-btn"
                        OnClick="btnEN_Click">EN</asp:LinkButton>
                </li>
            </ul>
        </nav>

        <div class="panel-central" runat="server">
            <h2 class="panel-titulo" runat="server" data-key="Bienvenido al panel de Administrador">Bienvenido al panel de Administrador</h2>
            <p class="panel-subtitulo" runat="server" data-key="Seleccione una opcion del menu para comenzar">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>
