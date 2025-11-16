<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReservarBoleto.aspx.cs" Inherits="ReservarBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reservar Boleto</title>

    <style>
        /* Estilos Globales para el cuerpo */

        .boton-accion {
            padding: 6px 14px;
            border-radius: 6px;
            text-decoration: none;
            font-weight: 600;
            font-size: 13px;
            display: inline-block;
            transition: 0.2s ease;
        }

        .boton-reservar {
            background-color: #4caf50;
            color: white;
        }

            .boton-reservar:hover {
                background-color: #43a047;
                transform: translateY(-1px);
            }

        .boton-beneficio {
            background-color: #0288d1;
            color: white;
        }

            .boton-beneficio:hover {
                background-color: #0277bd;
                transform: translateY(-1px);
            }

        body {
            font-family: Arial, sans-serif;
            background-color: #2c3e50;
            color: #ecf0f1;
            margin: 20px;
        }

        .contenedor-principal {
            background-color: #34495e;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4p x 8px rgba(0, 0, 0, 0.2);
            max-width: 1200px;
            margin: 0 auto;
        }

        h2 {
            color: #ffffff;
            border-bottom: 2px solid #2ecc71;
            padding-bottom: 10px;
            margin-bottom: 20px;
        }

        .panel-filtros {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            padding: 20px;
            background-color: #2c3e50;
            border-radius: 6px;
            margin-bottom: 30px;
        }

        .grupo-filtro {
            display: flex;
            flex-direction: column;
            min-width: 180px;
        }

            .grupo-filtro label {
                font-weight: bold;
                margin-bottom: 5px;
                color: #bdc3c7;
                font-size: 0.9em;
            }

        .control-input, .control-select {
            padding: 10px;
            border: 1px solid #7f8c8d;
            border-radius: 4px;
            background-color: #3f556d;
            color: #ecf0f1;
            font-size: 1em;
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
            border-radius: 4px;
            cursor: pointer;
            font-weight: bold;
            transition: background-color 0.3s ease;
        }

        .boton-primario {
            background-color: #3498db;
            color: white;
        }

            .boton-primario:hover {
                background-color: #2980b9;
            }

        .boton-secundario {
            background-color: #95a5a6;
            color: #2c3e50;
        }

            .boton-secundario:hover {
                background-color: #7f8c8d;
            }

        .contenedor-tabla {
            overflow-x: auto;
        }

        .data-grid {
            width: 100%;
            border-collapse: collapse;
            margin-top: 15px;
        }

            .data-grid th, .data-grid td {
                padding: 12px 8px;
                text-align: left;
                border-bottom: 1px solid #4a637d;
                word-wrap: break-word;
            }

            .data-grid thead th {
                background-color: #2c3e50;
                color: #ecf0f1;
                text-transform: uppercase;
                font-size: 0.9em;
                font-weight: bold;
            }

            .data-grid tr {
                background-color: #34495e;
            }

                .data-grid tr:nth-child(even) {
                    background-color: #3a536b;
                }

                .data-grid tr:hover {
                    background-color: #4a637d;
                }

        #contenedorPrincipal {
            width: 95%;
            max-width: 1400px;
            margin: 0 auto;
            background-color: #263238;
            padding: 30px;
            border-radius: 15px;
            box-shadow: 0 0 15px rgba(0,0,0,0.4);
            margin-top: 40px;
            margin-bottom: 40px;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
            background-color: #37474f;
            color: white;
        }

            .gridview th {
                background-color: #455a64;
                padding: 10px;
                text-align: center;
            }

            .gridview td {
                padding: 8px 10px;
                border-bottom: 1px solid #546e7a;
            }

            .gridview tr:hover td {
                background-color: #546e7a;
            }

            .gridview a {
                color: #82b1ff; /* color del link clásico */
            }
    </style>
</head>

<body>
    <form id="contenedorPrincipal" runat="server">
        <div class="contenedor-principal">

            <h2>Reservar Boleto: Consulta de Boletos</h2>

            <!-- 🔹 PANEL DE FILTROS -->
            <div class="panel-filtros">

                <div class="grupo-filtro">
                    <label for="ddlOrigen">Origen:</label>
                    <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="grupo-filtro">
                    <label for="ddlDestino">Destino:</label>
                    <asp:DropDownList ID="ddlDestino" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="grupo-filtro">
                    <label for="ddlClaseBoleto">Clase Boleto:</label>
                    <asp:DropDownList ID="ddlClaseBoleto" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

                <div class="grupo-filtro">
                    <label for="txtPesoEquipaje">Peso Equipaje (máx.):</label>
                    <asp:TextBox ID="txtPesoEquipaje" runat="server" CssClass="control-input" placeholder="kg" />
                </div>

                <div class="grupo-filtro">
                    <label for="txtPrecioDesde">Precio Desde:</label>
                    <asp:TextBox ID="txtPrecioDesde" runat="server" CssClass="control-input" placeholder="0.00" />
                </div>

                <div class="grupo-filtro">
                    <label for="txtPrecioHasta">Precio Hasta:</label>
                    <asp:TextBox ID="txtPrecioHasta" runat="server" CssClass="control-input" placeholder="9999.99" />
                </div>

                <div class="grupo-filtro checkbox-control">
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" onclick="toggleFechas()" />
                    <label>Filtrar por Fechas</label>
                </div>

                <div class="grupo-filtro">
                    <label for="txtFechaPartidaIda">Fecha Partida IDA:</label>
                    <asp:TextBox ID="txtFechaPartidaIda" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="grupo-filtro">
                    <label for="txtFechaLlegadaIda">Fecha Llegada IDA:</label>
                    <asp:TextBox ID="txtFechaLlegadaIda" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="grupo-filtro">
                    <label for="txtFechaPartidaVuelta">Fecha Partida VUELTA:</label>
                    <asp:TextBox ID="txtFechaPartidaVuelta" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="grupo-filtro">
                    <label for="txtFechaLlegadaVuelta">Fecha Llegada VUELTA:</label>
                    <asp:TextBox ID="txtFechaLlegadaVuelta" runat="server" CssClass="control-input" TextMode="Date" />
                </div>

                <div class="acciones-filtros">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="boton-primario" />
                    <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" CssClass="boton-secundario" />
                </div>

                <div class="grupo-filtro">
                    <label for="ddlBeneficioCliente">Beneficios Del Cliente:</label>
                    <asp:DropDownList ID="ddlBeneficios" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value="" />
                    </asp:DropDownList>
                </div>

            </div>

            <!-- 🔹 TABLA RESULTADOS -->
            <div class="contenedor-tabla">
                <asp:GridView ID="gvBoletos" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                    OnRowCommand="gvBoletos_RowCommand" DataKeyNames="NumeroBoleto">

                    <Columns>


                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>

                                <asp:LinkButton ID="btnReservar" runat="server"
                                    CommandName="Reservar"
                                    CommandArgument='<%# Eval("NumeroBoleto") %>'
                                    CssClass="boton-accion boton-reservar">
            Reservar
                                </asp:LinkButton>

                                &nbsp;

        <asp:LinkButton ID="btnReservarBeneficio" runat="server"
            CommandName="ReservarBeneficio"
            CommandArgument='<%# Eval("NumeroBoleto") %>'
            CssClass="boton-accion boton-beneficio">
            Reservar con Beneficio
        </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:BoundField DataField="NumeroBoleto" HeaderText="N° Boleto" />
                        <asp:BoundField DataField="Modalidad" HeaderText="Modalidad" />
                        <asp:BoundField DataField="Origen" HeaderText="Origen" />
                        <asp:BoundField DataField="Destino" HeaderText="Destino" />

                        <asp:BoundField DataField="FechaPartidaIDA" HeaderText="Partida IDA" />
                        <asp:BoundField DataField="FechaLlegadaIDA" HeaderText="Llegada IDA" />

                        <asp:BoundField DataField="FechaPartidaVUELTA" HeaderText="Partida VUELTA" />
                        <asp:BoundField DataField="FechaLlegadaVUELTA" HeaderText="Llegada VUELTA" />

                        <asp:BoundField DataField="ClaseBoleto" HeaderText="Clase" />
                        <asp:BoundField DataField="PesoEquipajePermitido" HeaderText="Peso Permitido" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="NumeroAsiento" HeaderText="Asiento" />

                    </Columns>

                </asp:GridView>
            </div>

        </div>
    </form>

    <!-- JavaScript para habilitar/deshabilitar fechas -->
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

        // 🔹 Habilita o deshabilita los botones "Reservar con Beneficio"
        function actualizarBotonesBeneficio() {

            // Obtener valor del dropdown
            var ddl = document.getElementById('<%= ddlBeneficios.ClientID %>');
        var tieneBeneficio = ddl.value !== "";

        // Obtener todos los botones del grid
        var botones = document.querySelectorAll("a[id*='btnReservarBeneficio']");

        botones.forEach(boton => {
            if (tieneBeneficio) {
                boton.style.pointerEvents = "auto";  // habilitar click
                boton.style.opacity = "1";          // visual normal
            } else {
                boton.style.pointerEvents = "none"; // deshabilitar click
                boton.style.opacity = "0.4";        // efecto visual desactivado
            }
        });
    }

    // 🔹 Ejecutar al cargar la página
    window.onload = function () {
        toggleFechas();
        actualizarBotonesBeneficio();
    };

    // 🔹 Ejecutar cuando el usuario cambie el beneficio
    document.addEventListener("DOMContentLoaded", function () {
        var ddl = document.getElementById('<%= ddlBeneficios.ClientID %>');
        ddl.addEventListener("change", actualizarBotonesBeneficio);
    });

    </script>

</body>
</html>
