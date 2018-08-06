<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="ConsReclamados.aspx.vb" Inherits="AleamRamais.ConsReclamados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    
   
    <table>
    <td class="style526">

        <asp:Panel ID="Panel15" runat="server" BorderStyle="None" Width="961px">
            <asp:Label ID="Label2" runat="server" Text="Nome Reclamado:" 
                BackColor="White" 
                style="font-size: medium; font-weight: 700; font-family: 'Trebuchet MS'; margin-left: 11px;"></asp:Label>
            <asp:TextBox ID="TxtSolicitante" runat="server" Height="23px" Width="489px"></asp:TextBox>
            <asp:Button ID="TxtPesquisar" runat="server" BackColor="Gray" 
                BorderColor="Black" BorderStyle="Groove" Height="29px" 
                style="font-size: medium; font-weight: 700; font-family: 'Trebuchet MS'; margin-left: 18px; margin-top: 6px" 
                Text="Pesquisar" Width="91px" />
        </asp:Panel>

    </td>
    </table>
    <table>
    <td class="style527">

         <asp:GridView ID="gdItens" runat="server" 
        CaptionAlign="Top" DataKeyNames="Codigo"
                       Height="47px" Style="margin-left: 15px; margin-top: 19px;
                        color: #000000; font-size: medium;" Width="1184px" 
        Caption="Reclamados" SelectedIndex="1" PageSize="20" 
    GridLines="None" UseAccessibleHeader="False"
                        CellPadding="8" ForeColor="#333333" TabIndex="3">
                        <AlternatingRowStyle BackColor="White" />                        
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" />
                        <PagerStyle Height="30px" BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="false" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView> 
        <asp:Timer ID="sAtualiza" runat="server" Enabled="False" Interval="100">
        </asp:Timer>
    </td>
    </table>
    
    </div>
</asp:Content>
