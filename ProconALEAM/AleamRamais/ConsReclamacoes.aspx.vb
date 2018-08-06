'Aplicativo para a Comissão de Defesa do Consumidor
'Data de criação: 19/11/2015 10:41h
'Desenvolvedor: Leonardo Metelys - Gerência de Aplicativos - ALEAM
'Formulário de Consulta de Reclamantes

Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Net.Mail
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.DirectoryServices.AccountManagement
Imports System.TimeSpan
Imports System.Globalization.CultureInfo

Public Class ConsReclamacoes
    Inherits System.Web.UI.Page
    Dim sqlConn As MySqlConnection
    Dim sqlCmd As MySqlCommand
    Dim da As MySqlDataAdapter
    Dim ds As DataSet
    Public sConta As Integer
    Public sSQL As String
    Public cnn As OdbcConnection
    Public myConnection As OleDbConnection
    Public myCommand As OleDbCommand
    Public dsr As OleDbDataReader
    Public sTotal As Double
    Public ra As Integer
    'Conexão com o MYSQL
    Const ConnStr As String = "Driver={MySQL ODBC 5.1 Driver};" + "Server=172.16.0.32;Database=proconaleam;uid=intranetadmin;pwd=Intranet@Al34m;option=3"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            CarregarGridTodos()

        End If
    End Sub

    Protected Sub TxtPesquisar_Click(sender As Object, e As EventArgs) Handles TxtPesquisar.Click
        If TxtSolicitante.Text <> "" Then


            CarregarGrid(TxtSolicitante.Text)

        Else

            CarregarGridTodos()

        End If
    End Sub

    Private Sub CarregarGrid(ByVal NomeReclamado As String)

        Dim myConnectionCorrigeFA01 As MySqlConnection
        Dim myDataAdapter As MySqlDataAdapter
        Dim myDataSet As DataSet
        Dim strSQL As String


        NomeReclamado = "%" + NomeReclamado + "%"

        myConnectionCorrigeFA01 = New MySqlConnection("server=172.16.0.32; user id=intranetadmin; password=Intranet@Al34m; database=proconaleam; pooling=false;")
        'If sInicio = sFinal Then

        strSQL = "SELECT codreclamacao, nomereclamado, nomereclamante, datareclamacao, notificacao  FROM reclamacao where nomereclamado like '" & NomeReclamado.ToUpper() & "' "

        myDataAdapter = New MySqlDataAdapter(strSQL, myConnectionCorrigeFA01)

        myDataSet = New DataSet()
        myDataAdapter.Fill(myDataSet, "reclamados")
        gditens.DataSource = myDataSet

        gditens.DataBind()
        myConnectionCorrigeFA01.Close()


    End Sub

    Private Sub CarregarGridTodos()

        Dim myConnectionCorrigeFA01 As MySqlConnection
        Dim myDataAdapter As MySqlDataAdapter
        Dim myDataSet As DataSet
        Dim strSQL As String



        myConnectionCorrigeFA01 = New MySqlConnection("server=172.16.0.32; user id=intranetadmin; password=Intranet@Al34m; database=proconaleam; pooling=false;")
        'If sInicio = sFinal Then

        strSQL = "SELECT codreclamacao, nomereclamado, nomereclamante, DATE_FORMAT(datareclamacao,'%d/%m/%Y') as DataReclamacao , notificacao  FROM reclamacao   order by codreclamacao"

        myDataAdapter = New MySqlDataAdapter(strSQL, myConnectionCorrigeFA01)

        myDataSet = New DataSet()
        myDataAdapter.Fill(myDataSet, "reclamados")
        gditens.DataSource = myDataSet

        gditens.DataBind()
        myConnectionCorrigeFA01.Close()


    End Sub

    Protected Sub gdItens_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gdItens.RowDataBound

        


    End Sub

    Protected Sub gdItens_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gdItens.RowCreated

        'Dim sDataCorreta As String = ""
        'Dim sDataReclamacao As String = ""
        'Dim sHoraReclamacao As String = ""

        ''Formatar a Data de modo apropriado 03/02/2016 09:12h
        'For ContadorLinhas As Integer = 0 To Me.gdItens.Rows.Count - 1

        '    'Data Reclamação
        '    If (Me.gdItens.Rows(ContadorLinhas).Cells(3).Text <> "") Then

        '        sDataCorreta = Me.gdItens.Rows(ContadorLinhas).Cells(3).Text

        '        Dim Ano As String = ""
        '        Dim Mes As String = ""
        '        Dim Dia As String = ""

        '        Ano = Mid(sDataCorreta, 1, 4)
        '        Mes = Replace(Mid(sDataCorreta, 6, 2), "-", "")
        '        Dia = Replace(Mid(sDataCorreta, 9, 2), "-", "")

        '        sDataReclamacao = Dia + "/" + Mes + "/" + Ano
        '        sHoraReclamacao = Mid(sDataCorreta, 12, 10)

        '        Me.gdItens.Rows(ContadorLinhas).Cells(3).Text = sDataReclamacao + "-" + sHoraReclamacao



        '    End If



        'Next



    End Sub
End Class