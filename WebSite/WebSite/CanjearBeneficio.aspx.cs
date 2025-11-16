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
            clienteCargado = gestorUsuario.BuscarClientePorDNI("77.777.777");
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
            lblBeneficios.Text = "";
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

    /* private void BT_CANJEARBENEFICIO490WC_Click(object sender, EventArgs e)
     {

         GestorBeneficio490WC gestorBeneficio490WC = new GestorBeneficio490WC();
         GestorCliente490WC gestorCliente490WC = new GestorCliente490WC();
         Beneficio490WC beneficioAplicar490WC = gestorBeneficio490WC.ObtenerBeneficioPorCodigo490WC(Convert.ToInt32(dgvBeneficio490WC.SelectedRows[0].Cells["ColumnaCodigoBeneficio490WC"].Value.ToString()));
         if (clienteCargado.EstrellasCliente490WC >= beneficioAplicar490WC.PrecioEstrella490WC)
         {
             if (clienteCargado.BeneficiosCliente490WC.Find(x => x.CodigoBeneficio490WC == beneficioAplicar490WC.CodigoBeneficio490WC) == null)
             {
                 gestorCliente490WC.ModificarEstrellasCliente490WC(clienteCargado.DNI490WC, beneficioAplicar490WC.PrecioEstrella490WC);
                 beneficioAplicar490WC.CantidadBeneficioReclamo490WC += 1;
                 gestorBeneficio490WC.Modificacion490WC(beneficioAplicar490WC);
                 gestorBeneficio490WC.AgregarBeneficioACliente490WC(clienteCargado.DNI490WC, beneficioAplicar490WC.CodigoBeneficio490WC);
                 clienteCargado = gestorCliente490WC.BuscarClientePorDNI490WC(clienteCargado.DNI490WC);
                 CargarCliente490WC(clienteCargado);
                 Mostrar490WC();
             }
             else
             {

             }
         }
         else
         {

         }

     var btnEliminar = new LinkButton
 {
     Text = "X",
     CommandArgument = cv.ID_CV.ToString(),
     OnClientClick = "return confirm('¿Eliminar este CV?');",
     Style =
         {
             ["margin-right"] = "10px",
             ["font-size"] = "20px",
             ["color"] = "red",
             ["text-decoration"] = "none",
             ["font-weight"] = "bold"
         }
 };


     }*/

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
                gestorUsuario.ModificarEstrellasCliente(clienteCargado.DNI,beneficioACanjear.PrecioEstrella);
                beneficioACanjear.CantidadBeneficioReclamo += 1;
                gestorBeneficio.Modificacion(beneficioACanjear);
                gestorBeneficio.AgregarBeneficioACliente(clienteCargado.DNI, beneficioACanjear.CodigoBeneficio);
                clienteCargado = gestorUsuario.BuscarClientePorDNI(clienteCargado.DNI);
                CargarInfoUsuario();
                Mostrar490WC();
            }
            else
            {

            }
        }
        else
        {

        }
    }


}