Imports Lidgren.Network

Module ClientHandleMsg

    Private typemapper As Dictionary(Of NetIncomingMessageType, Action(Of NetIncomingMessage)) = New Dictionary(Of NetIncomingMessageType, Action(Of NetIncomingMessage))()
    Private messagemapper As Dictionary(Of Enums.ServerPackets, Action(Of NetIncomingMessage)) = New Dictionary(Of Enums.ServerPackets, Action(Of NetIncomingMessage))()

    Public Sub InitTypes()
        typemapper.Add(NetIncomingMessageType.StatusChanged, AddressOf HandleStatusChange)
        typemapper.Add(NetIncomingMessageType.Data, AddressOf HandleData)
    End Sub

    Public Sub InitMessages()
        messagemapper.Add(Enums.ServerPackets.Pong, AddressOf HandlePong)
        messagemapper.Add(Enums.ServerPackets.Connected, AddressOf HandleConnected)
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

        Select Case newstatus
            Case NetConnectionStatus.Connected
                Console.WriteLine("We've connected to the server!")
                Connected = True

                ' Send a message to the server so we can get a response.
                Dim buffer = New NetBuffer()
                buffer.Write(Enums.ClientPackets.CanConnect)
                SendData(buffer)
                Exit Select
            Case NetConnectionStatus.Disconnected
                Console.WriteLine("We've disconnected from the server!")
                Connected = False
                Exit Select
        End Select

    End Sub

    Private Sub HandleData(Message As NetIncomingMessage)
        ' Get our packet ID, if we know it execute it!
        Dim exec As Action(Of NetIncomingMessage) = Nothing
        Dim type As Enums.ClientPackets = Message.ReadInt32()
        If messagemapper.TryGetValue(type, exec) Then exec(Message)
    End Sub

    Private Sub HandlePong(Message As NetIncomingMessage)
        ' Notify the console something has happened.
        Console.WriteLine("Received Pong, sending Ping!")

        ' Send back a ping!
        Dim buffer = New NetBuffer()
        buffer.Write(Enums.ClientPackets.Ping)
        SendData(buffer)
    End Sub

    Private Sub HandleConnected(Message As NetIncomingMessage)
        'connection established, lets get going!
        ConnectOk = True
    End Sub

End Module
