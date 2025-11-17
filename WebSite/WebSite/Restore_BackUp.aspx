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
        <nav id="navbarPrincipal" runat="server" class="navbar">
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="btnInicio"
                        Text="Inicio" CssClass="nav-link"
                        data-key="btn_inicio" CausesValidation="false"
                        OnClick="btnInicio_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnBackupRestore"
                        Text="Backup/Restore" CssClass="nav-link"
                        data-key="btn_backup" CausesValidation="false"
                        OnClick="btnBackupRestore_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnDigitosVerificadores"
                        Text="Dígitos Verificadores" CssClass="nav-link"
                        data-key="btn_Digitos" CausesValidation="false"
                        OnClick="btnDigitosVerificadores_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnClave"
                        Text="Cambiar Clave" CssClass="nav-link"
                        data-key="btn_clave" CausesValidation="false"
                        OnClick="btnCambiarClave_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnVuelos"
                        Text="Vuelos" CssClass="nav-link"
                        data-key="btn_vuelos" CausesValidation="false"
                        OnClick="btnVuelos_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnCerrarSesion"
                        Text="Cerrar Sesión" CssClass="nav-link cerrar"
                        data-key="btn_cerrarSesion" CausesValidation="false"
                        OnClick="btnCerrarSesion_Click"></asp:LinkButton>
                </li>
                <li style="display: inline-block; margin-left: 40px;">

                    <asp:LinkButton
                        ID="btnES"
                        runat="server"
                        CausesValidation="false"
                        CssClass="nav-link idioma-btn"
                        OnClick="btnES_Click">ES</asp:LinkButton>

                    <span style="margin: 0 8px; color: #888;">|</span>

                    <asp:LinkButton
                        ID="btnEN"
                        runat="server"
                        CausesValidation="false"
                        CssClass="nav-link idioma-btn"
                        OnClick="btnEN_Click">EN</asp:LinkButton>
                </li>
            </ul>
        </nav>
        <div class="page">
            <h1 class="page-title" data-key="🛡️ Gestión de Backup y Restore">🛡️ Gestión de Backup y Restore</h1>

            <div class="card">
                <h2 class="card-title" data-key="📦 Crear Backup">📦 Crear Backup</h2>
                <asp:Button ID="btnBackup" runat="server" Text="Realizar Backup" CssClass="btn" OnClick="btnBackup_Click" data-key="btn_backup" />
                <asp:Label ID="Label1" runat="server" Text="BackUp guardado en Documentos" Visible="false" data-key="BackUp guardado en Documentos"></asp:Label>
            </div>

            <div class="card">
                <h2 class="card-title" data-key="♻️ Restaurar Backup">♻️ Restaurar Backup</h2>
                <label for="archivo" class="input-label" data-key="Seleccionar archivo">Seleccionar archivo:</label>
                <asp:FileUpload ID="archivo" runat="server" CssClass="file-input" />
                <asp:Button ID="btnRestore" runat="server" Text="Restaurar Backup" CssClass="btn" OnClick="btnRestore_Click" data-key="btn_restore" />
                <asp:Label ID="Label2" runat="server" Text="Label" Visible="false"></asp:Label>
            </div>
            <div class="card">
                <h2 class="card-title" data-key="🔢 Calcular Dígito Verificador">🔢 Calcular Dígito Verificador</h2>

                <asp:Button ID="btnCalcularDV" runat="server" Text="Recalcular Dígito" CssClass="btn" OnClick="btnCalcularDV_Click" data-key="btn_calcularDVH" />

                <asp:Label ID="lblResultadoDV" runat="server" CssClass="mensaje-exito" Visible="false" />
            </div>
        </div>
    </form>
</body>
</html>
