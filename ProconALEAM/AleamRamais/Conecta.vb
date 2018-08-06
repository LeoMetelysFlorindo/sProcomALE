Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections
Imports MySql.Data.MySqlClient

Namespace Classes
    Public Class SqlDbConnect
        Private _isvalid As Boolean
        Private _message As String
        Private _stringConnection As String
        Private _connection As MySqlConnection
        Private _tabela As DataTable
        Private _parametros As IList = New ArrayList()
        Private _transaction As MySqlTransaction
        Private _command As MySqlCommand
        Private _reader As MySqlDataReader

        Public Property StringConnection() As String
            Get
                Return _stringConnection
            End Get
            Set(ByVal value As String)
                _stringConnection = value
            End Set
        End Property

        Public Property Connection() As MySqlConnection
            Get
                Return _connection
            End Get
            Set(ByVal value As MySqlConnection)
                _connection = value
            End Set
        End Property

        Public Property Tabela() As DataTable
            Get
                Return _tabela
            End Get
            Set(ByVal value As DataTable)
                _tabela = value
            End Set
        End Property

        Public Property Parametros() As IList
            Get
                Return _parametros
            End Get
            Set(ByVal value As IList)
                _parametros = value
            End Set
        End Property

        Public Property Transaction() As MySqlTransaction
            Get
                Return _transaction
            End Get
            Set(ByVal value As MySqlTransaction)
                _transaction = value
            End Set
        End Property

        Public Property Isvalid() As Boolean
            Get
                Return _isvalid
            End Get
            Set(ByVal value As Boolean)
                _isvalid = value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property

        Public Function Conectar() As Boolean
            Try
                Dim _connectionString As String = "server=172.16.0.32; user id=intranetadmin; password=Intranet@Al34m; database=proconaleam; pooling=false;"
                _connection = New MySqlConnection(_connectionString)
                _connection.Open()
                Return True
            Catch erro As Exception
                Message = erro.Message
                Return False
            End Try
        End Function

        Public Sub Desconectar()
            _connection.Close()
        End Sub

        Public Sub AdicionarParametro(ByVal nome As String, ByVal valor As Object, ByVal tipo As SqlDbType)
            Dim parametro As New MySqlParameter(nome, tipo)
            parametro.Direction = ParameterDirection.Input
            parametro.Value = valor
            _parametros.Add(parametro)
        End Sub

        Public Sub AdicionarParametroSaida(ByVal nome As String, ByVal tipo As SqlDbType)
            Dim parametro As New MySqlParameter(nome, tipo)
            parametro.Direction = ParameterDirection.Output

            _parametros.Add(parametro)
        End Sub

        Public Sub SetarSQL(ByVal SQL As String)
            _command = New MySqlCommand()
            _command.CommandType = CommandType.Text
            _command.CommandText = SQL
            _command.Connection = _connection
        End Sub

        Public Sub SetarSP(ByVal nomeSP As String)
            _command = New MySqlCommand()
            _command.CommandType = CommandType.StoredProcedure
            _command.CommandText = nomeSP
            _command.Connection = _connection
        End Sub

        Public Function Executar() As Boolean

            Try

                For Each parametro As MySqlParameter In _parametros
                    _command.Parameters.Add(parametro)
                Next



                Dim dataAdapter As New MySqlDataAdapter(_command)
                Tabela = New DataTable()
                dataAdapter.Fill(Tabela)

                _isvalid = True
                _message = ""

                Return True

            Catch erro As Exception
                _isvalid = False
                _message = erro.Message

                Return False

            End Try
        End Function

        Public Function retornaInfoUsuario(ByVal login As String) As Object()
            Try

                Dim values(5) As Object
                _command = New MySqlCommand("SELECT * FROM BRSUsuario WHERE Usu_Login = '" & login & "'", _connection)
                _reader = _command.ExecuteReader
                If (_reader.Read) Then
                    If (_reader.HasRows) Then
                        For i = 0 To 4
                            values(i) = _reader.GetValue(i)
                        Next

                    End If
                End If

                Return values
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


        Public Function retornaConsultaUsuarios(ByVal parametro As String, ByVal value As String) As MySqlDataReader
            Try


                _command = New MySqlCommand("SELECT * FROM BRSUsuario WHERE " & parametro & " LIKE '%" & value & "%'", _connection)
                _reader = _command.ExecuteReader

                Return _reader

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function retornaConsultaTodosUsuarios() As MySqlDataReader
            Try


                _command = New MySqlCommand("SELECT * FROM BRSUsuario", _connection)
                _reader = _command.ExecuteReader

                Return _reader

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function verificaUsuario(ByVal login As String) As Boolean

            Dim count As Integer = 0
            Dim exists As Boolean = False
            _command = New MySqlCommand("SELECT COUNT(*) FROM Usuario WHERE login = '" & login & "'", _connection)
            _reader = _command.ExecuteReader
            If (_reader.Read) Then
                If (_reader.HasRows) Then
                    count = _reader.GetInt32(0)
                End If
            End If

            If (count = 0) Then
                exists = False
            Else
                exists = True
            End If

            _reader.Close()

            Return exists

        End Function


        Public Function executaSQL(ByVal cmd As String) As Boolean

            Try

                _command = New MySqlCommand(cmd, _connection)
                _command.ExecuteNonQuery()

                Return True

            Catch ex As Exception
                Return False
            End Try


        End Function
    End Class
End Namespace
