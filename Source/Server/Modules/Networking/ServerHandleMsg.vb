Imports Lidgren.Network

Module ServerHandleMsg

    Private typemapper As Dictionary(Of NetIncomingMessageType, Action(Of NetIncomingMessage)) = New Dictionary(Of NetIncomingMessageType, Action(Of NetIncomingMessage))()
    Private messagemapper As Dictionary(Of Enums.ClientPackets, Action(Of NetIncomingMessage)) = New Dictionary(Of Enums.ClientPackets, Action(Of NetIncomingMessage))()

    Public Sub InitTypes()
        typemapper.Add(NetIncomingMessageType.StatusChanged, AddressOf HandleStatusChange)
        typemapper.Add(NetIncomingMessageType.Data, AddressOf HandleData)
    End Sub

    Public Sub InitMessages()
        messagemapper.Add(Enums.ClientPackets.Ping, AddressOf HandlePing)
        messagemapper.Add(Enums.ClientPackets.CanConnect, AddressOf HandleClientConnect)
    End Sub

    Public Sub HandleReceivedData(state As Object)
        ' Get our data from the completed message.
        Dim peer As NetPeer = state
        Dim message = peer.ReadMessage()

        ' If the message is valid, process it with the right handler for this message type.
        Dim exec As Action(Of NetIncomingMessage) = Nothing
        If typemapper.TryGetValue(message.MessageType, exec) Then exec(message)

        ' Recycle the message so we don't keep it open.
        peer.Recycle(message)
    End Sub

    Private Sub HandleStatusChange(Message As NetIncomingMessage)
        Dim newstatus As NetConnectionStatus = Message.ReadByte()

        ' Message.SenderConnection.RemoteUniqueIdentifier contains the ID (GUID) for this user. It can be used to identify who is who!
        ' Please note that while it -is- a Long, it is NOT an Index that goes up logically, it's an encoded GUID.

        Select Case newstatus
            Case NetConnectionStatus.Connected
                Console.WriteLine(String.Format("{0} has connected to the server.", NetUtility.ToHexString(Message.SenderConnection.RemoteUniqueIdentifier)))
                Exit Select
            Case NetConnectionStatus.Disconnected
                Console.WriteLine(String.Format("{0} has disconnected from the server.", NetUtility.ToHexString(Message.SenderConnection.RemoteUniqueIdentifier)))
                Exit Select
        End Select

    End Sub

    Private Sub HandleData(Message As NetIncomingMessage)
        ' Get our packet ID, if we know it execute it!
        Dim exec As Action(Of NetIncomingMessage) = Nothing
        Dim type As Enums.ClientPackets = Message.ReadInt32()
        If messagemapper.TryGetValue(type, exec) Then exec(Message)
    End Sub

    Private Sub HandlePing(Message As NetIncomingMessage)
        ' Message.SenderConnection.RemoteUniqueIdentifier contains the ID (GUID) for this user. It can be used to identify who is who!
        ' Please note that while it -is- a Long, it is NOT an Index that goes up logically, it's an encoded GUID.

        ' Notify the console something has happened.
        Console.WriteLine(String.Format("Received Ping from {0}, sending Pong!", NetUtility.ToHexString(Message.SenderConnection.RemoteUniqueIdentifier)))

        ' Send back a pong!
        Dim buffer = New NetBuffer()
        buffer.Write(Enums.ServerPackets.Pong)
        SendDataTo(Message.SenderConnection.RemoteUniqueIdentifier, buffer)
    End Sub

    Private Sub HandleClientConnect(Message As NetIncomingMessage)
        ' Message.SenderConnection.RemoteUniqueIdentifier contains the ID (GUID) for this user. It can be used to identify who is who!
        ' Please note that while it -is- a Long, it is NOT an Index that goes up logically, it's an encoded GUID.

        ' Notify the console something has happened.
        Console.WriteLine(String.Format("Received Connect Request from {0}, sending ok!", NetUtility.ToHexString(Message.SenderConnection.RemoteUniqueIdentifier)))

        ' Send back a pong!
        Dim buffer = New NetBuffer()
        buffer.Write(Enums.ServerPackets.Connected)
        SendDataTo(Message.SenderConnection.RemoteUniqueIdentifier, buffer)
    End Sub

End Module
