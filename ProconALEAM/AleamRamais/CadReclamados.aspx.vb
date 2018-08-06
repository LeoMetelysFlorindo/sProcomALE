'Aplicativo para a Comissão de Defesa do Consumidor
'Data de criação: 16/10/2015 08:00
'Desenvolvedor: Leonardo Metelys - Gerência de Aplicativos - ALEAM
'Formulário de Cadastro dos Reclamados
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net.Mail
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.TimeSpan
Imports System.Globalization.CultureInfo
Imports MySql.Data.MySqlClient
Imports System.Threading.Thread
Imports System.Globalization
Imports System.IO
Imports AleamRamais.Classes


Public Class CadReclamados1
    Inherits System.Web.UI.Page
    'Conexão com o MYSQL
    Const ConnStr As String = "Driver={MySQL ODBC 5.1 Driver};" + "Server=172.16.0.32;Database=proconaleam;uid=intranetadmin;pwd=Intranet@Al34m;option=3"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Pegar os dados do usuário logado
        If Not Page.IsPostBack Then

            'Dim currentADUser As System.DirectoryServices.AccountManagement.UserPrincipal
            'currentADUser = System.DirectoryServices.AccountManagement.UserPrincipal.Current
            'Dim userEmail As String = currentADUser.EmailAddress
            'Dim sUsuario As String = currentADUser.Name

            ''Informando o nome do usuário logado na rede
            ''sUsuario = Request.QueryString("id")
            'LbUsuario.Text = "Usuário Login: " + sUsuario
            'LbUsuario.Visible = True

            txtCodigo.Focus()

        End If
    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click, btnSalvar.Click

        Dim sCPF As String = ""
        Dim sCNPJ As String = ""

        If txtCodigo.Text <> "" Then

            If TxtNome.Text = "" Then

                lblAviso.Text = "Nome Reclamado não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If TxtCnpj.Text = "" Then

                lblAviso.Text = "CNPJ Reclamado não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If TxtEndereco.Text = "" Then

                lblAviso.Text = "Endereço Reclamado não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If


            If Txtbairro.Text = "" Then

                lblAviso.Text = "Bairro Reclamado não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If Len(TxtCnpj.Text) <= 14 Then
                sCPF = TxtCnpj.Text
            ElseIf Len(TxtCnpj.Text) >= 14 Then
                sCNPJ = TxtCnpj.Text
            End If


            Dim Objconn As New SqlDbConnect()
            Dim ssQL As String = "SELECT codigo FROM reclamado WHERE codigo  =  '" & Trim(txtCodigo.Text) & "'"

            Objconn.Conectar()

            Objconn.Parametros.Clear()

            Objconn.SetarSQL(ssQL)

            Objconn.Executar()

            '
            If Objconn.Tabela.Rows.Count > 0 Then



                Objconn.Conectar()
                Objconn.Parametros.Clear()
                ssQL = "UPDATE reclamado SET reclamado = '" + TxtNome.Text.ToUpper() & "', " & _
                                 "CNPJ = '" & sCNPJ & "', " & _
                                 "CPF = '" & sCPF & "', " & _
                                 "endereco = '" & TxtEndereco.Text.ToUpper() & "', bairro  = '" & TxtBairro.Text.ToUpper() & "', " & _
                                 "cep  = '" & TxtCEP.Text & "', " & _
                                 "cidade = '" & TxtCidade.Text.ToUpper() & "', " & _
                                 "uf = '" & TxtUF.Text.ToUpper() & "' WHERE codigo = '" & Trim(txtCodigo.Text) & "' "

                Objconn.SetarSQL(ssQL)

                Objconn.Executar()

                If Objconn.Executar() = False Then

                    lblAviso.Text = "Erro de alteração de dados."
                    lblAviso.Visible = True

                Else

                    lblAviso.Text = "Alteração efetuada com sucesso."
                    lblAviso.Visible = True

                End If

                Objconn.Desconectar()

            Else


                Objconn.Conectar()
                Objconn.Parametros.Clear()

                ssQL = "INSERT INTO reclamado (codigo,reclamado,CNPJ,CPF,endereco,bairro,cep,cidade,uf) VALUES ('" & Trim(txtCodigo.Text) & "','" & _
                                 TxtNome.Text.ToUpper() & "','" & Trim(sCNPJ) & "','" & Trim(sCPF) & "','" & _
                                 Trim(TxtEndereco.Text.ToUpper) & "','" & Trim(Txtbairro.Text.ToUpper()) & "','" & TXTCep.Text & "','" & TxtCidade.Text.ToUpper() & "','" & TxtUF.Text.ToUpper() & "')"

                Objconn.SetarSQL(ssQL)

                If Objconn.Executar() = False Then

                    lblAviso.Text = "Erro de inserção de dados."
                    lblAviso.Visible = True
                Else

                    lblAviso.Text = "Inserção efetuada com sucesso."
                    lblAviso.Visible = True

                End If

                Objconn.Desconectar()

            End If



        End If

    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        txtCodigo.Enabled = True

        txtCodigo.Text = ""
        TxtNome.Text = ""
        TxtCnpj.Text = ""
        TxtEndereco.Text = ""
        TxtCidade.Text = ""
        Txtbairro.Text = ""
        TXTCep.Text = ""
        TxtUF.Text = ""
        lblAviso.Visible = False
        txtCodigo.Focus()

    End Sub

    Protected Sub btnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub bntPesquisar_Click(sender As Object, e As ImageClickEventArgs) Handles bntPesquisar.Click

        If txtCodigo.Text <> "" Then



            Dim sAdmissao As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamado WHERE codigo =  '" & Trim(txtCodigo.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows

                    TxtNome.Text = DataRow("reclamado").ToString()
                    TxtCnpj.Text = DataRow("cnpj").ToString()
                    TxtEndereco.Text = DataRow("endereco").ToString()
                    TxtCidade.Text = DataRow("cidade").ToString()
                    Txtbairro.Text = DataRow("bairro").ToString()
                    TXTCep.Text = DataRow("cep").ToString()
                    TxtUF.Text = DataRow("uf").ToString()

                Next

                txtCodigo.Enabled = False

            Else

                txtCodigo.Enabled = False

                TxtNome.Text = ""
                TxtCnpj.Text = ""
                TxtEndereco.Text = ""
                TxtCidade.Text = ""
                Txtbairro.Text = ""
                TXTCep.Text = ""
                TxtUF.Text = ""

                TxtNome.Focus()

            End If

            Objconn.Desconectar()

        End If

    End Sub

    Protected Sub btnNovo_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click, BtnNovo.Click
        'Novo Registro

        Dim Objconn As New SqlDbConnect()
        Objconn.Conectar()
        Objconn.Parametros.Clear()

        'Gerar automaticamente o próximo código de registro
        Objconn.SetarSQL("SELECT count(codigo)+ 1 as NovoCodigo FROM reclamado")
        Objconn.Executar()

        If Objconn.Tabela.Rows.Count > 0 Then

            For Each DataRow In Objconn.Tabela.Rows

                txtCodigo.Text = DataRow("NovoCodigo").ToString()

            Next


        End If

        TxtNome.Text = ""
        TxtCnpj.Text = ""
        TxtEndereco.Text = ""
        TxtCidade.Text = ""
        Txtbairro.Text = ""
        TXTCep.Text = ""
        TxtUF.Text = ""

        TxtNome.Focus()

        'Usuário NUNCA DEVE TRATAR O CÓDIGO INTERNO
        txtCodigo.Enabled = False

        TxtNome.Focus()

    End Sub

    Protected Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged

        If txtCodigo.Text <> "" Then


            Dim sAdmissao As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamado WHERE codigo =  '" & Trim(txtCodigo.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows

                    TxtNome.Text = DataRow("reclamado").ToString()

                    If Not IsDBNull(DataRow("CNPJ").ToString()) Then
                        TxtCnpj.Text = DataRow("CNPJ").ToString()
                    End If

                    If Not IsDBNull(DataRow("CPF").ToString()) Then
                        TxtCnpj.Text = DataRow("CPF").ToString()
                    End If

                    TxtEndereco.Text = DataRow("endereco").ToString()
                    TxtCidade.Text = DataRow("cidade").ToString()
                    Txtbairro.Text = DataRow("bairro").ToString()
                    TXTCep.Text = DataRow("cep").ToString()
                    TxtUF.Text = DataRow("uf").ToString()



                Next

                txtCodigo.Enabled = False

            Else

                txtCodigo.Enabled = False
                TxtNome.Text = ""
                TxtCnpj.Text = ""
                TxtEndereco.Text = ""
                TxtCidade.Text = ""
                Txtbairro.Text = ""
                TXTCep.Text = ""
                TxtUF.Text = ""


                TxtNome.Focus()

            End If

            Objconn.Desconectar()


        End If

    End Sub
End Class