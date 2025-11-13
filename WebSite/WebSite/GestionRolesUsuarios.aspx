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
        <nav class="navbar">
            <ul>
                <li><a href="#">Inicio</a></li>
                <li><a href="#">Gestión Usuarios</a></li>
                <li><a href="#">Gestión Beneficios</a></li>
                <li><a href="#">Gestión Boletos</a></li>
                <li><a href="#">Cambiar Clave</a></li>
                <li><a href="#">Vuelos</a></li>
                <li><a href="#" class="cerrar">Cerrar Sesión</a></li>
            </ul>
        </nav>

        <div class="contenedor">
            <div class="columna izquierda">
                <h3>Roles y grupos</h3>
                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="combo"></asp:DropDownList>

                <asp:Button ID="btnVer" runat="server" Text="📄 Ver Detalle" CssClass="boton primario" />
                <asp:Button ID="btnModificar" runat="server" Text="✏️ Modificar Permisos" CssClass="boton primario" />

                <asp:Button ID="btnCrearRol" runat="server" Text="CREAR ROL"
                    CssClass="boton secundario" OnClientClick="abrirModalRol(); return false;" />

                <asp:Button ID="btnCrearGrupo" runat="server" Text="CREAR GRUPO DE PERMISOS"
                    CssClass="boton secundario" OnClientClick="abrirModalPermiso(); return false;" />
            </div>

            <div class="columna centro">
                <h3>Lista de permisos</h3>
                <asp:CheckBoxList ID="chkPermisos" runat="server" CssClass="lista"></asp:CheckBoxList>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Selección" CssClass="boton eliminar" />
            </div>

            <div class="columna derecha">
                <h3>Detalles</h3>
                <asp:Label ID="lblDetalles" runat="server" Text="Seleccione un rol para ver detalles." CssClass="detalle"></asp:Label>
            </div>
        </div>

        <div id="modalRol" class="modal">
            <div class="modal-contenido">
                <h3>Nuevo Rol</h3>
                <label>Nombre del Rol:</label>
                <input type="text" id="txtNombreRol" placeholder="Ej: Administrador" />
                <div class="acciones">
                    <button type="button" onclick="guardarRol()">Aceptar</button>
                    <button type="button" onclick="cerrarModalRol()">Cancelar</button>
                </div>
            </div>
        </div>

        <div id="modalPermiso" class="modal">
            <div class="modal-contenido">
                <h3>Nuevo Permiso Compuesto</h3>
                <label>Nombre del Permiso:</label>
                <input type="text" id="txtNombrePermiso" placeholder="Ej: Permiso Supervisor" />
                <div class="acciones">
                    <button type="button" onclick="guardarPermiso()">Aceptar</button>
                    <button type="button" onclick="cerrarModalPermiso()">Cancelar</button>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
