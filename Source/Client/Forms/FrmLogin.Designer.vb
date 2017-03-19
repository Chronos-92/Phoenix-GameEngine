<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LblConnection = New System.Windows.Forms.Label()
        Me.PnlControls = New System.Windows.Forms.Panel()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.BtnRegister = New System.Windows.Forms.Button()
        Me.BtnLogin = New System.Windows.Forms.Button()
        Me.TmrMenuLoop = New System.Windows.Forms.Timer(Me.components)
        Me.PnlControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblConnection
        '
        Me.LblConnection.AutoSize = True
        Me.LblConnection.Location = New System.Drawing.Point(431, 9)
        Me.LblConnection.Name = "LblConnection"
        Me.LblConnection.Size = New System.Drawing.Size(82, 13)
        Me.LblConnection.TabIndex = 0
        Me.LblConnection.Text = "Not Connected!"
        '
        'PnlControls
        '
        Me.PnlControls.Controls.Add(Me.BtnExit)
        Me.PnlControls.Controls.Add(Me.BtnRegister)
        Me.PnlControls.Controls.Add(Me.BtnLogin)
        Me.PnlControls.Location = New System.Drawing.Point(12, 217)
        Me.PnlControls.Name = "PnlControls"
        Me.PnlControls.Size = New System.Drawing.Size(517, 64)
        Me.PnlControls.TabIndex = 1
        Me.PnlControls.Visible = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.SystemColors.Control
        Me.BtnExit.ForeColor = System.Drawing.Color.Black
        Me.BtnExit.Location = New System.Drawing.Point(422, 21)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "Exit"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'BtnRegister
        '
        Me.BtnRegister.BackColor = System.Drawing.SystemColors.Control
        Me.BtnRegister.ForeColor = System.Drawing.Color.Black
        Me.BtnRegister.Location = New System.Drawing.Point(118, 21)
        Me.BtnRegister.Name = "BtnRegister"
        Me.BtnRegister.Size = New System.Drawing.Size(75, 23)
        Me.BtnRegister.TabIndex = 1
        Me.BtnRegister.Text = "Register"
        Me.BtnRegister.UseVisualStyleBackColor = False
        '
        'BtnLogin
        '
        Me.BtnLogin.BackColor = System.Drawing.SystemColors.Control
        Me.BtnLogin.ForeColor = System.Drawing.Color.Black
        Me.BtnLogin.Location = New System.Drawing.Point(14, 21)
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.Size = New System.Drawing.Size(75, 23)
        Me.BtnLogin.TabIndex = 0
        Me.BtnLogin.Text = "Login"
        Me.BtnLogin.UseVisualStyleBackColor = False
        '
        'TmrMenuLoop
        '
        Me.TmrMenuLoop.Enabled = True
        Me.TmrMenuLoop.Interval = 1000
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(541, 293)
        Me.Controls.Add(Me.PnlControls)
        Me.Controls.Add(Me.LblConnection)
        Me.ForeColor = System.Drawing.Color.Gainsboro
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmLogin"
        Me.Text = "Phoenix Game Engine"
        Me.PnlControls.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblConnection As Windows.Forms.Label
    Friend WithEvents PnlControls As Windows.Forms.Panel
    Friend WithEvents BtnExit As Windows.Forms.Button
    Friend WithEvents BtnRegister As Windows.Forms.Button
    Friend WithEvents BtnLogin As Windows.Forms.Button
    Friend WithEvents TmrMenuLoop As Windows.Forms.Timer
End Class
