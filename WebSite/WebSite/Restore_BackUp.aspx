<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Restore_BackUp.aspx.cs" Inherits="Restore_BackUp" %>

<!DOCTYPE html>
<html lang="es">
<head>
  <meta charset="UTF-8">
  <title>Gestión de Backup y Restore</title>
  <link rel="stylesheet" href="EstilosPaginas/BackUp.css" />
  <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
</head>
<body>
  <form id="form1" runat="server">
    <div class="page">
      <h1 class="page-title">🛡️ Gestión de Backup y Restore</h1>

      <div class="card">
        <h2 class="card-title">📦 Crear Backup</h2>
        <asp:Button ID="btnBackup" runat="server" Text="Realizar Backup" CssClass="btn" OnClick="btnBackup_Click"/>
          <asp:Label ID="Label1" runat="server" Text="BackUp guardado en Documentos" Visible="false"></asp:Label>
      </div>

      <div class="card">
        <h2 class="card-title">♻️ Restaurar Backup</h2>
        <label for="archivo" class="input-label">Seleccionar archivo:</label>
        <asp:FileUpload ID="archivo" runat="server" CssClass="file-input" />
        <asp:Button ID="btnRestore" runat="server" Text="Restaurar Backup" CssClass="btn" OnClick="btnRestore_Click"/>
          <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
      </div>
        <div class="card">
  <h2 class="card-title">🔢 Calcular Dígito Verificador</h2>

  <asp:Button ID="btnCalcularDV" runat="server" Text="Calcular Dígito" CssClass="btn"/>

  <asp:Label ID="lblResultadoDV" runat="server" CssClass="mensaje-exito" Visible="false" />
</div>
    </div>
  </form>
</body>
</html>