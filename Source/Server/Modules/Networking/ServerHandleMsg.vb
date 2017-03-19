Imports Lidgren.Network

Module ServerHandleMsg

    Private typemapper As Dictionary(Of NetIncomingMessageType, Action(Of NetIncomingMessage)) = New Dictionary(Of NetIncomingMessageType, Action(Of NetIncomingMessage))()
    Private messagemapper As Dictionary(Of Enums.ClientPackets, Action(Of Integer, NetIncomingMessage)) = New Dictionary(Of Enums.ClientPackets, Action(Of Integer, NetIncomingMessage))()

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
        Dim id = Message.SenderConnection.RemoteUniqueIdentifier

        Select Case newstatus
            Case NetConnectionStatus.Connected
                ' Add our user to our system so we can retrieve their Index later.
                AddNetworkId(id)
                Console.WriteLine(String.Format("Player {0} has connected to the server.", GetIndexFromNetworkId(id)))
                Exit Select
            Case NetConnectionStatus.Disconnected
                Console.WriteLine(String.Format("Player {0} has disconnected from the server.", GetIndexFromNetworkId(id)))
                ' Remove the user from our system.
                RemoveNetworkId(id)
                Exit Select
        End Select

    End Sub

    Private Sub HandleData(Message As NetIncomingMessage)
        ' Get our packet ID, if we know it execute it!
        Dim exec As Action(Of Integer, NetIncomingMessage) = Nothing
        Dim type As Enums.ClientPackets = Message.ReadInt32()
        If messagemapper.TryGetValue(type, exec) Then exec(GetIndexFromNetworkId(Message.SenderConnection.RemoteUniqueIdentifier), Message)
    End Sub

    Private Sub HandlePing(Index As Integer, Message As NetIncomingMessage)
        ' Message.SenderConnection.RemoteUniqueIdentifier contains the ID (GUID) for this user. It can be used to identify who is who!
        ' Please note that while it -is- a Long, it is NOT an Index that goes up logically, it's an encoded GUID.

        ' Notify the console something has happened.
        Console.WriteLine(String.Format("Received Ping from {0}, sending Pong!", NetUtility.ToHexString(Message.SenderConnection.RemoteUniqueIdentifier)))

        ' Send back a pong!
        Dim buffer = New NetBuffer()
        buffer.Write(Enums.ServerPackets.Pong)
        SendDataTo(Index, buffer)
    End Sub

    Private Sub HandleClientConnect(Index As Integer, Message As NetIncomingMessage)
        ' Message.SenderConnection.RemoteUniqueIdentifier contains the ID (GUID) for this user. It can be used to identify who is who!
        ' Please note that while it -is- a Long, it is NOT an Index that goes up logically, it's an encoded GUID.

        ' Notify the console something has happened.
        Console.WriteLine(String.Format("Received Connect Request from {0}, sending ok!", Index))

        ' Send back a pong!
        Dim buffer = New NetBuffer()
        buffer.Write(Enums.ServerPackets.Connected)
        SendDataTo(Index, buffer)
    End Sub

End Module
