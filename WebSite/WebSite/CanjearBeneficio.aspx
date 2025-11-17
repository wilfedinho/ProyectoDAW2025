<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CanjearBeneficio.aspx.cs" Inherits="CanjearBeneficio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beneficios del Cliente</title>
    <link href="Styles/Site.css" rel="stylesheet" />

<style>
    
    body {
        background-color: #1a2233; 
        font-family: 'Segoe UI', Arial, sans-serif;
        margin: 0;
        padding: 0;
        color: #e6eaf6; 
    }

    
    .card-container {
        width: 80%;
        margin: 60px auto;
        
        background-color: #f4f6fa; 
        border-radius: 12px; 
        padding: 30px;
        box-shadow: 0 4px 24px #001a3388; 
        color: #1a2233; 
    }

   
    .titulo-seccion {
        font-size: 2em; 
        font-weight: 500; 
        color: #274472; 
        border-bottom: 2px solid #4169a1; 
        padding-bottom: 10px;
        margin-bottom: 32px; 
        text-align: center; 
    }
    .boton-primario, .boton-secundario {
    padding: 10px 20px;
    border: none;
    border-radius: 6px; 
    cursor: pointer;
    font-weight: bold;
    transition: background-color 0.3s ease, transform 0.2s ease;
}
    
    .contenedor-beneficios {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        width: 100%;
        gap: 40px; 
    }

   
    .info-cliente {
        width: 35%;
        display: flex;
        flex-direction: column;
        gap: 15px;
        font-size: 1.1em;
        font-weight: normal; 
        color: #1a2233; 
        padding: 20px;
        border-right: 1px solid #c9d0d9; 
    }
    
    .info-cliente label {
        color: #274472; 
        font-weight: bold;
        font-size: 1.2em;
        margin-top: 10px;
    }

    .info-cliente asp\\:Label { 
        font-size: 1em;
        font-weight: normal;
        margin-left: 5px;
        color: #3a5a99; 
    }


  
    .grid-beneficios {
        width: 65%;
    }

    .grid-beneficios table {
        width: 100%;
        border-collapse: collapse;
        background-color: #ffffff; 
        color: #1a2233; 
        border-radius: 8px;
        overflow: hidden; 
        box-shadow: 0 2px 10px rgba(0,0,0,0.1);
    }

    .grid-beneficios th {
        background-color: #4169a1; 
        color: #ffffff;
        padding: 12px 10px;
        border-bottom: 2px solid #274472;
        text-align: center;
        font-weight: 600;
        font-size: 1em;
    }

    .grid-beneficios td {
        padding: 10px;
        border-bottom: 1px solid #e0e0e0; 
        text-align: center;
    }

    
    .grid-beneficios tr:nth-child(even) {
        background-color: #f9f9f9;
    }
    
    .grid-beneficios tr:hover {
        background-color: #eaf1f8; 
    }

    
    .btn-canjear {
        background-color: #4a78c1; 
        color: #fff;
        padding: 6px 12px;
        border-radius: 6px;
        cursor: pointer;
        font-weight: bold;
        border: none;
        transition: background-color 0.2s;
        text-decoration: none; 
    }

    .btn-canjear:hover {
        background-color: #274472; 
    }

</style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="card-container" runat="server">

            <div class="titulo-seccion" data-key="label-BeneficiosCliente" runat="server">Beneficios del Cliente</div>

            <div class="contenedor-beneficios" runat="server">

             
                <div class="info-cliente" runat="server">
                    <label data-key="label-nombre" runat="server" for="lblNombre">Nombre Del Usuario:</label>
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                    <label data-key="label-apellido" runat="server" for="lblApellido">Apellido Del Usuario:</label>
                    <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
                    <label data-key="label-estrellas" runat="server" for="lblEstrellas">Estrellas Del Usuario:</label>
                    <asp:Label ID="lblEstrellas" runat="server" Text="Estrellas acumuladas: "></asp:Label>
                    <label data-key="label-destino" id="lbdestino" runat="server" for="lblBeneficios">Beneficios Del Usuario:</label>
                    <asp:Label ID="lblBeneficios" runat="server"
                               Text="Beneficios del Cliente:"
                               Style="margin-top:20px;"></asp:Label>
                </div>

              
                <div class="grid-beneficios" runat="server">

                    <asp:GridView ID="gvBeneficios"
                                  runat="server"
                                  AutoGenerateColumns="False"
                                  CssClass="tabla"
                                  GridLines="None"
                                  OnRowCommand="gvBeneficios_RowCommand">

                        <Columns>

                            <asp:BoundField DataField="CodigoBeneficio" HeaderText="---" />
                            <asp:BoundField DataField="Nombre" HeaderText="---" />
                            <asp:BoundField DataField="PrecioEstrella" HeaderText="---" />
                            <asp:BoundField DataField="CantidadBeneficioReclamado" HeaderText="---" />
                            <asp:BoundField DataField="DescuentoAplicar" HeaderText="---" />

                            <asp:TemplateField HeaderText="---">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnCanjear"
                                                    runat="server"
                                                    Text="Canjear"
                                                    data-key="btn_canjear"
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
            <asp:Button ID="btnVolver" data-key="btn-volver" runat="server" Text="Volver" CssClass="boton-primario" OnClick="BT_Volver_Click"/>
        </div>

    </form>
</body>
</html>
