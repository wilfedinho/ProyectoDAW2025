<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CanjearBeneficio.aspx.cs" Inherits="CanjearBeneficio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beneficios del Cliente</title>
    <link href="Styles/Site.css" rel="stylesheet" />

<style>
    /* Usando la paleta de colores de Vuelos.aspx */
    /* Fondo Oscuro Principal */
    body {
        background-color: #1a2233; /* Fondo de Vuelos.aspx */
        font-family: 'Segoe UI', Arial, sans-serif;
        margin: 0;
        padding: 0;
        color: #e6eaf6; /* Color de texto claro general */
    }

    /* Contenedor Principal (Panel/Card) */
    .card-container {
        width: 80%;
        margin: 60px auto;
        /* Usamos el fondo claro de la sección de contenido de Vuelos.aspx para que destaque */
        background-color: #f4f6fa; 
        border-radius: 12px; /* Ligeramente más redondo para coincidir con las cards de Vuelos */
        padding: 30px;
        box-shadow: 0 4px 24px #001a3388; /* Sombra sutil de Vuelos */
        color: #1a2233; /* Color de texto oscuro dentro del contenedor claro */
    }

    /* Título de la Sección */
    .titulo-seccion {
        font-size: 2em; /* Similar al h2 de Vuelos */
        font-weight: 500; /* Similar al h2 de Vuelos */
        color: #274472; /* Color azul oscuro de Vuelos para el título */
        border-bottom: 2px solid #4169a1; /* Línea de acento azul */
        padding-bottom: 10px;
        margin-bottom: 32px; /* Margen mayor para separar */
        text-align: center; /* Centrar para un estilo más limpio */
    }

    /* PANEL GENERAL */
    .contenedor-beneficios {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        width: 100%;
        gap: 40px; /* Agregamos espacio para mejor visualización */
    }

    /* PANEL IZQUIERDO - Información del Cliente */
    .info-cliente {
        width: 35%;
        display: flex;
        flex-direction: column;
        gap: 15px;
        font-size: 1.1em;
        font-weight: normal; 
        color: #1a2233; /* Texto oscuro sobre el fondo claro */
        padding: 20px;
        border-right: 1px solid #c9d0d9; /* Separador sutil */
    }
    
    .info-cliente label {
        color: #274472; /* Color de etiqueta azul oscuro */
        font-weight: bold;
        font-size: 1.2em;
        margin-top: 10px;
    }

    .info-cliente asp\\:Label { /* Usar el selector para los controles ASP.NET si fuera necesario, aunque Label no lo necesita */
        font-size: 1em;
        font-weight: normal;
        margin-left: 5px;
        color: #3a5a99; /* Color de texto más suave */
    }


    /* GRID CONTENEDOR */
    .grid-beneficios {
        width: 65%;
    }

    /* GRIDVIEW estilo unificado */
    .grid-beneficios table {
        width: 100%;
        border-collapse: collapse;
        background-color: #ffffff; /* Fondo blanco para las celdas */
        color: #1a2233; /* Texto oscuro */
        border-radius: 8px;
        overflow: hidden; /* Para que el borde redondeado se aplique */
        box-shadow: 0 2px 10px rgba(0,0,0,0.1);
    }

    .grid-beneficios th {
        background-color: #4169a1; /* Azul de acento para la cabecera */
        color: #ffffff;
        padding: 12px 10px;
        border-bottom: 2px solid #274472;
        text-align: center;
        font-weight: 600;
        font-size: 1em;
    }

    .grid-beneficios td {
        padding: 10px;
        border-bottom: 1px solid #e0e0e0; /* Líneas divisorias muy suaves */
        text-align: center;
    }

    /* Estilo de fila alterna para mejor legibilidad */
    .grid-beneficios tr:nth-child(even) {
        background-color: #f9f9f9;
    }
    
    .grid-beneficios tr:hover {
        background-color: #eaf1f8; /* Un ligero cambio de color al pasar el ratón */
    }

    /* BOTÓN CANJEAR - Acento azul para mantener la paleta */
    .btn-canjear {
        background-color: #4a78c1; /* Un azul brillante para acción */
        color: #fff;
        padding: 6px 12px;
        border-radius: 6px;
        cursor: pointer;
        font-weight: bold;
        border: none;
        transition: background-color 0.2s;
        text-decoration: none; /* Asegurar que no esté subrayado si es LinkButton */
    }

    .btn-canjear:hover {
        background-color: #274472; /* Azul oscuro de Vuelos en hover */
    }

</style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="card-container">

            <div class="titulo-seccion">Beneficios del Cliente</div>

            <div class="contenedor-beneficios">

                <!-- PANEL IZQUIERDO -->
                <div class="info-cliente">
                    <label data-key="label-destino" for="lblNombre">Nombre Del Usuario:</label>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    <label data-key="label-destino" for="lblApellido">Apellido Del Usuario:</label>
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                    <label data-key="label-destino" for="lblEstrellas">Estrellas Del Usuario:</label>
                    <asp:Label ID="lblEstrellas" runat="server" Text="Estrellas acumuladas: "></asp:Label>
                    <label data-key="label-destino" for="lblBeneficios">Beneficios Del Usuario:</label>
                    <asp:Label ID="lblBeneficios" runat="server"
                               Text="Beneficios del Cliente:"
                               Style="margin-top:20px;"></asp:Label>
                </div>

                <!-- GRID BENEFICIOS -->
                <div class="grid-beneficios">

                    <asp:GridView ID="gvBeneficios"
                                  runat="server"
                                  AutoGenerateColumns="False"
                                  CssClass="tabla"
                                  GridLines="None"
                                  OnRowCommand="gvBeneficios_RowCommand">

                        <Columns>

                            <asp:BoundField DataField="CodigoBeneficio" HeaderText="Código" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="PrecioEstrella" HeaderText="Costo (estrellas)" />
                            <asp:BoundField DataField="CantidadBeneficioReclamado" HeaderText="Reclamado" />
                            <asp:BoundField DataField="DescuentoAplicar" HeaderText="Descuento" />

                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnCanjear"
                                                    runat="server"
                                                    Text="Canjear"
                                                    CommandName="Canjear"
                                                    CommandArgument='<%# Eval("CodigoBeneficio") %>'
                                                    CssClass="btn-canjear">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>

            </div>

        </div>

    </form>
</body>
</html>
