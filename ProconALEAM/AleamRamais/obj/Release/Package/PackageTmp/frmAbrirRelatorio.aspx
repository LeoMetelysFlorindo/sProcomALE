<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmAbrirRelatorio.aspx.vb" Inherits="AleamRamais.frmAbrirRelatorio" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <a href="frmAbrirRelatorio.aspx"></a><CR:CrystalReportViewer ID="crView" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1269px" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelView="None" ToolPanelWidth="200px" Width="1082px"  ClientIDMode="Static" DisplayStatusbar="False" DisplayToolbar="False" EnableDrillDown="False" EnableParameterPrompt="False" EnableTheming="False" EnableToolTips="False" GroupTreeStyle-ShowLines="False" HasDrilldownTabs="False" HasToggleGroupTreeButton="False" HasToggleParameterPanelButton="False" SeparatePages="False" />
        <CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
            <Report FileName="rptRelAudiencias.rpt">
            </Report>
        </CR:CrystalReportSource>
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="rptRelReclamacao.rpt">
            </Report>
        </CR:CrystalReportSource>
    <div>
    
       
    
    </div>
    </form>
</body>
</html>
