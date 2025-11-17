<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReservarBoleto.aspx.cs" Inherits="ReservarBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reservar Boleto</title>

    <style>
    
    body {
        font-family: 'Segoe UI', Arial, sans-serif;
        background-color: #1a2233; 
        color: #e6eaf6; 
        margin: 0; 
        padding: 0;
    }

   
    #contenedorPrincipal {
        width: 95%;
        max-width: 1400px;
        margin: 40px auto; 
        background-color: #f4f6fa; 
        padding: 30px;
        border-radius: 12px;
        box-shadow: 0 4px 24px #001a3388; 
        color: #1a2233; 
    }

    h2 {
        color: #274472; 
        font-size: 2em;
        font-weight: 500;
        border-bottom: 2px solid #4169a1;
        padding-bottom: 10px;
        margin-bottom: 30px;
        text-align: center;
    }

    
    .panel-filtros {
        display: flex;
        flex-wrap: wrap;
        gap: 20px;
        padding: 20px;
        background-color: #ffffff; 
        border-radius: 8px;
        margin-bottom: 30px;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    }

    .grupo-filtro {
        display: flex;
        flex-direction: column;
        min-width: 180px;
    }

        .grupo-filtro label {
            font-weight: 600;
            margin-bottom: 5px;
            color: #274472; 
            font-size: 0.9em;
        }

  
    .control-input, .control-select {
        padding: 10px;
        border: 1px solid #c9d0d9; 
        border-radius: 4px;
        background-color: #f9f9f9; 
        color: #1a2233;
        font-size: 1em;
        transition: border-color 0.2s;
    }

        .control-input:focus, .control-select:focus {
            border-color: #4169a1; 
            outline: none;
        }

    .grupo-filtro.checkbox-control {
        flex-direction: row;
        align-items: center;
        margin-top: 15px;
        min-width: 100px;
    }

        .grupo-filtro.checkbox-control label {
            margin-right: 10px;
            margin-bottom: 0;
            color: #1a2233; 
            font-weight: normal;
        }


    .acciones-filtros {
        display: flex;
        align-items: flex-end;
        gap: 10px;
        margin-top: 10px;
    }

    .boton-primario, .boton-secundario {
        padding: 10px 20px;
        border: none;
        border-radius: 6px; 
        cursor: pointer;
        font-weight: bold;
        transition: background-color 0.3s ease, transform 0.2s ease;
    }

   
    .boton-primario {
        background-color: #4169a1; 
        color: white;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
    }

        .boton-primario:hover {
            background-color: #274472; 
            transform: translateY(-1px);
        }

 
    .boton-secundario {
        background-color: #95a5a6;
        color: #1a2233;
    }

        .boton-secundario:hover {
            background-color: #7f8c8d;
            transform: translateY(-1px);
        }

    
    .contenedor-tabla {
        overflow-x: auto;
    }

    .gridview {
        width: 100%;
        border-collapse: collapse;
        background-color: #ffffff; 
        color: #1a2233;
        margin-top: 15px;
        border-radius: 8px;
        overflow: hidden;
        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
    }

        .gridview th {
            background-color: #4169a1; 
            color: #ffffff;
            padding: 12px 10px;
            text-align: center;
            font-weight: 600;
            text-transform: uppercase;
            font-size: 0.9em;
        }

        .gridview td {
            padding: 10px 10px;
            border-bottom: 1px solid #e0e0e0; 
            text-align: left;
        }

        .gridview tr:nth-child(even) {
            background-color: #f9f9f9; 
        }

        .gridview tr:hover td {
            background-color: #eaf1f8; 
        }

        .gridview a {
            color: #4169a1; 
        }
        

    .boton-accion {
        padding: 6px 14px;
        border-radius: 6px;
        text-decoration: none;
        font-weight: 600;
        font-size: 13px;
        display: inline-block;
        transition: 0.2s ease;
        white-space: nowrap; 
    }

 
    .boton-reservar {
        background-color: #2ecc71; 
        color: white;
    }

        .boton-reservar:hover {
            background-color: #27ae60;
            transform: translateY(-1px);
        }

    
    .boton-beneficio {
        background-color: #4a78c1; 
        color: white;
    }

        .boton-beneficio:hover {
            background-color: #3a5a99;
            transform: translateY(-1px);
        }

        
        a[id*='btnReservarBeneficio'][style*='opacity: 0.4'] {
            pointer-events: none;
            cursor: default;
            background-color: #4a78c1 !important; 
        }

</style>
</head>

<body>
    <form id="contenedorPrincipal" runat="server">
        <div class="contenedor-principal" runat="server">

            <h2 runat="server" data-key="reservarBoletos">Reservar Boletos</h2>

            
            <div class="panel-filtros" runat="server">

                <div class="grupo-filtro" runat="server">
                    <label data-key="label-origen" runat="server" for="ddlOrigen">Origen:</label>
                    <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="control-select">
                        <asp:ListItem data-key="listItemSeleccione" Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="label-destino" runat="server" for="ddlDestino">Destino:</label>
                    <asp:DropDownList ID="ddlDestino" runat="server" CssClass="control-select">
                        <asp:ListItem data-key="listItemSeleccione" Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="label-claseBoleto" runat="server" for="ddlClaseBoleto">Clase Boleto:</label>
                    <asp:DropDownList ID="ddlClaseBoleto" runat="server" CssClass="control-select">
                        <asp:ListItem data-key="listItemSeleccione" Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="grupo-filtro">
                    <label data-key="label-pesoEquipajeMax" runat="server" for="txtPesoEquipaje">Peso Equipaje (máx.):</label>
                    <asp:TextBox ID="txtPesoEquipaje" runat="server" CssClass="control-input" placeholder="kg" />
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="label-precioDesde" runat="server" for="txtPrecioDesde">Precio Desde:</label>
                    <asp:TextBox ID="txtPrecioDesde" runat="server" CssClass="control-input" placeholder="0.00" />
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="label-precioHasta" runat="server" for="txtPrecioHasta">Precio Hasta:</label>
                    <asp:TextBox ID="txtPrecioHasta" runat="server" CssClass="control-input" placeholder="9999.99" />
                </div>

                <div class="grupo-filtro checkbox-control" runat="server">
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" onclick="toggleFechas()" />
                    <label data-key="label-filtrarPorFechas" runat="server">Filtrar por Fechas</label>
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="fechaPartidaIda" runat="server" for="txtFechaPartidaIda">Fecha Partida IDA:</label>
                    <asp:TextBox ID="txtFechaPartidaIda" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="fechaLlegadaIda" runat="server" for="txtFechaLlegadaIda">Fecha Llegada IDA:</label>
                    <asp:TextBox ID="txtFechaLlegadaIda" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="fechaPartidaVuelta" runat="server" for="txtFechaPartidaVuelta">Fecha Partida VUELTA:</label>
                    <asp:TextBox ID="txtFechaPartidaVuelta" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="fechaLlegadaVuelta" runat="server" for="txtFechaLlegadaVuelta">Fecha Llegada VUELTA:</label>
                    <asp:TextBox ID="txtFechaLlegadaVuelta" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="acciones-filtros" runat="server">
                    <asp:Button ID="btnFiltrar" data-key="btn-filtrar" runat="server" Text="Filtrar" CssClass="boton-primario" OnClick="BT_FILTRAR_Click"/>
                    <asp:Button ID="btnRestablecer" data-key="btn-restablecer" runat="server" Text="Restablecer" CssClass="boton-secundario" OnClick="BT_LIMPIARFILTROS_Click" />
                </div>

                <div class="grupo-filtro" runat="server">
                    <label data-key="label-BeneficiosCliente" runat="server" for="ddlBeneficioCliente">Beneficios Del Cliente:</label>
                    <asp:DropDownList ID="ddlBeneficios" runat="server" CssClass="control-select">
                        <asp:ListItem data-key="listItemSeleccione" runat="server" Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

            </div>

            
            <div class="contenedor-tabla">
                <asp:GridView ID="gvBoletos" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                    OnRowCommand="gvBoletos_RowCommand" DataKeyNames="NumeroBoleto">

                    <Columns>


                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_acciones">---</span>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <asp:LinkButton ID="btnReservar" runat="server"
                                    CommandName="Reservar"
                                    CommandArgument='<%# Eval("NumeroBoleto") %>'
                                    CssClass="boton-accion boton-reservar">
                ---
                                </asp:LinkButton>

                                &nbsp;

            <asp:LinkButton ID="btnReservarBeneficio" runat="server"
                CommandName="ReservarBeneficio"
                CommandArgument='<%# Eval("NumeroBoleto") %>'
                CssClass="boton-accion boton-beneficio">
                ---
            </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_numBoleto">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("NumeroBoleto") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_modalidad">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Modalidad") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_origen">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Origen") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_destino">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Destino") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_partidaIda">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FechaPartidaIDA") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_llegadaIda">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FechaLlegadaIDA") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_partidaVuelta">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FechaPartidaVUELTA") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_llegadaVuelta">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("FechaLlegadaVUELTA") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_clase">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("ClaseBoleto") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_pesoPermitido">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("PesoEquipajePermitido") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_precio">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Precio") %>
                            </ItemTemplate>
                        </asp:TemplateField>



                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span data-key="header_asiento">---</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("NumeroAsiento") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>
            </div>

        <asp:Button ID="btnVolver" data-key="btn-volver" runat="server" Text="Volver" CssClass="boton-primario" OnClick="BT_Volver_Click"/>
                    
        </div>


    </form>

    
    <script type="text/javascript">
        function toggleFechas() {
            var habilitar = document.getElementById('<%= chkFiltrarFecha.ClientID %>').checked;

            var ids = [
                '<%= txtFechaPartidaIda.ClientID %>',
                '<%= txtFechaLlegadaIda.ClientID %>',
                '<%= txtFechaPartidaVuelta.ClientID %>',
                '<%= txtFechaLlegadaVuelta.ClientID %>'
            ];

            ids.forEach(i => {
                var el = document.getElementById(i);
                el.disabled = !habilitar;
                if (!habilitar) el.value = "";
            });
        }

        window.onload = toggleFechas;
    </script>

    <script type="text/javascript">

       
        function actualizarBotonesBeneficio() {

            
            var ddl = document.getElementById('<%= ddlBeneficios.ClientID %>');
            var tieneBeneficio = ddl.value !== "";

            
            var botones = document.querySelectorAll("a[id*='btnReservarBeneficio']");

            botones.forEach(boton => {
                if (tieneBeneficio) {
                    boton.style.pointerEvents = "auto";  
                    boton.style.opacity = "1";          
                } else {
                    boton.style.pointerEvents = "none"; 
                    boton.style.opacity = "0.4";        
                }
            });
        }

        
        window.onload = function () {
            toggleFechas();
            actualizarBotonesBeneficio();
        };

        
        document.addEventListener("DOMContentLoaded", function () {
            var ddl = document.getElementById('<%= ddlBeneficios.ClientID %>');
        ddl.addEventListener("change", actualizarBotonesBeneficio);
    });

    </script>

</body>
</html>
