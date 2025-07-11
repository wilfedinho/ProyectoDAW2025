﻿using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        try
        {
            Encryptador cifrador = new Encryptador();
            UsuarioBLL usuarioBLL = new UsuarioBLL();
            if(!usuarioBLL.VerificarDNI(txtDNI.Text)) throw new Exception("DNI No válido");
            if(!usuarioBLL.VerificarEmail(txtEmail.Text)) throw new Exception("Email no válido");
            if(usuarioBLL.VerificarDNIDuplicado(txtDNI.Text)) throw new Exception("DNI duplicado");
            if(usuarioBLL.VerificarEmailDuplicado(txtEmail.Text)) throw new Exception("Email duplicado");
            if(usuarioBLL.VerificarUsernameDuplicado(txtUsuario.Text)) throw new Exception("Usuario duplicado");
            Usuario usuario = new Usuario(txtUsuario.Text, txtNombre.Text, txtApellido.Text, txtDNI.Text, txtPassword.Text, txtEmail.Text, "Usuario");
            usuario.Contraseña = cifrador.EncryptadorIrreversible(usuario.Contraseña);
            BitacoraBLL gestorBitacora = new BitacoraBLL();
            Bitacora eventoGenerado = new Bitacora(usuario.Username, DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Registro", "Se registro con exito", 2);
            gestorBitacora.Alta(eventoGenerado);
            usuarioBLL.Alta(usuario);
            Response.Redirect("Login.aspx");
        }
        catch (Exception ex){ lblError.Text = $"{ex.Message}"; }
    }
}