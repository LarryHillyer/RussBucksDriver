Public Class ContinueCronJob
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim _dbApp As New ApplicationDbContext
        Try
            Using (_dbApp)

                Dim queryCronJobs = (From qCJ In _dbApp.CronJobs
                                     Where qCJ.CronJobName = CronJobName1.Text).SingleOrDefault

                If queryCronJobs Is Nothing Then
                    Exit Sub
                Else
                    queryCronJobs.ContinueTestIsSelected = True
                End If

                Dim cronJob2 = New CurrentCronJob
                cronJob2.CronJobName = queryCronJobs.CronJobName
                cronJob2.CronJobNumber = Guid.NewGuid.ToString
                cronJob2.CronJobStartDateTime = DateTime.Now.ToString
                cronJob2.CronJobType = queryCronJobs.CronJobType

                _dbApp.CurrentCronJobs.Add(cronJob2)


                _dbApp.SaveChanges()

            End Using

            Response.Redirect("~/Administration/TestDriver.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class