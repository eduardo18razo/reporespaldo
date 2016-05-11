using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceCatalogosUsuario;
using KiiniHelp.ServiceParametros;
using KiiniHelp.ServiceUsuarios;
using KiiniNet.Entities.Cat.Arbol.Organizacion;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones.Domicilio;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Sistema;
using KiiniNet.Entities.Cat.Usuario;
using KiiniNet.Entities.Operacion.Usuarios;
using KiiniNet.Entities.Parametros;
using KinniNet.Business.Utils;

namespace KiiniHelp.Usuarios
{
    public partial class FrmUsuarios : Page
    {
        readonly ServiceCatalogosUsuarioClient _serviceCatalogosUsuario = new ServiceCatalogosUsuarioClient();
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        readonly ServiceParametrosClient _serviceParametros = new ServiceParametrosClient();
        readonly ServiceUsuariosClient _serviceUsuarios = new ServiceUsuariosClient();
        private List<string> _lstError = new List<string>();

        #region Alerts
        private List<string> AlertaGeneral
        {
            set
            {
                panelAlertaGeneral.Visible = value.Any();
                if (!panelAlertaGeneral.Visible) return;
                rptErrorGeneral.DataSource = value.Select(s => new { Detalle = s }).ToList();
                rptErrorGeneral.DataBind();
            }
        }

        private List<string> AlertaDatosGenerales
        {
            set
            {
                panelAlertaModalDg.Visible = value.Any();
                if (!panelAlertaModalDg.Visible) return;
                rptErrorDg.DataSource = value;
                rptErrorDg.DataBind();
            }
        }

        private List<string> AlertaOrganizacion
        {
            set
            {
                panelAlertaOrganizacion.Visible = value.Any();
                if (!panelAlertaOrganizacion.Visible) return;
                rptErrorOrganizacion.DataSource = value;
                rptErrorOrganizacion.DataBind();
            }
        }

        private List<string> AlertaUbicacion
        {
            set
            {
                panelAlertaUbicacion.Visible = value.Any();
                if (!panelAlertaUbicacion.Visible) return;
                rptErrorUbicacion.DataSource = value;
                rptErrorUbicacion.DataBind();
            }
        }

        private List<string> AlertaRoles
        {
            set
            {
                panelAlertaRoles.Visible = value.Any();
                if (!panelAlertaRoles.Visible) return;
                rptErrorRoles.DataSource = value;
                rptErrorRoles.DataBind();
            }
        }

        private List<string> AlertaGrupos
        {
            set
            {
                panelAlertaGrupos.Visible = value.Any();
                if (!panelAlertaGrupos.Visible) return;
                rptErrorGrupos.DataSource = value;
                rptErrorGrupos.DataBind();
            }
        }

        private List<string> AlertaCampus
        {
            set
            {
                panelAlertaCampus.Visible = value.Any();
                if (!panelAlertaCampus.Visible) return;
                rptErrorCampus.DataSource = value;
                rptErrorCampus.DataBind();
            }
        }

        private List<string> AlertaCatalogos
        {
            set
            {
                panelAlertaCatalogo.Visible = value.Any();
                if (!panelAlertaCatalogo.Visible) return;
                rptErrorCatalogo.DataSource = value;
                rptErrorCatalogo.DataBind();
            }
        }

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

        #endregion Alerts

        #region Metodos
        private void LlenaCombos()
        {
            try
            {

                if (!IsPostBack)
                {
                    List<TipoUsuario> lstTipoUsuario = _serviceCatalogosSistema.ObtenerTiposUsuario(true);
                    Metodos.LlenaComboCatalogo(ddlTipoUsuario, lstTipoUsuario);
                    Metodos.LlenaComboCatalogo(ddlTipoUsuarioCampus, lstTipoUsuario);
                    Metodos.LlenaComboCatalogo(ddlTipoUsuarioCatalogo, lstTipoUsuario);
                }

            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        private void LlenaComboOrganizacion(int idTipoUsuario)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlHolding, _serviceCatalogosUsuario.ObtenerHoldings(idTipoUsuario, true));
                if (ddlHolding.Items.Count != 2) return;
                ddlHolding.SelectedIndex = 1;
                ddlHolding_OnSelectedIndexChanged(ddlHolding, null);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        private void LlenaComboUbicacion(int idTipoUsuario)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlpais, _serviceCatalogosUsuario.ObtenerPais(idTipoUsuario, true));
                if (ddlpais.Items.Count != 2) return;
                ddlpais.SelectedIndex = 1;
                ddlpais_OnSelectedIndexChanged(ddlpais, null);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private void LimpiaCampus()
        {
            try
            {
                txtDescripcionCampus.Text = string.Empty;
                txtCp.Text = string.Empty;
                txtCalle.Text = string.Empty;
                txtNoExt.Text = string.Empty;
                txtNoInt.Text = string.Empty;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        private void LimpiaCatalogo()
        {
            try
            {
                txtDescripcionCatalogo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        private void LimpiarPantalla()
        {
            try
            {
                Session["UsuarioGrupo"] = null;
                txtAp.Text = string.Empty;
                txtAm.Text = string.Empty;
                txtNombre.Text = string.Empty;
                btnModalOrganizacion.Visible = false;
                btnModalUbicacion.Visible = false;
                btnModalRoles.Visible = false;
                btnModalGrupos.Visible = false;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }

        }

        private void FiltraCombo(DropDownList ddlFiltro, DropDownList ddlLlenar, object source)
        {
            try
            {
                ddlLlenar.Items.Clear();
                if (ddlFiltro.SelectedValue != BusinessVariables.ComboBoxCatalogo.Value.ToString())
                {
                    ddlLlenar.Enabled = true;
                    Metodos.LlenaComboCatalogo(ddlLlenar, source);
                }
                else
                {
                    ddlLlenar.DataSource = null;
                    ddlLlenar.DataBind();
                }

                ddlLlenar.Enabled = ddlLlenar.DataSource != null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Validaciones

        private void ValidaCapturaDatosGenerales()
        {
            StringBuilder sb = new StringBuilder();
            if (txtAp.Text.Trim() == string.Empty)
                sb.AppendLine("Apellido Paterno es un campo obligatorio.<br>");
            if (txtAm.Text.Trim() == string.Empty)
                sb.AppendLine("Apellido Materno es un campo obligatorio.<br>");
            if (txtNombre.Text.Trim() == string.Empty)
                sb.AppendLine("Nombre es un campo obligatorio.<br>");

            List<ParametrosTelefonos> lstParamTelefonos = _serviceParametros.TelefonosObligatorios(Convert.ToInt32(ddlTipoUsuario.SelectedValue));
            List<TelefonoUsuario> telefonoUsuario = new List<TelefonoUsuario>();
            foreach (RepeaterItem item in rptTelefonos.Items)
            {
                Label tipoTelefono = (Label)item.FindControl("lblTipotelefono");
                TextBox numero = (TextBox)item.FindControl("txtNumero");
                TextBox extension = (TextBox)item.FindControl("txtExtension");
                if (tipoTelefono != null && numero != null && extension != null)
                {
                    telefonoUsuario.Add(new TelefonoUsuario { IdTipoTelefono = Convert.ToInt32(tipoTelefono.Text.Trim()), Numero = numero.Text.Trim(), Extension = extension.Text.Trim() });
                }
            }

            foreach (TelefonoUsuario telefono in telefonoUsuario)
            {
                ParametrosTelefonos parametroTipoTelefono = lstParamTelefonos.Single(s => s.IdTipoTelefono == telefono.IdTipoTelefono);
                if (telefonoUsuario.Count(c => c.IdTipoTelefono == telefono.IdTipoTelefono && c.Numero.Trim() != string.Empty) < parametroTipoTelefono.Obligatorios)
                    sb.AppendLine(String.Format("Debe capturar al menos {0} telefono(s) de {1}.<br>", parametroTipoTelefono.Obligatorios, parametroTipoTelefono.TipoTelefono.Descripcion));
            }

            List<CorreoUsuario> correos = rptCorreos.Items.Cast<RepeaterItem>().Select(item => (TextBox)item.FindControl("txtCorreo")).Where(correo => correo != null & correo.Text.Trim() != string.Empty).Select(correo => new CorreoUsuario { Correo = correo.Text.Trim() }).ToList();
            TipoUsuario paramCorreos = _serviceCatalogosSistema.ObtenerTiposUsuario(false).SingleOrDefault(s => s.Id == int.Parse(ddlTipoUsuario.SelectedValue));
            if (paramCorreos != null && (correos.Count(c => c.Correo != string.Empty) < paramCorreos.CorreosObligatorios))
                sb.AppendLine(String.Format("debe captura al menos {0} correo(s)<br>.", paramCorreos.CorreosObligatorios));

            if (sb.ToString() != string.Empty)
                throw new Exception(sb.ToString());
        }

        private void ValidaCapturaOrganizacion()
        {
            StringBuilder sb = new StringBuilder();
            if (ddlHolding.SelectedValue == BusinessVariables.ComboBoxCatalogo.Value.ToString())
                sb.AppendLine("Debe especificar al menos un Holding.<br>");

            if (sb.ToString() != string.Empty)
                throw new Exception(sb.ToString());
        }

        private void ValidaCapturaUbicacion()
        {
            StringBuilder sb = new StringBuilder();
            if (ddlpais.SelectedValue == BusinessVariables.ComboBoxCatalogo.Value.ToString())
                sb.AppendLine("Debe especificar al menos un Pais.<br>");
            if (ddlCampus.SelectedValue == BusinessVariables.ComboBoxCatalogo.Value.ToString())
                sb.AppendLine("Debe especificar al menos un Campus.<br>");

            if (sb.ToString() != string.Empty)
                throw new Exception(sb.ToString());
        }

        private void ValidaCapturaRoles()
        {
            StringBuilder sb = new StringBuilder();


            if (!chklbxRoles.Items.Cast<ListItem>().Any(item => item.Selected))
                sb.AppendLine("Debe seleccionar un Rol.<br>");

            if (sb.ToString() != string.Empty)
                throw new Exception(sb.ToString());
        }

        private void ValidaCapturaGrupos()
        {
            StringBuilder sb = new StringBuilder();


            //if (!chkLbxGrupos.Items.Cast<ListItem>().Any(item => item.Selected))
            //    sb.AppendLine("Debe seleccionar un Grupo.<br>");

            if (sb.ToString() != string.Empty)
                throw new Exception(sb.ToString());
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

        #endregion Validaciones

        #endregion Metodos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AlertaGeneral = new List<string>();
                AlertaDatosGenerales = new List<string>();
                AlertaOrganizacion = new List<string>();
                AlertaUbicacion = new List<string>();
                AlertaCampus = new List<string>();
                AlertaCatalogos = new List<string>();
                AlertaRoles = new List<string>();
                AlertaGrupos = new List<string>();
                AlertaGrupoUsuario = new List<string>();
                if (!IsPostBack)
                {
                    LlenaCombos();
                    Session["UsuarioTemporal"] = null;
                    Session["UsuarioGrupo"] = null;
                }

            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        protected void txtCp_OnTextChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlColonia, _serviceCatalogosSistema.ObtenerColoniasCp(int.Parse(txtCp.Text.Trim()), true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaCampus = _lstError;
            }
        }

        private void ValidaSeleccionCatalogo(string command)
        {
            try
            {
                switch (command)
                {
                    case "0":
                        if (ddlpais.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "3":
                        if (ddlpais.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCampus.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "4":
                        if (ddlpais.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCampus.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlTorre.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "5":
                        if (ddlpais.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCampus.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlTorre.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlPiso.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "6":
                        if (ddlpais.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCampus.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlTorre.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlPiso.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlZona.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "7":
                        if (ddlpais.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCampus.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlTorre.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlPiso.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlZona.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlSubZona.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlSiteRack.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;

                    case "9":
                        if (ddlHolding.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "10":
                        if (ddlHolding.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCompañia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "11":
                        if (ddlHolding.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCompañia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "12":
                        if (ddlHolding.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCompañia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlSubDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "13":
                        if (ddlHolding.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCompañia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlSubDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlGerencia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                    case "14":
                        if (ddlHolding.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlCompañia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlSubDireccion.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlGerencia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        if (ddlSubGerencia.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                            throw new Exception();
                        break;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editCatalogoUbicacion\");", true);
                throw new Exception("Debe de Seleccionarse un Padre para esta Operacion");
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            try
            {
                Button lbtn = (Button)sender;
                if (sender == null) return;
                if (lbtn.CommandArgument == "0")
                    ddlTipoUsuarioCampus.SelectedIndex = ddlTipoUsuario.SelectedIndex;
                else
                {
                    ValidaSeleccionCatalogo(lbtn.CommandArgument);
                    lblTitleCatalogo.Text = lbtn.CommandName;
                    hfCatalogo.Value = lbtn.CommandArgument;
                    ddlTipoUsuarioCatalogo.SelectedIndex = ddlTipoUsuario.SelectedIndex;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "MostrarPopup(\"#editCatalogoUbicacion\");", true);
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                if (int.Parse(((Button)sender).CommandArgument) >= 9)
                    AlertaOrganizacion = _lstError;
                else
                    AlertaUbicacion = _lstError;
            }
        }

        protected void ddlTipoGrupoSeleccionado_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoGrupoSeleccionado.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index) return;
                Metodos.LlenaComboCatalogo(ddlGruposUsuario, _serviceCatalogosUsuario.ObtenerGruposUsuario(Convert.ToInt32(ddlTipoGrupoSeleccionado.SelectedValue), true));
                ddlTipoGrupo.SelectedValue = ddlTipoGrupoSeleccionado.SelectedValue;
                ddlTipoGrupo_OnSelectedIndexChanged(ddlTipoGrupo, null);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupos = _lstError;
            }
        }

        protected void chkKbxRoles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chklbxRoles.Items.Cast<ListItem>().Any(item => item.Selected && int.Parse(item.Value) == (int) BusinessVariables.EnumRoles.Administrador))
                {
                    foreach (ListItem item in chklbxRoles.Items.Cast<ListItem>())
                    {
                        item.Selected = int.Parse(item.Value) == (int) BusinessVariables.EnumRoles.Administrador;
                    }
                }
                List<object> lst = new List<object>();
                foreach (ListItem item in chklbxRoles.Items.Cast<ListItem>().Where(item => item.Selected))
                {
                    lst.AddRange(_serviceCatalogosSistema.ObtenerTiposGruposByRol(Convert.ToInt32(item.Value), false));
                }
                lst.Insert(BusinessVariables.ComboBoxCatalogo.Index, new TipoGrupo { Id = BusinessVariables.ComboBoxCatalogo.Value, Descripcion = BusinessVariables.ComboBoxCatalogo.Descripcion });
                Metodos.LlenaComboCatalogo(ddlTipoGrupo, lst);
                Metodos.LlenaComboCatalogo(ddlTipoGrupoSeleccionado, lst);
                upGrupos.Update();
                btnModalGrupos.Visible = true;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        #region dropDownList

        protected void ddlTipoUsuario_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoUsuario.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                {
                    int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                    rptTelefonos.DataSource = _serviceParametros.ObtenerTelefonosParametrosIdTipoUsuario(idTipoUsuario, false);
                    rptTelefonos.DataBind();

                    rptCorreos.DataSource = _serviceParametros.ObtenerCorreosParametrosIdTipoUsuario(idTipoUsuario, false);
                    rptCorreos.DataBind();

                    LlenaComboOrganizacion(idTipoUsuario);
                    LlenaComboUbicacion(idTipoUsuario);
                    Metodos.LlenaListBoxCatalogo(chklbxRoles, _serviceCatalogosSistema.ObtenerRoles(idTipoUsuario, false));

                    Session["UsuarioTemporal"] = new Usuario();
                    divDatos.Visible = true;
                }
                else
                {
                    LimpiarPantalla();
                    divDatos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        protected void ddlpais_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlCampus, _serviceCatalogosUsuario.ObtenerCampus(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void ddlCampus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlTorre, _serviceCatalogosUsuario.ObtenerTorres(idTipoUsuario, id, true));
                FiltraCombo((DropDownList)sender, ddlPiso, null);
                FiltraCombo((DropDownList)sender, ddlZona, null);
                FiltraCombo((DropDownList)sender, ddlSubZona, null);
                FiltraCombo((DropDownList)sender, ddlSiteRack, null);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void ddlTorre_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlPiso, _serviceCatalogosUsuario.ObtenerPisos(idTipoUsuario, id, true));
                FiltraCombo((DropDownList)sender, ddlZona, null);
                FiltraCombo((DropDownList)sender, ddlSubZona, null);
                FiltraCombo((DropDownList)sender, ddlSiteRack, null);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void ddlPiso_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlZona, _serviceCatalogosUsuario.ObtenerZonas(idTipoUsuario, id, true));
                FiltraCombo((DropDownList)sender, ddlSubZona, null);
                FiltraCombo((DropDownList)sender, ddlSiteRack, null);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void ddlZona_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlSubZona, _serviceCatalogosUsuario.ObtenerSubZonas(idTipoUsuario, id, true));
                FiltraCombo((DropDownList)sender, ddlSiteRack, null);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void ddlSubZona_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlSiteRack, _serviceCatalogosUsuario.ObtenerSiteRacks(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void ddlHolding_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlCompañia, _serviceCatalogosUsuario.ObtenerCompañias(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void ddlCompañia_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlDireccion, _serviceCatalogosUsuario.ObtenerDirecciones(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void ddlDirecion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlSubDireccion, _serviceCatalogosUsuario.ObtenerSubDirecciones(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void ddlSubDireccion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlGerencia, _serviceCatalogosUsuario.ObtenerGerencias(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void ddlGerencia_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlSubGerencia, _serviceCatalogosUsuario.ObtenerSubGerencias(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void ddlSubGerencia_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int id = Convert.ToInt32(((DropDownList)sender).SelectedValue);
                FiltraCombo((DropDownList)sender, ddlJefatura, _serviceCatalogosUsuario.ObtenerJefaturas(idTipoUsuario, id, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void ddlJefatura_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #endregion dropDownList

        #region botones guardar crear

        protected void btnCrearCampus_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Metodos.ValidaCapturaCatalogoCampus(Convert.ToInt32(ddlTipoUsuarioCampus.SelectedValue), txtDescripcionCampus.Text, ddlColonia.SelectedValue == "" ? 0 : Convert.ToInt32(ddlColonia.SelectedValue), txtCalle.Text.Trim(), txtNoExt.Text.Trim(), txtNoInt.Text.Trim()))
                {
                    Ubicacion ubicacion = new Ubicacion
                    {
                        IdTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue),
                        IdPais = Convert.ToInt32(ddlpais.SelectedValue),
                        Campus = new Campus
                        {
                            IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCampus.SelectedValue),
                            Descripcion = txtDescripcionCampus.Text.Trim(),
                            Domicilio = new List<Domicilio>
                            {
                                new Domicilio
                                {
                                    IdColonia = Convert.ToInt32(ddlColonia.SelectedValue),
                                    Calle = txtCalle.Text.Trim(),
                                    NoExt = txtNoExt.Text.Trim(),
                                    NoInt = txtNoInt.Text.Trim()
                                }
                            },
                            Habilitado = chkHabilitado.Checked
                        }
                    };
                    _serviceCatalogosUsuario.GuardarUbicacion(ubicacion);
                    LimpiaCampus();
                    ddlpais_OnSelectedIndexChanged(ddlpais, null);
                    upUbicacion.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editCampus\");", true);
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaCampus = _lstError;
            }
        }

        protected void btnCancelarCampus_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiaCampus();
                ddlTipoUsuarioCatalogo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaCampus = _lstError;
            }
        }

        protected void btnGuardarCatalogo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Metodos.ValidaCapturaCatalogo(txtDescripcionCatalogo.Text))
                {
                    int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                    Ubicacion ubicacion = new Ubicacion
                    {
                        IdTipoUsuario = idTipoUsuario,
                        IdPais = Convert.ToInt32(ddlpais.SelectedValue)
                    };
                    idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                    Organizacion organizacion = new Organizacion
                    {
                        IdTipoUsuario = idTipoUsuario,
                        IdHolding = Convert.ToInt32(ddlHolding.SelectedValue)
                    };
                    switch (int.Parse(hfCatalogo.Value))
                    {
                        case 3:
                            ubicacion.IdCampus = Convert.ToInt32(ddlCampus.SelectedValue);
                            ubicacion.Torre = new Torre
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarUbicacion(ubicacion);
                            ddlCampus_OnSelectedIndexChanged(ddlCampus, null);
                            upUbicacion.Update();
                            break;
                        case 4:
                            ubicacion.IdCampus = Convert.ToInt32(ddlCampus.SelectedValue);
                            ubicacion.IdTorre = Convert.ToInt32(ddlTorre.SelectedValue);
                            ubicacion.Piso = new Piso
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarUbicacion(ubicacion);
                            ddlTorre_OnSelectedIndexChanged(ddlTorre, null);
                            upUbicacion.Update();
                            break;
                        case 5:
                            ubicacion.IdCampus = Convert.ToInt32(ddlCampus.SelectedValue);
                            ubicacion.IdTorre = Convert.ToInt32(ddlTorre.SelectedValue);
                            ubicacion.IdPiso = Convert.ToInt32(ddlPiso.SelectedValue);
                            ubicacion.Zona = new Zona
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };

                            _serviceCatalogosUsuario.GuardarUbicacion(ubicacion);
                            ddlPiso_OnSelectedIndexChanged(ddlPiso, null);
                            upUbicacion.Update();
                            break;
                        case 6:
                            ubicacion.IdCampus = Convert.ToInt32(ddlCampus.SelectedValue);
                            ubicacion.IdTorre = Convert.ToInt32(ddlTorre.SelectedValue);
                            ubicacion.IdPiso = Convert.ToInt32(ddlPiso.SelectedValue);
                            ubicacion.IdZona = Convert.ToInt32(ddlZona.SelectedValue);
                            ubicacion.SubZona = new SubZona
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };

                            _serviceCatalogosUsuario.GuardarUbicacion(ubicacion);
                            ddlZona_OnSelectedIndexChanged(ddlZona, null);
                            upUbicacion.Update();
                            break;
                        case 7:
                            ubicacion.IdCampus = Convert.ToInt32(ddlCampus.SelectedValue);
                            ubicacion.IdTorre = Convert.ToInt32(ddlTorre.SelectedValue);
                            ubicacion.IdPiso = Convert.ToInt32(ddlPiso.SelectedValue);
                            ubicacion.IdZona = Convert.ToInt32(ddlZona.SelectedValue);
                            ubicacion.IdSubZona = Convert.ToInt32(ddlSubZona.SelectedValue);
                            ubicacion.SiteRack = new SiteRack
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarUbicacion(ubicacion);
                            ddlSubZona_OnSelectedIndexChanged(ddlSubZona, null);
                            upUbicacion.Update();
                            break;
                        case 8:
                            organizacion.Holding = new Holding
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            LlenaComboOrganizacion(Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue));
                            upOrganizacion.Update();
                            break;
                        case 9:
                            organizacion.IdHolding = Convert.ToInt32(ddlHolding.SelectedValue);
                            organizacion.Compania = new Compania
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            ddlHolding_OnSelectedIndexChanged(ddlHolding, null);
                            upOrganizacion.Update();
                            break;
                        case 10:
                            organizacion.IdHolding = Convert.ToInt32(ddlHolding.SelectedValue);
                            organizacion.IdCompania = Convert.ToInt32(ddlCompañia.SelectedValue);
                            organizacion.Direccion = new Direccion
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            ddlCompañia_OnSelectedIndexChanged(ddlCompañia, null);
                            upOrganizacion.Update();
                            break;
                        case 11:
                            organizacion.IdHolding = Convert.ToInt32(ddlHolding.SelectedValue);
                            organizacion.IdCompania = Convert.ToInt32(ddlCompañia.SelectedValue);
                            organizacion.IdDireccion = Convert.ToInt32(ddlDireccion.SelectedValue);
                            organizacion.SubDireccion = new SubDireccion
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            ddlDirecion_OnSelectedIndexChanged(ddlDireccion, null);
                            upOrganizacion.Update();
                            break;
                        case 12:
                            organizacion.IdHolding = Convert.ToInt32(ddlHolding.SelectedValue);
                            organizacion.IdCompania = Convert.ToInt32(ddlCompañia.SelectedValue);
                            organizacion.IdDireccion = Convert.ToInt32(ddlDireccion.SelectedValue);
                            organizacion.IdSubDireccion = Convert.ToInt32(ddlSubDireccion.SelectedValue);
                            organizacion.Gerencia = new Gerencia
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            ddlSubDireccion_OnSelectedIndexChanged(ddlSubDireccion, null);
                            upOrganizacion.Update();
                            break;
                        case 13:
                            organizacion.IdHolding = Convert.ToInt32(ddlHolding.SelectedValue);
                            organizacion.IdCompania = Convert.ToInt32(ddlCompañia.SelectedValue);
                            organizacion.IdDireccion = Convert.ToInt32(ddlDireccion.SelectedValue);
                            organizacion.IdSubDireccion = Convert.ToInt32(ddlSubDireccion.SelectedValue);
                            organizacion.IdGerencia = Convert.ToInt32(ddlGerencia.SelectedValue);
                            organizacion.SubGerencia = new SubGerencia
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            ddlGerencia_OnSelectedIndexChanged(ddlGerencia, null);
                            upOrganizacion.Update();
                            break;
                        case 14:
                            organizacion.IdHolding = Convert.ToInt32(ddlHolding.SelectedValue);
                            organizacion.IdCompania = Convert.ToInt32(ddlCompañia.SelectedValue);
                            organizacion.IdDireccion = Convert.ToInt32(ddlDireccion.SelectedValue);
                            organizacion.IdSubDireccion = Convert.ToInt32(ddlSubDireccion.SelectedValue);
                            organizacion.IdGerencia = Convert.ToInt32(ddlGerencia.SelectedValue);
                            organizacion.IdSubGerencia = Convert.ToInt32(ddlSubGerencia.SelectedValue);
                            organizacion.Jefatura = new Jefatura
                            {
                                IdTipoUsuario = Convert.ToInt32(ddlTipoUsuarioCatalogo.SelectedValue),
                                Descripcion = txtDescripcionCatalogo.Text.Trim(),
                                Habilitado = chkHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarOrganizacion(organizacion);
                            ddlSubGerencia_OnSelectedIndexChanged(ddlSubGerencia, null);
                            upOrganizacion.Update();
                            break;
                    }
                    LimpiaCatalogo();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editCatalogoUbicacion\");", true);
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaCatalogos = _lstError;
            }
        }

        protected void btnCancelarCatalogo_OnClick(object sender, EventArgs e)
        {
            LimpiaCatalogo();
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaDatosGenerales();
                ValidaCapturaOrganizacion();
                ValidaCapturaUbicacion();
                ValidaCapturaRoles();
                ValidaCapturaGrupos();
                Usuario usuario = new Usuario
                {
                    IdTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue),
                    ApellidoPaterno = txtAp.Text.Trim(),
                    ApellidoMaterno = txtAm.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    DirectorioActivo = chkDirectoriActivo.Checked
                };
                usuario.TelefonoUsuario = new List<TelefonoUsuario>();
                foreach (RepeaterItem item in rptTelefonos.Items)
                {
                    Label tipoTelefono = (Label)item.FindControl("lblTipotelefono");
                    TextBox numero = (TextBox)item.FindControl("txtNumero");
                    TextBox extension = (TextBox)item.FindControl("txtExtension");
                    if (tipoTelefono != null && numero != null && extension != null)
                        usuario.TelefonoUsuario.Add(new TelefonoUsuario
                        {
                            IdTipoTelefono = Convert.ToInt32(tipoTelefono.Text.Trim()),
                            Numero = numero.Text.Trim(),
                            Extension = extension.Text.Trim()
                        });
                }
                usuario.CorreoUsuario = new List<CorreoUsuario>();
                foreach (TextBox correo in rptCorreos.Items.Cast<RepeaterItem>().Select(item => (TextBox)item.FindControl("txtCorreo")).Where(correo => correo != null & correo.Text.Trim() != string.Empty))
                {
                    usuario.CorreoUsuario.Add(new CorreoUsuario { Correo = correo.Text.Trim() });
                }

                #region organizacion
                Organizacion organizacion = new Organizacion
                {
                    IdTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue),
                    IdHolding = Convert.ToInt32(ddlHolding.SelectedValue)

                };

                if (ddlCompañia.SelectedValue != string.Empty & ddlCompañia.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    organizacion.IdCompania = Convert.ToInt32(ddlCompañia.SelectedValue);

                if (ddlDireccion.SelectedValue != string.Empty & ddlDireccion.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    organizacion.IdDireccion = Convert.ToInt32(ddlDireccion.SelectedValue);

                if (ddlSubDireccion.SelectedValue != string.Empty & ddlSubDireccion.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    organizacion.IdSubDireccion = Convert.ToInt32(ddlSubDireccion.SelectedValue);

                if (ddlGerencia.SelectedValue != string.Empty & ddlGerencia.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    organizacion.IdGerencia = Convert.ToInt32(ddlGerencia.SelectedValue);

                if (ddlSubGerencia.SelectedValue != string.Empty & ddlSubGerencia.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    organizacion.IdSubGerencia = Convert.ToInt32(ddlSubGerencia.SelectedValue);

                if (ddlJefatura.SelectedValue != string.Empty & ddlJefatura.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    organizacion.IdJefatura = Convert.ToInt32(ddlJefatura.SelectedValue);

                usuario.Organizacion = organizacion;
                #endregion organizacion

                #region Ubicacion
                Ubicacion ubicacion = new Ubicacion
                {
                    IdTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue),
                    IdPais = Convert.ToInt32(ddlpais.SelectedValue)
                };

                if (ddlCampus.SelectedValue != string.Empty & ddlCampus.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    ubicacion.IdCampus = Convert.ToInt32(ddlCampus.SelectedValue);

                if (ddlTorre.SelectedValue != string.Empty & ddlTorre.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    ubicacion.IdTorre = Convert.ToInt32(ddlTorre.SelectedValue);

                if (ddlPiso.SelectedValue != string.Empty & ddlPiso.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    ubicacion.IdPiso = Convert.ToInt32(ddlPiso.SelectedValue);

                if (ddlZona.SelectedValue != string.Empty & ddlZona.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    ubicacion.IdZona = Convert.ToInt32(ddlZona.SelectedValue);

                if (ddlSubZona.SelectedValue != string.Empty & ddlSubZona.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    ubicacion.IdSubZona = Convert.ToInt32(ddlSubZona.SelectedValue);

                if (ddlSiteRack.SelectedValue != string.Empty & ddlSiteRack.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                    ubicacion.IdSiteRack = Convert.ToInt32(ddlSiteRack.SelectedValue);

                usuario.Ubicacion = ubicacion;
                #endregion Ubicacion

                #region Rol
                usuario.UsuarioRol = new List<UsuarioRol>();
                foreach (ListItem item in chklbxRoles.Items.Cast<ListItem>().Where(item => item.Selected))
                {
                    usuario.UsuarioRol.Add(new UsuarioRol { RolTipoUsuario = new RolTipoUsuario { IdRol = Convert.ToInt32(item.Value), IdTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue) } });
                    //usuario.UsuarioRol.Add(new UsuarioRol { RolTipoUsuario = new Rol { Id = Convert.ToInt32(item.Value) } });
                }

                #endregion Rol

                #region Grupo

                usuario.UsuarioGrupo = new List<UsuarioGrupo>();

                foreach (RepeaterItem item in rptUsuarioGrupo.Items)
                {
                    Label lblIdGrupoUsuario = (Label)item.FindControl("lblIdGrupoUsuario");
                    Label lblIdSubGrupoUsuario = (Label)item.FindControl("lblIdTipoSubGrupo");
                    if (lblIdGrupoUsuario != null && lblIdSubGrupoUsuario != null)
                    {
                        usuario.UsuarioGrupo.Add(new UsuarioGrupo
                        {
                            IdGrupoUsuario = Convert.ToInt32(lblIdGrupoUsuario.Text),
                            IdSubGrupoUsuario = Convert.ToInt32(lblIdSubGrupoUsuario.Text)
                        });
                    }
                }

                #endregion Grupos

                _serviceUsuarios.GuardarUsuario(usuario);
                Response.Redirect("FrmUsuarios.aspx");
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGeneral = _lstError;
            }
        }

        #endregion botones guardar crear

        #region botones cerrar Cancelar
        protected void btnAceptarDatosGenerales_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaDatosGenerales();
                btnModalDatosGenerales.CssClass = "btn btn-success btn-lg";
                btnModalOrganizacion.CssClass = "btn btn-primary btn-lg";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalDatosGenerales\");", true);
                upOrganizacion.Update();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaDatosGenerales = _lstError;
            }
        }

        protected void btnCerrarOrganizacion_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaOrganizacion();
                btnModalOrganizacion.CssClass = "btn btn-success btn-lg";
                btnModalUbicacion.CssClass = "btn btn-primary btn-lg";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalOrganizacion\");", true);
                upUbicacion.Update();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaOrganizacion = _lstError;
            }
        }

        protected void btnCerrarUbicacion_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaUbicacion();
                btnModalUbicacion.CssClass = "btn btn-success btn-lg";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalUbicacion\");", true);
                btnModalRoles.CssClass = "btn btn-primary btn-lg";
                upRoles.Update();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaUbicacion = _lstError;
            }
        }

        protected void btnCerrarRoles_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaRoles();
                btnModalRoles.CssClass = "btn btn-success btn-lg";
                btnModalGrupos.CssClass = "btn btn-primary btn-lg";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalRoles\");", true);
                upGrupos.Update();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaRoles = _lstError;
            }
        }

        protected void btnCerrarGrupos_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaGrupos();
                btnModalGrupos.CssClass = "btn btn-success btn-lg";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalGrupos\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupos = _lstError;
            }
        }

        #endregion botones cerrar Cancelar

        protected void btnGuardarGrupoUsuario_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaGrupoUsuario();
                GrupoUsuario grupoUsuario = new GrupoUsuario();
                grupoUsuario.IdTipoGrupo = Convert.ToInt32(ddlTipoGrupoSeleccionado.SelectedItem.Value);
                grupoUsuario.Descripcion = txtDescripcionGrupoUsuario.Text;
                grupoUsuario.Habilitado = chkGrupoUsuario.Checked;
                grupoUsuario.SubGrupoUsuario = new List<SubGrupoUsuario>();
                foreach (ListItem item in chkLbxSubGrupoUsuario.Items.Cast<ListItem>().Where(item => item.Selected))
                {
                    grupoUsuario.SubGrupoUsuario.Add(new SubGrupoUsuario { IdTipoSubGrupo = Convert.ToInt32(item.Value) });
                }
                _serviceCatalogosUsuario.GuardarGrupoUsuario(grupoUsuario);

                Metodos.LlenaComboCatalogo(ddlGruposUsuario, _serviceCatalogosUsuario.ObtenerGruposUsuario(Convert.ToInt32(ddlTipoGrupoSeleccionado.SelectedValue), true));
                txtDescripcionGrupoUsuario.Text = string.Empty;
                ddlTipoGrupo_OnSelectedIndexChanged(ddlTipoGrupo, null);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#addGrupoUsuario\");", true);
                upGrupos.Update();
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

        protected void btnCancelarGrupoUsuario_OnClick(object sender, EventArgs e)
        {
            try
            {
                ValidaCapturaOrganizacion();
                btnModalOrganizacion.CssClass = "btn btn-success btn-lg";
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalOrganizacion\");", true);
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

        protected void btnAgregarGrupo_OnClick(object sender, EventArgs e)
        {
            try
            {
                List<UsuarioGrupo> lst = (List<UsuarioGrupo>)Session["UsuarioGrupo"];
                GrupoUsuario grupoUsuario = _serviceCatalogosUsuario.ObtenerGrupoUsuarioById(Convert.ToInt32(ddlGruposUsuario.SelectedItem.Value));
                SubGrupoUsuario subGrupoUsuario = _serviceCatalogosUsuario.ObtenerSubGrupoUsuario(grupoUsuario.Id, Convert.ToInt32(ddlTipoSubGrupo.SelectedValue));
                if (grupoUsuario == null || subGrupoUsuario == null) return;
                if (lst.Any(a => a.IdGrupoUsuario == grupoUsuario.Id && a.IdSubGrupoUsuario == subGrupoUsuario.Id))
                    throw new Exception("Este grupo ya se encuentra asignado");
                lst.Add(new UsuarioGrupo
                {
                    IdGrupoUsuario = grupoUsuario.Id,
                    IdSubGrupoUsuario = subGrupoUsuario.Id,
                    GrupoUsuario = grupoUsuario,
                    SubGrupoUsuario = subGrupoUsuario
                });

                Session["UsuarioGrupo"] = lst;
                rptUsuarioGrupo.DataSource = lst;
                rptUsuarioGrupo.DataBind();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupos = _lstError;
            }
        }

        protected void ddlGruposUsuario_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlTipoSubGrupo, _serviceCatalogosUsuario.ObtenerSubGruposUsuario(Convert.ToInt32(ddlGruposUsuario.SelectedValue), true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupos = _lstError;
            }
        }

        protected void ddlTipoGrupo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoGrupo;
                if (int.TryParse(ddlTipoGrupo.SelectedValue, out idTipoGrupo))
                {
                    Metodos.LlenaListBoxCatalogo(chkLbxSubGrupoUsuario, _serviceCatalogosUsuario.ObtenerTipoSubGrupos(idTipoGrupo, false));
                    
                    foreach (ListItem item in chkLbxSubGrupoUsuario.Items.Cast<ListItem>())
                    {
                        item.Selected = idTipoGrupo == (int)BusinessVariables.EnumRoles.Administrador;
                    }
                    chkLbxSubGrupoUsuario.Enabled = idTipoGrupo != (int)BusinessVariables.EnumRoles.Administrador;
                    Session["UsuarioGrupo"] = new List<UsuarioGrupo>();
                    rptUsuarioGrupo.DataSource = (List<UsuarioGrupo>)Session["UsuarioGrupo"];
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaGrupos = _lstError;
            }
        }
    }
}