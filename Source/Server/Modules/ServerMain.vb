Imports System.IO
Imports System.Reflection

Module ServerMain

    Public Sub Main()
        Dim time1 As Integer, time2 As Integer

        time1 = GetTickCount()

        ' Init some base values and locations used throughout the application.
        Init()
        CheckDirs()

        ' Load our options file and set our console title appropriately.
        LoadOptions()
        Console.Title = GameOptions.General.GameName
        Console.SetWindowSize(120, 20)

        ' Initialize our networking.
        InitNetworking()

        ' Start the Server
        OpenServer()

        Console.Clear()
        Console.WriteLine(" ____  _                      _        ____                           ")
        Console.WriteLine("|  _ \| |__   ___   ___ _ __ (_)_  __ / ___|  ___ _ ____   _____ _ __ ")
        Console.WriteLine("| |_) | '_ \ / _ \ / _ \ '_ \| \ \/ / \___ \ / _ \ '__\ \ / / _ \ '__|")
        Console.WriteLine("|  __/| | | | (_) |  __/ | | | |>  <   ___) |  __/ |   \ V /  __/ |   ")
        Console.WriteLine("|_|   |_| |_|\___/ \___|_| |_|_/_/\_\ |____/ \___|_|    \_/ \___|_|   ")

        Console.WriteLine("")

        time2 = GetTickCount()

        Console.WriteLine("Initialization complete. Server loaded in " & time2 - time1 & "ms.")
        Console.WriteLine("")
        Console.WriteLine("Use /help for the available commands.")

        ' Wait for input to close the server.
        Console.ReadKey()
        CloseServer()
    End Sub

    Private Sub Init()
        AppPath = New Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)).LocalPath
    End Sub

    Private Sub CheckDirs()
        CheckDir(Path.Combine(AppPath, DIR_DATA))
    End Sub

    Private Sub CheckDir(Path As String)
        If Not Directory.Exists(Path) Then Directory.CreateDirectory(Path)
    End Sub

    Public Function GetTickCount()
        Return Environment.TickCount
    End Function

End Module
