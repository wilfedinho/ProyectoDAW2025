<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuAdministrador.aspx.cs" Inherits="MenuAdministrador" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Panel Administrador</title>
    <link href="EstilosPaginas/MenuWebMaster.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="navbar">
            <div class="nav-item">Inicio</div>
            <div class="nav-item">Gestión Usuarios</div>
            <div class="nav-item">Gestión Beneficios</div>
            <div class="nav-item">Gestión Boletos</div>
            <div class="nav-item">Cambiar Clave</div>
            <div class="nav-item nav-right">Cerrar Sesion</div>
        </div>
        
        <div class="panel-central">
            <h2 class="panel-titulo">Bienvenido al panel de Administrador</h2>
            <p class="panel-subtitulo">Seleccioná una opción del menú para comenzar</p>
        </div>
    </form>
</body>
</html>