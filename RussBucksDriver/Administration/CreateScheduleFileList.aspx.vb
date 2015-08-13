Imports System.Xml
Imports System.Xml.Linq

Imports RussBucksDriver.JoinPools.Models

Public Class CreateScheduleFileList
    Inherits System.Web.UI.Page
    Private _dbApp As New ApplicationDbContext
    Private _dbPools As New PoolDbContext
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs)

        Try
            Using (_dbApp)
                Using (_dbPools)

                    Dim rootFolder = (From param1 In _dbApp.AppFolders).Single
                    System.IO.Directory.SetCurrentDirectory(rootFolder.rootFolder)

                    Dim queryPoolParam = (From param1 In _dbPools.PoolParameters
                                           Where param1.poolAlias = PoolAlias1.Text).Single

                    Dim sport1a = queryPoolParam.Sport


                    Dim ScheduleDataFileListDoc = XDocument.Load(".\TestFiles\ScheduleDataFileList" + sport1a + ".xml")

                    Dim querySDFLD = (From list1 In ScheduleDataFileListDoc.Descendants("schedulefiles").Descendants("file")).ToList


                    For Each file1 In querySDFLD
                        ScheduleDataFileListDoc.Descendants("schedulefiles").Descendants("file").Remove()
                    Next

                    Dim fFN = CInt(FirstFileNumber1.Text)
                    Dim lFN = CInt(LastFileNumber1.Text)

                    For fN = lFN To fFN Step -queryPoolParam.timePeriodIncrement

                        Dim xEFile As New XElement("file")
                        Dim xATimeP As New XAttribute("TimePeriod", queryPoolParam.timePeriodName + CStr(fN))
                        Dim xEFilePath As New XElement("filepath", ".\TestFiles\scheduleFile" + CStr(fN) + sport1a + ".xml")

                        ScheduleDataFileListDoc.Element("schedulefiles").AddFirst(xEFile)
                        ScheduleDataFileListDoc.Element("schedulefiles").Element("file").Add(xATimeP)
                        ScheduleDataFileListDoc.Element("schedulefiles").Element("file").Add(xEFilePath)
                    Next

                    ScheduleDataFileListDoc.Save(".\TestFiles\ScheduleDataFileList" + sport1a + ".xml")

                End Using
            End Using
        Catch ex As Exception

        End Try

    End Sub
End Class