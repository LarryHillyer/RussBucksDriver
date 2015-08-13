Public Class Create_Custom_Schedule
    Inherits System.Web.UI.Page

    Private CustomScheduleList As New List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim _dbPools As New PoolDbContext

            Try
                Using (_dbPools)
                    CustomScheduleCalendar1.SelectedDate = CStr(Session("selectedDate"))

                    Dim sport = CStr(Session("Sport"))
                    Dim cronJobName = CStr(Session("cronJobName"))
                    Dim SelectedDate = CustomScheduleCalendar1.SelectedDate.ToString("MM/dd/yyyy")

                    If sport = "baseball" Then

                        Dim queryMLB = (From qMLB In _dbPools.ScheduledGames
                                        Where qMLB.Sport = sport And qMLB.StartDate = SelectedDate).ToList

                        For Each game In queryMLB
                            Dim CustomScheduleDataTextField = game.HomeTeam + " vs " + game.AwayTeam + " " + game.StartTime
                            CustomScheduleList.Add(CustomScheduleDataTextField)
                            Dim customSchedule1 As New CustomScheduledGame
                            customSchedule1.CronJob = cronJobName
                            customSchedule1.AreTeamsTied = game.AreTeamsTied
                            customSchedule1.AwayScore = game.AwayScore
                            customSchedule1.AwayTeam = game.AwayTeam
                            customSchedule1.DisplayStatus1 = game.DisplayStatus1
                            customSchedule1.DisplayStatus2 = game.DisplayStatus2
                            customSchedule1.GameCode = game.GameCode
                            customSchedule1.GameDate = game.GameDate
                            customSchedule1.GameId = game.GameId
                            customSchedule1.GameTime = game.GameTime
                            customSchedule1.HomeScore = game.HomeScore
                            customSchedule1.HomeTeam = game.HomeTeam
                            customSchedule1.IsHomeTeamWinning = game.IsHomeTeamWinning
                            customSchedule1.MultipleGameNumber = game.MultipleGameNumber
                            customSchedule1.MultipleGamesAreScheduled = game.MultipleGamesAreScheduled
                            customSchedule1.OriginalStartDate = game.OriginalStartDate
                            customSchedule1.OriginalStartTime = game.OriginalStartTime
                            customSchedule1.PoolAlias = game.PoolAlias
                            customSchedule1.RescheduledGame = game.RescheduledGame
                            customSchedule1.SelectedForCustomSchedule = game.SelectedForCustomSchedule
                            customSchedule1.Sport = game.Sport
                            customSchedule1.StartDate = game.StartDate
                            customSchedule1.StartDateTime = game.StartDateTime
                            customSchedule1.StartTime = game.StartTime
                            customSchedule1.Status = game.Status
                            customSchedule1.WinningTeam = game.WinningTeam

                            _dbPools.CustomScheduledGames.Add(customSchedule1)
                        Next

                        CustomScheduleCheckBoxList1.DataSource = CustomScheduleList
                        CustomScheduleCheckBoxList1.DataBind()
                    End If

                    _dbPools.SaveChanges()

                End Using

            Catch ex As Exception

            End Try

        End If



    End Sub

    Protected Sub CustomScheduleCheckBoxList1_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim _dbPools2 As New PoolDbContext
        Dim selectedDate = CStr(Session("selectedDate"))
        Dim cronJobName = CStr(Session("cronJobName"))

        Try
            Using (_dbPools2)
                For Each item1 In CustomScheduleCheckBoxList1.Items
                    If item1.selected = True Then

                        Dim gameText = item1.value.ToString()
                        Dim gT = Split(gameText, " ")
                        Dim gameTime = gT(gT.GetLength(0) - 2) + " " + gT(gT.GetLength(0) - 1)
                        Dim gT2 = ""
                        For i = gT.GetLength(0) - 3 To 0 Step -1
                            gT2 = gT(i) + " " + gT2
                        Next
                        Dim gT3 = Split(gT2, " vs ")
                        Dim homeTeam = Trim(gT3(0))
                        Dim awayTeam = Trim(gT3(1))

                        Dim queryCustomMLBSchedule = (From qCMLBS In _dbPools2.CustomScheduledGames
                                                      Where qCMLBS.CronJob = cronJobName And qCMLBS.StartDate = selectedDate _
                                                      And qCMLBS.StartTime = gameTime And qCMLBS.HomeTeam = homeTeam And _
                                                      qCMLBS.AwayTeam = awayTeam).Single

                        queryCustomMLBSchedule.SelectedForCustomSchedule = True

                        _dbPools2.SaveChanges()
                    Else

                    End If
                Next

            End Using
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub CustomScheduleCalendar1_SelectionChanged(sender As Object, e As EventArgs)
        Dim _dbPools1 As New PoolDbContext

        Try
            Using (_dbPools1)


                Dim sport = CStr(Session("Sport"))
                Dim cronJobName = Session("cronJobName")
                Dim selectedDate = CustomScheduleCalendar1.SelectedDate.ToString("MM/dd/yyyy")
                Session("selectedDate") = selectedDate

                If sport = "baseball" Then


                    Dim queryMLB = (From qMLB In _dbPools1.ScheduledGames
                                    Where qMLB.Sport = sport And qMLB.StartDate = selectedDate).ToList

                    For Each game In queryMLB
                        Dim CustomScheduleDataTextField = game.HomeTeam + " vs " + game.AwayTeam + " " + game.StartTime
                        CustomScheduleList.Add(CustomScheduleDataTextField)
                        Dim customSchedule1 As New CustomScheduledGame
                        customSchedule1.CronJob = cronJobName
                        customSchedule1.AreTeamsTied = game.AreTeamsTied
                        customSchedule1.AwayScore = game.AwayScore
                        customSchedule1.AwayTeam = game.AwayTeam
                        customSchedule1.DisplayStatus1 = game.DisplayStatus1
                        customSchedule1.DisplayStatus2 = game.DisplayStatus2
                        customSchedule1.GameCode = game.GameCode
                        customSchedule1.GameDate = game.GameDate
                        customSchedule1.GameId = game.GameId
                        customSchedule1.GameTime = game.GameTime
                        customSchedule1.HomeScore = game.HomeScore
                        customSchedule1.HomeTeam = game.HomeTeam
                        customSchedule1.IsHomeTeamWinning = game.IsHomeTeamWinning
                        customSchedule1.MultipleGameNumber = game.MultipleGameNumber
                        customSchedule1.MultipleGamesAreScheduled = game.MultipleGamesAreScheduled
                        customSchedule1.OriginalStartDate = game.OriginalStartDate
                        customSchedule1.OriginalStartTime = game.OriginalStartTime
                        customSchedule1.PoolAlias = game.PoolAlias
                        customSchedule1.RescheduledGame = game.RescheduledGame
                        customSchedule1.SelectedForCustomSchedule = game.SelectedForCustomSchedule
                        customSchedule1.Sport = game.Sport
                        customSchedule1.StartDate = game.StartDate
                        customSchedule1.StartDateTime = game.StartDateTime
                        customSchedule1.StartTime = game.StartTime
                        customSchedule1.Status = game.Status
                        customSchedule1.WinningTeam = game.WinningTeam

                        _dbPools1.CustomScheduledGames.Add(customSchedule1)

                    Next

                    CustomScheduleCheckBoxList1.DataSource = CustomScheduleList
                    CustomScheduleCheckBoxList1.DataBind()
                End If

                _dbPools1.SaveChanges()

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Dim _dbPools3 As New PoolDbContext
        Dim _dbApp3 As New ApplicationDbContext
        Dim cronJobName = CStr(Session("cronJobName"))

        Try
            Using (_dbPools3)
                Using (_dbApp3)
                    Dim queryCustomSchedule = (From qCS In _dbPools3.CustomScheduledGames
                                               Where qCS.CronJob = cronJobName).ToList

                    For Each game In queryCustomSchedule
                        If game.SelectedForCustomSchedule = False Then
                            _dbPools3.CustomScheduledGames.Remove(game)
                        End If
                    Next

                    Dim queryQueuedSchedule = (From qQS In _dbPools3.QueuedScheduledGames
                                               Where qQS.CronJob = cronJobName).ToList

                    For Each game In queryQueuedSchedule
                        If game.SelectedForCustomSchedule = False Then
                            _dbPools3.QueuedScheduledGames.Remove(game)
                        End If
                    Next


                    _dbPools3.SaveChanges()

                    queryCustomSchedule = (From qCS In _dbPools3.CustomScheduledGames
                                               Where qCS.CronJob = cronJobName
                                               Order By qCS.StartDateTime Ascending).ToList

                    Dim dateList1 As New List(Of String)

                    For Each date1 In queryCustomSchedule
                        If dateList1.Contains(date1.GameDate) = False Then
                            dateList1.Add(date1.GameDate)
                        End If
                    Next

                    For Each date1 In dateList1
                        queryCustomSchedule = (From qCS In _dbPools3.CustomScheduledGames
                                               Where qCS.CronJob = cronJobName And qCS.GameDate = date1
                                               Order By qCS.StartDateTime Ascending).ToList

                        Dim cnt = 1
                        For Each game In queryCustomSchedule
                            game.GameId = "game" + CStr(cnt)
                            cnt += 1
                        Next

                        _dbPools3.SaveChanges()
                    Next

                    Dim startSeasonDate = CStr(Session("startSeasonDate"))
                    Dim startGameDate = dateList1(0)
                    Dim endGameDate = dateList1(dateList1.Count - 1)


                    Dim queryCronJob = (From qCJ In _dbApp3.CronJobs
                                        Where qCJ.CronJobName = cronJobName).Single

                    queryCronJob.SelectedSeasonStartDate = startSeasonDate
                    queryCronJob.SelectedSeasonStartGameDate = startGameDate
                    queryCronJob.SelectedSeasonEndDate = endGameDate

                    _dbApp3.SaveChanges()

                    Dim queryCronJobPools1 = (From qCJP1 In _dbApp3.CronJobPools
                             Where qCJP1.CronJobName = cronJobName).ToList

                    For Each pool1 In queryCronJobPools1
                        Dim queryPoolParam1 = (From qPP1 In _dbPools3.PoolParameters
                                               Where qPP1.poolAlias = pool1.CronJobPoolAlias).Single

                        queryPoolParam1.poolState = "Enter Picks"

                        queryPoolParam1.timePeriodIncrement = "1"

                        queryPoolParam1.seasonStartDate = DateTime.Parse(startSeasonDate + " " + "12:01 AM").Date.ToString("MM/dd/yyyy")
                        queryPoolParam1.seasonStartTime = "12:01 AM"

                        queryPoolParam1.seasonGameStart = DateTime.Parse(startGameDate + " " + "12:01 AM").Date.ToString("MM/dd/yyyy")

                        queryPoolParam1.seasonEndDate = DateTime.Parse(endGameDate + " " + "12:01 AM").Date.ToString("MM/dd/yyyy")

                        queryPoolParam1.CronJob = pool1.CronJobName
                        _dbPools3.SaveChanges()

                    Next

                    Dim cronJob2 = New CurrentCronJob
                    cronJob2.CronJobName = queryCronJob.CronJobName
                    cronJob2.CronJobNumber = Guid.NewGuid.ToString
                    cronJob2.CronJobStartDateTime = DateTime.Now.ToString
                    cronJob2.CronJobType = queryCronJob.CronJobType
                    _dbApp3.CurrentCronJobs.Add(cronJob2)

                    _dbApp3.SaveChanges()


                End Using
            End Using
        Catch ex As Exception

        End Try

        Response.Redirect("~/Default.aspx")

    End Sub
End Class