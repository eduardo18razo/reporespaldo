﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceMascaras;
using KiiniNet.Entities.Cat.Mascaras;
using KinniNet.Business.Utils;

namespace KiiniHelp.UserControls.Altas
{
    public partial class UcAltaMascaraAcceso : UserControl
    {
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        readonly ServiceMascarasClient _serviceMascaras = new ServiceMascarasClient();
        private List<string> _lstError = new List<string>();

        public int Ejemplo { get; set; }
        #region Alertas
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

        private List<string> AlertaModalAgregarCampo
        {
            set
            {
                panelAlertaAgregarCampo.Visible = value.Any();
                if (!panelAlertaAgregarCampo.Visible) return;
                rptErrorModalAgregarCampo.DataSource = value.Select(s => new { Detalle = s }).ToList();
                rptErrorModalAgregarCampo.DataBind();
            }
        }
        #endregion Alertas
        private void LlenaCombos()
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlTipoCampo, _serviceCatalogosSistema.ObtenerTipoCampoMascara(true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void LimpiarModalCampo()
        {
            try
            {
                txtDescripcionCampo.Text = string.Empty;
                chkRequerido.Checked = false;
                txtLongitudMinima.Text = string.Empty;
                txtLongitudMaxima.Text = string.Empty;
                txtValorMaximo.Text = string.Empty;
                txtSimboloMoneda.Text = string.Empty;
                ddlCatalogosCampo.SelectedIndex = ddlCatalogosCampo.SelectedIndex >= 1 ?  BusinessVariables.ComboBoxCatalogo.Index : -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void LimpiarMascara()
        {
            try
            {
                txtDescripcionCampo.Text = string.Empty;
                chkRequerido.Checked = false;
                txtLongitudMinima.Text = string.Empty;
                txtLongitudMaxima.Text = string.Empty;
                txtValorMaximo.Text = string.Empty;
                txtSimboloMoneda.Text = string.Empty;
                if (ddlCatalogosCampo.SelectedIndex > 0)
                    ddlCatalogosCampo.SelectedIndex = BusinessVariables.ComboBoxCatalogo.Index;
                Session["MascaraAlta"] = new Mascara();
                rptControles.DataSource = ((Mascara)Session["MascaraAlta"]).CampoMascara;
                rptControles.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AlertaGeneral = new List<string>();
                AlertaModalAgregarCampo = new List<string>();
                if (IsPostBack) return;
                Session["MascaraAlta"] = new Mascara();
                LlenaCombos();
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

        protected void chkObligatorio_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtMin = (TextBox)rptControles.Items[((RepeaterItem)((CheckBox)sender).NamingContainer).ItemIndex].FindControl("txtLongitudMinima");
                TextBox txtMax = (TextBox)rptControles.Items[((RepeaterItem)((CheckBox)sender).NamingContainer).ItemIndex].FindControl("txtLongitudMaxima");
                if (txtMin == null || txtMax == null) return;
                txtMin.Enabled = ((CheckBox)sender).Checked;
                txtMax.Enabled = ((CheckBox)sender).Checked;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaModalAgregarCampo = _lstError;
            }
        }

        protected void ddlTipoCampo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoCampo.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index) return;
                TipoCampoMascara tipoCampo = _serviceCatalogosSistema.TipoCampoMascaraId(Convert.ToInt32(ddlTipoCampo.SelectedValue));
                if (tipoCampo == null) return;
                lblTitleAgregarCampo.Text = "Agregar campo " + tipoCampo.Descripcion;
                txtLongitudMinima.Visible = tipoCampo.LongitudMinima;
                txtLongitudMaxima.Visible = tipoCampo.LongitudMaxima;
                divLongitudes.Visible = tipoCampo.LongitudMinima && tipoCampo.LongitudMaxima;
                divMoneda.Visible = tipoCampo.SimboloMoneda;
                divValorMaximo.Visible = tipoCampo.ValorMaximo;
                divCatalgo.Visible = tipoCampo.Catalogo;
                if (tipoCampo.Catalogo)
                {
                    Metodos.LlenaComboCatalogo(ddlCatalogosCampo, _serviceCatalogosSistema.ObtenerCatalogosMascaraCaptura(true));
                    divCatalgo.Visible = tipoCampo.Catalogo;
                }

                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "MostrarPopup(\"#agregarCampoMascara\");", true);
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

        protected void btnGuardarCampo_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtDescripcionCampo.Text.Trim() == string.Empty)
                throw new Exception("Debe especificar una descripcion");
                Mascara tmpMascara = ((Mascara)Session["MascaraAlta"]);
                if (tmpMascara.CampoMascara == null)
                    tmpMascara.CampoMascara = new List<CampoMascara>();
                TipoCampoMascara tipoCampo = _serviceCatalogosSistema.TipoCampoMascaraId(Convert.ToInt32(ddlTipoCampo.SelectedValue));

                tmpMascara.CampoMascara.Add(item: new CampoMascara
                {
                    IdCatalogo = tipoCampo.Catalogo ? Convert.ToInt32(ddlCatalogosCampo.SelectedValue) : (int?)null,
                    IdTipoCampoMascara = tipoCampo.Id,
                    Descripcion = txtDescripcionCampo.Text.Trim(),
                    Requerido = chkRequerido.Checked,
                    LongitudMinima = tipoCampo.LongitudMaxima ? Convert.ToInt32(txtLongitudMinima.Text.Trim()) : (int?)null,
                    LongitudMaxima = tipoCampo.LongitudMaxima ? Convert.ToInt32(txtLongitudMaxima.Text.Trim()) : (int?)null,
                    SimboloMoneda = tipoCampo.SimboloMoneda ? txtSimboloMoneda.Text.Trim() : null,
                    ValorMaximo = tipoCampo.ValorMaximo ? Convert.ToInt32(txtValorMaximo.Text.Trim()) : (int?)null,

                });

                rptControles.DataSource = tmpMascara.CampoMascara;
                rptControles.DataBind();
                Session["MascaraAlta"] = tmpMascara;
                ddlTipoCampo.SelectedIndex = BusinessVariables.ComboBoxCatalogo.Index;
                upControlesMascara.Update();
                LimpiarModalCampo();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPopup(\"#agregarCampoMascara\");", true);
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaModalAgregarCampo = _lstError;
            }
        }

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text.Trim() == string.Empty)
                    throw new Exception("Debe especificar un nombre.");
                Mascara nuevaMascara = ((Mascara)Session["MascaraAlta"]);
                if (((Mascara)Session["MascaraAlta"]).CampoMascara.Count<=0)
                    throw new Exception("Debe al menos un campo.");
                nuevaMascara.Descripcion = txtNombre.Text.Trim();
                _serviceMascaras.CrearMascara(nuevaMascara);
                LimpiarMascara();
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

        protected void btnLimpiarCampo_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiarModalCampo();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                AlertaModalAgregarCampo = _lstError;
            }
        }

        protected void btnLimpiar_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiarMascara();
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
    }
}