<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionRolesUsuarios.aspx.cs" Inherits="GestionRolesUsuarios" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Roles y Usuarios</title>
    <link rel="stylesheet" href="EstilosPaginas/GestionRolesUsuarios.css" />
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
    </ul>
</nav>


        <div class="contenedor">
            <div class="columna izquierda">
                <h3 data-key="Roles y grupos">Roles y grupos</h3>
                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="combo" OnSelectedIndexChanged="ddlRoles_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                <div class="edicion-permiso" runat="server" id="panelEdicion" visible="false">

                    <label class="etiqueta-profesional">Nuevo nombre del permiso/rol:</label>

                    <asp:TextBox ID="TextBox1" runat="server" CssClass="input-profesional" Placeholder="Escriba el nuevo nombre aquí..."></asp:TextBox>

                    <small class="descripcion-profesional">
                        Modificá el nombre del permiso o rol seleccionado.
                    </small>


                </div>
                <asp:Label ID="lblError" runat="server" CssClass="error-profesional" Visible="false" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnVer" runat="server" Text="📄 Ver Detalle" CssClass="boton primario" data-key="📄 Ver Detalle" OnClick="btnVer_Click"/>
                <asp:Button 
                    ID="btnModificar" 
                    runat="server" 
                    Text="✏️ Modificar Permiso" 
                    CssClass="boton primario" 
                    data-key="btn_modificarPermiso"
                    OnClientClick="abrirModalModificar(document.getElementById('<%= ddlRoles.ClientID %>').value, 'Modificando...'); return false;" OnClick="btnModificar_Click" />


                <asp:Button ID="btnCambiarPermiso" runat="server" Text="Cambiar Permisos" CssClass="boton primario" data-key="btn_cambiarPermisos" OnClick="btnCambiarPermisos_Click"/>

                <asp:Button ID="btnCrearRol" runat="server" Text="CREAR ROL"
                    CssClass="boton secundario" OnClientClick="abrirModalRol(); return false;" data-key="CREAR ROL" OnClick="btnCrearRol_Click"/>

                <asp:Button ID="btnCrearGrupo" runat="server" Text="CREAR GRUPO DE PERMISOS"
                    CssClass="boton secundario" OnClientClick="abrirModalPermiso(); return false;" data-key="CREAR GRUPO DE PERMISOS" OnClick="btnCrearGrupo_Click"/>

                <div id="panelCrearCompuesto" runat="server" visible="false" class="edicion-permiso">

                    <label class="etiqueta-profesional">Nombre del permiso/rol compuesto:</label>

                    <asp:TextBox ID="txtNombreCompuesto" runat="server" CssClass="input-profesional" Placeholder="Ej: Administrador General"></asp:TextBox>

                    <small class="descripcion-profesional">
                        Escribí el nombre del nuevo permiso compuesto y luego confirmá.
                    </small>

                    <asp:Button ID="btnConfirmarCompuesto" runat="server" Text="Crear Permiso Compuesto" CssClass="boton primario" OnClick="btnConfirmarCompuesto_Click" />

                    <asp:Label ID="lblErrorCompuesto" runat="server" CssClass="error-profesional" Visible="false"></asp:Label>

                </div>
             </div>

            <div class="columna centro">
                <h3 data-key="Lista de permisos">Lista de permisos</h3>
                <asp:CheckBoxList ID="chkPermisos" runat="server" CssClass="lista"></asp:CheckBoxList>
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Selección" CssClass="boton eliminar" data-key="Eliminar Seleccion" OnClick="btnEliminar_Click"/>
                <asp:Label ID="Label1" runat="server" CssClass="error-profesional" Visible="false"></asp:Label>
                <asp:Label ID="lblInfo" runat="server" CssClass="info-profesional" Visible="false"></asp:Label>
            </div>

            <div class="columna derecha">
                <h3 data-key="Detalles">Detalles</h3>

                <asp:TreeView 
                    ID="tvDetalles" 
                    runat="server"
                    CssClass="detalle"
                    ExpandDepth="0"
                    ShowExpandCollapse="true"
                    NodeStyle-ForeColor="White"
                    LeafNodeStyle-ForeColor="White"
                    RootNodeStyle-ForeColor="White"
                    ParentNodeStyle-ForeColor="White">
                </asp:TreeView>
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

        <!-- MODAL PERMISO -->
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

        <!-- CONTROLES OCULTOS -->
        <asp:TextBox ID="txtNuevoNombreServidor" runat="server" Style="display:none;"></asp:TextBox>
        <asp:Button ID="btnAceptarNuevoNombre" runat="server" Style="display:none;" OnClick="btnAceptarNuevoNombre_Click" />

        <!-- MODAL MODIFICAR -->
        <div id="modalModificar" class="modal">
            <div class="modal-contenido">
                <h3 id="tituloModalModificar">Modificando...</h3>

                <label>Ingrese el nuevo nombre:</label>
                <input type="text" id="txtNuevoNombre" placeholder="Nuevo nombre" />

                <div class="acciones">
                    <button type="button" onclick="guardarNuevoNombre()">Aceptar</button>
                    <button type="button" onclick="cerrarModalModificar()">Cancelar</button>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
