﻿using BE;
using BLL.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        Boleto BoletoAlta490WC;
        Usuario cliente490WC = new Usuario("", null, null, "Sistema", null, null, null);
        BoletoBLL gestorBoleto490WC = new BoletoBLL();
        string id490WC = "0";
        string origen490WC = txtOrigen.Text;
        string destino490WC = txtDestino.Text;
        DateTime fechaPartidaIDA;
        DateTime.TryParseExact(txtFechaInicioIDA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaPartidaIDA);
        DateTime fechaLlegadaIDA;
        DateTime.TryParseExact(txtFechaFinIDA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaLlegadaIDA);
        bool isVendido490WC = false;
        string asiento490WC = txtNumeroAsiento.Text;

        if (gestorBoleto490WC.VerificarFormatoAsiento(asiento490WC))
        {
            if (ddlClaseBoleto.SelectedIndex > 0)
            {

                string claseBoleto490WC = ddlClaseBoleto.SelectedItem.ToString();
                float pesoEquipaje = 0;
                float.TryParse(txtPesoEquipaje.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out pesoEquipaje);
                float precio = 0;
                float.TryParse(txtPrecio.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out precio);
                if (chkFiltrarFecha.Checked == false)
                {
                    if (fechaPartidaIDA <= fechaLlegadaIDA)
                    {
                        BoletoAlta490WC = new BoletoIDA(id490WC, origen490WC, destino490WC, fechaPartidaIDA, fechaLlegadaIDA, isVendido490WC, pesoEquipaje, claseBoleto490WC, precio, cliente490WC, asiento490WC);

                        if (!gestorBoleto490WC.ExisteBoletoEnAsiento(BoletoAlta490WC))
                        {
                            gestorBoleto490WC.Alta(BoletoAlta490WC);
                            CargarBoletos();
                            limpiar();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Datos Ingresados Duplicados!!!');", true);
                            limpiar();
                        }
                    }
                }
                else
                {
                    DateTime fechaPartidaVUELTA;
                    DateTime.TryParseExact(txtFechaInicioVUELTA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaPartidaVUELTA);
                    DateTime fechaLlegadaVUELTA;
                    DateTime.TryParseExact(txtFechaFinVUELTA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaLlegadaVUELTA);

                    if (fechaPartidaIDA <= fechaLlegadaIDA && fechaLlegadaIDA < fechaPartidaVUELTA && fechaPartidaVUELTA <= fechaLlegadaVUELTA)
                    {
                        BoletoAlta490WC = new BoletoIDAVUELTA(id490WC, origen490WC, destino490WC, fechaPartidaIDA, fechaLlegadaIDA, fechaPartidaVUELTA, fechaLlegadaVUELTA, isVendido490WC, pesoEquipaje, claseBoleto490WC, precio, cliente490WC, asiento490WC);
                        if (!gestorBoleto490WC.ExisteBoletoEnAsiento(BoletoAlta490WC))
                        {
                            gestorBoleto490WC.Alta(BoletoAlta490WC);
                            CargarBoletos();
                            limpiar();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Datos Ingresados Duplicados!!!');", true);
                            limpiar();
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Formato Del Numero de Asiento Invalido!!!, el correcto es A111');", true);
                limpiar();
            }
        }
    }


    protected void btnModificar_Click(object sender, EventArgs e)
    {
        BoletoBLL gestorBoleto490WC = new BoletoBLL();
        GridViewRow row = gvBoletos.SelectedRow;
        id = row.Cells[1].Text;
        Boleto BoletoModificado490WC = gestorBoleto490WC.ObtenerBoletoPorID(id);
        Usuario cliente490WC = new Usuario("", null, null, "Sistema", null, null, null);
        string origen490WC = txtOrigen.Text;
        string destino490WC = txtDestino.Text;
        string asiento = txtNumeroAsiento.Text;
        DateTime fechaPartidaIDA;
        DateTime.TryParseExact(txtFechaInicioIDA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaPartidaIDA);
        DateTime fechaLlegadaIDA;
        DateTime.TryParseExact(txtFechaFinIDA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaLlegadaIDA);
        if (gestorBoleto490WC.VerificarFormatoAsiento(asiento))
        {
            if (ddlClaseBoleto.SelectedIndex > 0)
            {
                string claseBoleto490WC = ddlClaseBoleto.SelectedItem.ToString();
                float pesoEquipaje = 0;
                float.TryParse(txtPesoEquipaje.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out pesoEquipaje);
                float precio = 0;
                float.TryParse(txtPrecio.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out precio);

                if (chkFiltrarFecha.Checked == false)
                {
                    if (fechaPartidaIDA <= fechaLlegadaIDA)
                    {
                        BoletoModificado490WC.Origen = origen490WC;
                        BoletoModificado490WC.Destino = destino490WC;
                        BoletoModificado490WC.FechaPartida = fechaPartidaIDA;
                        BoletoModificado490WC.FechaLlegada = fechaLlegadaIDA;
                        BoletoModificado490WC.EquipajePermitido = pesoEquipaje;
                        BoletoModificado490WC.ClaseBoleto = claseBoleto490WC;
                        BoletoModificado490WC.Precio = precio;
                        BoletoModificado490WC.Titular = cliente490WC;
                        BoletoModificado490WC.NumeroAsiento = asiento;

                        if (!gestorBoleto490WC.ExisteBoletoEnAsientoParaModificar(BoletoModificado490WC))
                        {
                            gestorBoleto490WC.Modificar(BoletoModificado490WC);
                            CargarBoletos();
                            limpiar();
                        }
                    }
                }
                else
                {
                    DateTime fechaPartidaVUELTA;
                    DateTime.TryParseExact(txtFechaInicioVUELTA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaPartidaVUELTA);
                    DateTime fechaLlegadaVUELTA;
                    DateTime.TryParseExact(txtFechaFinVUELTA.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaLlegadaVUELTA);

                    if (fechaPartidaIDA <= fechaLlegadaIDA && fechaLlegadaIDA < fechaPartidaVUELTA && fechaPartidaVUELTA <= fechaLlegadaVUELTA)
                    {
                        BoletoModificado490WC.Origen = origen490WC;
                        BoletoModificado490WC.Destino = destino490WC;
                        BoletoModificado490WC.FechaPartida = fechaPartidaIDA;
                        (BoletoModificado490WC as BoletoIDAVUELTA).FechaPartidaVUELTA = fechaPartidaVUELTA;
                        BoletoModificado490WC.FechaLlegada = fechaLlegadaIDA;
                        (BoletoModificado490WC as BoletoIDAVUELTA).FechaLlegadaVUELTA = fechaLlegadaVUELTA;
                        BoletoModificado490WC.EquipajePermitido = pesoEquipaje;
                        BoletoModificado490WC.ClaseBoleto = claseBoleto490WC;
                        BoletoModificado490WC.Precio = precio;
                        BoletoModificado490WC.Titular = cliente490WC;
                        BoletoModificado490WC.NumeroAsiento = asiento;

                        if (!gestorBoleto490WC.ExisteBoletoEnAsientoParaModificar(BoletoModificado490WC))
                        {
                            gestorBoleto490WC.Modificar(BoletoModificado490WC);
                            CargarBoletos();
                            limpiar();
                        }
                    }
                }
            }
        }
    }


    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        GridViewRow row = gvBoletos.SelectedRow;

        id = row.Cells[1].Text;
        if (id != null || id == "")
        {
            BoletoBLL gestorBoleto = new BoletoBLL();
            gestorBoleto.Baja(id);
            CargarBoletos();
            limpiar();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Debes Seleccionar un Boleto para Borrarlo!!!');", true);
            limpiar();
        }
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        limpiar();
    }
    protected void limpiar()
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

        id = row.Cells[1].Text;
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