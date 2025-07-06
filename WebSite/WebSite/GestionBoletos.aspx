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

        <div class="navbar">
            <div class="nav-item">Inicio</div>
            <div class="nav-item">Gestión Usuarios</div>
            <div class="nav-item">Gestión Beneficios</div>
            <div class="nav-item">Gestión Boletos</div>
            <div class="nav-item">Cambiar Clave</div>
            <div class="nav-item nav-right">Cerrar Sesion</div>
        </div>
        <div class="eventos-container">
            <h2>Gestion De Boletos</h2>
            <div class="filtros-form">
                <div class="filtro-group">
                    <label for="txtOrigen" class="filtro-label">Origen</label>
                    <asp:TextBox ID="txtOrigen" runat="server" CssClass="filtro-input" placeholder="Origen"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvOrigen" runat="server" ControlToValidate="txtOrigen"
                        ErrorMessage="El Origen del boleto es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label for="txtDestino" class="filtro-label">Destino</label>
                    <asp:TextBox ID="txtDestino" runat="server" CssClass="filtro-input" placeholder="Destino"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDestino" runat="server" ControlToValidate="txtDestino"
                        ErrorMessage="El Destino del boleto es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label for="txtFechaInicioIDA" class="filtro-label">Fecha Desde</label>
                    <asp:TextBox ID="txtFechaInicioIDA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha inicio IDA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaInicioVUELTA" class="filtro-label">Fecha Desde Vuelta</label>
                    <asp:TextBox ID="txtFechaInicioVUELTA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha inicio VUELTA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaFinIDA" class="filtro-label">Fecha Hasta</label>
                    <asp:TextBox ID="txtFechaFinIDA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha fin IDA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="txtFechaFinVUELTA" class="filtro-label">Fecha Hasta Vuelta</label>
                    <asp:TextBox ID="txtFechaFinVUELTA" runat="server" CssClass="filtro-input" TextMode="Date" placeholder="Fecha fin VUELTA"></asp:TextBox>
                </div>
                <div class="filtro-group">
                    <label for="chkFiltrarFecha" class="filtro-label">Modalidad IDA - VUELTA</label>
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" CssClass="filtro-checkbox" onclick="toggleFechas()" />
                </div>
                <div class="filtro-group">
                    <label for="ddlClaseBoleto" class="filtro-label">Clase Boleto</label>
                    <asp:DropDownList ID="ddlClaseBoleto" runat="server" CssClass="filtro-input">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                        <asp:ListItem Text="Turista" Value="Turista" />
                        <asp:ListItem Text="Ejecutiva" Value="Ejecutiva" />
                        <asp:ListItem Text="Primera Clase" Value="Primera Clase" />
                    </asp:DropDownList>
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Peso Del Equipaje Permitido</label>
                    <asp:TextBox ID="txtPesoEquipaje" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtPesoEquipaje"
                        ErrorMessage="El equipaje del boleto es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El precio es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label for="txtNumeroAsiento" class="filtro-label">Numero Asiento</label>
                    <asp:TextBox ID="txtNumeroAsiento" runat="server" CssClass="filtro-input" placeholder="Numero Asiento"></asp:TextBox>
                </div>
                <div class="filtro-group filtro-botones">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="filtro-btn" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="filtro-btn" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="filtro-btn" OnClick="btnBorrar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="filtro-btn" OnClick="btnLimpiar_Click" />
                </div>

                <div class="eventos-table-container">
                    <asp:GridView ID="gvBoletos" runat="server" CssClass="eventos-table" AutoGenerateColumns="False" DataKeyNames="ID, Origen, Destino,FechaPartidaIDA,FechaLlegadaIDA,FechaPartidaVUELTA,FechaLlegadaVUELTA,ClaseBoleto,PesoEquipaje,Precio,NumeroAsiento"
                        OnSelectedIndexChanged="gvBoletos_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="&#8594;" ButtonType="Link" ItemStyle-ForeColor="#2196F3" ItemStyle-Font-Size="Large" />
                            <asp:BoundField DataField="ID" HeaderText="NumeroBoleto" />
                            <asp:BoundField DataField="Origen" HeaderText="Origen" />
                            <asp:BoundField DataField="Destino" HeaderText="Destino" />
                            <asp:BoundField DataField="FechaPartidaIDA" HeaderText="FechaPartidaIDA" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                            <asp:BoundField DataField="FechaLlegadaIDA" HeaderText="FechaLlegadaIDA" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                            <asp:BoundField DataField="FechaPartidaVUELTA" HeaderText="FechaPartidaVUELTA" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                            <asp:BoundField DataField="FechaLlegadaVUELTA" HeaderText="FechaLlegadaVUELTA" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                            <asp:BoundField DataField="ClaseBoleto" HeaderText="Hora" HtmlEncode="False" />
                            <asp:BoundField DataField="PesoEquipaje" HeaderText="Peso Equipaje" />
                            <asp:BoundField DataField="Precio" HeaderText="Precio" />
                            <asp:BoundField DataField="NumeroAsiento" HeaderText="NumeroAsiento" />
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
