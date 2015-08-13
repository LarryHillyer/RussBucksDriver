Public Class CreateLicensee
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CreateLicensee_Click(sender As Object, e As EventArgs)

        Dim licenseeEmail = LicenseeEmailAddress1.Text
        Dim _dbPools1 As New PoolDbContext

        Try
            Using (_dbPools1)
                If licenseeEmail = "" Or licenseeEmail Is Nothing Then
                Else
                    Dim userId As String
                    Dim user1 As String = CStr(licenseeEmail)

                    Dim Ai As Int16 = InStr(user1, "@")
                    Dim Pi As Int16 = InStr(user1, ".")

                    userId = Left(user1, Ai - 1) + Mid(user1, (Ai + 1), Pi - Ai - 1) + Right(user1, Len(user1) - Pi)

                    Dim licensee1 As New licensee
                    licensee1.licenseeUserId = userId

                    _dbPools1.Licensees.Add(licensee1)

                    _dbPools1.SaveChanges()
                End If
            End Using
        Catch ex As Exception

        End Try




    End Sub
End Class