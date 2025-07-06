﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionUsuarios.aspx.cs" Inherits="GestionUsuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Usuarios</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Eventos.css" />
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

        <div class="eventos-container">
            <h2>Gestión de Usuarios</h2>
            <div class="filtros-form">
                <div class="filtro-group">
                    <label class="filtro-label">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvUsuario"
                        runat="server"
                        ControlToValidate="txtUsuario"
                        ErrorMessage="El usuario es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvNombre"
                        runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvApellido"
                        runat="server"
                        ControlToValidate="txtApellido"
                        ErrorMessage="El apellido es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">DNI</label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvDNI"
                        runat="server"
                        ControlToValidate="txtDNI"
                        ErrorMessage="El DNI es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator
                        ID="rfvEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="El email es obligatorio"
                        CssClass="validador-error"
                        Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Rol</label>
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
                        Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Cantidad de Estrellas</label>
                    <asp:TextBox ID="txtEstrellas" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator
                        ID="rfvEstrellas"
                        runat="server"
                        ControlToValidate="txtEstrellas"
                        ErrorMessage="La cantidad de estrellas es obligatoria"
                        CssClass="validador-error"
                        Display="Dynamic" />
                </div>
                <div class="filtro-group filtro-botones">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="validador-error" Visible="false" />
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="filtro-btn" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="filtro-btn" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="filtro-btn" OnClick="btnBorrar_Click" />
                </div>
            </div>
            <div class="eventos-table-container">
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
