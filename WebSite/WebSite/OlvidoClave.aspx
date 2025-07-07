<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OlvidoClave.aspx.cs" Inherits="OlvidoClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="EstilosPaginas/CambiarClave.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-central" style="max-width: 400px;">
            <h2 class="panel-titulo">Reseteo De Clave</h2>
            <div class="formulario-grid">
                <div class="filtro-group">
                    <label for="txtUsuario" class="filtro-label">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="filtro-input"  placeholder="Ingrese Su Usuario" />
                </div>
                <div class="filtro-group">
                    <label for="txtDNI" class="filtro-label">DNI</label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="filtro-input"  placeholder="Ingrese Su DNI" />
                </div>
            </div>
            <div class="botones-group" style="margin-top: 24px;">
                <asp:Button ID="btnCambiarClave" runat="server" Text="Resetear Clave" CssClass="boton-azul" OnClick="btnCambiarClave_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton-azul" OnClick="btnCancelar_Click" />
            </div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="eventos-resultados" EnableViewState="false" />
        </div>
    </form>
</body>
</html>
