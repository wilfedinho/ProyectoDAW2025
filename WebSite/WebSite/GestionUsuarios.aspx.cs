using BE;
using BLL.Tecnica;
using SERVICIOS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class GestionUsuarios : System.Web.UI.Page
{
    GestorPermisos gp = new GestorPermisos();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        if (Session["usuario"] != null && Session["rol"].ToString() == "Admin")
        {
            CargarUsuarios();

        }
        else
        {
            Response.Redirect("Vuelos.aspx");
        }
        if (Session["idioma"] == null)
        {
            Session["idioma"] = "ES";
            Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        }
        string idioma = Session["idioma"].ToString();

        if (idioma == "ES")
        {
            btnES.CssClass = "nav-link idioma-btn activo";
            btnEN.CssClass = "nav-link idioma-btn";
        }
        else
        {
            btnEN.CssClass = "nav-link idioma-btn activo";
            btnES.CssClass = "nav-link idioma-btn";
        }
        if (!IsPostBack)
        {
            gp.ActualizarGeneral();
        }

        TraducirPagina(this, Traductor.INSTANCIA(idioma));


    }
    public void CargarUsuarios()
    {
        UsuarioBLL gestorUsuario = new UsuarioBLL();
        var listaUsuarios = gestorUsuario.DevolverTodosLosUsuarios();
        var listaAdaptada = listaUsuarios.Select(e => new
        {
            Usuario = e.Username,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            DNI = e.DNI,
            Email = e.Email,
            Rol = e.Rol,
            Estrellas = e.EstrellasCliente
        }).ToList();
        gvUsuarios.DataSource = listaAdaptada;
        gvUsuarios.DataBind();
        BitacoraBLL gestorBitacora = new BitacoraBLL();
        Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Usuarios", "Consulta Usuarios", 1);
        gestorBitacora.Alta(eventoGenerado);
    }
    private void LimpiarCampos()
    {
        txtUsuario.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtDNI.Text = "";
        txtEmail.Text = "";
        ddlRol.SelectedIndex = 0;
        txtEstrellas.Text = "";
        gvUsuarios.SelectedIndex = -1;
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        lblMensaje.Visible = false;
        try
        {
            UsuarioBLL gestorUsuario = new UsuarioBLL();
            Encryptador cifrador = new Encryptador();
            string nombre490WC = txtNombre.Text;
            string apellido490WC = txtApellido.Text;
            string dni490WC = txtDNI.Text;
            string username490WC = txtUsuario.Text;
            string contraseña490WC = cifrador.EncryptadorIrreversible(dni490WC + apellido490WC);
            string email490WC = txtEmail.Text;
            string rol490WC = ddlRol.SelectedValue;


            if (!gestorUsuario.VerificarDNI(dni490WC))
            {
                lblMensaje.Text = "El DNI ingresado no es válido.";
                lblMensaje.Visible = true;
                return;
            }
            if (gestorUsuario.VerificarDNIDuplicado(dni490WC))
            {
                lblMensaje.Text = "El DNI ya está registrado.";
                lblMensaje.Visible = true;
                return;
            }
            if (!gestorUsuario.VerificarEmail(email490WC))
            {
                lblMensaje.Text = "El email ingresado no es válido.";
                lblMensaje.Visible = true;
                return;
            }
            if (gestorUsuario.VerificarEmailDuplicado(email490WC))
            {
                lblMensaje.Text = "El email ya está registrado.";
                lblMensaje.Visible = true;
                return;
            }
            if (gestorUsuario.VerificarUsernameDuplicado(username490WC))
            {
                lblMensaje.Text = "El nombre de usuario ya está registrado.";
                lblMensaje.Visible = true;
                return;
            }


            Usuario usuario490WC = new Usuario(username490WC, nombre490WC, apellido490WC, dni490WC, contraseña490WC, email490WC, rol490WC);
            gestorUsuario.Alta(usuario490WC);
            CargarUsuarios();
            lblMensaje.Text = "Usuario agregado correctamente.";
            lblMensaje.CssClass = "mensaje-exito";
            lblMensaje.Visible = true;
            LimpiarCampos();
            BitacoraBLL gestorBitacora = new BitacoraBLL();
            Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Usuarios", "Agregacion Usuarios", 2);
            gestorBitacora.Alta(eventoGenerado);
        }
        catch
        {
            lblMensaje.Text = "Ocurrió un error inesperado al agregar el usuario.";
            lblMensaje.Visible = true;
            LimpiarCampos();
        }
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        lblMensaje.Visible = false;
        if (gvUsuarios.SelectedDataKey != null)
        {
            try
            {
                UsuarioBLL gestorUsuario = new UsuarioBLL();
                Encryptador cifrador = new Encryptador();
                string username490WC = gvUsuarios.SelectedDataKey["Usuario"].ToString();
                string nombre490WC = txtNombre.Text;
                string apellido490WC = txtApellido.Text;
                string dni490WC = txtDNI.Text;
                string email490WC = txtEmail.Text;
                string rol490WC = ddlRol.SelectedValue;
                int estrellasCliente = int.Parse(txtEstrellas.Text);
                Usuario usuarioModificar = gestorUsuario.BuscarUsuarioPorUsername(username490WC);


                if (!gestorUsuario.VerificarEmail(email490WC))
                {
                    lblMensaje.Text = "El email ingresado no es válido.";
                    lblMensaje.Visible = true;
                    return;
                }
                if (gestorUsuario.VerificarEmailDuplicadoModificar(usuarioModificar.Email, email490WC))
                {
                    lblMensaje.Text = "El email ya está registrado.";
                    lblMensaje.Visible = true;
                    return;
                }



                usuarioModificar.Nombre = nombre490WC;
                usuarioModificar.Apellido = apellido490WC;

                usuarioModificar.Email = email490WC;
                usuarioModificar.Rol = rol490WC;
                usuarioModificar.EstrellasCliente = estrellasCliente;

                gestorUsuario.Modificar(usuarioModificar);

                CargarUsuarios();

                lblMensaje.Text = "Usuario modificado correctamente.";
                lblMensaje.CssClass = "mensaje-exito";
                lblMensaje.Visible = true;

                LimpiarCampos();
                BitacoraBLL gestorBitacora = new BitacoraBLL();
                Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Usuarios", "Modificacion Usuarios", 3);
                gestorBitacora.Alta(eventoGenerado);
            }
            catch
            {
                lblMensaje.Text = "Ocurrió un error al modificar el usuario.";
                lblMensaje.CssClass = "validador-error";
                lblMensaje.Visible = true;
            }
        }
        else
        {
            lblMensaje.Text = "Debe seleccionar un usuario para modificar.";
            lblMensaje.CssClass = "validador-error";
            lblMensaje.Visible = true;
            LimpiarCampos();
        }
    }
    protected void btnBorrar_Click(object sender, EventArgs e)
    {
        if (gvUsuarios.SelectedDataKey != null)
        {
            string username = gvUsuarios.SelectedDataKey["Usuario"].ToString();
            try
            {
                UsuarioBLL gestorUsuario = new UsuarioBLL();
                Usuario usuarioEliminar = gestorUsuario.BuscarUsuarioPorUsername(username);
                gestorUsuario.Baja(usuarioEliminar.Username);
                CargarUsuarios();
                lblMensaje.Text = "Usuario eliminado correctamente.";
                lblMensaje.CssClass = "mensaje-exito";
                lblMensaje.Visible = true;
                LimpiarCampos();
                BitacoraBLL gestorBitacora = new BitacoraBLL();
                Bitacora eventoGenerado = new Bitacora(Session["usuario"].ToString(), DateTime.Parse(DateTime.Now.Date.ToString(@"yyyy-MM-dd")), TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString(@"hh\:mm\:ss")), "Gestion Usuarios", "Eliminacion Usuarios", 4);
                gestorBitacora.Alta(eventoGenerado);
            }
            catch
            {
                lblMensaje.Text = "Ocurrió un error al eliminar el usuario.";
                lblMensaje.CssClass = "validador-error";
                lblMensaje.Visible = true;
                LimpiarCampos();
            }
        }
        else
        {
            lblMensaje.Text = "Debe seleccionar un usuario para eliminar.";
            lblMensaje.CssClass = "validador-error";
            lblMensaje.Visible = true;
            LimpiarCampos();
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
    }
    protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gvUsuarios.SelectedRow;

        txtUsuario.Text = Server.HtmlDecode(row.Cells[1].Text);
        txtNombre.Text = Server.HtmlDecode(row.Cells[2].Text);
        txtApellido.Text = Server.HtmlDecode(row.Cells[3].Text);
        txtDNI.Text = Server.HtmlDecode(row.Cells[4].Text);
        txtEmail.Text = Server.HtmlDecode(row.Cells[5].Text);
        ddlRol.SelectedValue = Server.HtmlDecode(row.Cells[6].Text);
        txtEstrellas.Text = Server.HtmlDecode(row.Cells[7].Text);
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
        Response.Redirect("GestionBeneficios.aspx");
    }

    protected void btnBoletos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionBoletos.aspx");
    }

    protected void btnClave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CambiarClave.aspx");
    }

    protected void btnVuelos_Click(object sender, EventArgs e)
    {
        Response.Redirect("Vuelos.aspx");
    }
    protected void btnCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Login.aspx");
    }
    protected void btnPermisos_Click(object sender, EventArgs e)
    {
        Response.Redirect("GestionRolesUsuarios.aspx");
    }

    protected void btnES_Click(object sender, EventArgs e)
    {
        Session["idioma"] = "ES";
        Traductor.INSTANCIA("ES").ActualizarIdioma("ES");
        Response.Redirect(Request.RawUrl);
    }

    protected void btnEN_Click(object sender, EventArgs e)
    {
        Session["idioma"] = "EN";
        Traductor.INSTANCIA("EN").ActualizarIdioma("EN");
        Response.Redirect(Request.RawUrl);
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