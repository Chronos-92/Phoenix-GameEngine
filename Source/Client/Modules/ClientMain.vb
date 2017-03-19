Imports System.IO
Imports System.Reflection

Module ClientMain

    Sub StartUp()
        ' Init some data and check for some directories.
        Init()
        CheckDirs()

        ' Load the game options.
        LoadOptions()

        ' Initialize Networking
        InitNetworking()

        ' Connect!
        FrmLogin.TmrMenuLoop.Enabled = True

    End Sub

    Private Sub Init()
        AppPath = New Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath
    End Sub

    Private Sub CheckDirs()
        CheckDir(Path.Combine(AppPath, DIR_RESOURCES))
    End Sub

    Private Sub CheckDir(Path As String)
        If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)
    End Sub

End Module
