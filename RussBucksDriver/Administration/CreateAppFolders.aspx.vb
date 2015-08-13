Public Class CreateAppFolders
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RootFolder1.Focus()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim _dbApp As New ApplicationDbContext
        Try
            Using (_dbApp)
                Dim appFolder1 As New AppFolder
                appFolder1.rootFolder = RootFolder1.Text
                appFolder1.driverRootFolder = DriverRootFolder1.Text
                appFolder1.testCronJobFolder = TestCronJobFolder1.Text
                appFolder1.scheduleCronJobFolder = ScheduleCronJobFolder1.Text
                appFolder1.scoreCronJobFolder = ScoreCronJobFolder1.Text

                Dim pythonScrapedFolder As String = "C:"
                Dim pythonScrapedFolderStrings = ScoreCronJobFolder1.Text.Split("\")

                For Each string1 In pythonScrapedFolderStrings
                    If string1 <> pythonScrapedFolderStrings(0) Then
                        pythonScrapedFolder = pythonScrapedFolder + "\\" + string1
                    End If
                Next
                appFolder1.scrapedFilesFolder = pythonScrapedFolder + "\\ScrapedFiles\\"

                pythonScrapedFolder = "C:"
                pythonScrapedFolderStrings = ScheduleCronJobFolder1.Text.Split("\")

                For Each string1 In pythonScrapedFolderStrings
                    If string1 <> pythonScrapedFolderStrings(0) Then
                        pythonScrapedFolder = pythonScrapedFolder + "\\" + string1
                    End If
                Next
                appFolder1.scrapedScheduleFilesFolder = pythonScrapedFolder + "\\ScrapedFiles\\"


                _dbApp.AppFolders.Add(appFolder1)
                _dbApp.SaveChanges()
            End Using
            Response.Redirect("~/Administration/TestDriver.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class