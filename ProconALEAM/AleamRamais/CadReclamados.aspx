<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CadReclamados.aspx.vb" Inherits="AleamRamais.CadReclamados1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
  
     
   <div class="blocoGrupoCampos" style="margin-left: 25px; width: 800px;">
        <fieldset class="bordaFieldset" style="width:780px;">
            <legend>Cadastro de Reclamados</legend>
                       
            <div class="blocoGrupoCampos">
                <div class="blocoeditor">
                    <label>
                        Cod. Reclamado</label>
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
                        Nome Reclamado</label>
                    <br />
                    <asp:TextBox ID="TxtNome" runat="server" Width="300px" TabIndex="1"></asp:TextBox>
                    
                </div>
                <div class="blocoeditor">
                 <label>
                      CNPJ / CPF</label>
                    <br />
                    <asp:TextBox ID="TxtCnpj" runat="server" Width="150px" TabIndex="2"></asp:TextBox>
                </div>
                <br />
                
            </div>

            <div class="blocoGrupoCampos"  style="margin-left: 0px;  width: 800px;">
                <div class="blocoeditor">
                 <label>
                        Endereço</label>
                    <br />
                    <asp:TextBox ID="TxtEndereco" runat="server" Width="450px" TabIndex="3"></asp:TextBox>
                </div>
                <div class="blocoeditor">
                     <label>
                        Cidade</label>
                    <br />
                    <asp:TextBox ID="TxtCidade" runat="server" Width="210px" TabIndex="4"></asp:TextBox>                    
                </div>
               <br />
           </div>    
           <div class="blocoGrupoCampos"  style="margin-left: 0px; width: 800px;"> 
                 <div class="blocoeditor">
                 <label>
                        Bairro</label>
                    <br />
                    <asp:TextBox ID="TxtBairro" runat="server" Width="336px" TabIndex="5"></asp:TextBox>
                </div>
                 <div class="blocoeditor">
                     <label>
                        CEP</label>
                    <br />
                    <asp:TextBox ID="TxtCEP" runat="server" Width="100px" TabIndex="6"></asp:TextBox>                    
                </div>
                <div class="blocoeditor">
                     <label>
                        UF</label>
                    <br />
                    <asp:TextBox ID="TxtUF" runat="server" Width="80px" TabIndex="7"></asp:TextBox>                    
                </div>

             </div>
                <div class="blocoGrupoCampos"  style="margin-left: 25px;  width: 800px;">
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
                <div class="blocoGrupoCampos"  style="margin-left: 25px;  width: 800px;" >
                <div class="blocoeditor">
                    <asp:Label ID="lblAviso" runat="server" Text="Erro ou Invalido." ForeColor="Red"
                        Visible="false"></asp:Label>
                </div>
                 </div>
        </fieldset>
        </div>
       <br/>
       <br/>
      <br/>
       <br/>
     <br/>
       <br/>
     <br/>
       <br/>
      
      
       
   
    

</asp:Content>
