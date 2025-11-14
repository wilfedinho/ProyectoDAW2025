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
        <div id="navbarPrincipal" runat="server" class="navbar">
            <asp:Button CssClass="nav-item" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" CausesValidation="false" data-key="btn_inicio"/>
            <asp:Button CssClass="nav-item" ID="btnUsuarios" runat="server" Text="Gestión Usuarios" OnClick="btnUsuarios_Click" CausesValidation="false" data-key="btn_usuarios"/>
            <asp:Button CssClass="nav-item" ID="btnBeneficios" runat="server" Text="Gestión Beneficios" OnClick="btnBeneficios_Click" CausesValidation="false" data-key="btn_beneficios"/>
            <asp:Button CssClass="nav-item" ID="btnBoletos" runat="server" Text="Gestión Boletos" OnClick="btnBoletos_Click" CausesValidation="false" data-key="btn_boletos"/>
            <asp:Button CssClass="nav-item" ID="btnClave" runat="server" Text="Cambiar Clave" OnClick="btnClave_Click" CausesValidation="false" data-key="btn_clave"/>
            <asp:Button CssClass="nav-item" ID="btnVuelos" runat="server" Text="Vuelos" OnClick="btnVuelos_Click" CausesValidation="false" data-key="btn_vuelos"/>
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false" data-key="btn_cerrarSesion"/>
        </div>
        <div class="page">
            <h1 class="page-title" data-key="🛡️ Gestión de Backup y Restore">🛡️ Gestión de Backup y Restore</h1>

            <div class="card">
                <h2 class="card-title" data-key="📦 Crear Backup">📦 Crear Backup</h2>
                <asp:Button ID="btnBackup" runat="server" Text="Realizar Backup" CssClass="btn" OnClick="btnBackup_Click" data-key="btn_backup"/>
                <asp:Label ID="Label1" runat="server" Text="BackUp guardado en Documentos" Visible="false" data-key="BackUp guardado en Documentos"></asp:Label>
            </div>

            <div class="card">
                <h2 class="card-title" data-key="♻️ Restaurar Backup">♻️ Restaurar Backup</h2>
                <label for="archivo" class="input-label" data-key="Seleccionar archivo">Seleccionar archivo:</label>
                <asp:FileUpload ID="archivo" runat="server" CssClass="file-input" />
                <asp:Button ID="btnRestore" runat="server" Text="Restaurar Backup" CssClass="btn" OnClick="btnRestore_Click" data-key="btn_restore"/>
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <div class="card">
                <h2 class="card-title" data-key="🔢 Calcular Dígito Verificador">🔢 Calcular Dígito Verificador</h2>

                <asp:Button ID="btnCalcularDV" runat="server" Text="Recalcular Dígito" CssClass="btn" OnClick="btnCalcularDV_Click" data-key="btn_calcularDVH"/>

                <asp:Label ID="lblResultadoDV" runat="server" CssClass="mensaje-exito" Visible="false" />
            </div>
        </div>
    </form>
</body>
</html>
