Imports System
Imports System.Data
Imports System.Data.Entity

Imports RussBucksDriver.JoinPools.Models

Public Class PoolParameters
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Sport1.Focus()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Dim _dbPools As New PoolDbContext
        Dim _dbLoserPool As New LosersPoolContext
        Try
            Using (_dbPools)
                Using (_dbLoserPool)

                    If PoolType1.Text = "LoserPool" Then

                        Dim queryPoolParams1 = (From qPP1 In _dbPools.PoolParameters
                            Where qPP1.poolAlias = PoolName1.Text).SingleOrDefault

                        If queryPoolParams1 Is Nothing Then
                            Dim poolParameter1 As New PoolParameter
                            poolParameter1.poolAlias = PoolName1.Text
                            poolParameter1.poolName = PoolType1.Text
                            poolParameter1.Sport = Sport1.Text
                            poolParameter1.timePeriodName = TimePeriodName1.Text
                            poolParameter1.timePeriodIncrement = TimeIncrement1.Text
                            poolParameter1.seasonStartDate = SeasonStartDate1.Text
                            poolParameter1.seasonStartTime = "12:01 AM"
                            poolParameter1.seasonGameStart = SeasonStartGameDate1.Text
                            poolParameter1.seasonEndDate = SeasonEndDate1.Text
                            poolParameter1.poolAdministrator = CStr(Session("userId"))
                            poolParameter1.poolState = "Enter Picks"

                            _dbPools.PoolParameters.Add(poolParameter1)

                            Dim userPool1 As New PoolAlias1
                            userPool1.PoolAlias = PoolName1.Text
                            userPool1.UserId = CStr(Session("userID"))
                            userPool1.UserName = UserHandle1.Text
                            userPool1.Sport = Sport1.Text
                            userPool1.PoolName = PoolType1.Text

                            _dbPools.BarPoolList.Add(userPool1)

                            _dbPools.SaveChanges()

                            Dim newUser3 As New UserChoices
                            newUser3.UserID = CStr(Session("userID"))
                            newUser3.UserName = UserHandle1.Text
                            newUser3.PoolAlias = PoolName1.Text
                            newUser3.TimePeriod = TimePeriodName1.Text + "1"
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
                            newUser3.Sport = Sport1.Text
                            newUser3.UserIsTied = False
                            newUser3.UserIsWinning = False
                            newUser3.UserPickPostponed = False

                            _dbLoserPool.UserChoicesList.Add(newUser3)
                            _dbLoserPool.SaveChanges()


                        Else
                            Label8.Text = "   Pool Name Already in Use!"
                            Label8.Visible = True
                            Exit Sub

                        End If

                    End If

                    Response.Redirect("~/Administration/TestDriver.aspx")
                End Using
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class