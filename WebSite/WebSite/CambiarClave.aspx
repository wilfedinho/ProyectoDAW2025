<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CambiarClave.aspx.cs" Inherits="CambiarClave" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cambiar Clave</title>
    <link href="EstilosPaginas/CambiarClave.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-central" style="max-width: 400px;">
            <h2 class="panel-titulo">Cambiar Clave</h2>
            <div class="formulario-grid">
                <div class="filtro-group">
                    <label for="txtNuevaClave" class="filtro-label">Nueva Clave</label>
                    <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="filtro-input" TextMode="Password" placeholder="Nueva clave" />
                </div>
                <div class="filtro-group">
                    <label for="txtConfirmarClave" class="filtro-label">Confirmar Clave</label>
                    <asp:TextBox ID="txtConfirmarClave" runat="server" CssClass="filtro-input" TextMode="Password" placeholder="Confirmar clave" />
                </div>
            </div>
            <div class="botones-group" style="margin-top: 24px;">
                <asp:Button ID="btnCambiarClave" runat="server" Text="Cambiar Clave" CssClass="boton-azul" OnClick="btnCambiarClave_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="boton-azul" OnClick="btnCancelar_Click" />
            </div>
            <asp:Label ID="lblMensaje" runat="server" CssClass="eventos-resultados" EnableViewState="false" />
        </div>
    </form>
</body>
</html>