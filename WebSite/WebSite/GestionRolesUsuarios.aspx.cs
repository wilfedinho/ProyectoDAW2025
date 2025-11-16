using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL.Tecnica;
using SERVICIOS;

public partial class GestionRolesUsuarios : System.Web.UI.Page
{
    GestorPermisos gp = new GestorPermisos();
    List<string> lista;
    UsuarioBLL lu = new UsuarioBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarRoles();
            MostrarPermisos();
            ddlRoles.Items.Insert(0, new ListItem("-- Seleccione un rol --", ""));
            ddlRoles.SelectedIndex = 0;
        }
        lista = new List<string>();
    }

    private void CargarRoles()
    {
        ddlRoles.Items.Clear();
        var roles = gp.ObtenerPermisos("Compuestos");
        foreach (var rol in roles)
        {
            ddlRoles.Items.Add(rol.DevolverNombrePermiso());
        }
    }

    protected void btnVer_Click(object sender, EventArgs e)
    {
        EntidadPermisoCompuesto permiso = gp.DevolverPermisoConHijos(ddlRoles.SelectedItem.Text) as EntidadPermisoCompuesto;
        MostrarDetallesRol(permiso);
    }

    private void MostrarDetallesRol(EntidadPermisoCompuesto rol)
    {
        try
        {
            tvDetalles.Nodes.Clear();
            TreeNode root = new TreeNode(rol.DevolverNombrePermiso());
            tvDetalles.Nodes.Add(root);
            foreach (var permiso in rol.listaPermisos)
            {
                root.ChildNodes.Add(CrearNodoPermiso(permiso));
            }
            tvDetalles.ExpandAll();
        }
        catch 
        {
            return;
        }
    }


    private TreeNode CrearNodoPermiso(EntidadPermiso permiso)
    {
        TreeNode nodo = new TreeNode(permiso.DevolverNombrePermiso());
        if (permiso is EntidadPermisoCompuesto compuesto)
        {
            foreach (var hijo in compuesto.listaPermisos)
            {
                nodo.ChildNodes.Add(CrearNodoPermiso(hijo));
            }
        }
        return nodo;
    }


    protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        LimpiarSeleccionPermisos();
        if (ddlRoles.SelectedItem != null)
        {
            List<EntidadPermiso> permisoRaiz = gp.ObtenerPermisosArbol();
            EntidadPermiso permisoSeleccionado = permisoRaiz.Find(x => x.DevolverNombrePermiso() == ddlRoles.SelectedItem.ToString());
            if (permisoSeleccionado is EntidadPermisoCompuesto pPermisoCompuesto)
            {
                CheckearPermisosenLista(pPermisoCompuesto);
            }
            if (ddlRoles.SelectedIndex != -1)
            {
                panelEdicion.Visible = true;
                TextBox1.Text = ddlRoles.SelectedItem.Text;
                lblError.Visible = false;
            }
        }
    }

    private void MostrarPermisos()
    {
        chkPermisos.Items.Clear();

        var permisos = gp.ObtenerPermisos("Todos excepto roles");

        foreach (var permiso in permisos)
        {
            chkPermisos.Items.Add(
                new ListItem(
                    permiso.DevolverNombrePermiso(),  
                    permiso.DevolverNombrePermiso() 
                )
            );
        }
    }

    private void LimpiarSeleccionPermisos()
    {
        for (int i = 0; i < chkPermisos.Items.Count; i++)
        {
            chkPermisos.Items[i].Selected = false;
        }
        lista.Clear();
    }

    private void CheckearPermisosenLista(EntidadPermisoCompuesto permisoRaiz)
    {
        if (permisoRaiz.DevolverNombrePermiso() != "Web Master")
        {
            foreach (EntidadPermiso p in permisoRaiz.DevolverListaPermisos())
            {
                int index = chkPermisos.Items.Cast<object>()
                .ToList()
                .FindIndex(item => item.ToString() == p.DevolverNombrePermiso());
                if (index != -1)
                {
                    chkPermisos.Items[index].Selected = true;
                    lista.Add(p.DevolverNombrePermiso());
                }
            }
        }
        else
        {
            for (int i = 0; i < chkPermisos.Items.Count; i++)
            {
                chkPermisos.Items[i].Selected = true;
            }
        }
    }

    protected void btnCambiarPermisos_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. Listas temporales
            List<string> permisosCheckeados = new List<string>();
            List<string> permisosCheckeadosNivel1 = new List<string>();
            // 2. Recorrer CheckBoxList (equivalente a CheckedItems)
            foreach (ListItem item in chkPermisos.Items)
            {
                if (item.Selected)
                {
                    permisosCheckeados.Add(item.Text);
                    permisosCheckeadosNivel1.Add(item.Text);

                    EntidadPermiso permiso = gp.ObtenerPermisosArbol().Find(x => x.DevolverNombrePermiso() == item.Text);

                    if (permiso != null && permiso.isComposite())
                    {
                        AgregarHijosRecursivosWeb((EntidadPermisoCompuesto)permiso, permisosCheckeados);
                    }
                }
            }
            // 3. Permisos eliminados (diferencia)
            var diferencia = permisosCheckeadosNivel1.Where(u => !lista.Any(x => x == u)).ToList();
            // 4. Actualizar permisos en la base
            gp.ActualizarPermisos(ddlRoles.SelectedItem.Text, permisosCheckeadosNivel1, diferencia);
            // 5. Actualizar lista local
            foreach (ListItem item in chkPermisos.Items)
            {
                if (item.Selected)
                {
                    if (!lista.Any(x => x == item.Text))
                        lista.Add(item.Text);
                }
                else
                {
                    if (lista.Any(x => x == item.Text))
                        lista.Remove(item.Text);
                }
            }
            // 6. Recargar página limpia (profesional)
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }

    protected void btnAceptarNuevoNombre_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoles.SelectedIndex == -1)
                throw new Exception("Debe seleccionar un permiso o rol.");

            string nuevoNombre = txtNuevoNombreServidor.Text;
            string nombreActual = ddlRoles.SelectedItem.Text;

            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new Exception("Debe ingresar un nombre para el nuevo permiso.");

            EntidadPermiso permiso = gp.ObtenerPermisos("Roles")
                                       .Find(x => x.DevolverNombrePermiso() == nombreActual);

            string aux = permiso == null ? "permiso" : "rol";

            if (gp.ExistePermiso(nuevoNombre))
                throw new Exception("El permiso o rol ya existe.");

            // MODIFICAR PERMISO/ROL
            gp.ModificarNombrePermiso(nombreActual, nuevoNombre);

            // REFRESCAR
            ddlRoles.Items.Clear();
            CargarRoles();

            // MENSAJE
            ScriptManager.RegisterStartupScript(this, GetType(), "ok",
                "alert('El nombre se modificó con éxito.');", true);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "error",
                $"alert('{ex.Message}');", true);
        }
    }
    


    private void AgregarHijosRecursivosWeb(EntidadPermisoCompuesto permiso, List<string> lista)
    {
        foreach (EntidadPermiso hijo in permiso.listaPermisos)
        {
            lista.Add(hijo.DevolverNombrePermiso());

            if (hijo.isComposite())
                AgregarHijosRecursivosWeb((EntidadPermisoCompuesto)hijo, lista);
        }
    }


    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoles.SelectedIndex == -1 || ddlRoles.SelectedItem.Text == "-- Seleccione un rol --")
                throw new Exception("Debe seleccionar un permiso o rol.");
            string nombreActual = ddlRoles.SelectedItem.Text;
            string nuevoNombre = TextBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new Exception("Debe ingresar un nombre válido.");
            if (gp.ExistePermiso(nuevoNombre))
                throw new Exception("Ya existe un permiso o rol con ese nombre.");
            gp.ModificarNombrePermiso(nombreActual, nuevoNombre);
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }



    protected void btnCrearRol_Click(object sender, EventArgs e)
    {
        panelCrearCompuesto.Visible = true;
        txtNombreCompuesto.Text = "";
        lblErrorCompuesto.Visible = false;
    }

    protected void btnConfirmarCompuesto_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. Validar que haya permisos seleccionados
            if (!chkPermisos.Items.Cast<ListItem>().Any(i => i.Selected))
                throw new Exception("Debe seleccionar al menos un permiso de la lista.");
            // 2. Validar nombre ingresado
            string nombrePermiso = txtNombreCompuesto.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombrePermiso))
                throw new Exception("Debe ingresar un nombre para el permiso.");
            // 3. Crear el permiso compuesto
            CrearPermisoCompuesto(nombrePermiso, true);
            // 4. Recargar la página
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            lblErrorCompuesto.Text = ex.Message;
            lblErrorCompuesto.Visible = true;
        }
    }

    public void CrearPermisoCompuesto(string pNombrePermiso, bool isRol)
    {
        List<string> items = GenerarLista();
        string error = $"Ocurrió un error";
        if (!gp.AgregarPermisoCompuesto(pNombrePermiso, items, isRol))
        {
            lblErrorCompuesto.Text = error;
            lblErrorCompuesto.Visible = true;
            return;
        }
    }
    public List<string> GenerarLista()
    {
        List<string> items = new List<string>();
        foreach (ListItem item in chkPermisos.Items)
        {
            if (item.Selected)
                items.Add(item.Text);
        }
        return items;
    }

    protected void btnCrearGrupo_Click(object sender, EventArgs e)
    {
        panelCrearCompuesto.Visible = true;
        txtNombreCompuesto.Text = "";
        lblErrorCompuesto.Visible = false;
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoles.SelectedIndex == -1 || ddlRoles.SelectedItem.Text == "-- Seleccione un rol --")
                throw new Exception("Debe seleccionar un permiso o rol.");
            string nombre = ddlRoles.SelectedItem.Text;
            EntidadPermiso permiso = gp.ObtenerPermisos("Roles").Find(x => x.DevolverNombrePermiso() == nombre);
            string aux = (permiso == null) ? "permiso" : "rol";
            if (lu.RolIsInUso(nombre))
            {

                throw new Exception("Este rol se encuentra en uso y no puede eliminarse.");
            }
            if (gp.EliminarPermiso(nombre))
            {
                lblInfo.Text = "Se ha eliminado el permiso con éxito.";
                lblInfo.Visible = true;
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }
}