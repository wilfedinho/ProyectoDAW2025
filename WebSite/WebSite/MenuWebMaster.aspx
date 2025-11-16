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

        <div class="navbar">
            <asp:Button CssClass="nav-item" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" CausesValidation="false" data-key="btn_inicio"/>
            <asp:Button CssClass="nav-item" ID="btnBackupRestore" runat="server" Text="Backup/Restore" OnClick="btnBackupRestore_Click" CausesValidation="false" data-key="btn_backup"/>
            <asp:Button CssClass="nav-item" ID="btnDigitosVerificadores" runat="server" Text="Dígitos Verificadores" OnClick="btnDigitosVerificadores_Click" CausesValidation="false" data-key="btn_Digitos"/>
            <asp:Button CssClass="nav-item" ID="btnBitacora" runat="server" Text="Bitácora" OnClick="btnBitacora_Click" CausesValidation="false" data-key="btn_bitacora"/>
            <asp:Button CssClass="nav-item" ID="btnCambiarClave" runat="server" Text="Cambiar Clave" OnClick="btnCambiarClave_Click" CausesValidation="false" data-key="btn_clave"/>
            <asp:Button CssClass="nav-item" ID="btnVuelos" runat="server" Text="Vuelos" OnClick="btnVuelos_Click" CausesValidation="false" data-key="btn_vuelos"/>
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CausesValidation="false" data-key="btn_cerrarSesion"/>
        </div>

        <div class="panel-central">
            <h2 class="panel-titulo" data-key="Bienvenido al panel de Web Master">Bienvenido al panel de Web Master</h2>
            <p class="panel-subtitulo" data-key="Seleccione una opcion del menu para comenzar">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>
