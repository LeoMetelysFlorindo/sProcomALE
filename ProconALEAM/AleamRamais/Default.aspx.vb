'Imports System.DirectoryServices.AccountManagement
Public Class _Default
    Inherits System.Web.UI.Page

    Public sUsuario As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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

        End If


    End Sub


   
End Class