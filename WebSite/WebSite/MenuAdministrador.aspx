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

        <div class="navbar">
            <asp:Button CssClass="nav-item" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" CausesValidation="false"/>
            <asp:Button CssClass="nav-item" ID="btnUsuarios" runat="server" Text="Gestión Usuarios" OnClick="btnUsuarios_Click" CausesValidation="false"/>
            <asp:Button CssClass="nav-item" ID="btnBeneficios" runat="server" Text="Gestión Beneficios" OnClick="btnBeneficios_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBoletos" runat="server" Text="Gestión Boletos" OnClick="btnBoletos_Click" CausesValidation="false"/>
            <asp:Button CssClass="nav-item" ID="btnClave" runat="server" Text="Cambiar Clave" OnClick="btnClave_Click" CausesValidation="false"/>
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false"/>
        </div>

        <div class="panel-central">
            <h2 class="panel-titulo">Bienvenido al panel de Administrador</h2>
            <p class="panel-subtitulo">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>
