<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FormLogin.aspx.vb" Inherits="AleamRamais.FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />     
    <title><%: Page.Title %> - My ASP.NET Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" /> 
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">        
        <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <script src="<%: ResolveUrl("~/Scripts/modernizr-2.5.3.js") %>"></script>
    </asp:PlaceHolder>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <meta name="viewport" content="width=device-width" />
   

</head>
<body>
    <form id="form1" runat="server">
         <header>
   <div id="mydiv" style="font-family: Arial Black; font-size: 24pt; width:100%;background:#7AC0DA">
    <section class="featured" style="height: 154px; color: #7AC0DA;">
         <asp:Table ID="Table3" runat="server" Height="144px"  Width="1158px"> 
             <asp:TableRow ID="TableRow27" runat="server" ForeColor="Teal">   
                 <asp:TableCell> <a href="#"><img src="Images/brasao_menor.png"  width="40%" id="Insert_logo" style="background:#7AC0DA; margin-left: 20px; margin-top: 20px;" /></a> </asp:TableCell>                 
                  <asp:TableCell> 
                      <div style="font-family: Arial Black;  font-size: 14pt; height: 46px; margin-bottom: 19px;">
            
                <h1 style="height: 43px;">COMISSÃO DE DEFESA DO CONSUMIDOR</h1>                
           
        </div>  
                            
       </asp:TableCell>                               
               
            </asp:TableRow>
                   
         </asp:Table>

    </section>
    </div>
      
    </header>
     <div class="blocoGrupoCampos">
     <div class="blocoeditor">
           <label Style="margin-left: 28px;" >USUÁRIO</label>
           <br/>        
           <asp:TextBox runat="server" ID="UserName" AutoPostBack="True" />
           <asp:RequiredFieldValidator Style="margin-left: 0px;"  ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="Campo obrigatório." ForeColor="#FF3300" />
        
   
           <br/>    
            <label Style="margin-left: 10px;" >
                        SENHA DE ACESSO</label>
                            <br />
                            <asp:TextBox runat="server" Style="margin-left: 0px;"  ID="Password" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="Campo obrigatório." ForeColor="#FF3300" />
                       
          <br />
          
         <asp:Button ID="Button1" Style="margin-left: 10px;"  runat="server" CommandName="Login" Text="Entrar" Width="91px"  />
          </div>
    </div>
    </form>
</body>
</html>
