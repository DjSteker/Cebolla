<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Nevegador
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Nevegador))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TextBox_URL = New System.Windows.Forms.TextBox()
        Me.Button_Browser = New System.Windows.Forms.Button()
        Me.Label_Estado = New System.Windows.Forms.Label()
        Me.ProgressBar_Progressbar = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(2, 26)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1259, 700)
        Me.WebBrowser1.TabIndex = 0
        '
        'TextBox_URL
        '
        Me.TextBox_URL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox_URL.Location = New System.Drawing.Point(80, 0)
        Me.TextBox_URL.Name = "TextBox_URL"
        Me.TextBox_URL.Size = New System.Drawing.Size(1181, 20)
        Me.TextBox_URL.TabIndex = 1
        '
        'Button_Browser
        '
        Me.Button_Browser.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_Browser.Location = New System.Drawing.Point(0, 0)
        Me.Button_Browser.Name = "Button_Browser"
        Me.Button_Browser.Size = New System.Drawing.Size(76, 20)
        Me.Button_Browser.TabIndex = 2
        Me.Button_Browser.Text = "Busqueda"
        Me.Button_Browser.UseVisualStyleBackColor = True
        '
        'Label_Estado
        '
        Me.Label_Estado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label_Estado.AutoSize = True
        Me.Label_Estado.Location = New System.Drawing.Point(118, 707)
        Me.Label_Estado.Name = "Label_Estado"
        Me.Label_Estado.Size = New System.Drawing.Size(72, 13)
        Me.Label_Estado.TabIndex = 3
        Me.Label_Estado.Text = "Label_Estado"
        '
        'ProgressBar_Progressbar
        '
        Me.ProgressBar_Progressbar.Location = New System.Drawing.Point(12, 706)
        Me.ProgressBar_Progressbar.Name = "ProgressBar_Progressbar"
        Me.ProgressBar_Progressbar.Size = New System.Drawing.Size(100, 14)
        Me.ProgressBar_Progressbar.TabIndex = 4
        '
        'Form_Nevegador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 729)
        Me.Controls.Add(Me.ProgressBar_Progressbar)
        Me.Controls.Add(Me.Label_Estado)
        Me.Controls.Add(Me.Button_Browser)
        Me.Controls.Add(Me.TextBox_URL)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Nevegador"
        Me.Text = "Nevegador"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents TextBox_URL As TextBox
    Friend WithEvents Button_Browser As Button
    Friend WithEvents Label_Estado As Label
    Friend WithEvents ProgressBar_Progressbar As ProgressBar
End Class

