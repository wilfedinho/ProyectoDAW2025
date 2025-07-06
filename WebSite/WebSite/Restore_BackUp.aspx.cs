using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SERVICIOS;

public partial class Restore_BackUp : System.Web.UI.Page
{
    BackUp b = new BackUp();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBackup_Click(object sender, EventArgs e)
    {
        if(b.GenerarBackUp()) { Label1.Text = "BackUp generado exitosamente!!!"; Label1.ForeColor = System.Drawing.Color.Green; }
        else { Label1.Text = "Hubo un problema para realizar el BackUp"; Label1.ForeColor = System.Drawing.Color.Red; }
    }
}