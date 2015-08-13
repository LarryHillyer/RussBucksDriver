Imports System.IO

Imports System.Threading
Imports System.Threading.Tasks

Public Class CreateJob
    Inherits Page
    Private PoolAliasList As New List(Of String)
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Init

        Dim _dbPools As New PoolDbContext

        Try
            Using (_dbPools)
                SportList1.Items.Add("baseball")
                SportList1.Items.Add("football")

                SportList1.SelectedValue = "baseball"

                CronJobTypeList1.Items.Add("Test")
                CronJobTypeList1.Items.Add("Schedule")
                CronJobTypeList1.Items.Add("Score")

                PoolList1.Items.Add("LoserPool")
                PoolList1.Items.Add("PlayoffPool")

                PoolList1.SelectedValue = "LoserPool"

                Dim queryPoolAliasList = (From poolParam1 In _dbPools.PoolParameters
                                     Where poolParam1.CronJob = "" Or poolParam1.CronJob Is Nothing).ToList

                If queryPoolAliasList.Count > 0 Then
                    For Each pool1 In queryPoolAliasList
                        PoolAliasList.Add(pool1.poolAlias)
                    Next
                    PoolAliasListCheckBox1.DataSource = PoolAliasList
                    PoolAliasListCheckBox1.DataBind()
                End If

                Dim currentDateTime = DateTime.Now

                Dim cDT = CStr(currentDateTime)
                Dim sp = cDT.IndexOf(" ")

                Dim currentDate = cDT.Substring(0, sp)
                Dim currentTime = cDT.Substring(sp + 1)

                StartDate1.SelectedDate = CDate(currentDate)
                StartGameDate1.SelectedDate = CDate(currentDate)
                EndGameDate1.SelectedDate = CDate(currentDate).AddDays(1)
                UserTest1.Checked = True
                Preseason1.Checked = False

                Session("Sport") = SportList1.SelectedValue

            End Using
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load


    End Sub

    Protected Sub Save1_Click(sender As Object, e As EventArgs)
        Dim _dbApp1 As New ApplicationDbContext
        Dim _dbPools1 As New PoolDbContext
        Dim _dbLoserPool1 As New LosersPoolContext
        Try
            Using (_dbApp1)
                Using (_dbPools1)
                    Using (_dbLoserPool1)


                        If CronJobName1.Text = "" Or CronJobName1.Text Is Nothing Then
                            Error1.Text = "Enter A Unique Cron Job Name"
                            Error1.ForeColor = Drawing.Color.Red
                            Error1.Visible = True
                            Exit Sub
                        Else
                            Error1.Visible = False
                        End If


                        Dim queryCronJobs = (From cJ1 In _dbApp1.CronJobs
                                             Where cJ1.CronJobName = CronJobName1.Text).ToList

                        If queryCronJobs.Count > 0 Then
                            Error1.Text = "Cron Job Name already in use"
                            Error1.ForeColor = Drawing.Color.Red
                            Error1.Visible = True
                            Exit Sub
                        Else
                            Error1.Visible = False
                        End If

                        Dim cronJobTypeIsSelected = False
                        For Each item1 In CronJobTypeList1.Items
                            If item1.selected = True Then
                                cronJobTypeIsSelected = True

                            End If
                        Next

                        If cronJobTypeIsSelected = False Then
                            Error2.Text = "No Cron Job Type Is Selected"
                            Error2.ForeColor = Drawing.Color.Red
                            Error2.Visible = True
                            Exit Sub
                        Else
                            Error2.Visible = False
                        End If

                        If PoolAliasListCheckBox1.Items.Count = 0 Then
                            Error3.Text = "Create a Pool First"
                            Error3.ForeColor = Drawing.Color.Red
                            Error3.Visible = True
                            Exit Sub
                        End If

                        For Each item1 In PoolAliasListCheckBox1.Items

                            If item1.selected = True Then
                                Dim cronJobPool1 = New CronJobPool
                                cronJobPool1.CronJobName = CronJobName1.Text
                                cronJobPool1.CronJobPoolAlias = item1.text
                                _dbApp1.CronJobPools.Add(cronJobPool1)
                            End If

                        Next

                        _dbApp1.SaveChanges()

                        Session("cronJobName") = CronJobName1.Text
                        Dim queryCronJobPools = (From qCJP1 In _dbApp1.CronJobPools
                                                 Where qCJP1.CronJobName = CronJobName1.Text).ToList

                        If queryCronJobPools.Count = 0 Then
                            Error3.Text = "No Pools Are Selected"
                            Error3.ForeColor = Drawing.Color.Red
                            Error3.Visible = True
                            Exit Sub
                        Else
                            Error3.Visible = False
                        End If

                        Dim cronJob1 As New CronJob
                        cronJob1.CronJobName = CronJobName1.Text
                        cronJob1.SelectedSport = SportList1.SelectedValue
                        cronJob1.CronJobType = CronJobTypeList1.SelectedValue

                        cronJob1.SelectedSeasonStartDate = StartDate1.SelectedDate.ToString("MM/dd/yyyy")
                        cronJob1.SelectedSeasonStartGameDate = StartGameDate1.SelectedDate.ToString("MM/dd/yyyy")
                        cronJob1.SelectedSeasonEndDate = EndGameDate1.SelectedDate.ToString("MM/dd/yyyy")

                        If UserTest1.Checked = True Then
                            cronJob1.UserTestIsSelected = True
                        Else
                            cronJob1.UserTestIsSelected = False
                        End If

                        If Preseason1.Checked = True Then
                            cronJob1.CronJobIsPreseason = True
                        Else
                            cronJob1.CronJobIsPreseason = False
                        End If

                        cronJob1.ContinueTestIsSelected = False

                        If CustomScheduleCheckBox1.Checked = True Then
                            cronJob1.CustomScheduleIsSelected = True

                        Else
                            cronJob1.CustomScheduleIsSelected = False

                            Dim cronJob2 = New CurrentCronJob
                            cronJob2.CronJobName = CronJobName1.Text
                            cronJob2.CronJobNumber = Guid.NewGuid.ToString
                            cronJob2.CronJobStartDateTime = DateTime.Now.ToString
                            cronJob2.CronJobType = CronJobTypeList1.SelectedValue

                            _dbApp1.CurrentCronJobs.Add(cronJob2)

                        End If

                        _dbApp1.CronJobs.Add(cronJob1)

                        _dbApp1.SaveChanges()

                        Dim queryCronJobPools1 = (From qCJP1 In _dbApp1.CronJobPools
                                                 Where qCJP1.CronJobName = CronJobName1.Text).ToList

                        For Each pool1 In queryCronJobPools
                            Dim queryPoolParam1 = (From qPP1 In _dbPools1.PoolParameters
                                                   Where qPP1.poolAlias = pool1.CronJobPoolAlias).Single

                            queryPoolParam1.poolState = "Enter Picks"

                            queryPoolParam1.seasonStartDate = StartDate1.SelectedDate.Date.ToString("MM/dd/yyyy")
                            queryPoolParam1.seasonStartTime = "12:01 AM"

                            queryPoolParam1.seasonGameStart = StartGameDate1.SelectedDate.Date.ToString("MM/dd/yyyy")

                            queryPoolParam1.seasonEndDate = EndGameDate1.SelectedDate.Date.ToString("MM/dd/yyyy")

                            queryPoolParam1.CronJob = pool1.CronJobName

                            If cronJob1.CronJobType = "Test" And cronJob1.SelectedSport = "baseball" Then
                                queryPoolParam1.timePeriodIncrement = "2"
                            End If

                            Dim queryBarPoolList = (From qBPL In _dbPools1.BarPoolList
                                                    Where qBPL.PoolAlias = pool1.CronJobPoolAlias).ToList

                            For Each user1 In queryBarPoolList
                                Dim newUser3 As New UserChoices
                                newUser3.UserID = user1.UserId
                                newUser3.UserName = user1.UserName
                                newUser3.PoolAlias = user1.PoolAlias
                                newUser3.TimePeriod = queryPoolParam1.timePeriodName + "1"
                                newUser3.Contender = True
                                newUser3.Team1Available = True
                                newUser3.Team2Available = True
                                newUser3.Team3Available = True
                                newUser3.Team4Available = True
                                newUser3.Team5Available = True
                                newUser3.Team6Available = True
                                newUser3.Team7Available = True
                                newUser3.Team8Available = True
                                newUser3.Team9Available = True
                                newUser3.Team10Available = True
                                newUser3.Team11Available = True
                                newUser3.Team12Available = True
                                newUser3.Team13Available = True
                                newUser3.Team14Available = True
                                newUser3.Team15Available = True
                                newUser3.Team16Available = True
                                newUser3.Team17Available = True
                                newUser3.Team18Available = True
                                newUser3.Team19Available = True
                                newUser3.Team20Available = True
                                newUser3.Team21Available = True
                                newUser3.Team22Available = True
                                newUser3.Team23Available = True
                                newUser3.Team24Available = True
                                newUser3.Team25Available = True
                                newUser3.Team26Available = True
                                newUser3.Team27Available = True
                                newUser3.Team28Available = True
                                newUser3.Team29Available = True
                                newUser3.Team30Available = True
                                newUser3.Team31Available = True
                                newUser3.Team32Available = True

                                newUser3.AdministrationPick = False
                                newUser3.Sport = user1.Sport
                                newUser3.UserIsTied = False
                                newUser3.UserIsWinning = False
                                newUser3.UserPickPostponed = False
                                newUser3.CronJob = pool1.CronJobName

                                _dbLoserPool1.UserChoicesList.Add(newUser3)

                            Next

                            _dbLoserPool1.SaveChanges()
                            _dbPools1.SaveChanges()

                        Next

                        If cronJob1.CustomScheduleIsSelected = False Then
                            Response.Redirect("~/Default.aspx")
                        Else

                            Session("selectedDate") = DateTime.Now.Date.ToString("MM/dd/yyyy")
                            Session("startSeasonDate") = cronJob1.SelectedSeasonStartDate
                            Dim cronJobName = CronJobName1.Text

                            Dim queryCustomSchedule = (From qCS In _dbPools1.CustomScheduledGames
                                                       Where qCS.CronJob = cronJobName).ToList

                            If queryCustomSchedule.Count > 0 Then
                                For Each game In queryCustomSchedule
                                    _dbPools1.CustomScheduledGames.Remove(game)
                                Next
                                _dbPools1.SaveChanges()
                            End If

                            Response.Redirect("~/Administration/Create Custom Schedule.aspx")

                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub

End Class

