<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionRolesUsuarios.aspx.cs" Inherits="GestionRolesUsuarios" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Roles y Usuarios</title>
    <link rel="stylesheet" href="EstilosPaginas/GestionRolesUsuarios.css" />
    <script src="GestionRolesUsuarios.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav id="navbarPrincipal" runat="server" class="navbar">
            <ul>
                <li><a href="#" data-key="btn_inicio" runat="server">Inicio</a></li>
                <li><a href="#" data-key="btn_usuarios" runat="server">Gestión Usuarios</a></li>
                <li><a href="#" data-key="btn_beneficios" runat="server">Gestión Beneficios</a></li>
                <li><a href="#" data-key="btn_boletos" runat="server">Gestión Boletos</a></li>
                <li><a href="#" data-key="btn_clave" runat="server">Cambiar Clave</a></li>
                <li><a href="#" data-key="btn_vuelos" runat="server">Vuelos</a></li>
                <li><a href="#" class="cerrar" data-key="btn_cerrarSesion" runat="server">Cerrar Sesión</a></li>
            </ul>
        </nav>

        <div class="contenedor">
            <div class="columna izquierda">
                <h3 data-key="Roles y grupos">Roles y grupos</h3>
                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="combo"></asp:DropDownList>

                <asp:Button ID="btnVer" runat="server" Text="📄 Ver Detalle" CssClass="boton primario" data-key="📄 Ver Detalle"/>
                <asp:Button ID="btnModificar" runat="server" Text="✏️ Modificar Permisos" CssClass="boton primario" data-key="btn_modificar"/>

                <asp:Button ID="btnCrearRol" runat="server" Text="CREAR ROL"
                    CssClass="boton secundario" OnClientClick="abrirModalRol(); return false;" data-key="CREAR ROL"/>

                <asp:Button ID="btnCrearGrupo" runat="server" Text="CREAR GRUPO DE PERMISOS"
                    CssClass="boton secundario" OnClientClick="abrirModalPermiso(); return false;" data-key="CREAR GRUPO DE PERMISOS"/>
            </div>

            <div class="columna centro">
                <h3 data-key="Lista de permisos">Lista de permisos</h3>
                <asp:CheckBoxList ID="chkPermisos" runat="server" CssClass="lista"></asp:CheckBoxList>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Selección" CssClass="boton eliminar" data-key="Eliminar Seleccion"/>
            </div>

            <div class="columna derecha">
                <h3 data-key="Detalles">Detalles</h3>
                <asp:Label ID="lblDetalles" runat="server" Text="Seleccione un rol para ver detalles." CssClass="detalle" data-key="Seleccione un rol para ver detalles"></asp:Label>
            </div>
        </div>

        <div id="modalRol" class="modal">
            <div class="modal-contenido">
                <h3 data-key="Nuevo Rol">Nuevo Rol</h3>
                <label data-key="Nombre del Rol:">Nombre del Rol:</label>
                <input type="text" id="txtNombreRol" placeholder="Ej: Administrador" />
                <div class="acciones">
                    <button type="button" onclick="guardarRol()" data-key="Aceptar">Aceptar</button>
                    <button type="button" onclick="cerrarModalRol()" data-key="Cancelar">Cancelar</button>
                </div>
            </div>
        </div>

        <div id="modalPermiso" class="modal">
            <div class="modal-contenido">
                <h3 data-key="Nuevo Permiso Compuesto">Nuevo Permiso Compuesto</h3>
                <label data-key="Nombre del Permiso: ">Nombre del Permiso:</label>
                <input type="text" id="txtNombrePermiso" placeholder="Ej: Permiso Supervisor" />
                <div class="acciones">
                    <button type="button" onclick="guardarPermiso()" data-key="Aceptar">Aceptar</button>
                    <button type="button" onclick="cerrarModalPermiso()" data-key="Cancelar">Cancelar</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
