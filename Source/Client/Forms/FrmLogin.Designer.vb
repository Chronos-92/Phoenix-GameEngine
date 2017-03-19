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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.PnlControls.Controls.Add(Me.Button3)
        Me.PnlControls.Controls.Add(Me.Button2)
        Me.PnlControls.Controls.Add(Me.Button1)
        Me.PnlControls.Location = New System.Drawing.Point(12, 217)
        Me.PnlControls.Name = "PnlControls"
        Me.PnlControls.Size = New System.Drawing.Size(517, 64)
        Me.PnlControls.TabIndex = 1
        Me.PnlControls.Visible = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.Control
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(422, 21)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(118, 21)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Register"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(14, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Login"
        Me.Button1.UseVisualStyleBackColor = False
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
    Friend WithEvents Button3 As Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents TmrMenuLoop As Windows.Forms.Timer
End Class
