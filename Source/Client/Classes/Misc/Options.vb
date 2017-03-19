Public Class Options

    Public Network As NetworkOptions

    Public Sub New()
        Network = New NetworkOptions()
    End Sub


    Public Class NetworkOptions
        Public Address As String = "127.0.0.1"
        Public Port As UInteger = 7001
    End Class
End Class
