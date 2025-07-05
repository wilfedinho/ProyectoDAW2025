using BE;
using BLL.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Eventos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarEventos();
    }
    //public void CargarEventos(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
    //{
    //    BitacoraBLL gestorBitacora = new BitacoraBLL();

    //    gvEventos.DataSource = gestorBitacora.ObtenerEventosPorConsulta490WC(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar);
    //    gvEventos.DataBind();
    //    LLenarCB490WC();
    //}

    public void CargarEventos(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
    {
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        var lista = gestorBitacora.ObtenerEventosPorConsulta(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar);

        var listaAdaptada = lista.Select(e => new
        {
            NumeroEvento = e.IdBitacora,
            Usuario = e.Username,
            FechaEvento = e.Fecha,
            Hora = e.Hora.ToString(),
            Modulo = e.Modulo,
            Descripcion = e.Descripcion,
            Criticidad = e.Criticidad
        }).ToList();

        gvEventos.DataSource = listaAdaptada;
        gvEventos.DataBind();
        LLenarCB();
    }

    public void LLenarCB()
    {
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        foreach (Bitacora bitacora in gestorBitacora.ObtenerEventosPorConsulta())
        {
            if (ddlModulo.Items.FindByText(bitacora.Modulo) == null)
                ddlModulo.Items.Add(new ListItem(bitacora.Modulo));

            if (ddlEvento.Items.FindByText(bitacora.Descripcion) == null)
                ddlEvento.Items.Add(new ListItem(bitacora.Descripcion));

            string criticidadStr = bitacora.Criticidad.ToString();
            if (ddlCriticidad.Items.FindByText(criticidadStr) == null)
                ddlCriticidad.Items.Add(new ListItem(criticidadStr));
        }
    }

    protected void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e)
    {
        bool isChecked = chkFiltrarFecha.Checked;
        if (isChecked)
        {
            txtFechaFin.Enabled = true;
            txtFechaInicio.Enabled = true;
        }
        else
        {
            txtFechaFin.Enabled = false;
            txtFechaInicio.Enabled = false;
            txtFechaFin.Text = string.Empty;
            txtFechaInicio.Text = string.Empty;

        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        string usuarioFiltrar = txtUsuario.Text;
        string moduloFiltrar = ddlModulo.SelectedValue;
        string descripcionFiltrar = ddlEvento.SelectedValue;
        string criticidadFiltrar = ddlCriticidad.SelectedValue;
        DateTime fechaMinSql = new DateTime(1753, 1, 1);
        DateTime fechaMaxSql = new DateTime(9999, 12, 31);
        if (chkFiltrarFecha.Checked)
        {
            if (DateTime.TryParse(txtFechaInicio.Text, out DateTime fechaInicioFiltrar))
            {
                if (DateTime.TryParse(txtFechaFin.Text, out DateTime fechaFinFiltrar))
                {
                    CargarEventos(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaFinFiltrar);
                }
                else
                {
                    CargarEventos(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaMaxSql);
                }
            }
            else
            {
                CargarEventos(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaMinSql, fechaMaxSql);
                if (DateTime.TryParse(txtFechaFin.Text, out DateTime fechaFinFiltrar))
                {
                    CargarEventos(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaMinSql, fechaFinFiltrar);
                }
                else
                {
                    CargarEventos(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaInicioFiltrar, fechaMaxSql);
                }
            }

        }
        else
        {
            CargarEventos(usuarioFiltrar, moduloFiltrar, descripcionFiltrar, criticidadFiltrar, fechaMinSql, fechaMaxSql);
        }
    }

    protected void btnRestablecer_Click(object sender, EventArgs e)
    {
        CargarEventos();
    }
}