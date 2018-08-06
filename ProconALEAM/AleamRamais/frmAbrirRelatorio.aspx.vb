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
Imports Microsoft.Reporting.WinForms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared


Public Class frmAbrirRelatorio

    Inherits System.Web.UI.Page

    Dim sCodReclamacao As String
    Dim sReclamacao As String
    Dim sCodReclamante As String
    Dim sNomeReclamante As String
    Dim sCodReclamado As String
    Dim sNomeReclamando As String
    Dim sCNPJ As String
    Dim sEnderecoReclamado As String
    Dim sHoraAudiencia As String
    Dim sDataAudiencia As String
    Dim sNotificacao As String
    Dim sDataReclamacao As String

    Dim sMes As String
    Dim sMesExtenso As String
    Dim sDataExtenso As String

    Dim sDescreveReclamacao As String

    Dim sSQQL As String
    'Conexão com o MYSQL
    Const ConnStr As String = "Driver={MySQL ODBC 5.1 Driver};" + "Server=172.16.0.32;Database=proconaleam;uid=intranetadmin;pwd=Intranet@Al34m;option=3"


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        'Pegar os dados do usuário logado
        If Not Page.IsPostBack Then

           

            'Pegando o Código da Reclamação
            sReclamacao = Request.QueryString("id")

            sCarregarRelatorio(sReclamacao)

            Dim myRelatorio As New rptRelReclamacao()

            'passa parametros de conexão com a base de dados
            myRelatorio.SetDatabaseLogon("proconaleam", "Intranet@Al34m")

            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues

            crParameterFieldDefinitions = myRelatorio.DataDefinition.ParameterFields

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Codreclamacao")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do Código da Reclamacao
            crParameterDiscreteValue.Value = sDescreveReclamacao
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            '
            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Reclamada")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do nome do Reclamado
            crParameterDiscreteValue.Value = sNomeReclamando
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@EnderecoReclamada")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do Endereço do Reclamado
            crParameterDiscreteValue.Value = sEnderecoReclamado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Reclamado")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do códifo do Reclamado
            crParameterDiscreteValue.Value = sNomeReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Reclamacao")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sReclamacao
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@HoraAudiencia")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Hora da Audiêmcia
            crParameterDiscreteValue.Value = sHoraAudiencia
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@DataAudiencia")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Data da Audiêmcia
            crParameterDiscreteValue.Value = sDataAudiencia
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Notificacao")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Notificação
            crParameterDiscreteValue.Value = sNotificacao
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@dataextenso")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Data da Audiêmcia
            crParameterDiscreteValue.Value = sDataExtenso
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            Me.crView.ReportSource = myRelatorio
            Me.crView.Visible = True

            'myRelatorio.PrintToPrinter(1, False, 0, 0)

            'crystalReportViewer.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
            '        crystalReportViewer.HasPrintButton = true;


            Me.crView.PrintMode = CrystalDecisions.Web.PrintMode.Pdf
            Me.crView.HasPrintButton = True


            
            'USANDOR O REPORTVIEWER - 10/11/2015 10:25h
            '--------------------------------------------------------------

            'ReportViewer1.ProcessingMode = ProcessingMode.Local
            'ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc")




            'Dim rpCodReclamacao As New ReportParameter()
            'rpCodReclamacao.Name = "CodReclamacao"
            'rpCodReclamacao.Values.Add("SO43661")

            ''Set the report parameters for the report
            'Dim parameters() As ReportParameter = {rpCodReclamacao}
            'ReportViewer1.LocalReport.SetParameters(parameters)

            'ReportViewer1.LocalReport.Refresh()

            '--------------------------------------------------------------


        End If


    End Sub


    Private Sub sCarregarRelatorio(sCodReclamacao As String)

      
        'Pegar dados da Reclamação
        Dim Objconn As New SqlDbConnect()
        Objconn.Conectar()
        Objconn.Parametros.Clear()

        'Gerar automaticamente o próximo código de registro
        Objconn.SetarSQL("SELECT a.*, b.endereco, b.cnpj FROM reclamacao a LEFT OUTER JOIN reclamado b on b. codigo = a.codreclamado where codreclamacao = " & sCodReclamacao)
        Objconn.Executar()

        If Objconn.Tabela.Rows.Count > 0 Then

            For Each DataRow In Objconn.Tabela.Rows

                sCodReclamante = DataRow("codreclamante").ToString()
                sNomeReclamante = DataRow("nomereclamante").ToString()
                sCodReclamado = DataRow("codreclamado").ToString()
                sNomeReclamando = DataRow("nomereclamado").ToString()
                sEnderecoReclamado = DataRow("endereco").ToString()
                sCNPJ = DataRow("cnpj").ToString()
                sReclamacao = DataRow("codmotivo").ToString()
                sHoraAudiencia = DataRow("hora").ToString()
                sDataReclamacao = DataRow("datareclamacao").ToString()

                Dim sValorData2 As String = ""
                Dim Ano As String = ""
                Dim Mes As String = ""
                Dim Dia As String = ""

                If Not IsDBNull(DataRow("dataaudiencia").ToString()) Then

                    sValorData2 = DataRow("dataaudiencia").ToString()
                    Ano = Mid(sValorData2, 1, 4)
                    Mes = Replace(Mid(sValorData2, 6, 2), "-", "")
                    Dia = Replace(Mid(sValorData2, 9, 2), "-", "")

                    sValorData2 = Dia + "/" + Mes + "/" + Ano

                    sDataAudiencia = sValorData2

                End If


                sNotificacao = DataRow("notificacao").ToString() + "- CDC/ALEAM"
                sCodReclamacao = DataRow("codreclamacao").ToString()
                sCodReclamacao = sCodReclamacao
                sDescreveReclamacao = sCodReclamacao + "/" + Mid(Now, 7, 4)

                sMes = Mid(sDataReclamacao, 6, 2)

                MesExteso(sMes)

                sDataExtenso = "Manaus, " + Mid(sDataReclamacao, 9, 2) + " de " + sMesExtenso + " de " + Mid(sDataReclamacao, 1, 4) + "."


            Next


        End If



        Objconn.Desconectar()



    End Sub

    Public Sub MesExteso(Mes As String)

        If Mes = "01" Then

            sMesExtenso = "Janeiro"

        ElseIf Mes = "02" Then

            sMesExtenso = "Fevereiro"

        ElseIf Mes = "03" Then

            sMesExtenso = "Março"

        ElseIf Mes = "04" Then

            sMesExtenso = "Abril"

        ElseIf Mes = "05" Then

            sMesExtenso = "Maio"

        ElseIf Mes = "06" Then

            sMesExtenso = "Junho"

        ElseIf Mes = "07" Then

            sMesExtenso = "Julho"

        ElseIf Mes = "08" Then

            sMesExtenso = "Agosto"

        ElseIf Mes = "09" Then

            sMesExtenso = "Setembro"

        ElseIf Mes = "10" Then

            sMesExtenso = "Outubro"

        ElseIf Mes = "11" Then

            sMesExtenso = "Novembro"

        ElseIf Mes = "12" Then

            sMesExtenso = "Dezembro"

        End If


    End Sub
End Class