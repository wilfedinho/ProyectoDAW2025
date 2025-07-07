<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrorBDAdmin.aspx.cs" Inherits="ErrorBDAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Error en la Base de Datos</title>
    <link rel="stylesheet" href="ErrorBD.css" />
    <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">
                <h1>⚠️ Error de Base de Datos</h1>
                <asp:Label ID="Label1" runat="server" 
                           Text="Inconsistencia en la base de datos. Por favor, comuníquese con el webmaster del sistema."
                           CssClass="error-text"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
