using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.UserControls.Altas;

namespace KiiniHelp.TestUsControl
{
    public partial class FrmTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
                //UcOrganizacion.IdTipoUsuario = 1;
        }

        protected void btnModalOrganizacion_OnClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "MostrarPopup(\"#modalTest\");", true);
        }
    }
}