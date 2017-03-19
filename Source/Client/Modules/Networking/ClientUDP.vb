Imports System.Threading
Imports Lidgren.Network

Module ClientUDP

    Private config As NetPeerConfiguration
    Private client As NetClient

    Public Sub InitNetworking()
        ' Initialize our messages and messagetypes
        InitTypes()
        InitMessages()

        ' Init our client networking socket.
        config = New NetPeerConfiguration("Phoenix")
        client = New NetClient(config)
        client.RegisterReceivedCallback(AddressOf HandleReceivedData, New SynchronizationContext())
    End Sub

    Public Sub SendData(Data As NetBuffer)
        Dim message = client.CreateMessage()
        message.Write(Data)
        client.SendMessage(message, NetDeliveryMethod.ReliableOrdered)
    End Sub

    Public Sub ConnectToServer()
        client.Start()
        Dim hail = client.CreateMessage("Coming in hot!")
        client.Connect(GameOptions.Network.Address, GameOptions.Network.Port, hail)
    End Sub

    Public Sub DisconnectFromServer()
        client.Disconnect("Halting client.")
    End Sub

End Module
