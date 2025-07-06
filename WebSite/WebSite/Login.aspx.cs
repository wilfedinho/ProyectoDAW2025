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
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        lblError.Visible = false;
        /*
        DigitoVerificador digitoVerificador = new DigitoVerificador();
        digitoVerificador.RecalcularDigitosVerificadores();*/
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
                        }
                        if(digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Usuario")
                        {
                            Response.Redirect("Vuelos.aspx");
                        }
                        if(!digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Admin")
                        {
                            Response.Redirect("ErrorBDAdmin.aspx");
                        }
                        if(digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "Admin")
                        {
                            //mandar al menu del admin
                        }
                        if(!digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "WebMaster")
                        {
                            Response.Redirect("Restore_BackUp.aspx");
                        }
                        if(digitoVerificador.VerificarIntegridadTodasLasTablasBool() && usuarioLoguear.Rol == "WebMaster")
                        {
                            //mandar al menu del webmaster
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


    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
    }
}