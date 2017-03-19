Imports System.Windows.Forms

Public Class FrmLogin
#Region "Frm Code"
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StartUp()
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

#End Region

#Region "Controls"
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click

    End Sub

    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles BtnRegister.Click

    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        DisconnectFromServer()
    End Sub
#End Region
End Class