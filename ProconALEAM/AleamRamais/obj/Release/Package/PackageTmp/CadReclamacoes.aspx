<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CadReclamacoes.aspx.vb" Inherits="AleamRamais.CadReclamacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

   
   <div class="blocoGrupoCampos" style="margin-left: 25px; width: 800px;">
        <fieldset class="bordaFieldset" style="width:780px;">
            <legend>Cadastro de Reclamações</legend>
            
            <asp:CheckBox ID="ChkFicha" Text="PDF Ficha Atendimento" runat="server" />
            <asp:CheckBox ID="ChkCadastro" Text="PDF Reclamação" runat="server" />
           
            
            <div class="blocoGrupoCampos">
                <div class="blocoeditor">
                    <label>
                        Cod. Reclamação</label>
                    <br />
                    <asp:TextBox ID="TxtCodReclamacao" runat="server" Width="100px" Enabled="True"></asp:TextBox>                                       
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
                        Data</label>
                    <br />
                    <asp:TextBox ID="TxtData" runat="server" Width="100px" TabIndex="1"></asp:TextBox>
                    
                </div>
                
                <br />
            </div>
            <div class="blocoGrupoCampos">   
                <div class="blocoeditor">
                    <label>
                        Cod. Reclamante</label>
                    <br />
                    <asp:TextBox ID="TxtReclamante" runat="server" Width="100px" TabIndex="2"></asp:TextBox>
                     
                                       
                </div>
                <div class="blocoeditor">
                <asp:ImageButton ID="bntPesReclamente" runat="server" 
                        ImageUrl="~/Images/pesq.jpg" 
                        Style="background-image: url(~/Styles/Imagens/pesqback.jpg);
                            background-repeat: no-repeat; margin-top:10px; background-position: right;" BackColor="#FF3300"
                            ForeColor="Black" BorderColor="#333300" Height="26px" Width="55px" />                  
                </div>
                <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Nome Reclamante</label>
                    <br />
                    <asp:TextBox ID="TxtNomereclamante" runat="server" Width="300px" TabIndex="3"></asp:TextBox>
                    
                </div>
            </div>
           
            <div class="blocoGrupoCampos">   
                <div class="blocoeditor">
                    <label>
                        Cod. Reclamado</label>
                    <br />
                    <asp:TextBox ID="TxtCodReclamado" runat="server" Width="100px" TabIndex="4"></asp:TextBox>
                     
                                       
                </div>
                <div class="blocoeditor">
                <asp:ImageButton ID="bntPesReclamado" runat="server" 
                        ImageUrl="~/Images/pesq.jpg" 
                        Style="background-image: url(~/Styles/Imagens/pesqback.jpg);
                            background-repeat: no-repeat; margin-top:10px; background-position: right;" BackColor="#FF3300"
                            ForeColor="Black" BorderColor="#333300" Height="26px" Width="55px" />                  
                </div>
                <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Nome Reclamado</label>
                    <br />
                    <asp:TextBox ID="TxtNomereclamado" runat="server" Width="300px" TabIndex="5"></asp:TextBox>
                    
                </div>
            </div>

            <div class="blocoGrupoCampos">   
                <div class="blocoeditor">
                    <label>
                       Motivo da Reclamação</label>
                    <br />
                   <asp:DropDownList runat="server" Height="21px" Width="323px" ID="CmbMotivo" AutoPostBack="True" TabIndex="6"></asp:DropDownList>                                         
                                       
                </div>
                <br />
             </div>     
             <div class="blocoGrupoCampos">   
                <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Fato Ocorrido</label>
                    <br />
                    <asp:TextBox ID="TxtFato" runat="server" Width="610px" TabIndex="7" Height="36px" TextMode="MultiLine"></asp:TextBox>
                    
                </div>
            </div>

            <div class="blocoGrupoCampos">   
                                
                <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Do Pedido</label>
                    <br />
                    <asp:TextBox ID="txtPedido" runat="server" Width="610px" TabIndex="8" Height="29px" TextMode="MultiLine"></asp:TextBox>
                    
                </div>
            </div>
           
            <br />
             <div class="blocoGrupoCampos">   
                <div class="blocoeditor">
                    <label>
                       Audiência Marcada Para</label>
                    <br />
                  <asp:TextBox ID="TxtAudiencia" runat="server" Width="148px" TabIndex="9" ></asp:TextBox>                                         
                                       
                </div>
                
                <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Hora</label>
                    <br />
                    <asp:TextBox ID="TxtHora" runat="server" Width="100px" TabIndex="10" ></asp:TextBox>                    
                </div>
                    <div class="blocoeditor">
                    <label style=" margin-left:0px;">
                        Nº Notificação</label>
                    <br />
                    <asp:TextBox ID="TxtNotificacao" runat="server" Width="109px" TabIndex="11" ></asp:TextBox>                    
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
                        <asp:Button ID="BtnImprimir" runat="server" Width="100px" Text="Imprimir" OnClick="btnImprmir_Click" />
                    </div>
                    <div class="blocoeditor">
                        <br />
                        <asp:Button ID="BtnImprimir_2" runat="server" Width="118px" Text="Ficha Atendimento" OnClick="btnImprmir_2_Click"  />
                    </div>

                    <div class="blocoeditor">
                        <br />
                        <asp:Button ID="BtnMenu" runat="server" Width="100px" Text="Gerar PDF" OnClick="btnMenu_Click" />
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
          <br />
     <br />
       <br />  
      <br />
     <br />
       <br />  
</asp:Content>

