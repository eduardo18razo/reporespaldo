using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using AjaxControlToolkit;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceCatalogosUsuario;
using KiiniNet.Entities.Operacion;
using KinniNet.Business.Utils;

namespace KiiniHelp.UserControls.Altas
{
    public partial class UcAltaInformacionConsulta : UserControl
    {
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        readonly ServiceCatalogosUsuarioClient _serviceCatalogosUsuario = new ServiceCatalogosUsuarioClient();

        private List<string> _lstError = new List<string>();

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

        private void LlenaCombos()
        {
            try
            {
                Metodos.LlenaComboCatalogo(ddlTipoInformacion, _serviceCatalogosSistema.ObtenerTipoInformacionConsulta(true));
                Metodos.LlenaComboCatalogo(ddlTipoDocumento, _serviceCatalogosSistema.ObtenerTipoDocumentos(true));
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
        public void ValidaCaptura(BusinessVariables.EnumTiposInformacionConsulta tipoInformacion)
        {
            try
            {
                if (txtDescripcion.Text.Trim() == string.Empty)
                    throw new Exception("Debe especificar una descripción");
                switch (tipoInformacion)
                {
                    case BusinessVariables.EnumTiposInformacionConsulta.Propietario:
                        if (txtEditor.Text.Trim() == string.Empty)
                            throw new Exception("Debe especificar un contenido");
                        break;
                    case BusinessVariables.EnumTiposInformacionConsulta.Documento:
                        if (!afuArchivo.HasFile)
                            throw new Exception("Debe especificar un documento");
                        break;
                    case BusinessVariables.EnumTiposInformacionConsulta.Paginahtml:
                        if (txtDescripcionUrl.Text.Trim() == string.Empty)
                            throw new Exception("Debe especificar una url de pagina");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            try
            {
                ddlTipoInformacion.SelectedIndex = BusinessVariables.ComboBoxCatalogo.Index;
                ddlTipoInformacion_OnSelectedIndexChanged(ddlTipoInformacion, null);
                ddlTipoDocumento.SelectedIndex = BusinessVariables.ComboBoxCatalogo.Index;
                txtDescripcion.Text = String.Empty;
                txtEditor.Text = string.Empty;
                txtDescripcionUrl.Text = string.Empty;
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

        protected void ddlTipoInformacion_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (Convert.ToInt32(ddlTipoInformacion.SelectedValue))
                {
                    case (int)BusinessVariables.EnumTiposInformacionConsulta.Propietario:
                        divPropietrario.Visible = true;
                        divDocumento.Visible = false;
                        divUrl.Visible = false;
                        break;
                    case (int)BusinessVariables.EnumTiposInformacionConsulta.Documento:
                        divPropietrario.Visible = false;
                        divDocumento.Visible = true;
                        divUrl.Visible = false;
                        break;
                    case (int)BusinessVariables.EnumTiposInformacionConsulta.Paginahtml:
                        divPropietrario.Visible = false;
                        divDocumento.Visible = false;
                        divUrl.Visible = true;
                        break;
                    default:
                        divPropietrario.Visible = false;
                        divDocumento.Visible = false;
                        divUrl.Visible = false;
                        break;
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

        protected void btnGuardar_OnClick(object sender, EventArgs e)
        {
            try
            {
                InformacionConsulta informacion = new InformacionConsulta
                {
                    Descripcion = txtDescripcion.Text.Trim(),
                    Habilitado = true,
                    IdTipoInfConsulta = Convert.ToInt32(ddlTipoInformacion.SelectedValue),
                    InformacionConsultaDatos = new List<InformacionConsultaDatos>()
                };
                switch (Convert.ToInt32(ddlTipoInformacion.SelectedValue))
                {
                    case (int)BusinessVariables.EnumTiposInformacionConsulta.Propietario:
                        ValidaCaptura(BusinessVariables.EnumTiposInformacionConsulta.Propietario);
                        informacion.InformacionConsultaDatos.Add(new InformacionConsultaDatos { Descripcion = txtEditor.Text, Orden = 1 });
                        break;
                    case (int)BusinessVariables.EnumTiposInformacionConsulta.Documento:
                        ValidaCaptura(BusinessVariables.EnumTiposInformacionConsulta.Documento);
                        informacion.IdTipoDocumento = Convert.ToInt32(ddlTipoDocumento.SelectedValue);
                        informacion.InformacionConsultaDatos.Add(new InformacionConsultaDatos { Descripcion = afuArchivo.FileName, Orden = 1 });
                        break;
                    case (int)BusinessVariables.EnumTiposInformacionConsulta.Paginahtml:
                        ValidaCaptura(BusinessVariables.EnumTiposInformacionConsulta.Paginahtml);
                        informacion.InformacionConsultaDatos.Add(new InformacionConsultaDatos { Descripcion = txtDescripcionUrl.Text.Trim(), Orden = 1 });
                        break;
                    default:
                        throw new Exception("Seeleccione un tipo de información");
                        break;
                }
                _serviceCatalogosUsuario.GuardarInformacionConsulta(informacion);
                LimpiarCampos();
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
        
        protected void btnLimpiar_OnClick(object sender, EventArgs e)
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
                AlertaGeneral = _lstError;
            }
        }

        protected void afuArchivo_OnUploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            try
            {
                string path = Server.MapPath("~/Uploads/") + e.FileName;
                afuArchivo.SaveAs(path);
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