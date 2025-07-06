using BE;
using BLL.Negocio;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestionBeneficios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        CargarBeneficios();

    }
    public void CargarBeneficios()
    {
        BeneficioBLL gestorUsuario = new BeneficioBLL();
        var listaBeneficios = gestorUsuario.ObtenerTodosLosBeneficios();
       
        var listaAdaptada = listaBeneficios.Select(e => new
        {
            CodigoBeneficio = e.CodigoBeneficio,
            Nombre = e.Nombre,
            Precio = e.PrecioEstrella,
            CantidadCanjeada = e.CantidadBeneficioReclamo,
            Descuento = e.DescuentoAplicar,
        }).ToList();
        gvBeneficios.DataSource = listaAdaptada;
        gvBeneficios.DataBind();
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
        //nada
    }

    protected void btnBoletos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionBoletos.aspx");
    }

    protected void btnClave_Click(object sender, EventArgs e)
    {
        //nada
    }

    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
}