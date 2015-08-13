Public Class KillCronJob
    Inherits System.Web.UI.Page

    Private cronJobList As New List(Of String)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _dbApp As New ApplicationDbContext
        Dim _dbPools As New PoolDbContext
        Dim _dbLoserPool As New LosersPoolContext

        If Not Page.IsPostBack Then
            Try
                Using (_dbApp)
                    Dim queryCronJobs = (From qCJ In _dbApp.CronJobs).ToList

                    If queryCronJobs.Count > 0 Then
                        For Each job1 In queryCronJobs
                            cronJobList.Add(job1.CronJobName)
                        Next
                    End If

                    CronJobList1.DataSource = cronJobList
                    CronJobList1.DataBind()
                End Using
            Catch ex As Exception

            End Try

        End If



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim _dbApp1 As New ApplicationDbContext
        Dim _dbPools1 As New PoolDbContext
        Dim _dbLoserPool1 As New LosersPoolContext
        Try
            Using (_dbApp1)
                Using (_dbPools1)
                    Using (_dbLoserPool1)

                        For Each item1 In CronJobList1.Items
                            If item1.selected = True Then

                                Dim cronJobName = CStr(item1.text)

                                Dim queryCronJobs = (From cJ1 In _dbApp1.CronJobs
                                                    Where cJ1.CronJobName = cronJobName Or cJ1.CronJobName Is Nothing Or cJ1.CronJobName = "").SingleOrDefault

                                If queryCronJobs Is Nothing Then
                                Else
                                    _dbApp1.CronJobs.Remove(queryCronJobs)
                                End If

                                Dim queryCurrentCronJobs = (From qCCJ1 In _dbApp1.CurrentCronJobs
                                                                Where qCCJ1.CronJobName = cronJobName Or qCCJ1.CronJobName Is Nothing Or qCCJ1.CronJobName = "").SingleOrDefault

                                If queryCurrentCronJobs Is Nothing Then
                                Else
                                    _dbApp1.CurrentCronJobs.Remove(queryCurrentCronJobs)
                                End If

                                Dim queryCronJobPools = (From cJ1 In _dbApp1.CronJobPools
                                                     Where cJ1.CronJobName = cronJobName Or cJ1.CronJobName Is Nothing Or cJ1.CronJobName = "").ToList

                                For Each pool1 In queryCronJobPools
                                    _dbApp1.CronJobPools.Remove(pool1)
                                Next

                                _dbApp1.SaveChanges()

                                Dim queryPoolParams = (From qPP1 In _dbPools1.PoolParameters
                                                       Where qPP1.CronJob = cronJobName).ToList

                                For Each pool1 In queryPoolParams
                                    pool1.CronJob = ""
                                Next

                                Dim queryCustomSchedule = (From qCS In _dbPools1.CustomScheduledGames
                                                           Where qCS.CronJob = cronJobName Or qCS.CronJob Is Nothing Or qCS.CronJob = "").ToList

                                For Each game In queryCustomSchedule
                                    _dbPools1.CustomScheduledGames.Remove(game)
                                Next

                                Dim queryQueuedScheduledGames = (From qQSG In _dbPools1.QueuedScheduledGames
                                                                 Where qQSG.CronJob = cronJobName Or qQSG.CronJob Is Nothing Or qQSG.CronJob = "").ToList

                                _dbPools1.SaveChanges()


                                Dim queryScheduleTimePeriods = (From qSTP In _dbLoserPool1.ScheduleTimePeriods
                                                                Where qSTP.CronJob = cronJobName Or qSTP.CronJob Is Nothing Or qSTP.CronJob = "").ToList

                                For Each time1 In queryScheduleTimePeriods
                                    _dbLoserPool1.ScheduleTimePeriods.Remove(time1)
                                Next

                                Dim queryScheduleEntities = (From qSE In _dbLoserPool1.ScheduleEntities
                                                             Where qSE.CronJob = cronJobName Or qSE.CronJob Is Nothing Or qSE.CronJob = "").ToList

                                For Each game1 In queryScheduleEntities
                                    _dbLoserPool1.ScheduleEntities.Remove(game1)
                                Next

                                Dim queryDeletedGames = (From qDG In _dbLoserPool1.DeletedGames
                                                         Where qDG.CronJob = cronJobName Or qDG.CronJob Is Nothing Or qDG.CronJob = "").ToList

                                For Each game1 In queryDeletedGames
                                    _dbLoserPool1.DeletedGames.Remove(game1)
                                Next

                                Dim queryScoringUpdate = (From qSU In _dbLoserPool1.ScoringUpdates
                                                          Where qSU.CronJobName = cronJobName Or qSU.CronJobName Is Nothing Or qSU.CronJobName = "").ToList

                                For Each update1 In queryScoringUpdate
                                    _dbLoserPool1.ScoringUpdates.Remove(update1)
                                Next

                                Dim queryCurrentScoringUpdate = (From qCSU In _dbLoserPool1.CurrentScoringUpdates
                                                                 Where qCSU.CronJobName = cronJobName Or qCSU.CronJobName Is Nothing Or qCSU.CronJobName = "").ToList

                                For Each update1 In queryCurrentScoringUpdate
                                    _dbLoserPool1.CurrentScoringUpdates.Remove(update1)
                                Next

                                Dim queryPostponedGames = (From qPG In _dbLoserPool1.PostponedGames
                                                          Where qPG.CronJobName = cronJobName Or qPG.CronJobName Is Nothing Or qPG.CronJobName = "").ToList

                                For Each game1 In queryPostponedGames
                                    _dbLoserPool1.PostponedGames.Remove(game1)
                                Next

                                Dim queryByeTeams = (From qBT In _dbLoserPool1.ByeTeamsList
                                                     Where qBT.CronJob = cronJobName Or qBT.CronJob Is Nothing Or qBT.CronJob = "").ToList

                                For Each team1 In queryByeTeams
                                    _dbLoserPool1.ByeTeamsList.Remove(team1)
                                Next

                                Dim queryLosers = (From qL In _dbLoserPool1.LoserList
                                                   Where qL.CronJob = cronJobName Or qL.CronJob Is Nothing Or qL.CronJob = "").ToList

                                For Each loser1 In queryLosers
                                    _dbLoserPool1.LoserList.Remove(loser1)
                                Next

                                Dim queryUserChoices = (From qUC In _dbLoserPool1.UserChoicesList
                                                        Where qUC.CronJob = cronJobName Or qUC.CronJob Is Nothing Or qUC.CronJob = "").ToList

                                For Each user1 In queryUserChoices
                                    _dbLoserPool1.UserChoicesList.Remove(user1)
                                Next

                                Dim queryUserPicks = (From qUP In _dbLoserPool1.UserPicks
                                                      Where qUP.CronJobName = cronJobName Or qUP.CronJobName Is Nothing Or qUP.CronJobName = "").ToList

                                For Each user1 In queryUserPicks
                                    _dbLoserPool1.UserPicks.Remove(user1)
                                Next

                                _dbLoserPool1.SaveChanges()
                            End If
                        Next

                        Response.Redirect("~/Administration/CreateJob.aspx")

                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs)
        Dim _dbApp1 As New ApplicationDbContext
        Dim _dbPools1 As New PoolDbContext
        Dim _dbLoserPool1 As New LosersPoolContext
        Try
            Using (_dbApp1)
                Using (_dbPools1)
                    Using (_dbLoserPool1)

                        Dim queryCronJobs = (From cJ1 In _dbApp1.CronJobs).SingleOrDefault

                        If queryCronJobs Is Nothing Then
                        Else
                            _dbApp1.CronJobs.Remove(queryCronJobs)
                        End If

                        Dim queryCurrentCronJobs = (From qCCJ1 In _dbApp1.CurrentCronJobs).SingleOrDefault

                        If queryCurrentCronJobs Is Nothing Then
                        Else
                            _dbApp1.CurrentCronJobs.Remove(queryCurrentCronJobs)
                        End If

                        Dim queryCronJobPools = (From cJ1 In _dbApp1.CronJobPools).ToList

                        For Each pool1 In queryCronJobPools
                            _dbApp1.CronJobPools.Remove(pool1)
                        Next

                        _dbApp1.SaveChanges()

                        Dim queryPoolParams = (From qPP1 In _dbPools1.PoolParameters).ToList

                        For Each pool1 In queryPoolParams
                            pool1.CronJob = ""
                        Next

                        Dim queryCustomSchedule = (From qCS In _dbPools1.CustomScheduledGames).ToList

                        _dbPools1.SaveChanges()


                        Dim queryScheduleTimePeriods = (From qSTP In _dbLoserPool1.ScheduleTimePeriods).ToList

                        For Each time1 In queryScheduleTimePeriods
                            _dbLoserPool1.ScheduleTimePeriods.Remove(time1)
                        Next

                        Dim queryScheduleEntities = (From qSE In _dbLoserPool1.ScheduleEntities).ToList

                        For Each game1 In queryScheduleEntities
                            _dbLoserPool1.ScheduleEntities.Remove(game1)
                        Next

                        Dim queryDeletedGames = (From qDG In _dbLoserPool1.DeletedGames).ToList

                        For Each game1 In queryDeletedGames
                            _dbLoserPool1.DeletedGames.Remove(game1)
                        Next

                        Dim queryScoringUpdate = (From qSU In _dbLoserPool1.ScoringUpdates).ToList

                        For Each update1 In queryScoringUpdate
                            _dbLoserPool1.ScoringUpdates.Remove(update1)
                        Next

                        Dim queryCurrentScoringUpdate = (From qCSU In _dbLoserPool1.CurrentScoringUpdates).ToList

                        For Each update1 In queryCurrentScoringUpdate
                            _dbLoserPool1.CurrentScoringUpdates.Remove(update1)
                        Next

                        Dim queryPostponedGames = (From qPG In _dbLoserPool1.PostponedGames).ToList

                        For Each game1 In queryPostponedGames
                            _dbLoserPool1.PostponedGames.Remove(game1)
                        Next

                        Dim queryByeTeams = (From qBT In _dbLoserPool1.ByeTeamsList).ToList

                        For Each team1 In queryByeTeams
                            _dbLoserPool1.ByeTeamsList.Remove(team1)
                        Next

                        Dim queryLosers = (From qL In _dbLoserPool1.LoserList).ToList

                        For Each loser1 In queryLosers
                            _dbLoserPool1.LoserList.Remove(loser1)
                        Next

                        Dim queryUserChoices = (From qUC In _dbLoserPool1.UserChoicesList).ToList

                        For Each user1 In queryUserChoices
                            _dbLoserPool1.UserChoicesList.Remove(user1)
                        Next

                        Dim queryUserPicks = (From qUP In _dbLoserPool1.UserPicks).ToList

                        For Each user1 In queryUserPicks
                            _dbLoserPool1.UserPicks.Remove(user1)
                        Next

                        _dbLoserPool1.SaveChanges()


                        Response.Redirect("~/Administration/CreateJob.aspx")

                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class