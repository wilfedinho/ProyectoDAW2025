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
                        CssClass="nav-link idioma-btn" CausesValidation="false"
                        OnClick="btnES_Click">ES</asp:LinkButton>

                    <span style="margin: 0 8px; color: #888;">|</span>

                    <asp:LinkButton
                        ID="btnEN"
                        runat="server"
                        CssClass="nav-link idioma-btn" CausesValidation="false"
                        OnClick="btnEN_Click">EN</asp:LinkButton>
                </li>
            </ul>
        </nav>

        <div class="eventos-container" runat="server">
            <h2 style="text-align: left;" runat="server" data-key="gestBeneficios">Gestión de Beneficios</h2>
            <div class="filtros-form" runat="server">

                <div class="filtro-group" runat="server">
                    <label class="filtro-label" runat="server" data-key="codBene">Código Beneficio</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" data-key="codigoObligatorio"
                        ErrorMessage="El código es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group" runat="server">
                    <label runat="server" data-key="nom" class="filtro-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="filtro-input" />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" data-key="nombreObligato"
                        ErrorMessage="El nombre es obligatorio" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group" runat="server">
                    <label runat="server" data-key="cantCanjeada" class="filtro-label">Cantidad Canjeada</label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="txtCantidad" data-key="CantObligatoria"
                        ErrorMessage="La cantidad es obligatoria" CssClass="validador-error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvCantidad" runat="server" ControlToValidate="txtCantidad"
                        MinimumValue="0" MaximumValue="1000000" Type="Integer" data-key="cantPositiva"
                        ErrorMessage="La cantidad debe ser positiva" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group" runat="server">
                    <label runat="server" data-key="precio" class="filtro-label">Precio</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="filtro-input" TextMode="Number" min="0" />
                    <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ControlToValidate="txtPrecio" data-key="preObligatorio"
                        ErrorMessage="El precio es obligatorio" CssClass="validador-error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvPrecio" runat="server" ControlToValidate="txtPrecio"
                        MinimumValue="0" MaximumValue="1000000" Type="Double" data-key="prePos"
                        ErrorMessage="El precio debe ser positivo" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group" runat="server">
                    <label runat="server" data-key="desc" class="filtro-label">Descuento (%)</label>
                    <asp:TextBox ID="txtDescuento" runat="server" CssClass="filtro-input" TextMode="Number" min="0" max="100" />
                    <asp:RequiredFieldValidator ID="rfvDescuento" runat="server" ControlToValidate="txtDescuento" data-key="descObligatorio"
                        ErrorMessage="El descuento es obligatorio" CssClass="validador-error" Display="Dynamic" />
                    <asp:RangeValidator ID="rvDescuento" runat="server" ControlToValidate="txtDescuento"
                        MinimumValue="0" MaximumValue="100" Type="Integer" data-key="descEntre"
                        ErrorMessage="El descuento debe estar entre 0 y 100" CssClass="validador-error" Display="Dynamic" />
                </div>
                <div class="filtro-group filtro-botones" runat="server">
                    <asp:Button ID="btnAgregar" runat="server" data-key="btn_agregar" Text="Agregar" CssClass="filtro-btn" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnModificar" runat="server" data-key="btn_modificar" Text="Modificar" CssClass="filtro-btn" OnClick="btnModificar_Click" />
                    <asp:Button ID="btnBorrar" runat="server" data-key="btn_borrar" Text="Borrar" CssClass="filtro-btn" OnClick="btnBorrar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" data-key="btn_limpiar" Text="Limpiar" CssClass="filtro-btn" OnClick="btnLimpiar_Click" CausesValidation="false" />
                </div>
                <div class="filtro-group" style="margin-bottom: 20px;" runat="server">
                    <label class="filtro-label" style="font-weight: bold;" runat="server" data-key="exportarXML">Exportar Datos a XML</label>
                    <asp:Button ID="btnSerializar" runat="server"
                        Text="Serializar (Guardar en XML)"
                        CssClass="filtro-btn"
                        OnClick="btnSerializar_Click"
                        CausesValidation="false"
                        data-key="serializar"
                        />
                </div>

                <div class="filtro-group">
                    <label class="filtro-label" runat="server" data-key="importarXML" style="font-weight: bold;">Importar Datos desde XML</label>
                    <asp:FileUpload ID="fuArchivoXML" runat="server"
                        CssClass="filtro-input"
                        Style="width: auto; display: inline-block;"
                        accept=".xml" />
                    <asp:Button ID="btnDeserializar" runat="server"
                        Text="Deserializar (Cargar desde XML)"
                        CssClass="filtro-btn"
                        data-key="deserializar"
                        OnClick="btnDeserializar_Click"
                        ValidationGroup="ImportXML"
                        />

                    <asp:RequiredFieldValidator ID="rfvArchivoXML" runat="server"
                        ControlToValidate="fuArchivoXML"
                        ErrorMessage="Debe seleccionar un archivo XML para importar."
                        data-key="debeSeleccionarXML"
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
                        <asp:BoundField DataField="CodigoBeneficio" HeaderText="---" />
                        <asp:BoundField DataField="Nombre" HeaderText="---" />
                        <asp:BoundField DataField="PrecioEstrella" HeaderText="---" />
                        <asp:BoundField DataField="CantidadBeneficioReclamo" HeaderText="---" />
                        <asp:BoundField DataField="DescuentoAplicar" HeaderText="---" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

