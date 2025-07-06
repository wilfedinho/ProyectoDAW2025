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
            <asp:Button CssClass="nav-item" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBackupRestore" runat="server" Text="Backup/Restore" OnClick="btnBackupRestore_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnDigitosVerificadores" runat="server" Text="Dígitos Verificadores" OnClick="btnDigitosVerificadores_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBitacora" runat="server" Text="Bitácora" OnClick="btnBitacora_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnCambiarClave" runat="server" Text="Cambiar Clave" OnClick="btnCambiarClave_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
        </div>

        <div class="panel-central">
            <h2 class="panel-titulo">Bienvenido al panel de Web Master</h2>
            <p class="panel-subtitulo">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>
