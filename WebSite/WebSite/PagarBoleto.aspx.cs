using BE;
using BLL.Negocio;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PagarBoleto : System.Web.UI.Page
{
    Usuario usuarioCobrar;
    Boleto boletoCobrar;
    float totalFactura;
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        usuarioCobrar = gestorUsuario.BuscarClientePorDNI(Session["dni"].ToString());
        boletoCobrar = null;
        if (!IsPostBack)
        {
            Mostrar();
        }
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
                                            }
                                            else
                                            {
                                                Factura facturaAlta490WC = new Factura(gestorFactura490WC.ObtenerTodasLasFacturas().Count + 1, usuarioCobrar.Nombre, usuarioCobrar.Apellido, usuarioCobrar.DNI, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), boletoCobrar.IDBoleto, boletoCobrar.Precio, totalFactura, boletoCobrar.BeneficioAplicado);

                                                gestorFactura490WC.Alta(facturaAlta490WC);
                                                gestorBoleto490WC.CobrarBoleto(boletoCobrar);
                                                gestorFactura490WC.GenerarFactura(facturaAlta490WC);

                                                gestorBoleto490WC.GenerarBoleto490WC(boletoCobrar);

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
}

