<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Iniciar Sesión</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/EstiloLogin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-box">
                <h2 class="login-title">Iniciar Sesión</h2>
                <hr class="login-divider" />
                <div class="login-form">
                    <asp:Label ID="lblError" runat="server" CssClass="login-error" ForeColor="Red" Visible="false"></asp:Label>
                    <div class="login-input-group">
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="login-input" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <div class="login-input-group">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="Clave"></asp:TextBox>
                    </div>
                    <div class="login-options">
                        <asp:CheckBox ID="chkRemember" runat="server" CssClass="login-checkbox" />
                        <span class="remember-label">Recordar Usuario</span>
                    </div>
                    <div class="login-actions">
                        <asp:Button ID="btnSignIn" runat="server" Text="Iniciar Sesión" CssClass="login-btn" OnClick="btnLogin_Click" />
                        <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="login-btn" OnClick="btnRegister_Click" />
                        <asp:Button ID="btnClaveOlvidada" runat="server" Text="Clave Olvidada?" CssClass="login-btn" OnClick="btnClaveOlvidada_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>