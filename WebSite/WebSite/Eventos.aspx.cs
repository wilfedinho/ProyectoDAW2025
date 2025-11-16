using BE;
using BLL.Tecnica;
using SERVICIOS;
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
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        if (Session["usuario"] != null && Session["rol"].ToString() == "WebMaster")
        {
            CargarEventos();
        }
        else
        {
            Response.Redirect("Vuelos.aspx");
        }
        ChequearAccesibilidadDeTodosLosControles();
    }

    public void ChequearAccesibilidadDeTodosLosControles()
    {
        GestorPermisos gp = new GestorPermisos();
        ChequearAccesibilidadRecursiva(Page, gp);
        ChequearAccesibilidadNavbar(navbarPrincipal, gp);
    }

    private void ChequearAccesibilidadNavbar(Control navbar, GestorPermisos gp)
    {
        foreach (Control ctrl in navbar.Controls)
        {
            if (ctrl is Button btn)
            {
                string permiso = btn.CommandName;
                if(permiso == "") { btn.Visible = true; continue; }

                if (!gp.TienePermiso(permiso, gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto))
                {
                    btn.Visible = false;
                }
            }
            else if (ctrl is LinkButton linkBtn)
            {
                string permiso = linkBtn.CommandName;
                if (permiso == "") { linkBtn.Visible = true; continue; }

                if (!gp.TienePermiso(permiso, gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto))
                {
                    linkBtn.Visible = false;
                }
            }
            else if (ctrl.HasControls())
            {
                ChequearAccesibilidadNavbar(ctrl, gp);
            }
        }
    }

    public void ChequearAccesibilidadRecursiva(Control contenedor, GestorPermisos gp)
    {
        foreach (Control ctrl in contenedor.Controls)
        {
            if (ctrl is Button)
            {
                ChequearAccesibilidad(ctrl as Button, gp);
                if (ctrl.HasControls())
                {
                    ChequearAccesibilidadRecursiva(ctrl, gp);
                }
            }
        }
    }

    public void ChequearAccesibilidad(Button boton, GestorPermisos gp)
    {
        boton.Visible = gp.Configurar_Control(boton.CommandName.ToString(), Session["rol"].ToString(), gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto);
    }


    public void CargarEventos(string usuarioFiltrar = "", string moduloFiltrar = "", string descripcionFiltrar = "", string criticidadFiltrar = "", DateTime? fechaInicioFiltrar = null, DateTime? fechaFinFiltrar = null)
    {
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Bitacora de Eventos", "Consulta de Eventos", 1);
        gestorBitacora.Alta(eventoGenerado);
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

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuWebMaster.aspx");
    }

    protected void btnBackupRestore_Click(object sender, EventArgs e)
    {
        Response.Redirect("Restore_BackUp.aspx");
    }

    protected void btnDigitosVerificadores_Click(object sender, EventArgs e)
    {
        Response.Redirect("Restore_BackUp.aspx");
    }

    protected void btnBitacora_Click(object sender, EventArgs e)
    {
        Response.Redirect("Eventos.aspx");
    }

    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarClave.aspx");
    }

    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}