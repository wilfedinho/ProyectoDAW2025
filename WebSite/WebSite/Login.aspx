<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/EstiloLogin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-box">
                <h2 class="login-title">Iniciar Sesion</h2>
                <hr class="login-divider" />
                <div class="login-form">
                    <asp:Label ID="lblError" runat="server" CssClass="login-error" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="login-input" placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="Clave"></asp:TextBox>
                    <div class="login-options">
                        <asp:CheckBox ID="chkRemember" runat="server" CssClass="login-checkbox" />
                        <label for="chkRemember" class="remember-label">Recordar Usuario</label>
                    </div>
                    <div class="login-actions">
                        <asp:Button ID="btnSignIn" runat="server" Text="Iniciar Sesion" CssClass="login-btn" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="login-btn register-btn" OnClick="btnRegister_Click" />
                        <asp:Button ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" CssClass="login-btn register-btn" OnClick="btnCerrarSesion_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>