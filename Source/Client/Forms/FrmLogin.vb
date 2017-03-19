Imports System.Windows.Forms

Public Class FrmLogin
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartUp()
    End Sub

    Private Sub FrmLogin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        DisconnectFromServer()
    End Sub

    Private Sub TmrMenuLoop_Tick(sender As Object, e As EventArgs) Handles TmrMenuLoop.Tick
        If Connected Then
            LblConnection.Text = "Connected!"
        Else
            LblConnection.Text = "Not Connected!"
            ConnectToServer()
        End If

        If ConnectOk Then
            PnlControls.Visible = True
        End If
    End Sub
End Class