<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="rptAbrirRelatorio_2.aspx.vb" Inherits="AleamRamais.rptAbrirRelatorio_2" %>



<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <a href="rptAbrirRelatorio_2.aspx"></a><CR:CrystalReportViewer ID="crView" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1269px" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelView="None" ToolPanelWidth="200px" Width="1082px"  ClientIDMode="Static" DisplayStatusbar="False" DisplayToolbar="False" EnableDrillDown="False" EnableParameterPrompt="False" EnableTheming="False" EnableToolTips="False" GroupTreeStyle-ShowLines="False" HasDrilldownTabs="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" SeparatePages="False" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <report filename="rptRelFichaAtendimento.rpt">
            </report>
        </CR:CrystalReportSource>
    <div>
    <div class="blocoeditor">
                        <br />
                    </div>
       
    
    </div>
        <a href="rptAbrirRelatorio_2.aspx">rptAbrirRelatorio_2.aspx</a></form>
</body>
</html>
