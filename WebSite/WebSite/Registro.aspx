<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Usuario</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Registro.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-box">
                <h2 class="login-title">REGISTRO</h2>
                <hr class="login-divider" />
                <div class="login-form">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="login-input" placeholder="Usuario"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                        ControlToValidate="txtUsuario"
                        ErrorMessage="El usuario es requerido"
                        Display="Dynamic"
                        ForeColor="Red"
                        SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="login-input" placeholder="Nombre"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" 
                        ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es requerido"
                        Display="Dynamic"
                        ForeColor="Red"
                        SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="login-input" placeholder="Apellido"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                        ControlToValidate="txtApellido"
                        ErrorMessage="El apellido es requerido"
                        Display="Dynamic"
                        ForeColor="Red"
                        SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="login-input" placeholder="DNI"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDNI" runat="server" 
                        ControlToValidate="txtDNI"
                        ErrorMessage="El DNI es requerido"
                        Display="Dynamic"
                        ForeColor="Red"
                        SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="login-input" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                        ControlToValidate="txtEmail"
                        ErrorMessage="El Email es requerido"
                        Display="Dynamic"
                        ForeColor="Red"
                        SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                        ControlToValidate="txtPassword"
                        ErrorMessage="La contraseña es requerida"
                        Display="Dynamic"
                        ForeColor="Red"
                        SetFocusOnError="true">
                    </asp:RequiredFieldValidator>
                    <div class="login-actions">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="login-btn" OnClick="btnRegistrar_Click" />
                    </div>
                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>