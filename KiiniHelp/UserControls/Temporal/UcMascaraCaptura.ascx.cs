using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using KiiniHelp.ServiceMascaras;
using KiiniNet.Entities.Cat.Mascaras;

namespace KiiniHelp.UserControls.Temporal
{
    public partial class UcMascaraCaptura : System.Web.UI.UserControl
    {
        readonly ServiceMascarasClient _serviceMascaras = new ServiceMascarasClient();
        private void PintaControles(List<CampoMascara> lstControles)
        {
            try
            {
                foreach (CampoMascara campo in lstControles)
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl createDiv =
                        new System.Web.UI.HtmlControls.HtmlGenericControl("DIV") {ID = "createDiv" + campo.Descripcion};
                    createDiv.Attributes["class"] = "form-group";
                    createDiv.InnerHtml = campo.Descripcion;

                    switch (campo.TipoCampoMascara.Descripcion)
                    {
                        case "ALFANUMERICO":
                            TextBox txtAlfanumerico = new TextBox
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "form-control"
                            };
                            createDiv.Controls.Add(txtAlfanumerico);
                            break;
                        case "CATALOGO":
                            DropDownList ddlCatalogo = new DropDownList
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "DropSelect"
                            };
                            createDiv.Controls.Add(ddlCatalogo);
                            break;
                        case "DECIMAL":
                            TextBox txtDecimal = new TextBox
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "form-control"
                            };
                            createDiv.Controls.Add(txtDecimal);
                            break;
                        case "ENTERO":
                            TextBox txtEntero = new TextBox
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "form-control"
                            };
                            createDiv.Controls.Add(txtEntero);
                            break;
                        case "FECHA":
                            TextBox txtFecha = new TextBox
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "form-control"
                            };
                            createDiv.Controls.Add(txtFecha);
                            break;
                        case "HORA":
                            TextBox txtHora = new TextBox
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "form-control"
                            };
                            createDiv.Controls.Add(txtHora);
                            break;
                        case "MONEDA":
                            TextBox txtMoneda = new TextBox
                            {
                                ID = "txt" + campo.Descripcion.Replace(" ", string.Empty),
                                Text = campo.Descripcion,
                                CssClass = "form-control"
                            };
                            createDiv.Controls.Add(txtMoneda);
                            break;
                        case "SI/NO":
                            CheckBox chk = new CheckBox { ID = "chk" + campo.Descripcion.Replace(" ", string.Empty), Text = campo.Descripcion };
                            createDiv.Controls.Add(chk);
                            break;
                    }
                    divControles.Controls.Add(createDiv);
                }
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
                PintaControles(_serviceMascaras.ObtenerMascaraCaptura(8).CampoMascara);
            }
        }
    }
}