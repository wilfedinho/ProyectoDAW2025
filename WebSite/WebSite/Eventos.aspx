<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Eventos.aspx.cs" Inherits="Eventos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Eventos</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Eventos.css" />

</head>
<body>
    <form id="form1" runat="server">

        <div class="navbar">
            <asp:Button CssClass="nav-item" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBackupRestore" runat="server" Text="Backup/Restore" OnClick="btnBackupRestore_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnDigitosVerificadores" runat="server" Text="Dígitos Verificadores" OnClick="btnDigitosVerificadores_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBitacora" runat="server" Text="Bitácora" OnClick="btnBitacora_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnCambiarClave" runat="server" Text="Cambiar Clave" OnClick="btnCambiarClave_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnVuelos" runat="server" Text="Vuelos" OnClick="btnVuelos_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
        </div>

        <div class="eventos-container">
            <h2>Bitacora de Eventos</h2>
            <div class="filtros-form">
                <div class="filtro-group">
                    <label for="txtDNI" class="filtro-label">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="filtro-input" placeholder="Usuario"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaInicio" class="filtro-label">Fecha Desde</label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha inicio"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaFin" class="filtro-label">Fecha Hasta</label>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha fin"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="chkFiltrarFecha" class="filtro-label">Filtrar por Fecha</label>
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" CssClass="filtro-checkbox" onclick="toggleFechas()" />
                </div>
                <div class="filtro-group">
                    <label for="ddlModulo" class="filtro-label">Módulo</label>
                    <asp:DropDownList ID="ddlModulo" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group">
                    <label for="ddlEvento" class="filtro-label">Descripción</label>
                    <asp:DropDownList ID="ddlEvento" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group">
                    <label for="ddlCriticidad" class="filtro-label">Criticidad</label>
                    <asp:DropDownList ID="ddlCriticidad" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group filtro-botones">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="filtro-btn" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" CssClass="filtro-btn" OnClick="btnRestablecer_Click" />
                </div>

                <div class="eventos-table-container">
                    <asp:GridView ID="gvEventos" runat="server" CssClass="eventos-table" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="NumeroEvento" HeaderText="N° Evento" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />


                            <asp:BoundField DataField="FechaEvento" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />


                            <asp:BoundField DataField="Hora" HeaderText="Hora" DataFormatString="{0:HH:mm:ss}" HtmlEncode="False" />

                            <asp:BoundField DataField="Modulo" HeaderText="Módulo" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                            <asp:BoundField DataField="Criticidad" HeaderText="Criticidad" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var chkFiltrarFechaId = '<%= chkFiltrarFecha.ClientID %>';
        var txtFechaInicioId = '<%= txtFechaInicio.ClientID %>';
        var txtFechaFinId = '<%= txtFechaFin.ClientID %>';
    </script>
    <script src="Scripts/filtrosEventos.js"></script>
</body>
</html>
