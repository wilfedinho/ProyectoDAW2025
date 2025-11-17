using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Vuelos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        if (Session["usuario"] == null)
        {
            
            btnCambiarClave.Visible = false;
            btnCerrarSesion.Visible = false;
        }
        else
        {
            lblMensaje.Text = $"Bienvenido {Session["usuario"]} A Sanza Flights";
            btnCambiarClave.Visible = true;
            btnCerrarSesion.Visible = true;
        }
        CargarVuelos();
        ChequearAccesibilidadDeTodosLosControles();

        string target = Request["__EVENTTARGET"];
        string arg = Request["__EVENTARGUMENT"];

        if (target == "SelectVuelo")
        {
            int idVuelo = int.Parse(arg);
            SeleccionarVuelo(idVuelo);
        }


    }

    private void CargarVuelos()
    {
        var vuelos = new List<dynamic>
    {
        new { ID = 1, Imagen = "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80",
              Titulo = "Reservar Boletos",
              Descripcion = "En Esta Opcion Tendras La Posibilidad De Reservar Los Boletos Disponibles...",
              Url = "ReservarBoleto.aspx"
        },

        new { ID = 2, Imagen = "https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80",
              Titulo = "Canjear Beneficios",
              Descripcion = "En Esta Opcion Tendras La Posibilidad De Canjear Los Beneficios...",
              Url = "CanjearBeneficio.aspx"
        },

        new { ID = 3, Imagen = "https://images.unsplash.com/photo-1502082553048-f009c37129b9?auto=format&fit=crop&w=400&q=80",
              Titulo = "Pagar Boletos",
              Descripcion = "En Esta Opcion Tendras La Posibilidad De Realizar Los Pagos...",
              Url = "PagarBoleto.aspx"
        }
    };

        repVuelos.DataSource = vuelos;
        repVuelos.DataBind();
    }


    private void SeleccionarVuelo(int idVuelo)
    {
        Session["VueloSeleccionado"] = idVuelo;
        Response.Redirect("ReservarBoleto.aspx");
    }

    public void ChequearAccesibilidadDeTodosLosControles()
    {
        GestorPermisos gp = new GestorPermisos();
        ChequearAccesibilidadRecursiva(Page, gp);
        ChequearAccesibilidadNavbar(navbarPrincipal, gp);
    }

    private void ChequearAccesibilidadNavbar(Control navbar, GestorPermisos gp)
    {
        try
        {
            foreach (Control ctrl in navbar.Controls)
            {
                if (ctrl is Button btn)
                {
                    string permiso = btn.CommandName;
                    if (permiso == "")
                    {
                        btn.Visible = true;
                        continue;
                    }
                    if (!gp.TienePermiso(permiso, gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto))
                    {
                        btn.Visible = false;
                    }
                    else
                    {
                        btn.Visible = true;
                    }
                }
                else if (ctrl is LinkButton linkBtn)
                {
                    string permiso = linkBtn.CommandName;
                    if (permiso == "")
                    {
                        linkBtn.Visible = true;
                        continue;
                    }
                    if (!gp.TienePermiso(permiso, gp.DevolverPermisoConHijos(Session["rol"].ToString()) as EntidadPermisoCompuesto))
                    {
                        linkBtn.Visible = false;
                    }
                    else
                    {
                        linkBtn.Visible = true;
                    }
                }
                else if (ctrl.HasControls())
                {
                    ChequearAccesibilidadNavbar(ctrl, gp);
                }
            }

        }
        catch { }
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

    protected void btnInicio_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void btnCambiarClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarClave.aspx");
    }

    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        if (Session["usuario"] != null)
        {
            BitacoraBLL gestorBitacora = new BitacoraBLL();
            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Landing Page", "Salida del Sistema", 4);
            gestorBitacora.Alta(eventoGenerado);
        }

        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }

    protected void btnMenuAdministrador_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuAdministrador.aspx");
    }

    protected void btnMenuWebMaster_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuWebMaster.aspx");
    }
}