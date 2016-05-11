﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceCatalogosUsuario;
using KiiniNet.Entities.Cat.Arbol.Nodos;
using KiiniNet.Entities.Cat.Operacion;
using KinniNet.Business.Utils;

namespace KiiniHelp.UserControls.Temporal
{
    public partial class UcCatalogoNiveles : UserControl
    {
        #region Variables
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        readonly ServiceCatalogosUsuarioClient _serviceCatalogosUsuario = new ServiceCatalogosUsuarioClient();
        private List<string> _lstError = new List<string>();
        #endregion Variables
        public int TipoUsuario { get; set; }
        public int TipoArbol { get; set; }

        public int Nivel1 { get; set; }
        public int Nivel2 { get; set; }
        public int Nivel3 { get; set; }
        public int Nivel4 { get; set; }
        public int Nivel5 { get; set; }
        public int Nivel6 { get; set; }
        public int Nivel7 { get; set; }

        public UpdatePanel UpPadre { get; set; }

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
        private void LimpiarNivel()
        {
            try
            {
                txtDescripcionNivel.Text = string.Empty;
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

        protected void btnGuardarNivel_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (Metodos.ValidaCapturaCatalogo(txtDescripcionNivel.Text))
                {
                    int idTipoUsuario = TipoUsuario;
                    int idTipoArbolAcceso = TipoArbol;
                    ArbolAcceso arbol = new ArbolAcceso
                    {
                        IdTipoUsuario = idTipoUsuario,
                        IdTipoArbolAcceso = idTipoArbolAcceso,
                        EsTerminal = chkNivelTerminal.Checked,
                        Habilitado = chkNivelHabilitado.Checked
                    };
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
                            break;
                        case 2:
                            arbol.IdNivel1 = Nivel1;
                            arbol.Nivel2 = new Nivel2
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            //ddlNivel1_OnSelectedIndexChanged(ddlNivel1, null);
                            break;
                        case 3:
                            arbol.IdNivel1 = Nivel1;
                            arbol.IdNivel2 = Nivel2;
                            arbol.Nivel3 = new Nivel3
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            //ddlNivel2_OnSelectedIndexChanged(ddlNivel2, null);
                            break;
                        case 4:
                            arbol.IdNivel1 = Nivel1;
                            arbol.IdNivel2 = Nivel2;
                            arbol.IdNivel3 = Nivel3;
                            arbol.Nivel4 = new Nivel4
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            //ddlNivel3_OnSelectedIndexChanged(ddlNivel3, null);
                            break;
                        case 5:
                            arbol.IdNivel1 = Nivel1;
                            arbol.IdNivel2 = Nivel2;
                            arbol.IdNivel3 = Nivel3;
                            arbol.IdNivel4 = Nivel4;
                            arbol.Nivel5 = new Nivel5
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            //ddlNivel4_OnSelectedIndexChanged(ddlNivel4, null);
                            break;
                        case 6:
                            arbol.IdNivel1 = Nivel1;
                            arbol.IdNivel2 = Nivel2;
                            arbol.IdNivel3 = Nivel3;
                            arbol.IdNivel4 = Nivel4;
                            arbol.IdNivel5 = Nivel5;
                            arbol.Nivel6 = new Nivel6
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            //ddlNivel5_OnSelectedIndexChanged(ddlNivel5, null);
                            break;
                        case 7:
                            arbol.IdNivel1 = Nivel1;
                            arbol.IdNivel2 = Nivel2;
                            arbol.IdNivel3 = Nivel3;
                            arbol.IdNivel4 = Nivel4;
                            arbol.IdNivel5 = Nivel5;
                            arbol.IdNivel6 = Nivel6;
                            arbol.Nivel7 = new Nivel7
                            {
                                IdTipoUsuario = idTipoUsuario,
                                Descripcion = txtDescripcionNivel.Text.Trim(),
                                Habilitado = chkNivelHabilitado.Checked
                            };
                            _serviceCatalogosUsuario.GuardarArbol(arbol);
                            //ddlNivel6_OnSelectedIndexChanged(ddlNivel6, null);
                            break;
                    }
                    LimpiarNivel();
                    UpPadre.Update();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "CierraPupup(\"#editNivel\");", true);
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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkNivelTerminal_OnCheckedChanged(object sender, EventArgs e)
        {
            divInfoConculta.Visible = chkNivelTerminal.Checked;
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
            catch (Exception)
            {
                throw;
            }
        }

        protected void rptInformacion_OnItemCreated(object sender, RepeaterItemEventArgs e)
        {
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
    }
}