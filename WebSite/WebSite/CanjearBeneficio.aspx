<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CanjearBeneficio.aspx.cs" Inherits="CanjearBeneficio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beneficios del Cliente</title>
    <link href="Styles/Site.css" rel="stylesheet" />

    <style>

        body {
            background-color: #1c2e4a; /* mismo fondo azul */
            font-family: 'Segoe UI', sans-serif;
            margin: 0;
            padding: 0;
        }

        .card-container {
            width: 80%;
            margin: 60px auto;
            background-color: #26384e; /* igual que tu panel */
            border-radius: 15px;
            padding: 30px;
            box-shadow: 0 0 20px rgba(0,0,0,0.5);
            color: #fff;
        }

        .titulo-seccion {
            font-size: 26px;
            font-weight: bold;
            color: #48ff83; /* verde igual */
            border-bottom: 2px solid #48ff83;
            padding-bottom: 10px;
            margin-bottom: 25px;
        }

        /* PANEL GENERAL */
        .contenedor-beneficios {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            width: 100%;
        }

        /* PANEL IZQUIERDO */
        .info-cliente {
            width: 35%;
            display: flex;
            flex-direction: column;
            gap: 18px;
            font-size: 30px;
            color: #48ff83; /* verde títulos */
            font-weight: bold;
        }

        /* GRID */
        .grid-beneficios {
            width: 60%;
        }

        /* GRIDVIEW estilo similar al de la imagen */
        .grid-beneficios table {
            width: 100%;
            border-collapse: collapse;
            background-color: #31485f;
            color: white;
        }

        .grid-beneficios th {
            background-color: #3d566f;
            padding: 10px;
            border-bottom: 2px solid #4d6a88;
            text-align: center;
        }

        .grid-beneficios td {
            padding: 10px;
            border-bottom: 1px solid #445d77;
            text-align: center;
        }

        /* BOTÓN CANJEAR */
        .btn-canjear {
            background-color: #48ff83;
            color: #000;
            padding: 6px 12px;
            border-radius: 6px;
            cursor: pointer;
            font-weight: bold;
            border: none;
        }

        .btn-canjear:hover {
            background-color: #2ecc71;
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
