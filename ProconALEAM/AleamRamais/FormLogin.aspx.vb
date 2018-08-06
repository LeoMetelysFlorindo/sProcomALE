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

Public Class FormLogin

    Inherits System.Web.UI.Page
    Dim sqlConn As SqlConnection
    Dim sqlCmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet

    Public sSQL As String
    Public myCommand As OleDbCommand
    Public dsr As OleDbDataReader
    Public sNomeCompleto As String
    Public ra As Integer
    Public widestData As Integer = 0

    Public ReadOnly Property Nome() As String
        Get
            Return UserName.Text
        End Get
    End Property

    'Conexão com o MYSQL
    Const ConnStr As String = "Driver={MySQL ODBC 5.1 Driver};" + "Server=172.16.0.32;Database=proconaleam;uid=intranetadmin;pwd=Intranet@Al34m;option=3"
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not Page.IsPostBack Then

            UserName.Focus()


        End If


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Abrir a base de dados
        Dim conn As New MySqlConnection
        Dim cmd As New MySqlCommand
        Dim myCommandFA As MySqlCommand

        Dim dsR As MySqlDataReader
        Dim sConn As MySqlConnection


        Dim sDataInicial As String = Now

        Dim Ano As String = Trim(Replace(Mid(sDataInicial, 7, 4), "/", ""))
        Dim Mes As String = Trim(Replace(Mid(sDataInicial, 4, 2), "/", ""))
        Dim Dia As String = Trim(Replace(Mid(sDataInicial, 1, 2), "/", ""))

        sSQL = "SELECT * FROM usuario WHERE login = '" & UserName.Text & "' AND senha = '" & Password.Text & "'"

        sConn = New MySqlConnection("server=172.16.0.32; user id=intranetadmin; password=Intranet@Al34m; database=proconaleam; pooling=false;")
        sConn.Open()

        'Verificar login e senha
        myCommandFA = New MySqlCommand(sSQL, sConn)
        dsR = myCommandFA.ExecuteReader

        'Usuários e Senha Corretos 
        If dsR.Read() Then

            sNomeCompleto = dsR("Nome")

            'Fechar a query
            dsR.Close()

            Response.Redirect("Default.aspx?ID=" + sNomeCompleto)

          

        End If

        dsR.Close()

       




    End Sub

  
End Class