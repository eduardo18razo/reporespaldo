using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceCatalogosUsuario;
using KiiniNet.Entities.Cat.Usuario;
using KinniNet.Business.Utils;

namespace KiiniHelp.UserControls.Altas
{
    public partial class UcAltaGrupos : UserControl
    {

        readonly ServiceCatalogosUsuarioClient _serviceCatalogosUsuario = new ServiceCatalogosUsuarioClient();
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        private List<string> _lstError = new List<string>();
        private List<string> AlertaGrupoUsuario
        {
            set
            {
                panelAlertaGrupoUsuario.Visible = value.Any();
                if (!panelAlertaGrupoUsuario.Visible) return;
                rptErrorGrupoUsuario.DataSource = value;
                rptErrorGrupoUsuario.DataBind();
            }
        }

        public int IdTipoGrugo
        {
            get { return Convert.ToInt32(dfIdGrupo.Value); }
            set
            {
                int index = ddlTipoGrupo.Items.Cast<ListItem>().TakeWhile(tipoGpo => int.Parse(tipoGpo.Value) != value).Count();
                ddlTipoGrupo.SelectedIndex = index;
                if(index!= 0)
                    ddlTipoGrupo_OnSelectedIndexChanged(ddlTipoGrupo, null);
                dfIdGrupo.Value = value.ToString();
            }
        }

        private void ValidaCapturaGrupoUsuario()
        {
            StringBuilder sb = new StringBuilder();

            if (ddlTipoGrupo.SelectedValue == BusinessVariables.ComboBoxCatalogo.Value.ToString())
                sb.AppendLine("Debe seleccionar un Tipo Grupo.<br>");

            if (txtDescripcionGrupoUsuario.Text.Trim() == string.Empty)
                sb.AppendLine("Descripcion es un campo obligatorio.<br>");

            if (sb.ToString() != string.Empty)
                throw new Exception(sb.ToString());
        }

        private void LimpiarCampos()
        {
            try
            {
                ddlTipoGrupo.SelectedIndex = BusinessVariables.ComboBoxCatalogo.Index;
                txtDescripcionGrupoUsuario.Text = String.Empty;
                chkLbxSubGrupoUsuario.Items.Clear();
                divTipoSubgrupo.Visible = false;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Metodos.LlenaComboCatalogo(ddlTipoGrupo, _serviceCatalogosSistema.ObtenerTiposGrupo(true));
            }
        }

        protected void btnGuardarGrupoUsuario_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaGrupoUsuario();
                GrupoUsuario grupoUsuario = new GrupoUsuario
                {
                    IdTipoGrupo = Convert.ToInt32(ddlTipoGrupo.SelectedValue),
                    Descripcion = txtDescripcionGrupoUsuario.Text,
                    Habilitado = chkGrupoUsuario.Checked,
                    SubGrupoUsuario = new List<SubGrupoUsuario>()
                };
                foreach (ListItem item in chkLbxSubGrupoUsuario.Items.Cast<ListItem>().Where(item => item.Selected))
                {
                    grupoUsuario.SubGrupoUsuario.Add(new SubGrupoUsuario { IdTipoSubGrupo = Convert.ToInt32(item.Value) });
                }
                _serviceCatalogosUsuario.GuardarGrupoUsuario(grupoUsuario);
                LimpiarCampos();
                IdTipoGrugo = Convert.ToInt32(dfIdGrupo.Value);
                ddlTipoGrupo_OnSelectedIndexChanged(ddlTipoGrupo, null);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupoUsuario = _lstError;
            }
        }

        protected void btnLimpiarGrupoUsuario_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupoUsuario = _lstError;
            }
        }

        protected void ddlTipoGrupo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoGrupo.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                {
                    divTipoSubgrupo.Visible = !divTipoSubgrupo.Visible;
                    chkLbxSubGrupoUsuario.Items.Clear();
                    return;
                }
                Metodos.LlenaListBoxCatalogo(chkLbxSubGrupoUsuario, _serviceCatalogosUsuario.ObtenerTipoSubGrupos(Convert.ToInt32(ddlTipoGrupo.SelectedValue), false));
                divTipoSubgrupo.Visible = chkLbxSubGrupoUsuario.Items.Count > 0;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupoUsuario = _lstError;
            }
        }
    }
}