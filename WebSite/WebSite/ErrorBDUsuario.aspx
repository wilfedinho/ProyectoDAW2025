<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorBDUsuario.aspx.cs" Inherits="ErrorBD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Página No Disponible</title>
    <link rel="stylesheet" href="ErrorBDUsuario.css" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h1>🚫 Página No Disponible</h1>
                <asp:Label ID="Label1" runat="server" 
                           Text="La página solicitada no está disponible en este momento." 
                           CssClass="error-text"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
