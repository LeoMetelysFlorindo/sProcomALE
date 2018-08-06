'Aplicativo para a Comissão de Defesa do Consumidor
'Data de criação: 26/10/2015 09:47h
'Desenvolvedor: Leonardo Metelys - Gerência de Aplicativos - ALEAM
'Formulário de Cadastro dos Reclamações
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

Public Class CadReclamacoes
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
    Dim sDataReclamacao As String


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

    Dim sMes As String
    Dim sMesExtenso As String
    Dim sDataExtenso As String

    Dim sSQQL As String
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

            ChkFicha.Checked = True
            TxtCodReclamacao.Focus()


            sSQQL = "SELECT * FROM motivo order by codmotivo"

            Dim Objconn As New SqlDbConnect()

            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL(sSQQL)
            Objconn.Executar()

            CmbMotivo.Items.Add("Selecione um item")

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows

                    CmbMotivo.Items.Add(DataRow("descricao").ToString())

                Next

            End If



        End If

    End Sub

    Protected Sub btnNovo_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click

        Dim Objconn As New SqlDbConnect()
        Objconn.Conectar()
        Objconn.Parametros.Clear()

        'Gerar automaticamente o próximo código de registro
        Objconn.SetarSQL("SELECT max(codreclamacao)+ 1 as NovoCodigo FROM reclamacao")
        Objconn.Executar()

        If Objconn.Tabela.Rows.Count > 0 Then

            For Each DataRow In Objconn.Tabela.Rows

                TxtCodReclamacao.Text = DataRow("NovoCodigo").ToString()

            Next


        End If

        Objconn.Desconectar()

        'Acrescentar a data de hoje 
        Dim sDataAtual As String = Now
        Dim sValorData As String
        Dim Ano As String = Mid(sDataAtual, 7, 4)
        Dim Dia As String = Replace(Mid(sDataAtual, 1, 2), "/", "")
        Dim Mes As String = Replace(Mid(sDataAtual, 3, 3), "/", "")

        sValorData = Dia + "/" + Mes + "/" + Ano
        TxtData.Text = sValorData



        TxtReclamante.Text = ""
        TxtNomereclamante.Text = ""
        TxtCodReclamado.Text = ""
        TxtNomereclamado.Text = ""
        CmbMotivo.SelectedIndex = 0
        TxtFato.Text = ""
        txtPedido.Text = ""
        TxtAudiencia.Text = ""
        TxtHora.Text = ""

        TxtReclamante.Focus()


    End Sub

    Protected Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click

        If TxtCodReclamacao.Text <> "" Then

            If TxtData.Text = "" Then

                lblAviso.Text = "DATA não informada!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If TxtReclamante.Text = "" Then

                lblAviso.Text = "Código Reclamante não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If TxtCodReclamado.Text = "" Then

                lblAviso.Text = "Código Reclamado não informadoo!!"
                lblAviso.Visible = True

                Exit Sub

            End If


            If TxtFato.Text = "" Then

                lblAviso.Text = "FATO não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

            If txtPedido.Text = "" Then

                lblAviso.Text = "PEDIDO não informado!!"
                lblAviso.Visible = True

                Exit Sub

            End If

        

            Dim Objconn As New SqlDbConnect()
            Dim ssQL As String = "SELECT * FROM reclamacao WHERE codreclamacao =  '" & Trim(TxtCodReclamacao.Text) & "'"

            Objconn.Conectar()

            Objconn.Parametros.Clear()

            Objconn.SetarSQL(ssQL)

            Objconn.Executar()


            If Objconn.Tabela.Rows.Count > 0 Then


                Dim sValorData As String
                Dim Ano As String = Mid(TxtData.Text, 7, 4)
                Dim Dia As String = Replace(Mid(TxtData.Text, 1, 2), "/", "")
                Dim Mes As String = Replace(Mid(TxtData.Text, 3, 3), "/", "")

                sValorData = Ano + "-" + Mes + "-" + Dia

                Dim sHora As String

                sHora = Mid(Now, 12, 8)

                sValorData = sValorData + " " + sHora

                Dim sValorData2 As String

                If TxtAudiencia.Text <> "" Then

                    Ano = Mid(TxtAudiencia.Text, 7, 4)
                    Dia = Replace(Mid(TxtAudiencia.Text, 1, 2), "/", "")
                    Mes = Replace(Mid(TxtAudiencia.Text, 3, 3), "/", "")

                    sValorData2 = Ano + "-" + Mes + "-" + Dia

                Else

                    sValorData2 = ""

                End If
               



                Objconn.Conectar()
                Objconn.Parametros.Clear()
                ssQL = "UPDATE reclamacao SET codreclamante = '" + TxtReclamante.Text & "', " & _
                                 "nomereclamante =  '" & TxtNomereclamante.Text.ToUpper() & "', codreclamado = '" & TxtCodReclamado.Text & "', " & _
                                 "nomereclamado  = '" & TxtNomereclamado.Text.ToUpper() & "', " & _
                                 "codmotivo = '" & CmbMotivo.Text.ToUpper() & "', dataaudiencia  = '" & sValorData2 & "', " & _
                                 "fatoocorrido  = '" & TxtFato.Text.ToUpper() & "', " & _
                                 "notificacao  = '" & TxtNotificacao.Text.ToUpper() & "', " & _
                                 "pedido = '" & txtPedido.Text.ToUpper() & "', hora  = '" & TxtHora.Text & "', " & _
                                 "datareclamacao = '" & sValorData & "' WHERE codreclamacao = '" & Trim(TxtCodReclamacao.Text) & "' "


                ' "datareclamacao  = '" & sValorData & "', " & _  -> Somente um testes na alteração da data e hora de inclusão 

                Objconn.SetarSQL(ssQL)

                Objconn.Executar()

                If Objconn.Executar() = False Then

                    lblAviso.Text = "Erro de alteração de dados."
                    lblAviso.Visible = True

                Else

                    lblAviso.Text = "Alteração efetuada com sucesso."
                    lblAviso.Visible = True

                    TxtCodReclamacao.Enabled = True
                    TxtCodReclamado.Enabled = True
                    TxtReclamante.Enabled = True

                    TxtCodReclamacao.Text = ""
                    TxtData.Text = ""
                    TxtReclamante.Text = ""
                    TxtNomereclamante.Text = ""
                    TxtCodReclamado.Text = ""
                    TxtNomereclamado.Text = ""
                    CmbMotivo.SelectedIndex = 0
                    TxtFato.Text = ""
                    txtPedido.Text = ""
                    TxtAudiencia.Text = ""
                    TxtHora.Text = ""
                    TxtNotificacao.Text = ""

                    TxtCodReclamacao.Focus()

                End If

                Objconn.Desconectar()

            Else


                Dim sValorData As String
                Dim Ano As String = Mid(TxtData.Text, 7, 4)
                Dim Dia As String = Replace(Mid(TxtData.Text, 1, 2), "/", "")
                Dim Mes As String = Replace(Mid(TxtData.Text, 3, 3), "/", "")

                sValorData = Ano + "-" + Mes + "-" + Dia

                Dim sHora As String

                sHora = Mid(Now, 12, 8)

                'Data de registro da reclamação
                sValorData = sValorData + " " + sHora

                Dim sValorData2 As String
                If TxtAudiencia.Text <> "" Then

                    Ano = Mid(TxtAudiencia.Text, 7, 4)
                    Dia = Replace(Mid(TxtAudiencia.Text, 1, 2), "/", "")
                    Mes = Replace(Mid(TxtAudiencia.Text, 3, 3), "/", "")

                    sValorData2 = Ano + "-" + Mes + "-" + Dia

                Else
                    sValorData2 = ""

                End If

                

                Objconn.Conectar()
                Objconn.Parametros.Clear()

                ssQL = "INSERT INTO reclamacao (codreclamacao,codreclamante,codreclamado, codmotivo,fatoocorrido,pedido,dataaudiencia," & _
                        "hora,atendente,nomereclamante,nomereclamado,datareclamacao,notificacao) VALUES ('" & Trim(TxtCodReclamacao.Text) & "','" & _
                         TxtReclamante.Text & "','" & TxtCodReclamado.Text & "','" & CmbMotivo.Text.ToUpper() & "','" & _
                         Trim(TxtFato.Text.ToUpper()) & "','" & Trim(txtPedido.Text.ToUpper()) & "','" & sValorData2 & "','" & TxtHora.Text & "','" & _
                         "" & "','" & TxtNomereclamante.Text.ToUpper() & " ','" & Trim(TxtNomereclamado.Text.ToUpper()) & "','" & sValorData & "','" & TxtNotificacao.Text.ToUpper() & "')"

                Objconn.SetarSQL(ssQL)

                If Objconn.Executar() = False Then

                    lblAviso.Text = "Erro de inserção de dados."
                    lblAviso.Visible = True
                Else

                    lblAviso.Text = "Inserção efetuada com sucesso."
                    lblAviso.Visible = True

                    TxtCodReclamacao.Enabled = True
                    TxtCodReclamado.Enabled = True
                    TxtReclamante.Enabled = True

                    TxtCodReclamacao.Text = ""
                    TxtData.Text = ""
                    TxtReclamante.Text = ""
                    TxtNomereclamante.Text = ""
                    TxtCodReclamado.Text = ""
                    TxtNomereclamado.Text = ""
                    CmbMotivo.SelectedIndex = 0
                    TxtFato.Text = ""
                    txtPedido.Text = ""
                    TxtAudiencia.Text = ""
                    TxtHora.Text = ""
                    TxtNotificacao.Text = ""

                    TxtCodReclamacao.Focus()

                End If

                Objconn.Desconectar()

            End If

        End If




    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        TxtCodReclamacao.Enabled = True
        TxtCodReclamado.Enabled = True
        TxtReclamante.Enabled = True

        TxtCodReclamacao.Text = ""
        TxtData.Text = ""
        TxtReclamante.Text = ""
        TxtNomereclamante.Text = ""
        TxtCodReclamado.Text = ""
        TxtNomereclamado.Text = ""
        CmbMotivo.SelectedIndex = 0
        TxtFato.Text = ""
        txtPedido.Text = ""
        TxtAudiencia.Text = ""
        TxtHora.Text = ""
        TxtNotificacao.Text = ""

        lblAviso.Visible = False
        TxtCodReclamacao.Focus()

    End Sub

    Protected Sub btnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click

        If TxtCodReclamacao.Text <> "" Then

            If ChkFicha.Checked = True Then



                ExportarFichaAtendimentoPDF(TxtCodReclamacao.Text)


            End If


            If ChkCadastro.Checked = True Then

                ExportarReclamacao(TxtCodReclamacao.Text)

            End If
        Else

            lblAviso.Text = "Informe um código de reclamação!"
            lblAviso.Visible = True

            TxtCodReclamacao.Focus()

        End If
    End Sub
    Private Sub ExportarReclamacao(CodigoReclamacao As String)

        Dim CrReport As New rptRelReclamacao() '// Report Name
        Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        sCarregarRelatorioReclamacao(CodigoReclamacao)

        'passa parametros de conexão com a base de dados
        CrReport.SetDatabaseLogon("proconaleam", "Intranet@Al34m")

        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldLocation As ParameterFieldDefinition
        Dim crParameterValues As ParameterValues

        crParameterFieldDefinitions = CrReport.DataDefinition.ParameterFields

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
       
        CrDiskFileDestinationOptions.DiskFileName = "\\172.16.0.31\DefesaConsumidor\Reclamcao_" + CodigoReclamacao + ".pdf"

        CrFormatTypeOptions.FirstPageNumber = 1 '// Start Page in the Report
        CrFormatTypeOptions.LastPageNumber = 1 '// End Page in the Report
        CrFormatTypeOptions.UsePageRange = True

        CrExportOptions = CrReport.ExportOptions

        With CrExportOptions

            '// Set the destination to a disk file
            .ExportDestinationType = ExportDestinationType.DiskFile

            '// Set the format to PDF
            .ExportFormatType = ExportFormatType.PortableDocFormat

            '// Set the destination options to DiskFileDestinationOptions object
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions

        End With

        Try
            '// Export the report
            CrReport.Export()
            lblAviso.Text = "PDF gerado com sucesso! Consulte a pasta no servidor!"
            lblAviso.Visible = True
        Catch err As Exception
            lblAviso.Text = err.ToString()
            lblAviso.Visible = True
        End Try



    End Sub
    Private Sub sCarregarRelatorioReclamacao(sCodReclamacao As String)


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

    Private Sub ExportarFichaAtendimentoPDF(CodigoReclamacao As String)

        Dim CrReport As New rptRelFichaAtendimento() '// Report Name
        Dim CrExportOptions As CrystalDecisions.Shared.ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

        sCarregarRelatorioFichaAtendimento(CodigoReclamacao)


        'passa parametros de conexão com a base de dados
        CrReport.SetDatabaseLogon("proconaleam", "Intranet@Al34m")

        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldLocation As ParameterFieldDefinition
        Dim crParameterValues As ParameterValues

        crParameterFieldDefinitions = CrReport.DataDefinition.ParameterFields

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

        CrDiskFileDestinationOptions.DiskFileName = "\\172.16.0.31\DefesaConsumidor\FichaAtendimento_" + CodigoReclamacao + ".pdf"

        CrFormatTypeOptions.FirstPageNumber = 1 '// Start Page in the Report
        CrFormatTypeOptions.LastPageNumber = 1 '// End Page in the Report
        CrFormatTypeOptions.UsePageRange = True

        CrExportOptions = CrReport.ExportOptions

        With CrExportOptions

            '// Set the destination to a disk file
            .ExportDestinationType = ExportDestinationType.DiskFile

            '// Set the format to PDF
            .ExportFormatType = ExportFormatType.PortableDocFormat

            '// Set the destination options to DiskFileDestinationOptions object
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions

        End With

        Try
            '// Export the report
            CrReport.Export()
            lblAviso.Text = "PDF gerado com sucesso! Consulte a pasta no servidor!"
            lblAviso.Visible = True
        Catch err As Exception
            lblAviso.Text = err.ToString()
            lblAviso.Visible = True
        End Try


    End Sub

    Private Sub sCarregarRelatorioFichaAtendimento(sCodReclamacao As String)

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

                sValorData2 = ""
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
    Protected Sub bntPesquisar_Click(sender As Object, e As ImageClickEventArgs) Handles bntPesquisar.Click

        If TxtCodReclamacao.Text <> "" Then


            Dim sData As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()

            Dim ssQL As String

            ssQL = "SELECT * FROM reclamacao WHERE codreclamacao = '" & Trim(TxtCodReclamacao.Text) & "'"

            Objconn.Conectar()


            Objconn.SetarSQL(ssQL)

            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows


                    sData = DataRow("datareclamacao").ToString()
                    Ano = Mid(sData, 1, 4)
                    Mes = Replace(Mid(sData, 6, 2), "-", "")
                    Dia = Replace(Mid(sData, 9, 2), "-", "")

                    Dim sValorData As String = Dia + "/" + Mes + "/" + Ano
                    Dim sValorData2 As String

                    If Not IsDBNull(DataRow("dataaudiencia").ToString()) Then

                        sValorData2 = DataRow("dataaudiencia").ToString()
                        Ano = Mid(sValorData2, 1, 4)
                        Mes = Replace(Mid(sValorData2, 6, 2), "-", "")
                        Dia = Replace(Mid(sValorData2, 9, 2), "-", "")

                        sValorData2 = Dia + "/" + Mes + "/" + Ano

                        '2015-11-29

                    End If

                    TxtData.Text = sValorData
                    TxtCodReclamacao.Text = DataRow("codreclamacao").ToString()
                    TxtReclamante.Text = DataRow("codreclamante").ToString()
                    TxtNomereclamante.Text = DataRow("nomereclamante").ToString()
                    TxtCodReclamado.Text = DataRow("codreclamado").ToString()
                    TxtNomereclamado.Text = DataRow("nomereclamado").ToString()

                    CmbMotivo.Text = DataRow("codmotivo").ToString()
                    TxtFato.Text = DataRow("fatoocorrido").ToString()
                    txtPedido.Text = DataRow("pedido").ToString()

                    TxtAudiencia.Text = sValorData2

                    TxtHora.Text = DataRow("hora").ToString()
                    TxtNotificacao.Text = DataRow("notificacao").ToString()


                Next

                TxtCodReclamacao.Enabled = False

            Else


                TxtCodReclamacao.Enabled = False
                TxtReclamante.Text = ""
                TxtNomereclamante.Text = ""
                TxtCodReclamado.Text = ""
                TxtNomereclamado.Text = ""
                CmbMotivo.SelectedIndex = 0
                TxtFato.Text = ""
                txtPedido.Text = ""
                TxtAudiencia.Text = ""
                TxtHora.Text = ""

                'Acrescentar a data de hoje 
                Dim sDataAtual As String = Now
                Dim sValorData As String
                Ano = Mid(sDataAtual, 7, 4)
                Dia = Replace(Mid(sDataAtual, 1, 2), "/", "")
                Mes = Replace(Mid(sDataAtual, 3, 3), "/", "")

                sValorData = Dia + "/" + Mes + "/" + Ano
                TxtData.Text = sValorData

                TxtReclamante.Focus()

            End If

            Objconn.Desconectar()


        End If




    End Sub


    Protected Sub bntPesReclamente_Click(sender As Object, e As ImageClickEventArgs) Handles bntPesReclamente.Click

        If TxtReclamante.Text <> "" Then


            Dim sData As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamante WHERE codreclamante =  '" & Trim(TxtReclamante.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows


                    TxtNomereclamante.Text = DataRow("reclamante").ToString()


                Next

                TxtReclamante.Enabled = False

            Else

                TxtNomereclamante.Text = "NÃO REGISTRADO! ERRO!!"

                TxtReclamante.Enabled = True
                TxtCodReclamado.Focus()

            End If

            Objconn.Desconectar()


        End If

    End Sub

    Protected Sub btnImprmir_Click(sender As Object, e As EventArgs) Handles BtnImprimir.Click

        'Repassar ao relatório o parâmetro do Código da Reclamação
        Response.Redirect("frmAbrirRelatorio.aspx?id=" & TxtCodReclamacao.Text)
    End Sub

    Protected Sub TxtCodReclamacao_TextChanged(sender As Object, e As EventArgs) Handles TxtCodReclamacao.TextChanged

        If TxtCodReclamacao.Text <> "" Then


            Dim sData As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamacao WHERE codreclamacao =  '" & Trim(TxtCodReclamacao.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows


                    sData = DataRow("datareclamacao").ToString()
                    Ano = Mid(sData, 7, 4)
                    Mes = Replace(Mid(sData, 1, 2), "/", "")
                    Dia = Replace(Mid(sData, 3, 3), "/", "")

                    Dim sValorData As String = Dia + "/" + Mes + "/" + Ano


                    TxtData.Text = sValorData

                    TxtCodReclamacao.Text = DataRow("codreclamacao").ToString()

                    TxtReclamante.Text = DataRow("codreclamante").ToString()
                    TxtNomereclamante.Text = DataRow("nomereclamante").ToString()
                    TxtCodReclamado.Text = DataRow("codreclamado").ToString()
                    TxtNomereclamado.Text = DataRow("nomereclamado").ToString()

                    CmbMotivo.Text = DataRow("codmotivo").ToString()
                    TxtFato.Text = DataRow("fatoocorrido").ToString()
                    txtPedido.Text = DataRow("pedido").ToString()

                    If IsDBNull(DataRow("dataaudiencia").ToString()) Then
                        TxtAudiencia.Text = ""
                    Else
                        TxtAudiencia.Text = DataRow("dataaudiencia").ToString()
                    End If

                    TxtHora.Text = DataRow("hora").ToString()



                Next

                TxtCodReclamacao.Enabled = False

            Else

                TxtCodReclamacao.Enabled = False
                TxtData.Text = ""
                TxtReclamante.Text = ""
                TxtNomereclamante.Text = ""
                TxtCodReclamado.Text = ""
                TxtNomereclamado.Text = ""
                CmbMotivo.SelectedIndex = 0
                TxtFato.Text = ""
                txtPedido.Text = ""
                TxtAudiencia.Text = ""
                TxtHora.Text = ""


                TxtReclamante.Focus()

            End If

            Objconn.Desconectar()


        End If


    End Sub

    Protected Sub TxtReclamante_TextChanged(sender As Object, e As EventArgs) Handles TxtReclamante.TextChanged

        If TxtReclamante.Text <> "" Then


            Dim sData As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamante WHERE codreclamante =  '" & Trim(TxtReclamante.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows


                    TxtNomereclamante.Text = DataRow("reclamante").ToString()


                Next

                TxtReclamante.Enabled = False

            Else

                TxtNomereclamante.Text = "NÃO REGISTRADO! ERRO!!"

                TxtReclamante.Enabled = True
                TxtReclamante.Focus()

            End If

            Objconn.Desconectar()


        End If



    End Sub

    Protected Sub TxtCodReclamado_TextChanged(sender As Object, e As EventArgs) Handles TxtCodReclamado.TextChanged

        If TxtCodReclamado.Text <> "" Then


            Dim sData As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamado WHERE codigo =  '" & Trim(TxtCodReclamado.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows


                    TxtNomereclamado.Text = DataRow("reclamado").ToString()


                Next

                TxtCodReclamado.Enabled = False

            Else

                TxtNomereclamado.Text = "NÃO REGISTRADO! ERRO!!"

                TxtCodReclamado.Enabled = True
                TxtCodReclamado.Focus()

            End If

            Objconn.Desconectar()


        End If



    End Sub

    Protected Sub bntPesReclamado_Click(sender As Object, e As ImageClickEventArgs) Handles bntPesReclamado.Click

        If TxtCodReclamado.Text <> "" Then


            Dim sData As String = ""
            Dim Ano As String = ""
            Dim Mes As String = ""
            Dim Dia As String = ""
            Dim Objconn As New SqlDbConnect()
            Objconn.Conectar()
            Objconn.Parametros.Clear()
            Objconn.SetarSQL("SELECT * FROM reclamado WHERE codigo =  '" & Trim(TxtCodReclamado.Text) & "'")
            Objconn.Executar()

            If Objconn.Tabela.Rows.Count > 0 Then

                For Each DataRow In Objconn.Tabela.Rows


                    TxtNomereclamado.Text = DataRow("reclamado").ToString()


                Next

                TxtCodReclamado.Enabled = False

            Else

                TxtNomereclamado.Text = "NÃO REGISTRADO! ERRO!!"

                TxtCodReclamado.Enabled = True
                TxtCodReclamado.Focus()

            End If

            Objconn.Desconectar()


        End If

    End Sub

    Protected Sub btnImprmir_2_Click(sender As Object, e As EventArgs) Handles BtnImprimir_2.Click

        'Repassar ao relatório o parâmetro do Código da Reclamação
        Response.Redirect("rptAbrirRelatorio_2.aspx?id=" & TxtCodReclamacao.Text)

    End Sub

    

    Protected Sub ChkFicha_CheckedChanged(sender As Object, e As EventArgs) Handles ChkFicha.CheckedChanged

        If ChkFicha.Checked = True Then

            ChkCadastro.Checked = False

        End If

    End Sub

    Protected Sub ChkCadastro_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCadastro.CheckedChanged

        If ChkCadastro.Checked = True Then

            ChkFicha.Checked = False

        End If

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