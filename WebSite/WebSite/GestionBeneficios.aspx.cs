using BE;
using BLL.Negocio;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Serialization;

public partial class GestionBeneficios : System.Web.UI.Page
{
    GestorPermisos gp = new GestorPermisos();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        if (!IsPostBack)
        {
            if (Session["usuario"] != null && Session["rol"].ToString() == "Admin")
            {
                CargarBeneficios();
            }
            else
            {
                Response.Redirect("Vuelos.aspx");
            }
        }
        if (Session["idioma"] == null)
        {
            Session["idioma"] = "ES";
            Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        }
        string idioma = Session["idioma"].ToString();

        if (idioma == "ES")
        {
            btnES.CssClass = "nav-link idioma-btn activo";
            btnEN.CssClass = "nav-link idioma-btn";
        }
        else
        {
            btnEN.CssClass = "nav-link idioma-btn activo";
            btnES.CssClass = "nav-link idioma-btn";
        }
        if (!IsPostBack)
        {
            gp.ActualizarGeneral();
        }

        TraducirPagina(this, Traductor.INSTANCIA(idioma));
    }


    public void CargarBeneficios()
    {
        BeneficioBLL gestorUsuario = new BeneficioBLL();
        var listaBeneficios = gestorUsuario.ObtenerTodosLosBeneficios();

        var listaAdaptada = listaBeneficios.Select(e => new
        {
            CodigoBeneficio = e.CodigoBeneficio,
            Nombre = e.Nombre,
            PrecioEstrella = e.PrecioEstrella,
            CantidadBeneficioReclamo = e.CantidadBeneficioReclamo,
            DescuentoAplicar = e.DescuentoAplicar,
        }).ToList();
        gvBeneficios.DataSource = listaAdaptada;
        gvBeneficios.DataBind();
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Beneficios", "Consulta de Beneficios", 1);
        gestorBitacora.Alta(eventoGenerado);
    }

    private void LimpiarCampos()
    {
        txtCodigo.Text = "";
        txtNombre.Text = "";
        txtPrecio.Text = "";
        txtCantidad.Text = "";
        txtDescuento.Text = "";
        gvBeneficios.SelectedIndex = -1;
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        BeneficioBLL gestorBeneficio490WC = new BeneficioBLL();
        int codigoBeneficio490WC = int.Parse(txtCodigo.Text);
        if (!gestorBeneficio490WC.ExisteNombreBeneficioAlta(txtNombre.Text))
        {
            if (int.TryParse(txtPrecio.Text, out int precioEstrella490WC))
            {
                if (int.TryParse(txtCantidad.Text, out int cantidadReclamo490WC))
                {
                    Beneficio beneficioduplicado = gestorBeneficio490WC.ObtenerBeneficioPorCodigo(codigoBeneficio490WC);
                    if (beneficioduplicado == null)
                    {
                        float descuentoAplicar = int.Parse(txtDescuento.Text);
                        descuentoAplicar = descuentoAplicar / 100;
                        string nombre490WC = txtNombre.Text;
                        int idBeneficio490WC = codigoBeneficio490WC;
                        Beneficio beneficioAlta490WC = new Beneficio(idBeneficio490WC, nombre490WC, precioEstrella490WC, cantidadReclamo490WC, descuentoAplicar);
                        gestorBeneficio490WC.Alta(beneficioAlta490WC);
                        CargarBeneficios();
                        LimpiarCampos();
                        BitacoraBLL gestorBitacora = new BitacoraBLL();
                        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Beneficios", "Agregacion Beneficio", 3);
                        gestorBitacora.Alta(eventoGenerado);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('El codigo ingresado Ya lo tiene un Beneficio Existente!!!');", true);
                    }
                }
            }
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        BeneficioBLL gestorBeneficio = new BeneficioBLL();
        int codigoBeneficio490WC = int.Parse(gvBeneficios.SelectedDataKey["CodigoBeneficio"].ToString());
        if (!gestorBeneficio.ExisteNombreBeneficioModificar(txtNombre.Text, codigoBeneficio490WC))
        {
            if (int.TryParse(txtPrecio.Text, out int precioEstrella490WC))
            {
                if (int.TryParse(txtCantidad.Text, out int cantidadReclamo490WC))
                {
                    float descuentoAplicar = int.Parse(txtDescuento.Text);
                    descuentoAplicar = descuentoAplicar / 100;
                    string nombre490WC = txtNombre.Text;
                    Beneficio beneficioModificado490WC = gestorBeneficio.ObtenerBeneficioPorCodigo(codigoBeneficio490WC);
                    beneficioModificado490WC.Nombre = nombre490WC;
                    beneficioModificado490WC.PrecioEstrella = precioEstrella490WC;
                    beneficioModificado490WC.CantidadBeneficioReclamo = cantidadReclamo490WC;
                    beneficioModificado490WC.DescuentoAplicar = descuentoAplicar;
                    gestorBeneficio.Modificacion(beneficioModificado490WC);
                    CargarBeneficios();
                    LimpiarCampos();
                    BitacoraBLL gestorBitacora = new BitacoraBLL();
                    Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Beneficios", "Modificacion Beneficio", 3);
                    gestorBitacora.Alta(eventoGenerado);
                }
            }
        }
    }

    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        BeneficioBLL gestorBeneficio = new BeneficioBLL();
        if (gvBeneficios.SelectedDataKey != null)
        {
            int codigoBeneficio490WC = int.Parse(gvBeneficios.SelectedDataKey["CodigoBeneficio"].ToString());
            if (gestorBeneficio.Baja(codigoBeneficio490WC))
            {
                CargarBeneficios();
                LimpiarCampos();
                BitacoraBLL gestorBitacora = new BitacoraBLL();
                Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Beneficios", "Eliminacion Beneficio", 5);
                gestorBitacora.Alta(eventoGenerado);
            }
            else
            {
                lblMensaje.Text = "No se pudo eliminar el beneficio. Puede que esté asociado a un cliente.";
                lblMensaje.CssClass = "validador-error";
                lblMensaje.Visible = true;
            }
        }

    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
        CargarBeneficios();
    }
    protected void gvBeneficios_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvBeneficios.SelectedRow;

        txtCodigo.Text = Server.HtmlDecode(row.Cells[1].Text);
        txtNombre.Text = Server.HtmlDecode(row.Cells[2].Text);
        txtPrecio.Text = Server.HtmlDecode(row.Cells[3].Text);
        txtCantidad.Text = Server.HtmlDecode(row.Cells[4].Text);
        float descuento = float.Parse(Server.HtmlDecode(row.Cells[5].Text));
        descuento = descuento * 100;
        txtDescuento.Text = descuento.ToString();

    }

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuAdministrador.aspx");
    }

    protected void btnUsuarios_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionUsuarios.aspx");
    }

    protected void btnBeneficios_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionBeneficios.aspx");
    }

    protected void btnBoletos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionBoletos.aspx");
    }

    protected void btnClave_Click(object sender, EventArgs e)
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

    protected void btnSerializar_Click(object sender, EventArgs e)
    {
        List<Beneficio> beneficiosASerializar = new List<Beneficio>();
        foreach (GridViewRow row in gvBeneficios.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSeleccionar");
            if (chk != null && chk.Checked)
            {
                int rowIndex = row.RowIndex;
                int codigo = Convert.ToInt32(gvBeneficios.DataKeys[rowIndex]["CodigoBeneficio"]);
                string nombre = gvBeneficios.DataKeys[rowIndex]["Nombre"].ToString();
                int precio = int.Parse(gvBeneficios.DataKeys[rowIndex]["PrecioEstrella"].ToString());
                int cantidad = int.Parse(gvBeneficios.DataKeys[rowIndex]["CantidadBeneficioReclamo"].ToString());
                float descuento = float.Parse(gvBeneficios.DataKeys[rowIndex]["DescuentoAplicar"].ToString());
                Beneficio beneficio = new Beneficio
                {
                    CodigoBeneficio = codigo,
                    Nombre = nombre,
                    PrecioEstrella = precio,
                    CantidadBeneficioReclamo = cantidad,
                    DescuentoAplicar = descuento
                };

                beneficiosASerializar.Add(beneficio);
            }
        }

        if (beneficiosASerializar.Count > 0)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string direc = Path.Combine(path, "BeneficiosSerializados");
            if (!Directory.Exists(direc))
            {
                Directory.CreateDirectory(direc);
            }
            string horaNow = DateTime.Now.ToString("HHmmss");
            string file = $"BeneficioSerializado_{horaNow}.xml";
            string fullPath = Path.Combine(direc, file);
            WebService ws = new WebService();
            ws.Serializar(fullPath, beneficiosASerializar);
            lblMensaje.Text = $"Se han serializado {beneficiosASerializar.Count} beneficios.";
            lblMensaje.Visible = true;
        }
        else
        {
            lblMensaje.Text = "No has seleccionado ningún beneficio para serializar.";
            lblMensaje.Visible = true;
        }

        foreach (GridViewRow row in gvBeneficios.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkSeleccionar");
            chk.Checked = false;
        }
        CargarBeneficios();
    }

    protected void btnDeserializar_Click(object sender, EventArgs e)
    {
        if (!fuArchivoXML.HasFile)
        {
            lblMensaje.Text = "No se seleccionó ningún archivo.";
            lblMensaje.Visible = true;
            return;
        }

        string fileExtension = Path.GetExtension(fuArchivoXML.FileName);
        if (!fileExtension.Equals(".xml", StringComparison.OrdinalIgnoreCase))
        {
            lblMensaje.Text = "Error: El archivo seleccionado no es un .xml";
            lblMensaje.Visible = true;
            return;
        }

        if (fuArchivoXML.PostedFile.ContentLength == 0)
        {
            lblMensaje.Text = "Error: El archivo XML que seleccionaste está vacío (0 bytes).";
            lblMensaje.Visible = true;
            return;
        }

        string tempFilePath = "";

        try
        {
            string tempFileName = Guid.NewGuid().ToString() + ".xml";
            tempFilePath = Path.Combine(Path.GetTempPath(), tempFileName);

            fuArchivoXML.SaveAs(tempFilePath);

            WebService ws = new WebService();
            List<Beneficio> beneficios = ws.Deserializar(tempFilePath);

            var listaAdaptada = beneficios.Select(e => new
            {
                CodigoBeneficio = e.CodigoBeneficio,
                Nombre = e.Nombre,
                PrecioEstrella = e.PrecioEstrella,
                CantidadBeneficioReclamo = e.CantidadBeneficioReclamo,
                DescuentoAplicar = e.DescuentoAplicar
            }).ToList();

            gvBeneficios.DataSource = listaAdaptada;
            gvBeneficios.DataBind();

            lblMensaje.Text = "Datos cargados correctamente desde XML.";
            lblMensaje.Visible = true;
        }
        catch (Exception ex)
        {
            lblMensaje.Text = "Error al procesar el archivo: " + ex.Message;
            lblMensaje.Visible = true;
        }
        finally
        {
            if (!string.IsNullOrEmpty(tempFilePath) && File.Exists(tempFilePath))
            {
                File.Delete(tempFilePath);
            }
        }
    }

    protected void btnPermisos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionRolesUsuarios.aspx");
    }

    protected void btnES_Click(object sender, EventArgs e)
    {
        Session["idioma"] = "ES";
        Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEN_Click(object sender, EventArgs e)
    {
        Session["idioma"] = "EN";
        Traductor.INSTANCIA("EN").ActualizarIdioma("EN");
        Response.Redirect(Request.RawUrl);
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