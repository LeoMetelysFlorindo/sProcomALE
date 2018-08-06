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
Public Class ConsAudiencias
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

    Private Sub CarregarGrid(ByVal sDataReclamacao As String)

        Dim myConnectionCorrigeFA01 As MySqlConnection
        Dim myDataAdapter As MySqlDataAdapter
        Dim myDataSet As DataSet
        Dim strSQL As String
        Dim sDataConsulta As String

        Dim Ano As String = Mid(sDataReclamacao, 7, 4)
        Dim Dia As String = Replace(Mid(sDataReclamacao, 1, 2), "/", "")
        Dim Mes As String = Replace(Mid(sDataReclamacao, 3, 3), "/", "")

        sDataConsulta = Ano + "-" + Mes + "-" + Dia

        myConnectionCorrigeFA01 = New MySqlConnection("server=172.16.0.32; user id=intranetadmin; password=Intranet@Al34m; database=proconaleam; pooling=false;")
        'If sInicio = sFinal Then

        strSQL = "SELECT DATE_FORMAT(dataaudiencia,'%d/%m/%Y') as DataAudiencia, concat(nomereclamante,' x ',nomereclamado) as PARTES, hora, ' ' as ACAO, 'COMISSÃO DE DEFESA DO CONSUMIDOR' as LOCAL, notificacao as NoProcesso  FROM reclamacao where substr(dataaudiencia,1,10) = '" & sDataConsulta & "' order by dataaudiencia"

        myDataAdapter = New MySqlDataAdapter(strSQL, myConnectionCorrigeFA01)

        myDataSet = New DataSet()
        myDataAdapter.Fill(myDataSet, "reclamados")
        gdItens.DataSource = myDataSet

        gdItens.DataBind()
        myConnectionCorrigeFA01.Close()


    End Sub

    Private Sub CarregarGridTodos()

        Dim myConnectionCorrigeFA01 As MySqlConnection
        Dim myDataAdapter As MySqlDataAdapter
        Dim myDataSet As DataSet
        Dim strSQL As String



        myConnectionCorrigeFA01 = New MySqlConnection("server=172.16.0.32; user id=intranetadmin; password=Intranet@Al34m; database=proconaleam; pooling=false;")
        'If sInicio = sFinal Then

        strSQL = "SELECT DATE_FORMAT(dataaudiencia,'%d/%m/%Y') as DataAudiencia, concat(nomereclamante,' x ',nomereclamado) as PARTES, hora, ' ' as ACAO, 'COMISSÃO DE DEFESA DO CONSUMIDOR' as LOCAL, notificacao as NoProcesso  FROM reclamacao r order by dataaudiencia"

        myDataAdapter = New MySqlDataAdapter(strSQL, myConnectionCorrigeFA01)

        myDataSet = New DataSet()
        myDataAdapter.Fill(myDataSet, "reclamados")
        gditens.DataSource = myDataSet

        gditens.DataBind()
        myConnectionCorrigeFA01.Close()


    End Sub
End Class