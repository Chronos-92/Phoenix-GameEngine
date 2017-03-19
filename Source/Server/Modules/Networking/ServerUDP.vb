﻿Imports System.Threading
Imports Lidgren.Network

Module ServerUDP

    Private server As NetServer
    Private config As NetPeerConfiguration
    Private indexmapper As Dictionary(Of Integer, Long)

    Public Sub InitNetworking()
        ' Initialize our messages and messagetypes
        InitTypes()
        InitMessages()

        ' Set up our local variables.
        indexmapper = New Dictionary(Of Integer, Long)()

        ' Create a new config, set it up and create our main server handler.
        config = New NetPeerConfiguration("Phoenix")
        config.Port = GameOptions.Network.Port
        config.MaximumConnections = GameOptions.General.MaxPlayers
        server = New NetServer(config)
        server.RegisterReceivedCallback(New SendOrPostCallback(AddressOf HandleReceivedData), New SynchronizationContext())
    End Sub

    Public Sub SendDataTo(Index As Integer, Data As NetBuffer)
        SendData(indexmapper(Index), Data)
    End Sub

    Private Sub SendData(Id As Long, Data As NetBuffer)
        Dim Message = server.CreateMessage()
        Message.Write(Data)
        server.SendMessage(Message, GetConnectionFromId(Id), NetDeliveryMethod.ReliableOrdered)
    End Sub

    Public Sub OpenServer()
        server.Start()
    End Sub

    Public Sub CloseServer()
        server.Shutdown("Halting server.")
    End Sub

    Private Function GetConnectionFromId(Id As Long) As NetConnection
        GetConnectionFromId = server.Connections.Where(Function(x) x.RemoteUniqueIdentifier = Id).Single()
    End Function

    Public Sub AddNetworkId(Id As Long)
        If Not indexmapper.Any(Function(x) x.Value = Id) Then
            indexmapper.Add(GetNewIndex(), Id)
        Else
            Throw New Exception("Unable to add duplicate User Id!")
        End If
    End Sub

    Public Sub RemoveNetworkId(Id As Long)
        indexmapper.Remove(indexmapper.Where(Function(x) x.Value = Id).Single().Key)
    End Sub

    Public Function GetIndexFromNetworkId(Id As Long) As Integer
        GetIndexFromNetworkId = indexmapper.Where(Function(x) x.Value = Id).Single().Key
    End Function

    Private Function GetNewIndex() As Integer
        Dim available = Enumerable.Range(0, GameOptions.General.MaxPlayers).Except(indexmapper.Keys)
        If available.Count() < 1 Then
            GetNewIndex = False
        Else
            GetNewIndex = available.First()
        End If

    End Function
End Module
