using BE;
using BLL.Negocio;
using BLL.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReservarBoleto : System.Web.UI.Page
{
    Boleto boletoCargado;
    Usuario ClienteCargado;
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        boletoCargado = null;
        ClienteCargado = gestorUsuario.BuscarClientePorDNI("77.777.777");
        if (!IsPostBack)
        {
            Mostrar490WC();
            LLenarCB();
            LimpiarCampos490WC();
        }

    }

    public void Mostrar490WC(string origen490WC = "", string destino490WC = "", string claseBoleto490WC = "", float? precioDesde490WC = null, float? precioHasta490WC = null, float? pesoPermitido490WC = null, DateTime? fechaPartida490WC = null, DateTime? fechaLlegada490WC = null, DateTime? fechaPartidaVUELTA490WC = null, DateTime? fechaLlegadaVUELTA490WC = null)
    {
        BoletoBLL gestorBoleto490WC = new BoletoBLL();
        var listaAdaptadaIDAVUELTA = gestorBoleto490WC.ObtenerBoletosFiltrados(origen490WC, destino490WC, claseBoleto490WC, precioDesde490WC, precioHasta490WC, pesoPermitido490WC, fechaPartida490WC, fechaLlegada490WC, fechaPartidaVUELTA490WC, fechaLlegadaVUELTA490WC)
            .Where(b => b is BoletoIDAVUELTA && b.Titular == null)
            .Select(b => new
            {
                NumeroBoleto = b.IDBoleto,
                Modalidad = "IDA_VUELTA",
                Origen = b.Origen,
                Destino = b.Destino,
                FechaPartidaIDA = b.FechaPartida.ToShortDateString(),
                FechaLlegadaIDA = b.FechaLlegada.ToShortDateString(),
                FechaPartidaVUELTA = (b as BoletoIDAVUELTA).FechaPartidaVUELTA.ToShortDateString(),
                FechaLlegadaVUELTA = (b as BoletoIDAVUELTA).FechaLlegadaVUELTA.ToShortDateString(),
                ClaseBoleto = b.ClaseBoleto,
                PesoEquipajePermitido = b.EquipajePermitido,
                Precio = b.Precio,
                NumeroAsiento = b.NumeroAsiento
            }).ToList();

        var listaAdaptadaIDA = gestorBoleto490WC.ObtenerBoletosFiltrados(origen490WC, destino490WC, claseBoleto490WC, precioDesde490WC, precioHasta490WC, pesoPermitido490WC, fechaPartida490WC, fechaLlegada490WC, fechaPartidaVUELTA490WC, fechaLlegadaVUELTA490WC)
            .Where(b => b is BoletoIDA && b.Titular == null)
            .Select(b => new
            {
                NumeroBoleto = b.IDBoleto,
                Modalidad = "IDA",
                Origen = b.Origen,
                Destino = b.Destino,
                FechaPartidaIDA = b.FechaPartida.ToShortDateString(),
                FechaLlegadaIDA = b.FechaLlegada.ToShortDateString(),
                FechaPartidaVUELTA = "",
                FechaLlegadaVUELTA = "",
                ClaseBoleto = b.ClaseBoleto,
                PesoEquipajePermitido = b.EquipajePermitido,
                Precio = b.Precio,
                NumeroAsiento = b.NumeroAsiento
            }).ToList();

        var listaUnificada = listaAdaptadaIDAVUELTA.Concat(listaAdaptadaIDA).ToList();

        gvBoletos.DataSource = listaUnificada;
        gvBoletos.DataBind();
        LLenarCB();
    }

    public void LLenarCB()
    {
        BoletoBLL gestorBoleto490WC = new BoletoBLL();
        ddlOrigen.Items.Clear();
        ddlDestino.Items.Clear();
        ddlClaseBoleto.Items.Clear();
        ddlBeneficios.Items.Clear();
        ddlOrigen.Items.Add("");
        ddlDestino.Items.Add("");
        ddlClaseBoleto.Items.Add("");
        ddlBeneficios.Items.Add("");
        foreach (Boleto boleto490WC in gestorBoleto490WC.ObtenerTodosLosBoletos())
        {
            if (boleto490WC.IsVendido == false)
            {
                if (ddlOrigen.Items.FindByText(boleto490WC.Origen) == null)
                    ddlOrigen.Items.Add(boleto490WC.Origen);

                if (ddlDestino.Items.FindByText(boleto490WC.Destino) == null)
                    ddlDestino.Items.Add(boleto490WC.Destino);

                if (ddlClaseBoleto.Items.FindByText(boleto490WC.ClaseBoleto) == null)
                    ddlClaseBoleto.Items.Add(boleto490WC.ClaseBoleto);
            }
        }
        if (ClienteCargado != null && ClienteCargado.BeneficiosCliente.Count > 0)
        {
            foreach (Beneficio bene in ClienteCargado.BeneficiosCliente)
            {
                if (ddlBeneficios.Items.FindByText(bene.Nombre) == null)
                    ddlBeneficios.Items.Add(bene.Nombre);
            }
        }
    }
    public void LimpiarCampos490WC()
    {
        txtPesoEquipaje.Text = "";
        txtPrecioDesde.Text = "";
        txtPrecioHasta.Text = "";
        ddlOrigen.SelectedIndex = -1;
        ddlDestino.SelectedIndex = -1;
        ddlClaseBoleto.SelectedIndex = -1;
        txtFechaPartidaIda.Text = "";
        txtFechaLlegadaIda.Text = "";
        txtFechaPartidaVuelta.Text = "";
        txtFechaLlegadaVuelta.Text = "";
    }

    protected void BT_FILTRAR_Click(object sender, EventArgs e)
    {

        string Origen490WC = ddlOrigen.SelectedIndex >= 0 ? ddlOrigen.SelectedItem.ToString() : "";
        string Destino490WC = ddlDestino.SelectedIndex >= 0 ? ddlDestino.SelectedItem.ToString() : "";
        string ClaseBoleto490WC = ddlClaseBoleto.SelectedIndex >= 0 ? ddlClaseBoleto.SelectedItem.ToString() : "";

        float? PrecioDesde490WC = null;
        float? PrecioHasta490WC = null;
        float? PesoPermitido490WC = null;

        DateTime? FechaPartida490WC = null;
        DateTime? FechaLlegada490WC = null;
        DateTime? FechaPartidaVUELTA490WC = null;
        DateTime? FechaLlegadaVUELTA490WC = null;


        if (float.TryParse(txtPrecioDesde.Text, out float precioDesde))
            PrecioDesde490WC = precioDesde;

        if (float.TryParse(txtPrecioHasta.Text, out float precioHasta))
            PrecioHasta490WC = precioHasta;

        if (float.TryParse(txtPesoEquipaje.Text, out float pesoPermitido))
            PesoPermitido490WC = pesoPermitido;


        if (chkFiltrarFecha.Checked)
        {
            if (DateTime.TryParse(txtFechaPartidaIda.Text, out DateTime fPartidaIda))
                FechaPartida490WC = fPartidaIda;

            if (DateTime.TryParse(txtFechaLlegadaIda.Text, out DateTime fLlegadaIda))
                FechaLlegada490WC = fLlegadaIda;

            if (DateTime.TryParse(txtFechaPartidaVuelta.Text, out DateTime fPartidaVuelta))
                FechaPartidaVUELTA490WC = fPartidaVuelta;

            if (DateTime.TryParse(txtFechaLlegadaVuelta.Text, out DateTime fLlegadaVuelta))
                FechaLlegadaVUELTA490WC = fLlegadaVuelta;
        }


        Mostrar490WC(
            Origen490WC,
            Destino490WC,
            ClaseBoleto490WC,
            PrecioDesde490WC,
            PrecioHasta490WC,
            PesoPermitido490WC,
            FechaPartida490WC,
            FechaLlegada490WC,
            FechaPartidaVUELTA490WC,
            FechaLlegadaVUELTA490WC
        );


        LimpiarCampos490WC();
    }

    private void BT_LIMPIARFILTROS490WC_Click(object sender, EventArgs e)
    {
        Mostrar490WC();
        LimpiarCampos490WC();
    }

    protected void gvBoletos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        BoletoBLL gestorBoleto = new BoletoBLL();
        BeneficioBLL gestorBeneficio = new BeneficioBLL();
        UsuarioBLL gestorCliente = new UsuarioBLL();
        int idBoleto = Convert.ToInt32(e.CommandArgument);
        boletoCargado = gestorBoleto.ObtenerBoletoPorID(idBoleto.ToString());
        switch (e.CommandName)
        {
            case "Reservar":
                gestorBoleto.AsignarBoletoCliente(boletoCargado, ClienteCargado);
                Mostrar490WC();
                break;

            case "ReservarBeneficio":
                Beneficio beneficioAplicar = ClienteCargado.BeneficiosCliente.Find(x => x.Nombre == ddlBeneficios.SelectedItem.ToString());
                gestorBeneficio.AplicarBeneficio(boletoCargado.IDBoleto, beneficioAplicar.DescuentoAplicar, beneficioAplicar.Nombre);
                boletoCargado = gestorBoleto.ObtenerBoletoConBeneficio(boletoCargado.IDBoleto);
                gestorBeneficio.EliminarBeneficioDeCliente(ClienteCargado.DNI, beneficioAplicar.CodigoBeneficio);
                ClienteCargado = gestorCliente.BuscarClientePorDNI(ClienteCargado.DNI);


                gestorBoleto.AsignarBoletoCliente(boletoCargado, ClienteCargado);
                Mostrar490WC();
                break;
        }
    }


}