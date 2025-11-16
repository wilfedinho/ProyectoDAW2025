<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReservarBoleto.aspx.cs" Inherits="ReservarBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reservar Boleto</title>
    <style>
        /* Estilos Globales para el cuerpo */
        body {
            font-family: Arial, sans-serif;
            background-color: #2c3e50; /* Fondo general oscuro */
            color: #ecf0f1; /* Color de texto claro */
            margin: 20px;
        }

        /* Contenedor Principal similar al panel de la imagen */
        .contenedor-principal {
            background-color: #34495e; /* Fondo del panel (azul oscuro) */
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            max-width: 1200px;
            margin: 0 auto;
        }

        h2 {
            color: #ffffff;
            border-bottom: 2px solid #2ecc71; /* Línea verde de separación */
            padding-bottom: 10px;
            margin-bottom: 20px;
        }

        /* --- Estilos para la Sección de Filtros --- */
        .panel-filtros {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            padding: 20px;
            background-color: #2c3e50; /* Fondo más oscuro para la sección de filtros */
            border-radius: 6px;
            margin-bottom: 30px;
        }

        .grupo-filtro {
            display: flex;
            flex-direction: column;
            min-width: 180px; /* Ancho mínimo para cada filtro */
        }

        .grupo-filtro label {
            font-weight: bold;
            margin-bottom: 5px;
            color: #bdc3c7; /* Color de etiqueta más sutil */
            font-size: 0.9em;
        }

        /* Estilos de controles de formulario (Inputs y Selects) */
        .control-input, .control-select {
            padding: 10px;
            border: 1px solid #7f8c8d;
            border-radius: 4px;
            background-color: #3f556d; /* Fondo del campo de entrada */
            color: #ecf0f1;
            font-size: 1em;
            /* Estilos para el DropDownList */
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
        }

        /* Estilo específico para los TextBox de fechas para que se vean bien */
        .control-input[type="date"] {
            color: #ecf0f1; 
        }
        
        /* Estilo para el Checkbox que controla la fecha */
        .grupo-filtro.checkbox-control {
            flex-direction: row; /* La etiqueta al lado del checkbox */
            align-items: center; /* Centrar verticalmente */
            margin-top: 15px; /* Espacio para que quede alineado con los botones de acción */
            min-width: 100px;
        }
        .grupo-filtro.checkbox-control label {
             margin-right: 10px;
             margin-bottom: 0;
        }


        /* Contenedor de botones para que estén juntos */
        .acciones-filtros {
            display: flex;
            align-items: flex-end; /* Alinear con los campos de arriba */
            gap: 10px;
            margin-top: 10px; /* Empuja un poco hacia abajo */
        }

        /* Estilos de botones */
        .boton-primario, .boton-secundario {
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-weight: bold;
            transition: background-color 0.3s ease;
        }

        .boton-primario {
            background-color: #3498db; /* Azul */
            color: white;
        }

        .boton-primario:hover {
            background-color: #2980b9;
        }

        .boton-secundario {
            background-color: #95a5a6; /* Gris */
            color: #2c3e50;
        }

        .boton-secundario:hover {
            background-color: #7f8c8d;
        }

        /* --- Estilos para la Tabla/DataGrid (GridView) --- */
        .contenedor-tabla {
            overflow-x: auto; /* Permite desplazamiento horizontal */
        }

        .data-grid {
            width: 100%;
            border-collapse: collapse; 
            margin-top: 15px;
        }

        .data-grid th, .data-grid td {
            padding: 12px 8px;
            text-align: left;
            border-bottom: 1px solid #4a637d; /* Separador de filas */
            word-wrap: break-word; 
        }

        /* Encabezado de la tabla (GridView HeaderStyle) */
        .data-grid thead th { 
            background-color: #2c3e50; /* Fondo más oscuro para el encabezado */
            color: #ecf0f1;
            text-transform: uppercase;
            font-size: 0.9em;
            font-weight: bold;
        }

        /* Filas del cuerpo (GridView RowStyle/AlternatingRowStyle) */
        .data-grid tr {
            background-color: #34495e; 
        }

        .data-grid tr:nth-child(even) { /* Filas pares */
            background-color: #3a536b; 
        }

        .data-grid tr:hover {
            background-color: #4a637d; 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor-principal">
            <h2>Reservar Boleto: Consulta de Boletos</h2>

            <div class="panel-filtros">
                
                <div class="grupo-filtro">
                    <label for="ddlOrigen">Origen:</label>
                    <asp:DropDownList ID="ddlOrigen" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="grupo-filtro">
                    <label for="ddlDestino">Destino:</label>
                    <asp:DropDownList ID="ddlDestino" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="grupo-filtro">
                    <label for="ddlClaseBoleto">Clase Boleto:</label>
                    <asp:DropDownList ID="ddlClaseBoleto" runat="server" CssClass="control-select">
                        <asp:ListItem Text="-- Seleccione --" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="grupo-filtro">
                    <label for="txtPesoEquipaje">Peso Equipaje (máx.):</label>
                    <asp:TextBox ID="txtPesoEquipaje" runat="server" CssClass="control-input" placeholder="kg"></asp:TextBox>
                </div>
                
                <div class="grupo-filtro">
                    <label for="txtPrecioDesde">Precio Desde:</label>
                    <asp:TextBox ID="txtPrecioDesde" runat="server" CssClass="control-input" placeholder="0.00"></asp:TextBox>
                </div>
                <div class="grupo-filtro">
                    <label for="txtPrecioHasta">Precio Hasta:</label>
                    <asp:TextBox ID="txtPrecioHasta" runat="server" CssClass="control-input" placeholder="9999.99"></asp:TextBox>
                </div>

                <div class="grupo-filtro checkbox-control">
                    <asp:CheckBox ID="chkFiltrarFecha" runat="server" CssClass="filtro-checkbox" onclick="toggleFechas()" />
                    <label for="chkFiltrarFecha">Filtrar por Fechas</label>
                </div>
                
                <div class="grupo-filtro">
                    <label for="txtFechaPartidaIda">Fecha Partida IDA:</label>
                    <asp:TextBox ID="txtFechaPartidaIda" runat="server" CssClass="control-input" TextMode="Date"></asp:TextBox>
                </div>
                <div class="grupo-filtro">
                    <label for="txtFechaLlegadaIda">Fecha Llegada IDA:</label>
                    <asp:TextBox ID="txtFechaLlegadaIda" runat="server" CssClass="control-input" TextMode="Date"></asp:TextBox>
                </div>
                <div class="grupo-filtro">
                    <label for="txtFechaPartidaVuelta">Fecha Partida VUELTA:</label>
                    <asp:TextBox ID="txtFechaPartidaVuelta" runat="server" CssClass="control-input" TextMode="Date"></asp:TextBox>
                </div>
                <div class="grupo-filtro">
                    <label for="txtFechaLlegadaVuelta">Fecha Llegada VUELTA:</label>
                    <asp:TextBox ID="txtFechaLlegadaVuelta" runat="server" CssClass="control-input" TextMode="Date"></asp:TextBox>
                </div>
                
                <div class="acciones-filtros">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="boton-primario" OnClick="BT_FILTRAR_Click"/>
                    <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer" CssClass="boton-secundario" />
                </div>
            </div>
            
            <div class="contenedor-tabla">
                <asp:GridView ID="gvBoletos" runat="server" CssClass="data-grid" AutoGenerateColumns="False" 
                              EmptyDataText="No se encontraron boletos con los criterios de búsqueda seleccionados.">
                    <Columns>
                        <asp:BoundField DataField="NumeroBoleto" HeaderText="Nº Boleto" ItemStyle-Width="80px" />
                        <asp:BoundField DataField="Modalidad" HeaderText="Modalidad" />
                        <asp:BoundField DataField="Origen" HeaderText="Origen" ItemStyle-Width="60px" />
                        <asp:BoundField DataField="Destino" HeaderText="Destino" ItemStyle-Width="60px" />
                        <asp:BoundField DataField="FechaPartidaIDA" HeaderText="F. Partida IDA" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="FechaLlegadaIDA" HeaderText="F. Llegada IDA" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="FechaPartidaVUELTA" HeaderText="F. Partida VTA" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="FechaLlegadaVUELTA" HeaderText="F. Llegada VTA" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="ClaseBoleto" HeaderText="Clase" />
                        <asp:BoundField DataField="PesoEquipajePermitido" HeaderText="Peso Eq. (kg)" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="NumeroAsiento" HeaderText="Nº Asiento" />
                    </Columns>
                    <HeaderStyle CssClass="data-grid-header" />
                </asp:GridView>
            </div>
        </div>
    </form>

    <script type="text/javascript">
        var chkFiltrarFechaId = '<%= chkFiltrarFecha.ClientID %>';
        var txtFechaPartidaIdaId = '<%= txtFechaPartidaIda.ClientID %>';
        var txtFechaLlegadaIdaId = '<%= txtFechaLlegadaIda.ClientID %>';
        var txtFechaPartidaVueltaId = '<%= txtFechaPartidaVuelta.ClientID %>';
        var txtFechaLlegadaVueltaId = '<%= txtFechaLlegadaVuelta.ClientID %>';

        function toggleFechas() {
            var chk = document.getElementById(chkFiltrarFechaId);
            
            var txtPartidaIda = document.getElementById(txtFechaPartidaIdaId);
            var txtLlegadaIda = document.getElementById(txtFechaLlegadaIdaId);
            var txtPartidaVuelta = document.getElementById(txtFechaPartidaVueltaId);
            var txtLlegadaVuelta = document.getElementById(txtFechaLlegadaVueltaId);

            // Invertimos la lógica: si está marcado, están habilitados. Si no, deshabilitados.
            var habilitar = chk.checked;

            if (txtPartidaIda) {
                txtPartidaIda.disabled = !habilitar;
            }
            if (txtLlegadaIda) {
                txtLlegadaIda.disabled = !habilitar;
            }
            if (txtPartidaVuelta) {
                txtPartidaVuelta.disabled = !habilitar;
            }
            if (txtLlegadaVuelta) {
                txtLlegadaVuelta.disabled = !habilitar;
            }
            
            // Opcional: limpiar los valores si se desactiva el filtrado
            if (!habilitar) {
                if (txtPartidaIda) txtPartidaIda.value = '';
                if (txtLlegadaIda) txtLlegadaIda.value = '';
                if (txtPartidaVuelta) txtPartidaVuelta.value = '';
                if (txtLlegadaVuelta) txtLlegadaVuelta.value = '';
            }
        }

        // Ejecutar al cargar la página para establecer el estado inicial (deshabilitados por defecto)
        window.onload = function() {
            // Se asume que por defecto el checkbox no está marcado, por lo que las fechas inician deshabilitadas.
            toggleFechas();
            
            // También se puede agregar el listener para manejo posterior, aunque ya está en el 'onclick' del control ASP.NET
        };
    </script>
</body>
</html>