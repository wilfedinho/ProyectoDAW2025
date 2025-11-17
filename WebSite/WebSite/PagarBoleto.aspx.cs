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

public partial class PagarBoleto : System.Web.UI.Page
{
    Usuario usuarioCobrar;
    Boleto boletoCobrar;
    float totalFactura;
    GestorPermisos gp = new GestorPermisos();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["usuario"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        usuarioCobrar = gestorUsuario.BuscarClientePorDNI(Session["dni"].ToString());
        boletoCobrar = null;
        if (!IsPostBack)
        {
            Mostrar();
        }
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

    public void Mostrar()
    {
        BoletoBLL gestorBoleto = new BoletoBLL();
        var boletosPorPagarGeneral = gestorBoleto.ObtenerBoletosPorPagarCliente(usuarioCobrar);
        var boletosPorPagarIDA = boletosPorPagarGeneral.Where(x => x is BoletoIDA).Select(x => new
        {
            NumeroBoleto = x.IDBoleto,
            Origen = x.Origen,
            Destino = x.Destino,
            FechaPartidaIDA = x.FechaPartida.ToShortDateString(),
            FechaLlegadaIDA = x.FechaLlegada.ToShortDateString(),
            FechaPartidaVUELTA = "",
            FechaLlegadaVUELTA = "",
            PesoEquipaje = x.EquipajePermitido,
            ClaseBoleto = x.ClaseBoleto,
            Precio = x.Precio,
            NumeroAsiento = x.NumeroAsiento,
            BeneficioAplicado = x.BeneficioAplicado
        }).ToList();
        var boletosPorPagarIDAVUELTA = boletosPorPagarGeneral.Where(x => x is BoletoIDAVUELTA).Select(x => new
        {
            NumeroBoleto = x.IDBoleto,
            Origen = x.Origen,
            Destino = x.Destino,
            FechaPartidaIDA = x.FechaPartida.ToShortDateString(),
            FechaLlegadaIDA = x.FechaLlegada.ToShortDateString(),
            FechaPartidaVUELTA = (x as BoletoIDAVUELTA).FechaPartidaVUELTA.ToShortDateString(),
            FechaLlegadaVUELTA = (x as BoletoIDAVUELTA).FechaLlegadaVUELTA.ToShortDateString(),
            PesoEquipaje = x.EquipajePermitido,
            ClaseBoleto = x.ClaseBoleto,
            Precio = x.Precio,
            NumeroAsiento = x.NumeroAsiento,
            BeneficioAplicado = x.BeneficioAplicado
        }).ToList();

        var listaUnificada = boletosPorPagarIDAVUELTA.Concat(boletosPorPagarIDA).ToList();
        gvBoletosPorPagar.DataSource = listaUnificada;
        gvBoletosPorPagar.DataBind();
    }
    protected void gvBoletosPorPagar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Pagar")
        {
            string numeroBoleto = e.CommandArgument.ToString();

            UsuarioBLL gestorCliente = new UsuarioBLL();
            GestorPagos gestorPagos = new GestorPagos();
            GestorFactura gestorFactura490WC = new GestorFactura();
            BoletoBLL gestorBoleto490WC = new BoletoBLL();
            boletoCobrar = gestorBoleto490WC.ObtenerBoletoPorID(numeroBoleto);
            string datosTarjeta490WC = "";
            if (boletoCobrar != null)
            {
                if (rbCredito.Checked)
                {
                    datosTarjeta490WC = $"{rbCredito.Text},{txtNumeroTarjeta.Text},{txtNombreTitular.Text},{txtApellidoTitular.Text},{txtFechaEmision.Text},{txtFechaVencimiento.Text},{txtCodigoSeguridad.Text}";
                }
                else
                {
                    datosTarjeta490WC = $"{rbDebito.Text},{txtNumeroTarjeta.Text},{txtNombreTitular.Text},{txtApellidoTitular.Text},{txtFechaEmision.Text},{txtFechaVencimiento.Text},{txtCodigoSeguridad.Text}";
                }
                if (gestorCliente.VerificarFormatoNumeroTarjeta(txtNumeroTarjeta.Text))
                {
                    if (!string.IsNullOrEmpty(txtNombreTitular.Text))
                    {
                        if (!string.IsNullOrEmpty(txtApellidoTitular.Text))
                        {
                            if (gestorCliente.VerificarFormatoFechaTarjeta(txtFechaEmision.Text))
                            {
                                if (gestorCliente.VerificarFormatoFechaVencimientoTarjeta(txtFechaVencimiento.Text) && gestorCliente.VerificarRangoFechasTarjeta(txtFechaEmision.Text, txtFechaVencimiento.Text))
                                {
                                    if (gestorCliente.VerificarFormatoCVVTarjeta(txtCodigoSeguridad.Text))
                                    {
                                        Encryptador encryptador = new Encryptador();
                                        datosTarjeta490WC = encryptador.EncryptadorReversible(datosTarjeta490WC);
                                        totalFactura = boletoCobrar.Precio;
                                        if (gestorPagos.ValidarPago(datosTarjeta490WC, totalFactura))
                                        {
                                            if (boletoCobrar.BeneficioAplicado != null)
                                            {

                                                Factura facturaAlta490WC = new Factura(gestorFactura490WC.ObtenerTodasLasFacturas().Count + 1, usuarioCobrar.Nombre, usuarioCobrar.Apellido, usuarioCobrar.DNI, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), boletoCobrar.IDBoleto, boletoCobrar.Precio, totalFactura, boletoCobrar.BeneficioAplicado);

                                                gestorFactura490WC.Alta(facturaAlta490WC);
                                                gestorBoleto490WC.CobrarBoleto(boletoCobrar);
                                                gestorFactura490WC.GenerarFactura(facturaAlta490WC);

                                                gestorBoleto490WC.GenerarBoleto490WC(boletoCobrar);
                                                BitacoraBLL gestorBitacora = new BitacoraBLL();
                                                Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Pago de Boleto", "Pagar Boleto", 2);
                                                gestorBitacora.Alta(eventoGenerado);
                                            }
                                            else
                                            {
                                                Factura facturaAlta490WC = new Factura(gestorFactura490WC.ObtenerTodasLasFacturas().Count + 1, usuarioCobrar.Nombre, usuarioCobrar.Apellido, usuarioCobrar.DNI, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), boletoCobrar.IDBoleto, boletoCobrar.Precio, totalFactura, boletoCobrar.BeneficioAplicado);

                                                gestorFactura490WC.Alta(facturaAlta490WC);
                                                gestorBoleto490WC.CobrarBoleto(boletoCobrar);
                                                gestorFactura490WC.GenerarFactura(facturaAlta490WC);

                                                gestorBoleto490WC.GenerarBoleto490WC(boletoCobrar);
                                                BitacoraBLL gestorBitacora = new BitacoraBLL();
                                                Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Pago de Boleto", "Pagar Boleto", 2);
                                                gestorBitacora.Alta(eventoGenerado);

                                            }
                                        }
                                        else
                                        {
                                            string mensajeError = "Error: Pago Rechazado!!";
                                            string script = $"alert('{mensajeError}');";
                                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                                        }
                                        
                                        Mostrar();
                                    }
                                    else
                                    {
                                        string mensajeError = "Error: Codigo De Seguridad Invalido!!";
                                        string script = $"alert('{mensajeError}');";
                                        ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                                    }
                                }
                                else
                                {
                                    string mensajeError = "Error: Fechas Tarjeta Inconsistentes!!";
                                    string script = $"alert('{mensajeError}');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                                }
                            }
                            else
                            {
                                string mensajeError = "Error: Fechas Tarjeta Inconsistentes!!";
                                string script = $"alert('{mensajeError}');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                            }
                        }
                        else
                        {
                            string mensajeError = "Error: Debe Ingresar Un Apellido Del Titular De La Tarjeta!!";
                            string script = $"alert('{mensajeError}');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                        }
                    }
                    else
                    {
                        string mensajeError = "Error: Debe Ingresar Un Nombre Del Titular De La Tarjeta!!";
                        string script = $"alert('{mensajeError}');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                    }
                }
                else
                {
                    string mensajeError = "Error: Numero De Tarjeta Ingresadp Invalido!!";
                    string script = $"alert('{mensajeError}');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "mostrarError", script, true);
                }
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
                   
                    else if (ctrl is RadioButton rb)
                    {
                        rb.Text = traduccion;
                    }

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

