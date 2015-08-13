Public Class CreateSportDatesOfTheWeeks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then
            StartGameDate1.SelectedDate = DateTime.Today
            EndGameDate1.SelectedDate = DateTime.Today
        End If


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim _dbPools As New PoolDbContext

        Try
            Using (_dbPools)
                Dim startGameDate = StartGameDate1.SelectedDate
                Dim GameDate = StartGameDate1.SelectedDate
                Dim endGameDate = EndGameDate1.SelectedDate
                Dim leagueName = TextBox1.Text
                Dim seasonPhase = TextBox2.Text
                Dim weekNum = 1

                While GameDate <= endGameDate
                    For day1 = 1 To 7
                        Dim date1 As New SportDatesOfTheWeek
                        date1.Sport = leagueName
                        date1.Date1 = GameDate
                        date1.WeekNumber = "Week" + CStr(weekNum)
                        date1.Phase = seasonPhase
                        GameDate = GameDate.AddDays(1)
                        _dbPools.SportDatesOfTheWeeks.Add(date1)
                    Next
                    weekNum += 1
                End While
                _dbPools.SaveChanges()
                Response.Redirect("~/Administration/TestDriver.aspx")
            End Using

        Catch ex As Exception

        End Try

    End Sub
End Class