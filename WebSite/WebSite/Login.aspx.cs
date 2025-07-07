using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using BLL.Tecnica;
using SERVICIOS;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Visible = false;
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        lblError.Visible = false;
        if (Session["usuario"] != null && Session["rol"].ToString() == "Admin")
        {
            Response.Redirect("MenuAdministrador.aspx");
        }
        if(Session["usuario"] != null && Session["rol"].ToString() == "Usuario")
        {
            Response.Redirect("Vuelos.aspx");
        }
        if(Session["usuario"] != null && Session["rol"].ToString() == "WebMaster")
        {
            Response.Redirect("MenuWebMaster.aspx");
        }
    }

  
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registro.aspx");
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["usuario"] == null)
            {
                UsuarioBLL gestorUsuario = new UsuarioBLL();
                Usuario usuarioLoguear = gestorUsuario.BuscarUsuarioPorUsername(txtUsername.Text);
                if (usuarioLoguear != null)
                {
                    if (gestorUsuario.VerificarCredenciales(txtUsername.Text, txtPassword.Text))
                    {
                        DigitoVerificador digitoVerificador = new DigitoVerificador();
                        AlmacenarSesion(usuarioLoguear);
                        if (!digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Usuario")
                        {
                            Response.Redirect("ErrorBDUsuario.aspx");
                            BitacoraBLL gestorBitacora = new BitacoraBLL();
                            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Now.Date, DateTime.Now.TimeOfDay, "Login", "Ingreso al Sistema", 4);
                            gestorBitacora.Alta(eventoGenerado);
                        }
                        if(digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Usuario")
                        {
                            Response.Redirect("Vuelos.aspx");
                            BitacoraBLL gestorBitacora = new BitacoraBLL();
                            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Now.Date, DateTime.Now.TimeOfDay, "Login", "Ingreso al Sistema", 4);
                            gestorBitacora.Alta(eventoGenerado);
                        }
                        if(!digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Admin")
                        {
                            Response.Redirect("ErrorBDAdmin.aspx");
                            BitacoraBLL gestorBitacora = new BitacoraBLL();
                            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Now.Date, DateTime.Now.TimeOfDay, "Login", "Ingreso al Sistema", 4);
                            gestorBitacora.Alta(eventoGenerado);
                        }
                        if(digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Admin")
                        {
                            Response.Redirect("MenuAdministrador.aspx");
                            BitacoraBLL gestorBitacora = new BitacoraBLL();
                            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Now.Date, DateTime.Now.TimeOfDay, "Login", "Ingreso al Sistema", 4);
                            gestorBitacora.Alta(eventoGenerado);
                        }
                        if(!digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "WebMaster")
                        {
                            Response.Redirect("Restore_BackUp.aspx");
                            BitacoraBLL gestorBitacora = new BitacoraBLL();
                            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Now.Date, DateTime.Now.TimeOfDay, "Login", "Ingreso al Sistema", 4);
                            gestorBitacora.Alta(eventoGenerado);
                        }
                        if(digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "WebMaster")
                        {
                            Response.Redirect("MenuWebMaster.aspx");
                            BitacoraBLL gestorBitacora = new BitacoraBLL();
                            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Now.Date, DateTime.Now.TimeOfDay, "Login", "Ingreso al Sistema", 4);
                            gestorBitacora.Alta(eventoGenerado);
                        }
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        lblError.Text = "Credenciales Ingresadas Incorrectas!!!";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Text = "El usuario ingresado no existe!!!";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Ya existe una sesion iniciada!!!";
                lblError.Visible = true;
            }
        }
         catch { }
    }
    public void AlmacenarSesion(Usuario usuarioSesion)
    {
        Session["usuario"] = $"{usuarioSesion.Username}";
        Session["rol"] = $"{usuarioSesion.Rol}";
    }

    protected void btnClaveOlvidada_Click(object sender, EventArgs e)
    {
        Response.Redirect("OlvidoClave.aspx");
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
    }
}