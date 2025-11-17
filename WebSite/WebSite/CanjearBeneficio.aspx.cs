using BE;
using BLL.Negocio;
using BLL.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CanjearBeneficio : System.Web.UI.Page
{
    public Usuario clienteCargado;
    protected void Page_Load(object sender, EventArgs e)
    {

        Mostrar490WC();
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        clienteCargado = gestorUsuario.BuscarClientePorDNI("44.714.502");
        CargarInfoUsuario();

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
                string mensajeError = "Error: El Usuario Ya Posee El Beneficio Que Desea Canjear!!";
                string script = $"alert('{mensajeError}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
            }
        }
    }
}