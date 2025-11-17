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
                    <asp:LinkButton runat="server" ID="btnBitacora"
                        Text="Bitácora" CssClass="nav-link"
                        data-key="btn_Bitacora" CausesValidation="false"
                        OnClick="btnBitacora_Click"></asp:LinkButton>
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

        <div class="eventos-container" runat="server">
            <h2 runat="server" data-key="bitacoraEventos">Bitacora de Eventos</h2>
            <div class="filtros-form" runat="server">
                <div class="filtro-group" runat="server">
                    <label for="txtDNI" class="filtro-label" runat="server" data-key="Usuario">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="filtro-input"></asp:TextBox>
                </div>
                <div class="filtro-group" runat="server">
                    <label for="txtFechaInicio" runat="server" data-key="Fecha Desde" class="filtro-label">Fecha Desde</label>
                    <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha inicio"></asp:TextBox>
                </div>
                <div class="filtro-group" runat="server">
                    <label for="txtFechaFin" runat="server" data-key="Fecha Hasta" class="filtro-label">Fecha Hasta</label>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha fin"></asp:TextBox>
                </div>
                <div class="filtro-group" runat="server">
                    <label for="chkFiltrarFecha" runat="server" data-key="Filtrar por Fecha" class="filtro-label">Filtrar por Fecha</label>
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" CssClass="filtro-checkbox" onclick="toggleFechas()" />
                </div>
                <div class="filtro-group" runat="server">
                    <label for="ddlModulo" runat="server" data-key="modulo" class="filtro-label">Módulo</label>
                    <asp:DropDownList ID="ddlModulo" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group" runat="server">
                    <label for="ddlEvento" runat="server" data-key="descripciao" class="filtro-label">Descripción</label>
                    <asp:DropDownList ID="ddlEvento" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group" runat="server">
                    <label for="ddlCriticidad" runat="server" data-key="criticidad" class="filtro-label">Criticidad</label>
                    <asp:DropDownList ID="ddlCriticidad" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group filtro-botones" runat="server">
                    <asp:Button ID="btnFiltrar" runat="server" data-key="btnFiltrar" Text="Filtrar" CssClass="filtro-btn" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnRestablecer" runat="server" data-key="btnRestablecer" Text="Restablecer" CssClass="filtro-btn" OnClick="btnRestablecer_Click" />
                </div>

                <div class="eventos-table-container" runat="server">
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
