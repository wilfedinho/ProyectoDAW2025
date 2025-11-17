<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PagarBoleto.aspx.cs" Inherits="PagarBoleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pagar Boletos</title>

    <style>
        body {
            background-color: #1a2233;
            color: #e6eaf6;
            font-family: 'Segoe UI', Arial, sans-serif;
            margin: 0;
            padding: 30px;
        }


        .contenedor-principal {
            background-color: #232b3e;
            border-radius: 12px;
            padding: 40px;
            box-shadow: 0 4px 24px #00000088;
            display: flex;
            flex-direction: column;
            gap: 30px;
            max-width: 1000px;
            margin: 0 auto;
        }


        .titulo-seccion {
            font-size: 2em;
            font-weight: 500;
            color: #4169a1;
            border-bottom: 2px solid #274472;
            padding-bottom: 10px;
            margin-bottom: 10px;
            text-align: center;
        }


        .grid-container {
            padding: 15px;
            display: flex;
            justify-content: center;
        }

        .gvEstilo {
            width: 70%;
            border-collapse: collapse;
            color: #e6eaf6;
            border-radius: 8px;
            overflow: hidden;
            display: table;
            margin: 0;
        }

            .gvEstilo th {
                background-color: #4169a1 !important;
                color: white !important;
                padding: 12px 10px;
                text-align: center;
                font-weight: 600;
                font-size: 0.9em;
            }

            .gvEstilo td {
                background-color: #232b3e;
                color: #e6eaf6;
                padding: 10px;
                border-bottom: 1px solid #3a5a99;
            }

            .gvEstilo tr:nth-child(even) td {
                background-color: #1a2233;
            }

            .gvEstilo tr:hover td {
                background-color: #2c3654;
            }


        .boton-accion {
            background-color: #4a78c1;
            color: white;
            border: none;
            padding: 6px 12px;
            border-radius: 6px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.2s;
            text-decoration: none;
        }

            .boton-accion:hover {
                background-color: #274472;
            }

        .boton-primario, .boton-secundario {
            padding: 10px 20px;
            border: none;
            border-radius: 6px; 
            cursor: pointer;
            font-weight: bold;
            transition: background-color 0.3s ease, transform 0.2s ease;
        }

        .gvEstilo + div {
            padding: 20px;
            background-color: #1a2233 !important;
            border: 2px solid #4169a1 !important;
            border-radius: 10px;
            text-align: center;
            color: #4169a1 !important;
            font-size: 1.1em;
            font-weight: bold;
        }



        .form-pago {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 25px 60px;
            padding: 20px 10px;
        }

        .label-txt {
            color: #e6eaf6;
            font-size: 1em;
            font-weight: 600;
            margin-bottom: 5px;
            display: block;
        }

        .input-txt {
            background-color: #1a2233;
            border: 1px solid #3a5a99;
            color: white;
            padding: 10px;
            width: 90%;
            border-radius: 6px;
            font-size: 1em;
            transition: border-color 0.2s;
        }

            .input-txt:focus {
                border-color: #4169a1;
                outline: none;
            }


        .boton-pagar {
            background-color: #2ecc71;
            color: black;
            padding: 14px 22px;
            font-size: 20px;
            border-radius: 8px;
            border: none;
            cursor: pointer;
            font-weight: bold;
            width: 260px;
            align-self: center;
            grid-column: 1 / span 2;
            margin-top: 10px;
            transition: background-color 0.2s, transform 0.2s;
        }

            .boton-pagar:hover {
                background-color: #27ae60;
                transform: translateY(-1px);
            }


        input[type='radio'] + label {
            color: #e6eaf6 !important;
            font-size: 1.1em !important;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">

        <div class="contenedor-principal" runat="server">

            <div class="titulo-seccion" data-key="boletosPorPagar" runat="server">Boletos por Pagar</div>

            <div class="grid-container" runat="server">

                <asp:GridView ID="gvBoletosPorPagar" runat="server" Width="100%"
                    AutoGenerateColumns="False"
                    CssClass="gvEstilo"
                    GridLines="None"
                    BorderWidth="0"
                    OnRowCommand="gvBoletosPorPagar_RowCommand">
                    <EmptyDataTemplate>
                        <div style="padding: 20px; background-color: #0f1e33; border: 2px solid #49ff58; border-radius: 10px; text-align: center; color: #49ff58; font-size: 20px;" runat="server" data-key="noPoseeBoletos">
                            El Usuario No Posee Boletos Por Pagar.
                        </div>
                    </EmptyDataTemplate>

                    <Columns>

                        <asp:BoundField DataField="NumeroBoleto" HeaderText="---" />
                        <asp:BoundField DataField="Origen" HeaderText="---" />
                        <asp:BoundField DataField="Destino" HeaderText="---" />
                        <asp:BoundField DataField="FechaPartidaIDA" HeaderText="---" />
                        <asp:BoundField DataField="FechaLlegadaIDA" HeaderText="---" />
                        <asp:BoundField DataField="FechaPartidaVUELTA" HeaderText="---" />
                        <asp:BoundField DataField="FechaLlegadaVUELTA" HeaderText="---" />
                        <asp:BoundField DataField="PesoEquipaje" HeaderText="---" />
                        <asp:BoundField DataField="ClaseBoleto" HeaderText="---" />
                        <asp:BoundField DataField="Precio" HeaderText="---" />
                        <asp:BoundField DataField="NumeroAsiento" HeaderText="---" />
                        <asp:BoundField DataField="BeneficioAplicado" HeaderText="---" />


                        <asp:TemplateField HeaderText="---">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnPagarBoleto"
                                    runat="server"
                                    Text="Pagar"
                                    CommandName="Pagar"
                                    data-key="btn_pagar"
                                    CommandArgument='<%# Eval("NumeroBoleto") %>'
                                    CssClass="boton-accion">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                </asp:GridView>

            </div>
            </div>


            <div class="titulo-seccion" runat="server" data-key="datosPago">Datos de Pago</div>

            <div class="form-pago" runat="server">

                <asp:RadioButton
                    ID="rbCredito"
                    runat="server"
                    Text="Tarjeta de Crédito"
                    GroupName="TipoTarjeta"
                    Checked="true"
                    data-key="tarjetaCredito"
                    Style="font-size: 18px; color: white;" />

                <asp:RadioButton
                    ID="rbDebito"
                    runat="server"
                    Text="Tarjeta de Débito"
                    GroupName="TipoTarjeta"
                    data-key="tarjetaDebito"
                    Style="font-size: 18px; color: white;" />

                <div runat="server">
                    <label class="label-txt" runat="server" data-key="numTarjeta">Número de Tarjeta</label>
                    <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="input-txt" PlaceHolder="Ej: 1111222233334444"></asp:TextBox>
                </div>

                <div runat="server">
                    <label class="label-txt" runat="server" data-key="fechaEmision">Fecha de Emisión</label>
                    <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="input-txt" PlaceHolder="Ej: 10/25"></asp:TextBox>
                </div>

                <div runat="server">
                    <label class="label-txt" runat="server" data-key="fechaVencimiento">Fecha Vencimiento</label>
                    <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="input-txt" PlaceHolder="Ej: 10/25"></asp:TextBox>
                </div>

                <div runat="server">
                    <label class="label-txt" runat="server" data-key="codSeguridad">Código Seguridad</label>
                    <asp:TextBox ID="txtCodigoSeguridad" runat="server" CssClass="input-txt" PlaceHolder="Ej: 999"></asp:TextBox>
                </div>

                <div runat="server">
                    <label class="label-txt" runat="server" data-key="nomTitular">Nombre Titular</label>
                    <asp:TextBox ID="txtNombreTitular" runat="server" CssClass="input-txt"></asp:TextBox>
                </div>

                <div runat="server">
                    <label class="label-txt" data-key="apeTitular" runat="server">Apellido Titular</label>
                    <asp:TextBox ID="txtApellidoTitular" runat="server" CssClass="input-txt"></asp:TextBox>
                </div>
            </div>

            <asp:Button ID="btnVolver" data-key="btn-volver" runat="server" Text="Volver" CssClass="boton-primario" OnClick="BT_Volver_Click" />
    </form>

</body>
</html>
