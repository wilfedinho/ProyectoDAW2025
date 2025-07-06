<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuWebMaster.aspx.cs" Inherits="MenuWebMaster" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Panel Web Master</title>
    <link href="EstilosPaginas/MenuWebMaster.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="navbar">
            <div class="nav-item">Inicio</div>
            <div class="nav-item">Backup/Restore</div>
            <div class="nav-item">Dígitos Verificadores</div>
            <div class="nav-item">Bitácora</div>
            <div class="nav-item">Cambiar Clave</div>
            <div class="nav-item nav-right">Cerrar Sesión</div>
        </div>
        
        <div class="panel-central">
            <h2 class="panel-titulo">Bienvenido al panel de Web Master</h2>
            <p class="panel-subtitulo">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>