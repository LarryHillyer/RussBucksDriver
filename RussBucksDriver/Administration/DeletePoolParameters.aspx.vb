Imports RussBucksDriver.JoinPools.Models


Public Class DeletePoolParameters
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim _dbPools = New PoolDbContext

        Try
            Using (_dbPools)
                Dim queryParameters = (From param1 In _dbPools.PoolParameters).ToList

                If queryParameters.Count > 0 Then
                    For Each param1 In queryParameters
                        _dbPools.PoolParameters.Remove(param1)
                    Next
                End If
                _dbPools.SaveChanges()

                Response.Redirect("~/Administration/TestDriver.aspx")
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Dim _dbPools1 As New PoolDbContext
        Try
            Using (_dbPools1)
                Dim queryParameters = (From param1 In _dbPools1.PoolParameters
                                       Where param1.poolAlias = PoolName1.Text).SingleOrDefault
                If queryParameters Is Nothing Then
                    Label3.Text = "Not A Valid Pool"
                    Label3.Visible = True
                    Exit Sub
                Else

                    Dim queryPoolAliases = (From qPA In _dbPools1.BarPoolList
                                            Where qPA.PoolAlias = queryParameters.poolAlias).ToList

                    If queryPoolAliases.Count > 0 Then
                        For Each user1 In queryPoolAliases
                            _dbPools1.BarPoolList.Remove(user1)
                        Next
                    End If

                    _dbPools1.PoolParameters.Remove(queryParameters)

                    _dbPools1.SaveChanges()

                    Response.Redirect("~/Administration/TestDriver.aspx")

                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class