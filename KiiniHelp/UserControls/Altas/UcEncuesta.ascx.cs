﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using KiiniHelp.Funciones;
using KiiniHelp.ServiceCatalogosSistema;
using KiiniHelp.ServiceCatalogosUsuario;
using KiiniNet.Entities.Cat.Sistema;
using KiiniNet.Entities.Cat.Usuario;
using KinniNet.Business.Utils;

namespace KiiniHelp.UserControls.Altas
{
    public partial class UcEncuesta : UserControl
    {
        readonly ServiceCatalogosSistemaClient _serviceCatalogosSistema = new ServiceCatalogosSistemaClient();
        readonly ServiceCatalogosUsuarioClient _serviceCatalogosUsuario = new ServiceCatalogosUsuarioClient();
        private List<string> _lstError = new List<string>();
        private List<string> Alerta
        {
            set
            {
                panelAlerta.Visible = value.Any();
                if (!panelAlerta.Visible) return;
                rptErrorGrupoUsuario.DataSource = value;
                rptErrorGrupoUsuario.DataBind();
            }
        }

        //private List<string> AlertaModal
        //{
        //    set
        //    {
        //        panelAlertaAgregarPregunta.Visible = value.Any();
        //        if (!panelAlertaAgregarPregunta.Visible) return;
        //        rptErrorModalAgregarPregunta.DataSource = value;
        //        rptErrorModalAgregarPregunta.DataBind();
        //    }
        //}

        private void LimpiarEncuesta()
        {
            try
            {
                Session["Encuesta"] = new Encuesta();
                txtDescripcionEncuesta.Text = string.Empty;
                ddlTipoEncuesta.SelectedIndex = BusinessVariables.ComboBoxCatalogo.Index;
                chkPonderacion.Checked = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Alerta = new List<string>();
            if (!IsPostBack)
            {
                Session["Encuesta"] = new Encuesta();
                Metodos.LlenaComboCatalogo(ddlTipoEncuesta, _serviceCatalogosSistema.ObtenerTiposEncuesta(true));
            }
        }

        protected void ddlTipoEncuesta_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Encuesta tmpEncuesta = ((Encuesta)Session["Encuesta"]);
                //if (tmpEncuesta.EncuestaPregunta == null)
                //    tmpEncuesta.EncuestaPregunta = new List<EncuestaPregunta>();
                //TipoEncuesta tipoEncuesta = _serviceCatalogosSistema.TipoEncuestaId(Convert.ToInt32(ddlTipoEncuesta.SelectedValue));
                //foreach (RespuestaTipoEncuesta respuesta in tipoEncuesta.RespuestaTipoEncuesta)
                //{
                //    tmpEncuesta.EncuestaPregunta.Add(new EncuestaPregunta
                //    {
                //        Pregunta = string.Empty,
                //    });
                //}

                //rptPreguntas.DataSource = tmpEncuesta.EncuestaPregunta;
                //rptPreguntas.DataBind();
                //Session["Encuesta"] = tmpEncuesta;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                Alerta = _lstError;
            }
        }

        protected void btnLimpiarEncuesta_OnClick(object sender, EventArgs e)
        {
            try
            {
                LimpiarEncuesta();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                Alerta = _lstError;
            }
        }

        protected void btnGuardarEncuesta_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoEncuesta.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                    throw new Exception("Seleccione un tipo de encuesta");
                if (txtDescripcionEncuesta.Text.Trim() == string.Empty)
                    throw new Exception("Especifique una descripción");

                Encuesta nuevaEncuesta = ((Encuesta)Session["Encuesta"]);
                nuevaEncuesta.IdTipoEncuesta = Convert.ToInt32(ddlTipoEncuesta.SelectedValue);
                nuevaEncuesta.Descripcion = txtDescripcionEncuesta.Text.Trim();
                if (nuevaEncuesta.EncuestaPregunta == null || nuevaEncuesta.EncuestaPregunta.Count == 0)
                    throw new Exception("Debe agregar al menos una pregunta");
                if (nuevaEncuesta.EncuestaPregunta.Sum(s => s.Ponderacion) != 100)
                {
                    throw new Exception("La ponderacion debe sumar 100");
                }
                foreach (EncuestaPregunta pregunta in nuevaEncuesta.EncuestaPregunta)
                {
                    pregunta.Id = 0;
                }
                _serviceCatalogosUsuario.GuardarEncuesta(nuevaEncuesta);
                LimpiarEncuesta();
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                Alerta = _lstError;
            }
        }

        protected void btnAddPregunta_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (ddlTipoEncuesta.SelectedIndex == BusinessVariables.ComboBoxCatalogo.Index)
                    throw new Exception("Especifique el tipo de encuesta");
                if (txtPregunta.Text.Trim() == string.Empty)
                    throw new Exception("Especifique una pregunta");
                if (txtPonderacion.Text.Trim() == string.Empty)
                    throw new Exception("Especifique una ponderacion");

                Encuesta tmpEncuesta = ((Encuesta)Session["Encuesta"]);
                if (tmpEncuesta.EncuestaPregunta == null)
                    tmpEncuesta.EncuestaPregunta = new List<EncuestaPregunta>();

                TipoEncuesta tipoEncuesta = _serviceCatalogosSistema.TipoEncuestaId(Convert.ToInt32(ddlTipoEncuesta.SelectedValue));

                if (txtIdPregunta.Text.Trim() == string.Empty)
                    tmpEncuesta.EncuestaPregunta.Add(new EncuestaPregunta
                    {
                        Id = tmpEncuesta.EncuestaPregunta.Count + 1,
                        Pregunta = txtPregunta.Text.Trim(),
                        Ponderacion = decimal.Parse(txtPonderacion.Text.Trim())
                    });
                else
                {
                    EncuestaPregunta pregunta = tmpEncuesta.EncuestaPregunta.SingleOrDefault(s => s.Id == Convert.ToInt32(txtIdPregunta.Text.Trim()));
                    if (pregunta != null)
                    {
                        pregunta.Pregunta = txtPregunta.Text.Trim();
                        pregunta.Ponderacion = decimal.Parse(txtPonderacion.Text.Trim());
                    }
                }


                rptPreguntas.DataSource = tmpEncuesta.EncuestaPregunta;
                rptPreguntas.DataBind();
                Session["Encuesta"] = tmpEncuesta;
                txtIdPregunta.Text = string.Empty;
                txtPregunta.Text = string.Empty;
                txtPonderacion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                Alerta = _lstError;
            }
        }

        protected void OnClick(object sender, EventArgs e)
        {
            try
            {
                EncuestaPregunta pregunta = ((Encuesta)Session["Encuesta"]).EncuestaPregunta.SingleOrDefault(s => s.Id == Convert.ToInt32(((LinkButton)sender).CommandArgument));
                if (pregunta != null)
                {
                    txtIdPregunta.Text = pregunta.Id.ToString();
                    txtPregunta.Text = pregunta.Pregunta;
                    txtPonderacion.Text = pregunta.Ponderacion.ToString(CultureInfo.InvariantCulture);
                }
            }
            catch (Exception ex)
            {
                if (_lstError == null)
                {
                    _lstError = new List<string>();
                }
                _lstError.Add(ex.Message);
                Alerta = _lstError;
            }
        }
    }
}