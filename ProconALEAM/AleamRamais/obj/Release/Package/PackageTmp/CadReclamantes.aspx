<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CadReclamantes.aspx.vb" Inherits="AleamRamais.CadReclamados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    
   <div class="blocoGrupoCampos" style="margin-left: 25px; width: 800px;">
        <fieldset class="bordaFieldset" style="width:780px; height: 419px;">
            <legend>Cadastro de Reclamantes</legend>
           
            
            <div class="blocoGrupoCampos">
                <div class="blocoeditor">
                    <label>
                        Cod. Reclamante</label>
                    <br />
                    <asp:TextBox ID="txtCodigo" runat="server" Width="100px">
                    </asp:TextBox>
                     
                                       
                </div>
                <div class="blocoeditor">
                <asp:ImageButton ID="bntPesquisar" runat="server" 
                        ImageUrl="~/Images/pesq.jpg" 
                        Style="background-image: url(~/Styles/Imagens/pesqback.jpg);
                            background-repeat: no-repeat; margin-top:10px; background-position: right;" BackColor="#FF3300"
                            ForeColor="Black" BorderColor="#333300" Height="26px" Width="55px" />                  
                </div>
                <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Nome</label>
                    <br />
                    <asp:TextBox ID="TxtNome" runat="server" Width="300px" TabIndex="1"></asp:TextBox>
                    
                </div>
                <div class="blocoeditor">
                 <label>
                      RG</label>
                    <br />
                    <asp:TextBox ID="TxtRG" runat="server" Width="100px" TabIndex="2"></asp:TextBox>
                </div>
                <br />
                
            </div>
           <div class="blocoeditor">
                 <label>
                        Natural DE</label>
                    <br />
                    <asp:TextBox ID="TxtNaturalidade" runat="server" Width="200px" TabIndex="3"></asp:TextBox>
                </div>
             <div class="blocoeditor">
                 <label>
                        UF</label>
                    <br />
                    <asp:TextBox ID="TxtUF" runat="server" Width="90px" TabIndex="4"></asp:TextBox>
                </div>
                <div class="blocoeditor">
                 <label>
                        Data Nascimento</label>
                    <br />
                    <asp:TextBox ID="TxtDataNasc" runat="server" Width="115px" AutoPostBack="True" TabIndex="5"></asp:TextBox>
                </div>
                <div class="blocoeditor">
                 <label>
                        Estado Civil</label>
                    <br />
                    <asp:TextBox ID="TxtEstadoCivil" runat="server" Width="200px" TabIndex="6"></asp:TextBox>
                </div>
            
                <div class="blocoeditor" style="margin-left: 0px;">
                 <div class="blocoeditor">
                 <label>
                        CPF</label>
                    <br />
                    <asp:TextBox ID="TxtCPF" runat="server" Width="136px" TabIndex="7"></asp:TextBox>
                </div>
                 <div class="blocoeditor">
                     <label>
                        Filiação</label>
                    <br />
                    <asp:TextBox ID="TxtFiliacao" runat="server" Width="521px" TabIndex="8"></asp:TextBox>
                    
                </div>
                
                 <div class="blocoeditor" style="margin-left: 0px;">
                 <div class="blocoeditor">
                 <label>
                        Contato</label>
                    <br />
                    <asp:TextBox ID="TxtContato" runat="server" Width="136px" TabIndex="9"></asp:TextBox>
                </div>
                <div class="blocoeditor">
                     <label>
                        Endereço</label>
                    <br />
                    <asp:TextBox ID="TxtEndereco" runat="server" Width="364px" TabIndex="10"></asp:TextBox>
                    
                </div>                
                <br />
                     <div class="blocoeditor" style="margin-left: 0px;">
                 <div class="blocoeditor">
                 <label>
                        Bairro</label>
                    <br />
                    <asp:TextBox ID="Txtbairro" runat="server" Width="306px" TabIndex="11"></asp:TextBox>
                </div>
                <div class="blocoeditor">
                     <label>
                        CEP</label>
                    <br />
                    <asp:TextBox ID="TXTCep" runat="server" Width="96px" TabIndex="12"></asp:TextBox>
                    
                </div> 
                         <div class="blocoeditor">
                     <label>
                        Profissão</label>
                    <br />
                    <asp:TextBox ID="TxtProfissao" runat="server" Width="188px" TabIndex="13"></asp:TextBox>
                    
                </div>  

             </div>
                <div class="blocoGrupoCampos">
                    <div class="blocoeditor">
                      <br />
                      <asp:Button ID="BtnNovo" ValidationGroup="btnNovo" runat="server" Width="100px"
                       Text="Novo" OnClick="btnNovo_Click" />
                    </div>
                    
                     <div class="blocoeditor">
                        <br />
                        <asp:Button ID="btnSalvar" ValidationGroup="btnSalvar" runat="server" Width="100px"
                            Text="Salvar" OnClick="btnSalvar_Click" />
                    </div>
                    <div class="blocoeditor">
                        <br />
                        <asp:Button ID="btnCancelar" runat="server" Width="100px" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>

                    <div class="blocoeditor">
                        <br />
                        <asp:Button ID="BtnMenu" runat="server" Width="100px" Text="Menu" OnClick="btnMenu_Click" />
                    </div>
                </div>
                <div class="blocoGrupoCampos" style="margin-left: 25px;">
                <div class="blocoeditor">
                    <asp:Label ID="lblAviso" runat="server" Text="Erro ou Invalido." ForeColor="Red"
                        Visible="false"></asp:Label>
                </div>
                 </div>
        </fieldset>
    </div>
     <br />
    <br />
    <br />
    <br />
    <br />
    <br />
     <br />
    <br />
    <br />
    <br />
    <br />
     <br />
    <br />
    <br />
</asp:Content>
