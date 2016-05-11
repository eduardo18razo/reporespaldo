using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceCatalogosUsuario;
using KiiniHelp.ServiceMascaras;
using KiiniNet.Entities.Cat.Arbol.Nodos;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Sistema;
using KiiniNet.Entities.Operacion;
using KinniNet.Business.Utils;

namespace KiiniHelp.ArbolesAecceso
{
    public partial class FrmAltaArbolAcceso : Page
    {
        #region Variables
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        readonly ServiceCatalogosUsuarioClient _serviceCatalogosUsuario = new ServiceCatalogosUsuarioClient();
        readonly ServiceMascarasClient _serviceMascaras = new ServiceMascarasClient();

        private List<string> _lstError = new List<string>();
        #endregion Variables

        #region Propiedades privadas
        private List<string> AlertaGeneral
        {
            set
            {
                panelAlert.Visible = value.Any();
                if (!panelAlert.Visible) return;
                rptHeaderError.DataSource = value;
                rptHeaderError.DataBind();
            }
        }
        private List<string> AlertaNivel
        {
            set
            {
                panelAlertaNivel.Visible = value.Any();
                if (!panelAlertaNivel.Visible) return;
                rptErrorNivel.DataSource = value;
                rptErrorNivel.DataBind();
            }
        }
        #endregion Propiedades privadas

        #region Metodos
        private void LlenaCombos()
        {
            try
            {
                List<TipoUsuario> lstTipoUsuario = _serviceCatalogosSistema.ObtenerTiposUsuario(true);
                Metodos.LlenaComboCatalogo(ddlTipoUsuario, lstTipoUsuario);
                Metodos.LlenaComboCatalogo(ddlTipoUsuarioNivel, lstTipoUsuario);
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

        private void LimpiarNivel()
        {
            try
            {
                txtDescripcionNivel.Text = string.Empty;
                chkNivelTerminal.Checked = false;
                chkNivelTerminal_OnCheckedChanged(chkNivelTerminal, null);
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

        private void ValidaCapturaArbol()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                if (ddlTipoArbol.SelectedValue == BusinessVariables.ComboBoxCatalogo.Value.ToString())
                    sb.AppendLine("Debe especificar un tipo de arbol.<br>");

                if (ddlNivel1.SelectedValue == BusinessVariables.ComboBoxCatalogo.Value.ToString())
                    sb.AppendLine("Debe especificar al menos un nivel.<br>");


                if (sb.ToString() != string.Empty)
                    throw new Exception(sb.ToString());
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


        #endregion Metodos

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AlertaGeneral = new List<string>();
                AlertaNivel = new List<string>();
                if (!IsPostBack)
                {
                    LlenaCombos();
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

        protected void OnClick(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoUsuario.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                    throw new Exception("Seleccione un tipo de usuario");
                }
                if (ddlTipoArbol.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                    throw new Exception("Seleccione un tipo de arbol");
                }
                Button lbtn = (Button)sender;
                if (sender == null) return;
                switch (lbtn.CommandArgument)
                {
                    case "10":
                        btnCerrarGrupo.CommandArgument = ((int)BusinessVariables.EnumTiposGrupos.Responsabilidad).ToString();
                        UcAltaGrupos.IdTipoGrugo = (int)BusinessVariables.EnumTiposGrupos.Responsabilidad;
                        break;
                    case "11":
                        btnCerrarGrupo.CommandArgument = ((int)BusinessVariables.EnumTiposGrupos.Atención).ToString();
                        UcAltaGrupos.IdTipoGrugo = (int)BusinessVariables.EnumTiposGrupos.Atención;
                        break;
                    case "12":
                        btnCerrarGrupo.CommandArgument = ((int)BusinessVariables.EnumTiposGrupos.Especialdeconsulta).ToString();
                        UcAltaGrupos.IdTipoGrugo = (int)BusinessVariables.EnumTiposGrupos.Especialdeconsulta;
                        break;
                    case "2":
                        if (ddlNivel1.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 1");
                        }
                        break;
                    case "3":
                        if (ddlNivel1.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 1");
                        }
                        if (ddlNivel2.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 2");
                        }
                        break;
                    case "4":
                        if (ddlNivel1.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 1");
                        }
                        if (ddlNivel2.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 2");
                        }
                        if (ddlNivel3.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 3");
                        }
                        break;
                    case "5":
                        if (ddlNivel1.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 1");
                        }
                        if (ddlNivel2.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 2");
                        }
                        if (ddlNivel3.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 3");
                        }
                        if (ddlNivel4.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 4");
                        }
                        break;
                    case "6":
                        if (ddlNivel1.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 1");
                        }
                        if (ddlNivel2.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 2");
                        }
                        if (ddlNivel3.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 3");
                        }
                        if (ddlNivel4.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 4");
                        }
                        if (ddlNivel5.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 5");
                        }
                        break;
                    case "7":
                        if (ddlNivel1.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 1");
                        }
                        if (ddlNivel2.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 2");
                        }
                        if (ddlNivel3.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 3");
                        }
                        if (ddlNivel4.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 4");
                        }
                        if (ddlNivel5.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 5");
                        }
                        if (ddlNivel6.SelectedIndex <= BusinessVariables.ComboBoxCatalogo.Index)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                            throw new Exception("Seleccione nivel 6");
                        }
                        break;
                }
                lblTitleCatalogo.Text = lbtn.CommandName;
                hfCatalogo.Value = lbtn.CommandArgument;
                ddlTipoUsuarioNivel.SelectedIndex = ddlTipoUsuario.SelectedIndex;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "MostrarPopup(\"#editNivel\");", true);

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

        protected void ddlTipoUsuario_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoUsuario.SelectedIndex != BusinessVariables.ComboBoxCatalogo.Index)
                {
                    //divDatos.Visible = true;
                    Metodos.LimpiarCombo(ddlTipoArbol);
                    Metodos.LimpiarCombo(ddlNivel1);
                    Metodos.LimpiarCombo(ddlNivel2);
                    Metodos.LimpiarCombo(ddlNivel3);
                    Metodos.LimpiarCombo(ddlNivel4);
                    Metodos.LimpiarCombo(ddlNivel5);
                    Metodos.LimpiarCombo(ddlNivel6);
                    Metodos.LimpiarCombo(ddlNivel7);
                    Metodos.LlenaComboCatalogo(ddlTipoArbol, _serviceCatalogosSistema.ObtenerTiposArbolAcceso(true));
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
        protected void ddlTipoArbol_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel1);
                Metodos.LimpiarCombo(ddlNivel2);
                Metodos.LimpiarCombo(ddlNivel3);
                Metodos.LimpiarCombo(ddlNivel4);
                Metodos.LimpiarCombo(ddlNivel5);
                Metodos.LimpiarCombo(ddlNivel6);
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                Metodos.LlenaComboCatalogo(ddlNivel1, _serviceCatalogosUsuario.ObtenerNivel1(idTipoArbol, idTipoUsuario, true));

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

        protected void ddlNivel1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel2);
                Metodos.LimpiarCombo(ddlNivel3);
                Metodos.LimpiarCombo(ddlNivel4);
                Metodos.LimpiarCombo(ddlNivel5);
                Metodos.LimpiarCombo(ddlNivel6);
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int idNivelFiltro = Convert.ToInt32(ddlNivel1.SelectedValue);
                if (!_serviceCatalogosUsuario.EsNodoTerminal(idTipoUsuario, idTipoArbol, idNivelFiltro, null, null, null, null, null, null))
                    Metodos.FiltraCombo(ddlNivel1, ddlNivel2, _serviceCatalogosUsuario.ObtenerNivel2(idTipoArbol, idTipoUsuario, idNivelFiltro, true));
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

        protected void ddlNivel2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel3);
                Metodos.LimpiarCombo(ddlNivel4);
                Metodos.LimpiarCombo(ddlNivel5);
                Metodos.LimpiarCombo(ddlNivel6);
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int idNivelFiltro = Convert.ToInt32(ddlNivel2.SelectedValue);
                if (!_serviceCatalogosUsuario.EsNodoTerminal(idTipoUsuario, idTipoArbol, Convert.ToInt32(ddlNivel1.SelectedValue), idNivelFiltro, null, null, null, null, null))
                    Metodos.FiltraCombo(ddlNivel2, ddlNivel3, _serviceCatalogosUsuario.ObtenerNivel3(idTipoArbol, idTipoUsuario, idNivelFiltro, true));
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

        protected void ddlNivel3_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel4);
                Metodos.LimpiarCombo(ddlNivel5);
                Metodos.LimpiarCombo(ddlNivel6);
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int idNivelFiltro = Convert.ToInt32(ddlNivel3.SelectedValue);
                if (!_serviceCatalogosUsuario.EsNodoTerminal(idTipoUsuario, idTipoArbol, Convert.ToInt32(ddlNivel1.SelectedValue), Convert.ToInt32(ddlNivel2.SelectedValue), Convert.ToInt32(ddlNivel3.SelectedValue), null, null, null, null))
                    Metodos.FiltraCombo(ddlNivel3, ddlNivel4, _serviceCatalogosUsuario.ObtenerNivel4(idTipoArbol, idTipoUsuario, idNivelFiltro, true));
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

        protected void ddlNivel4_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel5);
                Metodos.LimpiarCombo(ddlNivel6);
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int idNivelFiltro = Convert.ToInt32(ddlNivel4.SelectedValue);
                if (!_serviceCatalogosUsuario.EsNodoTerminal(idTipoUsuario, idTipoArbol, Convert.ToInt32(ddlNivel1.SelectedValue), Convert.ToInt32(ddlNivel2.SelectedValue), Convert.ToInt32(ddlNivel3.SelectedValue), idNivelFiltro, null, null, null))
                    Metodos.FiltraCombo(ddlNivel4, ddlNivel5, _serviceCatalogosUsuario.ObtenerNivel5(idTipoArbol, idTipoUsuario, idNivelFiltro, true));
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

        protected void ddlNivel5_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel6);
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int idNivelFiltro = Convert.ToInt32(ddlNivel5.SelectedValue);
                if (!_serviceCatalogosUsuario.EsNodoTerminal(idTipoUsuario, idTipoArbol, Convert.ToInt32(ddlNivel1.SelectedValue), Convert.ToInt32(ddlNivel2.SelectedValue), Convert.ToInt32(ddlNivel3.SelectedValue), Convert.ToInt32(ddlNivel4.SelectedValue), idNivelFiltro, null, null))
                    Metodos.FiltraCombo(ddlNivel5, ddlNivel6, _serviceCatalogosUsuario.ObtenerNivel6(idTipoArbol, idTipoUsuario, idNivelFiltro, true));
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

        protected void ddlNivel6_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Metodos.LimpiarCombo(ddlNivel7);
                int idTipoArbol = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                int idNivelFiltro = Convert.ToInt32(ddlNivel6.SelectedValue);
                if (!_serviceCatalogosUsuario.EsNodoTerminal(idTipoUsuario, idTipoArbol, Convert.ToInt32(ddlNivel1.SelectedValue), Convert.ToInt32(ddlNivel2.SelectedValue), Convert.ToInt32(ddlNivel3.SelectedValue), Convert.ToInt32(ddlNivel4.SelectedValue), Convert.ToInt32(ddlNivel5.SelectedValue), idNivelFiltro, null))
                    Metodos.FiltraCombo(ddlNivel6, ddlNivel7, _serviceCatalogosUsuario.ObtenerNivel7(idTipoArbol, idTipoUsuario, idNivelFiltro, true));
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

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            try
            {

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

        protected void btnGuardarNivel_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Metodos.ValidaCapturaCatalogo(txtDescripcionNivel.Text))
                {
                    int idTipoUsuario = Convert.ToInt32(ddlTipoUsuario.SelectedValue);
                    int idTipoArbolAcceso = Convert.ToInt32(ddlTipoArbol.SelectedValue);
                    ArbolAcceso arbol = new ArbolAcceso
                    {
                        IdTipoUsuario = idTipoUsuario,
                        IdTipoArbolAcceso = idTipoArbolAcceso,
                        EsTerminal = chkNivelTerminal.Checked,
                        Habilitado = chkNivelHabilitado.Checked

                    };
                    if (chkNivelTerminal.Checked)
                    {
                        arbol.InventarioArbolAcceso = new List<InventarioArbolAcceso>();
                        arbol.InventarioArbolAcceso.Add(new InventarioArbolAcceso());
                        arbol.InventarioArbolAcceso[0].IdMascara = Convert.ToInt32(ddlMascaraAcceso.SelectedValue);
                        arbol.InventarioArbolAcceso[0].IdSLA = Convert.ToInt32(ddlSla.SelectedValue);
                        arbol.InventarioArbolAcceso[0].IdGrupoResponsable = Convert.ToInt32(ddlGruposResponsables.SelectedValue);
                        arbol.InventarioArbolAcceso[0].IdGrupoAtendedor = Convert.ToInt32(ddlGruposAtendedores.SelectedValue);
                        arbol.InventarioArbolAcceso[0].IdGrupoEspConsulta = Convert.ToInt32(ddlGruposConsulta.SelectedValue);
                        arbol.InventarioArbolAcceso[0].Descripcion = txtDescripcionNivel.Text.Trim();
                        arbol.InventarioArbolAcceso[0].IdEncuesta = Convert.ToInt32(ddlEncuesta.SelectedValue) == BusinessVariables.ComboBoxCatalogo.Value ? (int?)null : Convert.ToInt32(ddlEncuesta.SelectedValue);
                        arbol.InventarioArbolAcceso[0].InventarioInfConsulta = new List<InventarioInfConsulta>();
                    }
                    foreach (RepeaterItem item in rptInformacion.Items)
                    {
                        if (((CheckBox)item.FindControl("chkInfoConsulta")).Checked)
                        {
                            Label lblId = (Label)item.FindControl("lblIdTipoInformacion");
                            arbol.InventarioArbolAcceso[0].InventarioInfConsulta.Add(new InventarioInfConsulta { IdInfConsulta = Convert.ToInt32(lblId.Text) });
                        }
                    }
                    switch (int.Parse(hfCatalogo.Value))
                    {
                        case 1:
                            arbol.Nivel1 = new Nivel1
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlTipoArbol_OnSelectedIndexChanged(ddlTipoArbol, null);
                            break;
                        case 2:
                            arbol.IdNivel1 = Convert.ToInt32(ddlNivel1.SelectedValue);
                            arbol.Nivel2 = new Nivel2
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlNivel1_OnSelectedIndexChanged(ddlNivel1, null);
                            break;
                        case 3:
                            arbol.IdNivel1 = Convert.ToInt32(ddlNivel1.SelectedValue);
                            arbol.IdNivel2 = Convert.ToInt32(ddlNivel2.SelectedValue);
                            arbol.Nivel3 = new Nivel3
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlNivel2_OnSelectedIndexChanged(ddlNivel2, null);
                            break;
                        case 4:
                            arbol.IdNivel1 = Convert.ToInt32(ddlNivel1.SelectedValue);
                            arbol.IdNivel2 = Convert.ToInt32(ddlNivel2.SelectedValue);
                            arbol.IdNivel3 = Convert.ToInt32(ddlNivel3.SelectedValue);
                            arbol.Nivel4 = new Nivel4
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlNivel3_OnSelectedIndexChanged(ddlNivel3, null);
                            break;
                        case 5:
                            arbol.IdNivel1 = Convert.ToInt32(ddlNivel1.SelectedValue);
                            arbol.IdNivel2 = Convert.ToInt32(ddlNivel2.SelectedValue);
                            arbol.IdNivel3 = Convert.ToInt32(ddlNivel3.SelectedValue);
                            arbol.IdNivel4 = Convert.ToInt32(ddlNivel4.SelectedValue);
                            arbol.Nivel5 = new Nivel5
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlNivel4_OnSelectedIndexChanged(ddlNivel4, null);
                            break;
                        case 6:
                            arbol.IdNivel1 = Convert.ToInt32(ddlNivel1.SelectedValue);
                            arbol.IdNivel2 = Convert.ToInt32(ddlNivel2.SelectedValue);
                            arbol.IdNivel3 = Convert.ToInt32(ddlNivel3.SelectedValue);
                            arbol.IdNivel4 = Convert.ToInt32(ddlNivel4.SelectedValue);
                            arbol.IdNivel5 = Convert.ToInt32(ddlNivel5.SelectedValue);
                            arbol.Nivel6 = new Nivel6
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlNivel5_OnSelectedIndexChanged(ddlNivel5, null);
                            break;
                        case 7:
                            arbol.IdNivel1 = Convert.ToInt32(ddlNivel1.SelectedValue);
                            arbol.IdNivel2 = Convert.ToInt32(ddlNivel2.SelectedValue);
                            arbol.IdNivel3 = Convert.ToInt32(ddlNivel3.SelectedValue);
                            arbol.IdNivel4 = Convert.ToInt32(ddlNivel4.SelectedValue);
                            arbol.IdNivel5 = Convert.ToInt32(ddlNivel5.SelectedValue);
                            arbol.IdNivel6 = Convert.ToInt32(ddlNivel6.SelectedValue);
                            arbol.Nivel7 = new Nivel7
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            ddlNivel6_OnSelectedIndexChanged(ddlNivel6, null);
                            break;
                    }
                    LimpiarNivel();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }

        }

        protected void btnCancelarNivel_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiarNivel();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#editNivel\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }

        protected void chkNivelTerminal_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNivelHabilitado.Checked)
                {
                    divNodoTerminal.Visible = chkNivelTerminal.Checked;
                    List<InformacionConsulta> infoCons = _serviceCatalogosSistema.ObtenerTipoInformacionConsulta(false).Select(tipoInf => new InformacionConsulta { TipoInfConsulta = tipoInf }).ToList();
                    rptInformacion.DataSource = infoCons;
                    rptInformacion.DataBind();
                    Metodos.LlenaComboCatalogo(ddlMascaraAcceso, _serviceMascaras.ObtenerMascarasAcceso(true));
                    Metodos.LlenaComboCatalogo(ddlSla, _serviceCatalogosUsuario.ObtenerSla(true));
                    Metodos.LlenaComboCatalogo(ddlGruposResponsables, _serviceCatalogosUsuario.ObtenerGruposUsuario((int)BusinessVariables.EnumTiposGrupos.Responsabilidad, true));
                    Metodos.LlenaComboCatalogo(ddlGruposAtendedores, _serviceCatalogosUsuario.ObtenerGruposUsuario((int)BusinessVariables.EnumTiposGrupos.Atención, true));
                    Metodos.LlenaComboCatalogo(ddlGruposConsulta, _serviceCatalogosUsuario.ObtenerGruposUsuario((int)BusinessVariables.EnumTiposGrupos.Especialdeconsulta, true));
                    Metodos.LlenaComboCatalogo(ddlEncuesta, _serviceCatalogosUsuario.ObtenerEncuestas(true));
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }

        }

        protected void rptInformacion_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DropDownList ddlPropietario = (DropDownList)e.Item.FindControl("ddlPropietario");
                DropDownList ddlDocumento = (DropDownList)e.Item.FindControl("ddlDocumento");
                DropDownList ddlUrl = (DropDownList)e.Item.FindControl("ddlUrl");
                if (ddlPropietario == null && ddlDocumento == null && ddlUrl == null) return;
                Metodos.LlenaComboCatalogo(ddlPropietario, _serviceCatalogosUsuario.ObtenerInformacionConsulta(BusinessVariables.EnumTiposInformacionConsulta.Propietario, true));
                Metodos.LlenaComboCatalogo(ddlDocumento, _serviceCatalogosUsuario.ObtenerInformacionConsulta(BusinessVariables.EnumTiposInformacionConsulta.Documento, true));
                Metodos.LlenaComboCatalogo(ddlUrl, _serviceCatalogosUsuario.ObtenerInformacionConsulta(BusinessVariables.EnumTiposInformacionConsulta.Paginahtml, true));
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }

        protected void chkInfoConsulta_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Eventos#endregion Eventos

        #region Cerrar Modales
        protected void btnCerraraltaInformacion_OnClick(object sender, EventArgs e)
        {
            try
            {
                rptInformacion.DataSource = null;
                rptInformacion.DataBind();
                List<InformacionConsulta> infoCons = _serviceCatalogosSistema.ObtenerTipoInformacionConsulta(false).Select(tipoInf => new InformacionConsulta { TipoInfConsulta = tipoInf }).ToList();
                rptInformacion.DataSource = infoCons;
                rptInformacion.DataBind();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalAltaInfCons\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }

        protected void btnCerrarModalAltaMascara_OnClick(object sender, EventArgs e)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlMascaraAcceso, _serviceMascaras.ObtenerMascarasAcceso(true));
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalAltaMascara\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }

        protected void btnCerrarAltaSla_OnClick(object sender, EventArgs e)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlSla, _serviceCatalogosUsuario.ObtenerSla(true));
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalAltaSla\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }

        protected void btnCerrarGrupo_OnClick(object sender, EventArgs e)
        {
            try
            {
                switch (int.Parse(((Button)sender).CommandArgument))
                {
                    case (int)BusinessVariables.EnumTiposGrupos.Responsabilidad:
                        Metodos.LlenaComboCatalogo(ddlGruposResponsables, _serviceCatalogosUsuario.ObtenerGruposUsuario((int)BusinessVariables.EnumTiposGrupos.Responsabilidad, true));
                        break;
                    case (int)BusinessVariables.EnumTiposGrupos.Atención:
                        Metodos.LlenaComboCatalogo(ddlGruposAtendedores, _serviceCatalogosUsuario.ObtenerGruposUsuario((int)BusinessVariables.EnumTiposGrupos.Atención, true));
                        break;
                    case (int)BusinessVariables.EnumTiposGrupos.Especialdeconsulta:
                        Metodos.LlenaComboCatalogo(ddlGruposConsulta, _serviceCatalogosUsuario.ObtenerGruposUsuario((int)BusinessVariables.EnumTiposGrupos.Especialdeconsulta, true));
                        break;
                }
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalAltaGrupo\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }

        protected void btnCerrarEncuesta_OnClick(object sender, EventArgs e)
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlEncuesta, _serviceCatalogosUsuario.ObtenerEncuestas(true));
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#modalAltaEncuesta\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }
        #endregion Cerrar Modales

        protected void btnLimpiarNivel_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiarNivel();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaNivel = _lstError;
            }
        }
    }
}