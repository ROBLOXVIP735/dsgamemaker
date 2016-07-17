Imports System.IO
Module SettingsLib

    Public SettingNames As New List(Of String)
    Public SettingValues As New List(Of String)
    Public SettingsPath As String = Directory.GetCurrentDirectory() + "\data.dat"

    Public Sub LoadSettings()
        SettingNames.Clear()
        SettingValues.Clear()
        For Each SettingLine As String In File.ReadAllLines(SettingsPath)
            Dim SettingName As String = SettingLine.Substring(0, SettingLine.IndexOf(" "))
            Dim SettingValue As String = SettingLine.Substring(SettingLine.IndexOf(" ") + 1)
            SettingNames.Add(SettingName)
            SettingValues.Add(SettingValue)
        Next
    End Sub

    Public Sub SaveSettings()
        Dim FinalString As String = String.Empty
        For i = 0 To SettingNames.Count - 1
            FinalString += SettingNames(i) + " " + SettingValues(i) + vbcrlf
        Next
        File.WriteAllText(SettingsPath, FinalString)
    End Sub

    Public Function GetSetting(ByVal SettingName As String) As String
        For i = 0 To SettingNames.Count - 1
            If SettingNames(i) = SettingName Then Return SettingValues(i)
        Next
        Return String.Empty
    End Function

    Public Sub SetSetting(ByVal SettingName As String, ByVal SettingValue As String)
        Dim BackupValues As New List(Of String)
		Dim i = 0
        For Each Setting As String In SettingNames
            If SettingNames(i) = SettingName Then
                BackupValues.Add(SettingValue)
            Else
                BackupValues.Add(SettingValues(i))
            End If
			i = i + 1
        Next
		i = 0
        SettingValues.Clear()
        For i = 0 To BackupValues.Count - 1
            SettingValues.Add(BackupValues(i))
        Next
        BackupValues.Clear()
    End Sub

End Module
