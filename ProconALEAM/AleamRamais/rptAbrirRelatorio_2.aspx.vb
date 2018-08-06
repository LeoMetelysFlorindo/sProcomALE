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
Public Class rptAbrirRelatorio_2
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
    Dim sBairroReclamado As String
    Dim sCEPReclamado As String
    Dim sPedido As String
    Dim sDataImpressao As String


    'Dados Reclamante
    Dim sNaturalidade As String
    Dim sUFReclamante As String
    Dim sDataNascimento As String
    Dim sEstadoCivil As String
    Dim sRG As String
    Dim sCPF As String
    Dim sFiliacao As String
    Dim sEnderecoReclamante As String
    Dim sBairroReclamante As String
    Dim sCEPReclamante As String
    Dim sContatoReclamante As String

    Dim sDescreveReclamacao As String
    Dim sMotivoReclamacao As String
    Dim sOpcao1 As String
    Dim sOpcao2 As String
    Dim sOpcao3 As String
    Dim sOpcao4 As String
    Dim sOpcao5 As String
    Dim sOpcao6 As String
    Dim sOpcao7 As String
    Dim sOpcao8 As String

    'Data por Extenso
    Dim sMes As String
    Dim sMesExtenso As String
    Dim sDataExtenso As String

    Dim sSQQL As String
    'Conexão com o MYSQL
    Const ConnStr As String = "Driver={MySQL ODBC 5.1 Driver};" + "Server=172.16.0.32;Database=proconaleam;uid=intranetadmin;pwd=Intranet@Al34m;option=3"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Pegar os dados do usuário logado
        If Not Page.IsPostBack Then



            'Pegando o Código da Reclamação
            sReclamacao = Request.QueryString("id")

            sCarregarRelatorio(sReclamacao)

            Dim myRelatorio As New rptRelFichaAtendimento()

            'passa parametros de conexão com a base de dados
            myRelatorio.SetDatabaseLogon("proconaleam", "Intranet@Al34m")

            Dim crParameterDiscreteValue As ParameterDiscreteValue
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldLocation As ParameterFieldDefinition
            Dim crParameterValues As ParameterValues

            crParameterFieldDefinitions = myRelatorio.DataDefinition.ParameterFields

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@CodReclamacao")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do Código da Reclamacao
            crParameterDiscreteValue.Value = sCodReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            '
            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Reclamado")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do nome do Reclamado
            crParameterDiscreteValue.Value = sNomeReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Naturalidade")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do Endereço do Reclamado
            crParameterDiscreteValue.Value = sNaturalidade
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@UF")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor do códifo do Reclamado
            crParameterDiscreteValue.Value = sUFReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@DataNasc")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sDataNascimento
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@EstadoCivil")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sEstadoCivil
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@RG")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sRG
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@CPF")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sCPF
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Endereco")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sEnderecoReclamado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Bairro")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sBairroReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@CEP")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sCEPReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Contato")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sContatoReclamante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao1")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao1
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao2")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao2
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao3")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao3
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao4")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao4
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao5")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao5
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao6")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao6
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao7")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao7
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Opcao8")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sOpcao8
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Reclamada")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sNomeReclamando
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@CNPJ")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sCNPJ
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@EnderecoReclamada")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sEnderecoReclamado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@BairroReclamado")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sBairroReclamado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@CepReclamado")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sCEPReclamado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Fato")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sReclamacao
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Pedido")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Reclamação
            crParameterDiscreteValue.Value = sPedido
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

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@Filiacao")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Data da Audiêmcia
            crParameterDiscreteValue.Value = sFiliacao
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)

            crParameterFieldLocation = crParameterFieldDefinitions.Item("@dataimpressao")
            crParameterValues = crParameterFieldLocation.CurrentValues
            crParameterDiscreteValue = New CrystalDecisions.Shared.ParameterDiscreteValue
            'obtem o valor da Data da Audiêmcia
            crParameterDiscreteValue.Value = sDataImpressao
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues)


            Me.crView.ReportSource = myRelatorio
            Me.crView.Visible = True

            'myRelatorio.PrintToPrinter(1, False, 0, 0)

            'crystalReportViewer.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
            '        crystalReportViewer.HasPrintButton = true;


            Me.crView.PrintMode = CrystalDecisions.Web.PrintMode.Pdf
            Me.crView.HasPrintButton = True




        End If




    End Sub


    Private Sub sCarregarRelatorio(sCodReclamacao As String)

        'Pegar dados da Reclamação
        Dim Objconn As New SqlDbConnect()
        Objconn.Conectar()
        Objconn.Parametros.Clear()

        sSQQL = "SELECT a.*, b.endereco as Enderecoreclamado, b.cnpj, b.bairro as BairroReclamado, b.cep as CepReclamando, c.filiacao as Filiacao, c.* FROM reclamacao a LEFT OUTER JOIN reclamado b on b.codigo = a.codreclamado LEFT OUTER JOIN reclamante c on c.codreclamante = a.codreclamante where codreclamacao = " & sCodReclamacao
        'Gerar automaticamente o próximo código de registro
        Objconn.SetarSQL(sSQQL)
        Objconn.Executar()

        If Objconn.Tabela.Rows.Count > 0 Then

            For Each DataRow In Objconn.Tabela.Rows

                sCodReclamante = DataRow("codreclamante").ToString()
                sNomeReclamante = DataRow("nomereclamante").ToString()
                sCodReclamado = DataRow("codreclamado").ToString()
                sNomeReclamando = DataRow("nomereclamado").ToString()
                sEnderecoReclamado = DataRow("Enderecoreclamado").ToString()
                sCNPJ = DataRow("cnpj").ToString()
                sReclamacao = DataRow("fatoocorrido").ToString()
                sPedido = DataRow("pedido").ToString()
                sHoraAudiencia = DataRow("hora").ToString()
                sNaturalidade = DataRow("naturalidade").ToString()
                sUFReclamante = DataRow("uf").ToString()
                sEstadoCivil = DataRow("estadocivil").ToString()
                sRG = DataRow("rg").ToString()
                sCPF = DataRow("cpf").ToString()
                sFiliacao = DataRow("Filiacao").ToString()
                sBairroReclamante = DataRow("bairro").ToString()
                sCEPReclamante = DataRow("CEP").ToString()
                sContatoReclamante = DataRow("contato").ToString()
                sMotivoReclamacao = DataRow("codmotivo").ToString()
                sBairroReclamado = DataRow("BairroReclamado").ToString()
                sCEPReclamado = DataRow("CepReclamando").ToString()
                sDataImpressao = DataRow("datareclamacao").ToString()

                Dim Ano As String = ""
                Dim Mes As String = ""
                Dim Dia As String = ""

                Ano = Mid(sDataImpressao, 1, 4)
                Mes = Replace(Mid(sDataImpressao, 6, 2), "-", "")
                Dia = Replace(Mid(sDataImpressao, 9, 2), "-", "")

                sDataImpressao = Dia + "/" + Mes + "/" + Ano


                If sMotivoReclamacao = "PRÁTICA ABUSIVA / PREÇOS" Then

                    sOpcao1 = "(X)"
                    sOpcao2 = "( )"
                    sOpcao3 = "( )"
                    sOpcao4 = "( )"
                    sOpcao5 = "( )"
                    sOpcao6 = "( )"
                    sOpcao7 = "( )"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "PRÁTICA ABUSIVA / PRODUTO" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "(X)"
                    sOpcao3 = "( )"
                    sOpcao4 = "( )"
                    sOpcao5 = "( )"
                    sOpcao6 = "( )"
                    sOpcao7 = "( )"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "VÍCIO APARENTE" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "( )"
                    sOpcao3 = "(X)"
                    sOpcao4 = "( )"
                    sOpcao5 = "( )"
                    sOpcao6 = "( )"
                    sOpcao7 = "( )"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "VÍCIO OCULTO" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "( )"
                    sOpcao3 = "( )"
                    sOpcao4 = "(X)"
                    sOpcao5 = "( )"
                    sOpcao6 = "( )"
                    sOpcao7 = "( )"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "COBRANÇA INDEVIDA" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "( )"
                    sOpcao3 = "( )"
                    sOpcao4 = "( )"
                    sOpcao5 = "(X)"
                    sOpcao6 = "( )"
                    sOpcao7 = "( )"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "OBRIGAÇÃO DE FAZER" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "( )"
                    sOpcao3 = "( )"
                    sOpcao4 = "( )"
                    sOpcao5 = "( )"
                    sOpcao6 = "(X)"
                    sOpcao7 = "( )"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "COBRANÇA ABUSIVA" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "( )"
                    sOpcao3 = "( )"
                    sOpcao4 = "( )"
                    sOpcao5 = "( )"
                    sOpcao6 = "( )"
                    sOpcao7 = "(X)"
                    sOpcao8 = "( )"

                ElseIf sMotivoReclamacao = "MÁ-PRESTAÇÃO DE SERVIÇOS" Then

                    sOpcao1 = "( )"
                    sOpcao2 = "( )"
                    sOpcao3 = "( )"
                    sOpcao4 = "( )"
                    sOpcao5 = "( )"
                    sOpcao6 = "( )"
                    sOpcao7 = "( )"
                    sOpcao8 = "(X)"

                End If

                Dim sValorData2 As String = ""
                Ano = ""
                Mes = ""
                Dia = ""

                If Not IsDBNull(DataRow("dataaudiencia").ToString()) Then

                    sValorData2 = DataRow("dataaudiencia").ToString()
                    Ano = Mid(sValorData2, 1, 4)
                    Mes = Replace(Mid(sValorData2, 6, 2), "-", "")
                    Dia = Replace(Mid(sValorData2, 9, 2), "-", "")

                    sValorData2 = Dia + "/" + Mes + "/" + Ano

                    sDataAudiencia = sValorData2

                End If

                Ano = ""
                Mes = ""
                Dia = ""

                If Not IsDBNull(DataRow("datanasc").ToString()) Then

                    sValorData2 = DataRow("datanasc").ToString()
                    Ano = Mid(sValorData2, 7, 4)
                    Mes = Replace(Mid(sValorData2, 4, 2), "-", "")
                    Dia = Replace(Mid(sValorData2, 1, 2), "-", "")

                    sValorData2 = Dia + "/" + Mes + "/" + Ano

                    sDataNascimento = sValorData2


                End If



                sNotificacao = DataRow("notificacao").ToString() + "- CDC/ALEAM"
                sCodReclamacao = DataRow("codreclamacao").ToString()
                sCodReclamacao = sCodReclamacao
                sDescreveReclamacao = sCodReclamacao + "/" + Mid(Now, 7, 4)

            Next


        End If



        Objconn.Desconectar()



    End Sub

   
End Class