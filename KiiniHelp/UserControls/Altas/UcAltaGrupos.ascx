<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAltaGrupos.ascx.cs" Inherits="KiiniHelp.UserControls.Altas.UcAltaGrupos" %>
<asp:UpdatePanel ID="upGrupoUsuario" runat="server">
    <ContentTemplate>
        <div class="alert alert-warning" id="panelAlertaGrupoUsuario" runat="server" visible="false">
            <div>
                <div style="float: left">
                    <asp:Image runat="server" ImageUrl="~/Images/error.jpg" />
                </div>
                <div style="float: left">
                    <h3>Error</h3>
                </div>
                <div class="clearfix clear-fix" />
            </div>
            <hr />
            <asp:Repeater runat="server" ID="rptErrorGrupoUsuario">
                <ItemTemplate>
                    <ul>
                        <li><%# Container.DataItem %></li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">
                 Alta de Grupos
            </div>
            <div class="panel-body">
                <div>
                    <asp:HiddenField runat="server" ID="dfIdGrupo" />
                    <asp:HiddenField runat="server" ID="dfModalPadre" />
                    <div>
                        <div class="form-group">
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Tipo de Grupo</label>
                                <asp:DropDownList runat="server" ID="ddlTipoGrupo" CssClass="DropSelect" OnSelectedIndexChanged="ddlTipoGrupo_OnSelectedIndexChanged" AutoPostBack="True" />
                            </div>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">Descripcion</label>
                                <asp:TextBox runat="server" ID="txtDescripcionGrupoUsuario" placeholder="DESCRIPCION" class="form-control" />
                            </div>
                            <div class="panel panel-primary" style="width: 300px" runat="server" visible="False" id="divTipoSubgrupo">
                                <div class="panel-heading">
                                    <div>
                                        <h3 class="panel-title">Tipo SubGrupo</h3>
                                    </div>
                                </div>
                                <div class="panel-body">
                                    <asp:CheckBoxList runat="server" ID="chkLbxSubGrupoUsuario" AutoPostBack="True" />
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:CheckBox runat="server" ID="chkGrupoUsuario" Checked="True" Visible="False" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel-footer" style="text-align: center">
                <asp:Button ID="btnGuardarGrupoUsuario" runat="server" CssClass="btn btn-lg btn-success" Text="Guardar" OnClick="btnGuardarGrupoUsuario_OnClick" />
                <asp:Button ID="btnLimpiarGrupoUsuario" runat="server" CssClass="btn btn-lg btn-danger" Text="Limpiar" OnClick="btnLimpiarGrupoUsuario_OnClick" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
