Public Class Options

    Public General As GeneralOptions
    Public Network As NetworkOptions

    Public Sub New()
        General = New GeneralOptions()
        Network = New NetworkOptions()
    End Sub

    Public Class GeneralOptions
        Public GameName As String = "Phoenix Engine"
        Public MOTD As String = "Welcome to the Phoenix Engine!"
        Public MaxPlayers As UInteger = 100
    End Class

    Public Class NetworkOptions
        Public Port As UInteger = 7001
    End Class
End Class
