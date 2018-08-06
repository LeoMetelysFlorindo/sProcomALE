'Aplicativo para a Comissão de Defesa do Consumidor
'Data de criação: 16/10/2015 08:00
'Desenvolvedor: Leonardo Metelys - Gerência de Aplicativos - ALEAM
'Formulário de Cadastro dos Reclamantes

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

Public Class CadReclamados
    Inherits System.Web.UI.Page

    Dim strSQL As String = ""
    Dim sData As String = ""

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

    Protected Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click, BtnMenu.Click, BtnMenu.Click, BtnMenu.Click, BtnMenu.Click
        Response.Redirect("Default.aspx")
    End Sub


    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        txtCodigo.Enabled = True
        txtCodigo.Text = ""
        TxtNome.Text = ""
        TxtRG.Text = ""
        TxtNaturalidade.Text = ""
        TxtUF.Text = ""
        TxtDataNasc.Text = ""
        TxtEstadoCivil.Text = ""
        TxtCPF.Text = ""
        TxtFiliacao.Text = ""
        TxtContato.Text = ""
        TxtEndereco.Text = ""
        Txtbairro.Text = ""
        TXTCep.Text = ""
        lblAviso.Visible = False
        txtCodigo.Focus()

    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click, BtnNovo.Click

        If txtCodigo.Text <> "" Then

            If TxtNome.Text = "" Then

                lblAviso.Text = "Nome Reclamante não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If TxtRG.Text = "" Then

                lblAviso.Text = "RG Reclamante não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If TxtEndereco.Text = "" Then

                lblAviso.Text = "Endereço Reclamante não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If


            If TxtContato.Text = "" Then

                lblAviso.Text = "Contato Reclamante não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If


            Dim Objconn As New SqlDbConnect()
            Dim ssQL As String = ""
            Objconn.Conectar()
            Objconn.Parametros.Clear()

            Objconn.SetarSQL("SELECT codreclamante  FROM reclamante WHERE codreclamante =  '" & Trim(txtCodigo.Text) & "'")
            Objconn.Executar()
            Objconn.Desconectar()
            '
            If Objconn.Tabela.Rows.Count > 0 Then

                Dim Ano As String = Mid(TxtDataNasc.Text, 7, 4)
                Dim Mes As String = Mid(TxtDataNasc.Text, 4, 2)
                Dim Dia As String = Mid(TxtDataNasc.Text, 1, 2)
                Dim sAdmissao As String = Ano + "-" + Mes + "-" + Dia


                Objconn.Conectar()
                Objconn.Parametros.Clear()
                ssQL = "UPDATE reclamante SET reclamante = '" + TxtNome.Text.ToUpper() & "', " & _
                                 "RG =  '" & TxtRG.Text & "', datanasc = '" & sAdmissao & "', " & _
                                 "naturalidade = '" & TxtNaturalidade.Text.ToUpper() & "', cpf  = '" & TxtCPF.Text & "', " & _
                                 "estadocivil = '" & TxtEstadoCivil.Text.ToUpper() & "', uf  = '" & TxtUF.Text.ToUpper() & "', " & _
                                 "endereco = '" & TxtEndereco.Text.ToUpper() & "', bairro  = '" & Txtbairro.Text.ToUpper() & "', " & _
                                 "contato = '" & TxtContato.Text.ToUpper() & "', cep  = '" & TXTCep.Text & "', " & _
                                 "profissao = '" & TxtProfissao.Text.ToUpper() & "', " & _
                                 "filiacao = '" & TxtFiliacao.Text.ToUpper() & "' WHERE codreclamante = '" & Trim(txtCodigo.Text) & "' "

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

                Dim Ano As String = Mid(TxtDataNasc.Text, 7, 4)
                Dim Mes As String = Mid(TxtDataNasc.Text, 4, 2)
                Dim Dia As String = Mid(TxtDataNasc.Text, 1, 2)
                Dim sAdmissao As String = Ano + "-" + Mes + "-" + Dia

                ssQL = "INSERT INTO reclamante (codreclamante,reclamante,datanasc,naturalidade,rg, " & _
                                 "cpf,estadocivil,uf,filiacao,endereco,bairro,contato,cep,profissao) VALUES ('" & Trim(txtCodigo.Text) & "','" & _
                                 TxtNome.Text.ToUpper() & "','" & Trim(sAdmissao) & "','" & TxtNaturalidade.Text.ToUpper() & "','" & _
                                 Trim(TxtRG.Text) & "','" & Trim(TxtCPF.Text) & "','" & TxtEstadoCivil.Text.ToUpper() & "','" & TxtUF.Text.ToUpper() & "','" & TxtFiliacao.Text.ToUpper() & "', '" & _
                                 TxtEndereco.Text.ToUpper & "','" & Txtbairro.Text.ToUpper() & "', '" & TxtContato.Text.ToUpper() & "', '" & _
                                 TXTCep.Text & "','" & TxtProfissao.Text.ToUpper() & "')"



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

    Protected Sub bntPesquisar_Click(sender As Object, e As ImageClickEventArgs) Handles bntPesquisar.Click



        If txtCodigo.Text <> "" Then



            Dim sAdmissao As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            strSQL = "SELECT * FROM reclamante WHERE codreclamante =  '" & Trim(txtCodigo.Text) & "'"


            Objconn.SetarSQL(strSQL)
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows

                    TxtNome.Text = DataRow("reclamante").ToString()
                    TxtRG.Text = DataRow("rg").ToString()
                    TxtNaturalidade.Text = DataRow("naturalidade").ToString()
                    TxtUF.Text = DataRow("uf").ToString()

                    sData = DataRow("datanasc").ToString()

                    Ano = ""
                    Mes = ""
                    Dia = ""

                    Ano = Mid(sData, 1, 4)
                    Mes = Replace(Mid(sData, 6, 2), "-", "")
                    Dia = Replace(Mid(sData, 9, 2), "-", "")

                    sData = Dia + "/" + Mes + "/" + Ano


                    TxtDataNasc.Text = sData
                    TxtEstadoCivil.Text = DataRow("estadocivil").ToString()
                    TxtCPF.Text = DataRow("cpf").ToString()
                    TxtFiliacao.Text = DataRow("filiacao").ToString()
                    TxtContato.Text = DataRow("contato").ToString()
                    TxtEndereco.Text = DataRow("endereco").ToString()
                    Txtbairro.Text = DataRow("bairro").ToString()
                    TXTCep.Text = DataRow("cep").ToString()
                    TxtProfissao.Text = DataRow("profissao").ToString()

                Next

                txtCodigo.Enabled = False

            Else

                txtCodigo.Enabled = False
                TxtNome.Text = ""
                TxtRG.Text = ""
                TxtNaturalidade.Text = ""
                TxtUF.Text = ""
                TxtDataNasc.Text = ""
                TxtEstadoCivil.Text = ""
                TxtCPF.Text = ""
                TxtFiliacao.Text = ""
                TxtContato.Text = ""
                TxtEndereco.Text = ""
                Txtbairro.Text = ""
                TXTCep.Text = ""
                TxtProfissao.Text = ""

                TxtNome.Focus()

            End If

            Objconn.Desconectar()

        End If

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
            Objconn.SetarSQL("SELECT * FROM reclamante WHERE codreclamante =  '" & Trim(txtCodigo.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows

                    TxtNome.Text = DataRow("reclamante").ToString()
                    TxtRG.Text = DataRow("rg").ToString()
                    TxtNaturalidade.Text = DataRow("naturalidade").ToString()
                    TxtUF.Text = DataRow("uf").ToString()

                    sData = DataRow("datanasc").ToString()

                    Ano = ""
                    Mes = ""
                    Dia = ""

                    Ano = Mid(sData, 1, 4)
                    Mes = Replace(Mid(sData, 6, 2), "-", "")
                    Dia = Replace(Mid(sData, 9, 2), "-", "")

                    sData = Dia + "/" + Mes + "/" + Ano

                    TxtDataNasc.Text = sData
                    TxtEstadoCivil.Text = DataRow("estadocivil").ToString()
                    TxtCPF.Text = DataRow("cpf").ToString()
                    TxtFiliacao.Text = DataRow("filiacao").ToString()
                    TxtContato.Text = DataRow("contato").ToString()
                    TxtEndereco.Text = DataRow("endereco").ToString()
                    Txtbairro.Text = DataRow("bairro").ToString()
                    TXTCep.Text = DataRow("cep").ToString()
                    TxtProfissao.Text = DataRow("profissao").ToString()

                Next

                txtCodigo.Enabled = False

            Else

                txtCodigo.Enabled = False
                TxtNome.Text = ""
                TxtRG.Text = ""
                TxtNaturalidade.Text = ""
                TxtUF.Text = ""
                TxtDataNasc.Text = ""
                TxtEstadoCivil.Text = ""
                TxtCPF.Text = ""
                TxtFiliacao.Text = ""
                TxtContato.Text = ""
                TxtEndereco.Text = ""
                Txtbairro.Text = ""
                TXTCep.Text = ""
                TxtProfissao.Text = ""

                TxtNome.Focus()

            End If

            Objconn.Desconectar()


        End If
    End Sub

    Protected Sub btnNovo_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click, BtnNovo.Click, BtnNovo.Click
        'Novo Registro

        Dim Objconn As New SqlDbConnect()
        Objconn.Conectar()
        Objconn.Parametros.Clear()

        'Gerar automaticamente o próximo código de registro
        Objconn.SetarSQL("SELECT count(codreclamante)+ 1 as NovoCodigo FROM reclamante")
        Objconn.Executar()

        If Objconn.Tabela.Rows.Count > 0 Then

            For Each DataRow In Objconn.Tabela.Rows

                txtCodigo.Text = DataRow("NovoCodigo").ToString()

            Next


        End If

        TxtNome.Text = ""
        TxtRG.Text = ""
        TxtNaturalidade.Text = ""
        TxtUF.Text = ""
        TxtDataNasc.Text = ""
        TxtEstadoCivil.Text = ""
        TxtCPF.Text = ""
        TxtFiliacao.Text = ""
        TxtContato.Text = ""
        TxtEndereco.Text = ""
        Txtbairro.Text = ""
        TXTCep.Text = ""
        TxtProfissao.Text = ""

        'Usuário NUNCA DEVE TRATAR O CÓDIGO INTERNO
        txtCodigo.Enabled = False

        TxtNome.Focus()

    End Sub
End Class