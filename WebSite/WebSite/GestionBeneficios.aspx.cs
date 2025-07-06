using BE;
using BLL.Negocio;
using BLL.Tecnica;
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
                }
            }
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {

    }
    protected void gvBeneficios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}