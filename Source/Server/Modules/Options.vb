Imports System.IO
Imports Newtonsoft.Json

Module OptionsData
    Public Sub LoadOptions()
        If Not File.Exists(GetOptionsFile()) Then
            GameOptions = New Options()
            SaveOptions()
        End If
        GameOptions = JsonConvert.DeserializeObject(Of Options)(File.ReadAllText(GetOptionsFile()))
    End Sub

    Public Sub SaveOptions()
        File.WriteAllText(GetOptionsFile(), JsonConvert.SerializeObject(GameOptions))
    End Sub

    Public Function GetOptionsFile() As String
        GetOptionsFile = Path.Combine(AppPath, DIR_DATA, "Options.json")
    End Function
End Module
