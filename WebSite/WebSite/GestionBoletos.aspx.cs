using BE;
using BLL.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestionBoletos : System.Web.UI.Page
{
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        CargarBoletos();
    }
    public void CargarBoletos()
    {
        BoletoBLL gestorUsuario = new BoletoBLL();
        var listaBeneficios = gestorUsuario.ObtenerTodosLosBoletos();
        var listaAdaptada = listaBeneficios.Select(e => new
        {
            ID = e.IDBoleto,
            Origen = e.Origen,
            Destino = e.Destino,
            FechaPartidaIDA = e.FechaPartida,
            FechaLlegadaIDA = e.FechaLlegada,
            FechaPartidaVUELTA = (e is BoletoIDAVUELTA bole) ? bole.FechaPartidaVUELTA : (DateTime?)null,
            FechaLlegadaVUELTA = (e is BoletoIDAVUELTA bole2) ? bole2.FechaLlegadaVUELTA : (DateTime?)null,
            ClaseBoleto = e.ClaseBoleto,
            PesoEquipaje = e.EquipajePermitido,
            Precio = e.Precio,
            NumeroAsiento = e.NumeroAsiento
        }).ToList();
        gvBoletos.DataSource = listaAdaptada;
        gvBoletos.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtOrigen.Text = "";
        txtDestino.Text = "";
        txtFechaInicioIDA.Text = "";
        txtFechaFinIDA.Text = "";
        txtFechaInicioVUELTA.Text = "";
        txtFechaFinVUELTA.Text = "";
        ddlClaseBoleto.SelectedIndex = 0;
        txtPesoEquipaje.Text = "";
        txtPrecio.Text = "";
        txtNumeroAsiento.Text = "";
        chkFiltrarFecha.Checked = false;
        chkFiltrarFecha.Enabled = true; 
    }
    protected void gvBoletos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvBoletos.SelectedRow;

        
        txtOrigen.Text = row.Cells[2].Text;
        txtDestino.Text = row.Cells[3].Text;
        txtFechaInicioIDA.Text = ParseDateForInput(row.Cells[4].Text);
        txtFechaFinIDA.Text = ParseDateForInput(row.Cells[5].Text);
        ddlClaseBoleto.SelectedValue = Server.HtmlDecode(row.Cells[8].Text);
        
        txtPesoEquipaje.Text = row.Cells[9].Text.Replace(',', '.');
        txtPrecio.Text = row.Cells[10].Text.Replace(',', '.');
        txtNumeroAsiento.Text = row.Cells[11].Text;

        
        string fechaPartidaVuelta = row.Cells[6].Text;
        string fechaLlegadaVuelta = row.Cells[7].Text;

        bool esIdaVuelta = !string.IsNullOrEmpty(fechaPartidaVuelta) && fechaPartidaVuelta != "&nbsp;";

        if (esIdaVuelta)
        {
            chkFiltrarFecha.Checked = true;
            txtFechaInicioVUELTA.Text = ParseDateForInput(fechaPartidaVuelta);
            txtFechaFinVUELTA.Text = ParseDateForInput(fechaLlegadaVuelta);
        }
        else
        {
            chkFiltrarFecha.Checked = false;
            txtFechaInicioVUELTA.Text = "";
            txtFechaFinVUELTA.Text = "";
        }
        chkFiltrarFecha.Enabled = false;
    }

    
    private string ParseDateForInput(string dateText)
    {
        DateTime dt;
        if (DateTime.TryParseExact(dateText, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dt))
            return dt.ToString("yyyy-MM-dd");
        return "";
    }
}