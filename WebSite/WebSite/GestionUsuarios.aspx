<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUsuarios.aspx.cs" Inherits="GestionUsuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Usuarios</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Eventos.css" />
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
                        CausesValidation="false"
                        OnClick="btnES_Click">ES</asp:LinkButton>

                    <span style="margin: 0 8px; color: #888;">|</span>

                    <asp:LinkButton
                        ID="btnEN"
                        runat="server"
                        CssClass="nav-link idioma-btn"
                        CausesValidation="false"
                        OnClick="btnEN_Click">EN</asp:LinkButton>
                </li>
            </ul>
        </nav>

        <div class="eventos-container" runat="server">
            <h2 runat="server" data-key="Gestion de Usuarios">Gestión de Usuarios</h2>
            <div class="filtros-form" runat="server">
                <div class="filtro-group">
                    <label class="filtro-label" runat="server" data-key="Usuario">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvUsuario"
                        runat="server"
                        ControlToValidate="txtUsuario"
                        ErrorMessage="El usuario es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="El usuario es obligatorio" />
                </div>
                <div class="filtro-group" runat="server">
                    <label class="filtro-label" runat="server" data-key="Nombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvNombre"
                        runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="El nombre es obligatorio" />
                </div>
                <div class="filtro-group" runat="server">
                    <label data-key="Apellido" class="filtro-label" runat="server">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvApellido"
                        runat="server"
                        ControlToValidate="txtApellido"
                        ErrorMessage="El apellido es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="El apellido es obligatorio" />
                </div>
                <div class="filtro-group" runat="server">
                    <label class="filtro-label">DNI</label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvDNI"
                        runat="server"
                        ControlToValidate="txtDNI"
                        ErrorMessage="El DNI es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="El DNI es obligatorio" />
                </div>
                <div class="filtro-group" runat="server">
                    <label class="filtro-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="El email es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="El email es obligatorio" />
                </div>
                <div class="filtro-group" runat="server">
                    <label data-key="Rol" class="filtro-label" runat="server">Rol</label>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                        <asp:ListItem Text="WebMaster" Value="WebMaster" />
                        <asp:ListItem Text="Admin" Value="Admin" />
                        <asp:ListItem Text="Usuario" Value="Usuario" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator
                        ID="rfvRol"
                        runat="server"
                        ControlToValidate="ddlRol"
                        InitialValue=""
                        ErrorMessage="El rol es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="El rol es obligatorio" />
                </div>
                <div class="filtro-group" runat="server">
                    <label class="filtro-label" data-key="cantEstrellas" runat="server">Cantidad de Estrellas</label>
                    <asp:TextBox ID="txtEstrellas" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator
                        ID="rfvEstrellas"
                        runat="server"
                        ControlToValidate="txtEstrellas"
                        ErrorMessage="La cantidad de estrellas es obligatoria"
                        CssClass="validador-error"
                        Display="Dynamic"
                        data-key="La cantidad de estrellas es obligatoria" />
                </div>
                <div class="filtro-group filtro-botones" runat="server">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="validador-error" Visible="false" />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="filtro-btn" OnClick="btnAgregar_Click" data-key="btn_agregar" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="filtro-btn" OnClick="btnModificar_Click" data-key="btn_modificar" />
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="filtro-btn" OnClick="btnBorrar_Click" data-key="btn_borrar" />
                </div>
            </div>
            <div class="eventos-table-container" runat="server">
                <asp:GridView ID="gvUsuarios" runat="server" CssClass="eventos-table"
                    AutoGenerateColumns="False" DataKeyNames="Usuario,Nombre,Apellido,DNI,Email,Rol,Estrellas"
                    OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
                    <Columns>

                        <asp:CommandField ShowSelectButton="True" SelectText="&#8594;" ButtonType="Link" ItemStyle-ForeColor="#2196F3" ItemStyle-Font-Size="Large" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Rol" HeaderText="Rol" />
                        <asp:BoundField DataField="Estrellas" HeaderText="Estrellas" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
