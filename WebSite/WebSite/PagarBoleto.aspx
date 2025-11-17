<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PagarBoleto.aspx.cs" Inherits="PagarBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pagar Boletos</title>

    <style>
        body {
            background-color: #0f223d;
            color: white;
            font-family: Arial;
            margin: 0;
            padding: 30px;
        }

        .contenedor-principal {
            background-color: #11263f;
            border-radius: 20px;
            padding: 30px;
            box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.4);
            display: flex;
            flex-direction: column;
            gap: 35px;
        }

        .titulo-seccion {
            font-size: 26px;
            font-weight: bold;
            color: #49ff58;
            border-bottom: 2px solid #49ff58;
            padding-bottom: 5px;
            margin-bottom: 15px;
        }

        /* CONTENEDOR GRID */
        .grid-container {
            padding: 15px;
        }

        /* GRIDVIEW */
        .estilo-grid header {
            background-color: #49ff58 !important;
        }

        .gvEstilo th {
            background-color: #49ff58 !important;
            color: black !important;
            padding: 10px;
            text-align: center;
        }

        .gvEstilo td {
            background-color: #11263f;
            color: white;
            padding: 8px;
        }

        .gvEstilo tr:nth-child(even) td {
            background-color: #0f1e33;
        }

        .boton-accion {
            background-color: #49ff58;
            color: black;
            border: none;
            padding: 6px 12px;
            border-radius: 6px;
            font-weight: bold;
            cursor: pointer;
        }

        .form-pago {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 25px 60px;
            padding: 20px 10px;
        }

        .label-txt {
            color: #49ff58;
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 5px;
            display: block;
        }

        .input-txt {
            background-color: #0f1e33;
            border: 2px solid #49ff58;
            color: white;
            padding: 8px;
            width: 90%;
            border-radius: 6px;
        }

        .boton-pagar {
            background-color: #49ff58;
            color: black;
            padding: 14px 22px;
            font-size: 20px;
            border-radius: 10px;
            border: none;
            cursor: pointer;
            font-weight: bold;
            width: 260px;
            align-self: center;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">

        <div class="contenedor-principal">

            <!-- Título -->
            <div class="titulo-seccion">Boletos por Pagar</div>

            <!-- GRIDVIEW -->
            <div class="grid-container">

                <asp:GridView ID="gvBoletosPorPagar" runat="server" Width="100%"
                    AutoGenerateColumns="False"
                    CssClass="gvEstilo"
                    GridLines="None"
                    BorderWidth="0"
                    OnRowCommand="gvBoletosPorPagar_RowCommand">
                    <EmptyDataTemplate>
                        <div style="padding: 20px; background-color: #0f1e33; border: 2px solid #49ff58; border-radius: 10px; text-align: center; color: #49ff58; font-size: 20px;">
                            El Usuario No Posee Boletos Por Pagar.
                        </div>
                    </EmptyDataTemplate>

                    <Columns>

                        <asp:BoundField DataField="NumeroBoleto" HeaderText="Código" />
                        <asp:BoundField DataField="Origen" HeaderText="Origen" />
                        <asp:BoundField DataField="Destino" HeaderText="Destino" />
                        <asp:BoundField DataField="FechaPartidaIDA" HeaderText="Partida Ida" />
                        <asp:BoundField DataField="FechaLlegadaIDA" HeaderText="Llegada Ida" />
                        <asp:BoundField DataField="FechaPartidaVUELTA" HeaderText="Partida Vuelta" />
                        <asp:BoundField DataField="FechaLlegadaVUELTA" HeaderText="Llegada Vuelta" />
                        <asp:BoundField DataField="PesoEquipaje" HeaderText="Equipaje" />
                        <asp:BoundField DataField="ClaseBoleto" HeaderText="Clase" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="NumeroAsiento" HeaderText="Asiento" />
                        <asp:BoundField DataField="BeneficioAplicado" HeaderText="Beneficio" />


                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPagarBoleto"
                                    runat="server"
                                    Text="Pagar"
                                    CommandName="Pagar"
                                    CommandArgument='<%# Eval("NumeroBoleto") %>'
                                    CssClass="boton-accion">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>

            <!-- SECCIÓN DATOS DE PAGO -->
            <div class="titulo-seccion">Datos de Pago</div>

            <div class="form-pago">

                <asp:RadioButton
                    ID="rbCredito"
                    runat="server"
                    Text="Tarjeta de Crédito"
                    GroupName="TipoTarjeta"
                    Checked="true"
                    Style="font-size: 18px; color: white;" />

                <asp:RadioButton
                    ID="rbDebito"
                    runat="server"
                    Text="Tarjeta de Débito"
                    GroupName="TipoTarjeta"
                    Style="font-size: 18px; color: white;" />

                <div>
                    <label class="label-txt">Número de Tarjeta</label>
                    <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="input-txt" PlaceHolder="Ej: 1111222233334444"></asp:TextBox>
                </div>

                <div>
                    <label class="label-txt">Fecha de Emisión</label>
                    <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="input-txt" PlaceHolder="Ej: 10/25"></asp:TextBox>
                </div>

                <div>
                    <label class="label-txt">Fecha Vencimiento</label>
                    <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="input-txt" PlaceHolder="Ej: 10/25"></asp:TextBox>
                </div>

                <div>
                    <label class="label-txt">Código Seguridad</label>
                    <asp:TextBox ID="txtCodigoSeguridad" runat="server" CssClass="input-txt" PlaceHolder="Ej: 999"></asp:TextBox>
                </div>

                <div>
                    <label class="label-txt">Nombre Titular</label>
                    <asp:TextBox ID="txtNombreTitular" runat="server" CssClass="input-txt"></asp:TextBox>
                </div>

                <div>
                    <label class="label-txt">Apellido Titular</label>
                    <asp:TextBox ID="txtApellidoTitular" runat="server" CssClass="input-txt"></asp:TextBox>
                </div>
    </form>

</body>
</html>
