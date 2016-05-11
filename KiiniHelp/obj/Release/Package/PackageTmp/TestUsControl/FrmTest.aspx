<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmTest.aspx.cs" Inherits="KiiniHelp.TestUsControl.FrmTest" %>
<%@ Register Src="~/UserControls/Altas/UcAltaInformacionConsulta.ascx" TagPrefix="uc1" TagName="UcAltaInformacionConsulta" %>
<%@ Register Src="~/UserControls/Altas/UcAltaMascaraAcceso.ascx" TagPrefix="uc1" TagName="UcAltaMascaraAcceso" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function CierraPopup(modalName) {
            debugger;
            $(modalName).modal('hide');
            return true;
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <uc1:UcAltaMascaraAcceso runat="server" ID="UcAltaMascaraAcceso" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>

        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<div class="modal fade" id="modalTest" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <uc1:UcEncuesta runat="server" id="UcEncuesta1" />
    </div>--%>
</asp:Content>
