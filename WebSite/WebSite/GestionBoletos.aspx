<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionBoletos.aspx.cs" Inherits="GestionBoletos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                    <asp:LinkButton runat="server" ID="btnUsuarios"
                        Text="Gestión Usuarios" CssClass="nav-link"
                        data-key="btn_usuarios" CausesValidation="false"
                        OnClick="btnUsuarios_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnPermisos"
                        Text="Gestión Permisos" CssClass="nav-link"
                        data-key="btn_permisos" CausesValidation="false"
                        OnClick="btnPermisos_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnBeneficios"
                        Text="Gestión Beneficios" CssClass="nav-link"
                        data-key="btn_beneficios" CausesValidation="false"
                        OnClick="btnBeneficios_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnBoletos"
                        Text="Gestión Boletos" CssClass="nav-link"
                        data-key="btn_boletos" CausesValidation="false"
                        OnClick="btnBoletos_Click"></asp:LinkButton>
                </li>

                <li>
                    <asp:LinkButton runat="server" ID="btnClave"
                        Text="Cambiar Clave" CssClass="nav-link"
                        data-key="btn_clave" CausesValidation="false"
                        OnClick="btnClave_Click"></asp:LinkButton>
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
                        CssClass="nav-link idioma-btn"
                        OnClick="btnES_Click">ES</asp:LinkButton>

                    <span style="margin: 0 8px; color: #888;">|</span>

                    <asp:LinkButton
                        ID="btnEN"
                        runat="server"
                        CssClass="nav-link idioma-btn"
                        OnClick="btnEN_Click">EN</asp:LinkButton>
                </li>
            </ul>
        </nav>
        <div class="eventos-container">
            <h2 runat="server" id="tituloPrincipal" data-key="Gestion de Boletos">Gestion De Boletos</h2>
            <div class="filtros-form">
                <div class="filtro-group">
                    <label for="txtOrigen" class="filtro-label" data-key="Origen">Origen"</label>
                    <asp:TextBox ID="txtOrigen" runat="server" CssClass="filtro-input" placeholder="Origen"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvOrigen" runat="server" ControlToValidate="txtOrigen"
                        ErrorMessage="El Origen del boleto es obligatorio" CssClass="validador-error" Display="Dynamic" data-key="El origen del boleto es obligatorio" />
                </div>
                <div class="filtro-group">
                    <label for="txtDestino" class="filtro-label" data-key="Destino">Destino</label>
                    <asp:TextBox ID="txtDestino" runat="server" CssClass="filtro-input" placeholder="Destino"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDestino" runat="server" ControlToValidate="txtDestino"
                        ErrorMessage="El Destino del boleto es obligatorio" CssClass="validador-error" Display="Dynamic" data-key="El Destino del boleto es obligatorio" />
                </div>
                <div class="filtro-group">
                    <label for="txtFechaInicioIDA" class="filtro-label" data-key="Fecha Desde">Fecha Desde</label>
                    <asp:TextBox ID="txtFechaInicioIDA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha inicio IDA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaInicioVUELTA" class="filtro-label" data-key="Fecha Desde Vuelta">Fecha Desde Vuelta</label>
                    <asp:TextBox ID="txtFechaInicioVUELTA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha inicio VUELTA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaFinIDA" class="filtro-label" data-key="Fecha Hasta">Fecha Hasta</label>
                    <asp:TextBox ID="txtFechaFinIDA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha fin IDA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaFinVUELTA" class="filtro-label" data-key="Fecha Hasta Vuelta">Fecha Hasta Vuelta</label>
                    <asp:TextBox ID="txtFechaFinVUELTA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha fin VUELTA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="chkFiltrarFecha" class="filtro-label" data-key="Modalidad IDA - VUELTA">Modalidad IDA - VUELTA</label>
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" CssClass="filtro-checkbox" onclick="toggleFechas()" />
                </div>
                <div class="filtro-group">
                    <label for="ddlClaseBoleto" class="filtro-label" data-key="Clase Boleto">Clase Boleto</label>
                    <asp:DropDownList ID="ddlClaseBoleto" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" data-key="-- Seleccione --" />
                        <asp:ListItem Text="Turista" Value="Turista" data-key="Turista" />
                        <asp:ListItem Text="Ejecutiva" Value="Ejecutiva" data-key="Ejecutiva" />
                        <asp:ListItem Text="Primera Clase" Value="Primera Clase" data-key="Primera Clase" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group">
                    <label class="filtro-label" data-key="Peso Del Equipaje Permitido">Peso Del Equipaje Permitido</label>
                    <asp:TextBox ID="txtPesoEquipaje" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtPesoEquipaje"
                        ErrorMessage="El equipaje del boleto es obligatorio" CssClass="validador-error" Display="Dynamic" data-key="El equipaje del boleto es obligatorio" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El precio es obligatorio" CssClass="validador-error" Display="Dynamic" data-key="El precio es obligatorio" />
                </div>
                <div class="filtro-group">
                    <label for="txtNumeroAsiento" class="filtro-label" data-key="Numero Asiento">Numero Asiento</label>
                    <asp:TextBox ID="txtNumeroAsiento" runat="server" CssClass="filtro-input" placeholder="Numero Asiento"></asp:TextBox>
                </div>
                <div class="filtro-group filtro-botones">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="filtro-btn" OnClick="btnAgregar_Click" data-key="btn_agregar" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="filtro-btn" OnClick="btnModificar_Click" data-key="btn_modificar" />
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="filtro-btn" OnClick="btnBorrar_Click" data-key="btn_borrar" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="filtro-btn" OnClick="btnLimpiar_Click" CausesValidation="false" data-key="btnLimpiar" />
                </div>

                <div class="eventos-table-container">
                    <asp:GridView ID="gvBoletos" runat="server" CssClass="eventos-table" AutoGenerateColumns="False" DataKeyNames="ID, Origen, Destino,FechaPartidaIDA,FechaLlegadaIDA,FechaPartidaVUELTA,FechaLlegadaVUELTA,ClaseBoleto,PesoEquipaje,Precio,NumeroAsiento"
                        OnSelectedIndexChanged="gvBoletos_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="&#8594;" ButtonType="Link" ItemStyle-ForeColor="#2196F3" ItemStyle-Font-Size="Large" />
                            <asp:BoundField DataField="ID" HeaderText="NumeroBoleto"></asp:BoundField>
                            <asp:BoundField DataField="Origen" HeaderText="Origen"></asp:BoundField>
                            <asp:BoundField DataField="Destino" HeaderText="Destino"></asp:BoundField>
                            <asp:BoundField DataField="FechaPartidaIDA" HeaderText="FechaPartidaIDA"></asp:BoundField>
                            <asp:BoundField DataField="FechaLlegadaIDA" HeaderText="FechaLlegadaIDA"></asp:BoundField>
                            <asp:BoundField DataField="FechaPartidaVUELTA" HeaderText="FechaPartidaVUELTA"></asp:BoundField>
                            <asp:BoundField DataField="FechaLlegadaVUELTA" HeaderText="FechaLlegadaVUELTA"></asp:BoundField>
                            <asp:BoundField DataField="ClaseBoleto" HeaderText="Clase"></asp:BoundField>
                            <asp:BoundField DataField="PesoEquipaje" HeaderText="Peso Equipaje"></asp:BoundField>
                            <asp:BoundField DataField="Precio" HeaderText="Precio"></asp:BoundField>
                            <asp:BoundField DataField="NumeroAsiento" HeaderText="NumeroAsiento"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        var chkFiltrarFechaId = '<%= chkFiltrarFecha.ClientID %>';
        var txtFechaInicioId = '<%= txtFechaInicioVUELTA.ClientID %>';
        var txtFechaFinId = '<%= txtFechaFinVUELTA.ClientID %>';
    </script>
    <script src="Scripts/filtrosEventos.js"></script>
</body>
</html>
