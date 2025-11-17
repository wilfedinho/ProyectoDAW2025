<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuWebMaster.aspx.cs" Inherits="MenuWebMaster" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Panel Web Master</title>
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
                    <asp:LinkButton runat="server" ID="btnBackupRestore"
                        Text="Backup/Restore" CssClass="nav-link"
                        data-key="btn_backup" CausesValidation="false"
                        OnClick="btnBackupRestore_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnDigitosVerificadores"
                        Text="Dígitos Verificadores" CssClass="nav-link"
                        data-key="btn_Digitos" CausesValidation="false"
                        OnClick="btnDigitosVerificadores_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnBitacora"
                        Text="Bitácora" CssClass="nav-link"
                        data-key="btn_Bitacora" CausesValidation="false"
                        OnClick="btnBitacora_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnClave"
                        Text="Cambiar Clave" CssClass="nav-link"
                        data-key="btn_clave" CausesValidation="false"
                        OnClick="btnCambiarClave_Click"></asp:LinkButton>
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




        <div class="panel-central" runat="server">
            <h2 class="panel-titulo" runat="server" data-key="Bienvenido al panel de Web Master">Bienvenido al panel de Web Master</h2>
            <p class="panel-subtitulo" runat="server" data-key="Seleccione una opcion del menu para comenzar">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>
