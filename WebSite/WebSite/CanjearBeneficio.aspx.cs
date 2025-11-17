using BE;
using BLL.Negocio;
using BLL.Tecnica;
using Org.BouncyCastle.Utilities;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CanjearBeneficio : System.Web.UI.Page
{
    public Usuario clienteCargado;
    GestorPermisos gp =new GestorPermisos();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        Mostrar490WC();
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        clienteCargado = gestorUsuario.BuscarClientePorDNI(Session["dni"].ToString());
        CargarInfoUsuario();
        if (Session["idioma"] == null)
        {
            Session["idioma"] = "ES";
            Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        }
        string idioma = Session["idioma"].ToString();

        if (!IsPostBack)
        {
            gp.ActualizarGeneral();
        }

        TraducirPagina(this, Traductor.INSTANCIA(idioma));
    }

    public void Mostrar490WC()
    {
        BeneficioBLL gestorBeneficio = new BeneficioBLL();
        var beneficiosEnlistados = gestorBeneficio.ObtenerTodosLosBeneficios().Select(x => new
        {
            CodigoBeneficio = x.CodigoBeneficio,
            Nombre = x.Nombre,
            PrecioEstrella = x.PrecioEstrella,
            CantidadBeneficioReclamado = x.CantidadBeneficioReclamo,
            DescuentoAplicar = x.DescuentoAplicar
        });
        gvBeneficios.DataSource = beneficiosEnlistados;
        gvBeneficios.DataBind();
    }

    public void CargarInfoUsuario()
    {
        if (clienteCargado != null)
        {
            lblNombre.Text = "";
            lblApellido.Text = "";
            lblEstrellas.Text = "";
            lblBeneficios.Text = string.Empty;
            lblNombre.Text = clienteCargado.Nombre;
            lblApellido.Text = clienteCargado.Apellido;
            lblEstrellas.Text = clienteCargado.EstrellasCliente.ToString();
            if (clienteCargado.BeneficiosCliente.Count > 0)
            {
                foreach (Beneficio bene in clienteCargado.BeneficiosCliente)
                {
                    lblBeneficios.Text += bene.Nombre + "<br/>";
                }
            }
            else
            {
                lblBeneficios.Text = "No posee beneficios canjeados.";
            }
        }
    }
    protected void gvBeneficios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Canjear")
        {
            string codigo = e.CommandArgument.ToString();
            BeneficioBLL gestorBeneficio = new BeneficioBLL();
            UsuarioBLL gestorUsuario = new UsuarioBLL();
            Beneficio beneficioACanjear = gestorBeneficio.ObtenerTodosLosBeneficios().Find(b => b.CodigoBeneficio.ToString() == codigo);
            if (clienteCargado.BeneficiosCliente.Find(x => x.CodigoBeneficio == beneficioACanjear.CodigoBeneficio) == null)
            {
                int resultadoEstrellas = clienteCargado.EstrellasCliente - beneficioACanjear.PrecioEstrella;
                if (resultadoEstrellas >= 0)
                {
                    gestorUsuario.ModificarEstrellasCliente(clienteCargado.DNI, beneficioACanjear.PrecioEstrella);
                    beneficioACanjear.CantidadBeneficioReclamo += 1;
                    gestorBeneficio.Modificacion(beneficioACanjear);
                    gestorBeneficio.AgregarBeneficioACliente(clienteCargado.DNI, beneficioACanjear.CodigoBeneficio);
                    clienteCargado = gestorUsuario.BuscarClientePorDNI(clienteCargado.DNI);
                    CargarInfoUsuario();
                    Mostrar490WC();
                }
                else
                {
                    string mensajeError = "Error: No Posee Las Estrellas Suficientes Para Canjear El Beneficio!!";
                    string script = $"alert('{mensajeError}');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                }
            }
            else
            {
                string mensajeError = "Error: El Usuario Ya Posee El Beneficio Que Desea Canjear!!";
                string script = $"alert('{mensajeError}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
            }
        }
    }

    protected void BT_Volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");

    }

    public void TraducirPagina(Control contenedor, Traductor traductor)
    {
        foreach (Control ctrl in contenedor.Controls)
        {
            string idioma = Session["idioma"]?.ToString() ?? "ES";

            // NAVBAR
            if (ctrl.ID == "navbarPrincipal")
            {
                TraducirNavbar(ctrl, traductor);
            }
            else
            {
                // 🔥 1. Obtener la data-key para CUALQUIER tipo de control
                string dataKey = null;

                if (ctrl is WebControl wc)
                    dataKey = wc.Attributes["data-key"];
                else if (ctrl is HtmlControl hc)
                    dataKey = hc.Attributes["data-key"];

                // 🔥 2. Si existe key, traducir según tipo
                if (!string.IsNullOrEmpty(dataKey))
                {
                    string traduccion = traductor.Traducir(dataKey, idioma);

                    if (ctrl is LinkButton lb)
                        lb.Text = traduccion;

                    else if (ctrl is Button btn)
                        btn.Text = traduccion;

                    else if (ctrl is Label lbl)
                        lbl.Text = traduccion;

                    else if (ctrl is HtmlAnchor anchor)
                        anchor.InnerText = traduccion;

                    else if (ctrl is HtmlGenericControl hgc)
                        hgc.InnerText = traduccion;

                    else if (ctrl is CheckBoxList cbl)
                    {
                        foreach (ListItem item in cbl.Items)
                        {
                            string key = item.Attributes["data-key"];
                            if (!string.IsNullOrEmpty(key))
                                item.Text = traductor.Traducir(key, idioma);
                        }
                    }
                }
            }
            // Recursividad
            if (ctrl.HasControls())
                TraducirPagina(ctrl, traductor);
        }
    }
    public void TraducirNavbar(Control navbar, Traductor traductor)
    {
        string idioma = Session["idioma"]?.ToString() ?? "ES";

        foreach (Control ctrl in navbar.Controls)
        {
            // Caso A: es un HtmlAnchor <a runat="server">
            if (ctrl is HtmlAnchor anchor)
            {
                string key = anchor.Attributes["data-key"];
                if (!string.IsNullOrEmpty(key))
                {
                    anchor.InnerText = traductor.Traducir(key, idioma);
                }
            }

            // Caso B: es un LinkButton (si lo usás más adelante)
            else if (ctrl is LinkButton lb)
            {
                string key = lb.Attributes["data-key"];
                if (!string.IsNullOrEmpty(key))
                {
                    lb.Text = traductor.Traducir(key, idioma);
                }
            }

            // Recursivo para <ul>, <li>, etc.
            if (ctrl.HasControls())
            {
                TraducirNavbar(ctrl, traductor);
            }
        }
    }
}