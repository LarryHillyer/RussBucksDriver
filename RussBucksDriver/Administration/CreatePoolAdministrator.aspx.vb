Imports RussBucksDriver.JoinPools.Models
Imports RussBucksDriver.LosersPool.Models

Public Class CreatePoolAdministrator
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PoolName1.Focus()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Dim _dbPools As New PoolDbContext
        Dim _dbLosersPool As New LosersPoolContext

        Try
            Using (_dbPools)
                Using (_dbLosersPool)
                    If UserName1.Text Is Nothing And LicenseeName1.Text Is Nothing Then
                    ElseIf UserName1.Text Is Nothing And LicenseeName1.Text = "" Then
                    ElseIf UserName1.Text Is Nothing And LicenseeName1.Text Is Nothing Then
                    ElseIf UserName1.Text = "" And LicenseeName1.Text = "" Then
                    ElseIf UserName1.Text = "" And LicenseeName1.Text Is Nothing Then
                    Else
                        Dim admin1 As New PoolAdministrator1
                        admin1.PoolAdministrator = UserName1.Text
                        admin1.LicenseeUserId = LicenseeName1.Text
                        admin1.PoolAdministratorAlias = PoolCode1.Text
                        admin1.PoolAlias = PoolName1.Text
                        _dbPools.PoolAdministrators.Add(admin1)
                        _dbPools.SaveChanges()
                    End If

                    PoolName1.Text = ""
                    UserName1.Text = ""

                    Response.Redirect("~/Administration/TestDriver.aspx")

                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class