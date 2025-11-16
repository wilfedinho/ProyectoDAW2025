<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GestionBeneficios.aspx.cs" Inherits="GestionBeneficios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Gestión de Beneficios</title>
    <link rel="stylesheet" type="text/css" href="EstilosPaginas/Eventos.css" />
</head>
<body>
    <form id="form1" runat="server">

        <div id="navbarPrincipal" runat="server" class="navbar">
            <asp:Button CssClass="nav-item" ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnUsuarios" runat="server" Text="Gestión Usuarios" OnClick="btnUsuarios_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBeneficios" runat="server" Text="Gestión Beneficios" OnClick="btnBeneficios_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnBoletos" runat="server" Text="Gestión Boletos" OnClick="btnBoletos_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnClave" runat="server" Text="Cambiar Clave" OnClick="btnClave_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item" ID="btnVuelos" runat="server" Text="Vuelos" OnClick="btnVuelos_Click" CausesValidation="false" />
            <asp:Button CssClass="nav-item nav-right" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" CausesValidation="false" />
        </div>

        <div class="eventos-container">
            <h2 style="text-align: left;">Gestión de Beneficios</h2>
            <div class="filtros-form">

                <div class="filtro-group">
                    <label class="filtro-label">Código Beneficio</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"
                        ErrorMessage="El código es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div></div>
                <div class="filtro-group">
                    <label class="filtro-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="El nombre es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Cantidad Canjeada</label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtCantidad"
                        ErrorMessage="La cantidad es obligatoria" CssClass="validador-error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvCantidad" runat="server" ControlToValidate="txtCantidad"
                        MinimumValue="0" MaximumValue="1000000" Type="Integer"
                        ErrorMessage="La cantidad debe ser positiva" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio"
                        ErrorMessage="El precio es obligatorio" CssClass="validador-error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvPrecio" runat="server" ControlToValidate="txtPrecio"
                        MinimumValue="0" MaximumValue="1000000" Type="Double"
                        ErrorMessage="El precio debe ser positivo" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group">
                    <label class="filtro-label">Descuento (%)</label>
                    <asp:TextBox ID="txtDescuento" runat="server" CssClass="filtro-input" TextMode="Number" min="0" max="100" />
                    <asp:RequiredFieldValidator ID="rfvDescuento" runat="server" ControlToValidate="txtDescuento"
                        ErrorMessage="El descuento es obligatorio" CssClass="validador-error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvDescuento" runat="server" ControlToValidate="txtDescuento"
                        MinimumValue="0" MaximumValue="100" Type="Integer"
                        ErrorMessage="El descuento debe estar entre 0 y 100" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group filtro-botones">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="filtro-btn" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="filtro-btn" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="filtro-btn" OnClick="btnBorrar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="filtro-btn" OnClick="btnLimpiar_Click" CausesValidation="false" />
                </div>
                <div class="filtro-group" style="margin-bottom: 20px;">
                    <label class="filtro-label" style="font-weight: bold;">Exportar Datos a XML</label>
                    <asp:Button ID="btnSerializar" runat="server"
                        Text="Serializar (Guardar en XML)"
                        CssClass="filtro-btn"
                        OnClick="btnSerializar_Click"
                        CausesValidation="false"
                        ToolTip="Guarda todos los beneficios actuales en un archivo XML." />
                </div>

                <div class="filtro-group">
                    <label class="filtro-label" style="font-weight: bold;">Importar Datos desde XML</label>
                    <asp:FileUpload ID="fuArchivoXML" runat="server"
                        CssClass="filtro-input"
                        Style="width: auto; display: inline-block;"
                        accept=".xml" />
                    <asp:Button ID="btnDeserializar" runat="server"
                        Text="Deserializar (Cargar desde XML)"
                        CssClass="filtro-btn"
                        OnClick="btnDeserializar_Click"
                        ValidationGroup="ImportXML"
                        ToolTip="Carga y reemplaza los beneficios desde el archivo XML seleccionado." />

                    <asp:RequiredFieldValidator ID="rfvArchivoXML" runat="server"
                        ControlToValidate="fuArchivoXML"
                        ErrorMessage="Debe seleccionar un archivo XML para importar."
                        CssClass="validador-error" Display="Dynamic"
                        ValidationGroup="ImportXML" />
                </div>

                <asp:Label ID="lblMensaje" runat="server" CssClass="validador-error" Visible="false" />
            </div>
            <div class="eventos-table-container">
                <asp:GridView ID="gvBeneficios" runat="server" CssClass="eventos-table"
                    AutoGenerateColumns="False"
                    DataKeyNames="CodigoBeneficio,Nombre,PrecioEstrella,CantidadBeneficioReclamo,DescuentoAplicar"
                    OnSelectedIndexChanged="gvBeneficios_SelectedIndexChanged">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccionar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowSelectButton="True" SelectText="&#8594;" ButtonType="Link" ItemStyle-ForeColor="#2196F3" ItemStyle-Font-Size="Large" />
                        <asp:BoundField DataField="CodigoBeneficio" HeaderText="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="PrecioEstrella" HeaderText="Precio" />
                        <asp:BoundField DataField="CantidadBeneficioReclamo" HeaderText="Cantidad Canjeada" />
                        <asp:BoundField DataField="DescuentoAplicar" HeaderText="Descuento (%)" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

