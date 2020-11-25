<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarExportarRegistro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarExportarRegistro))
        Me.GroupBoxExportar = New System.Windows.Forms.GroupBox()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.lblPastaExportar = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnPastaExportar = New System.Windows.Forms.Button()
        Me.GroupBoxImportar = New System.Windows.Forms.GroupBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.lblPastaImportar = New System.Windows.Forms.Label()
        Me.lblImportarDe = New System.Windows.Forms.Label()
        Me.btnPastaImportar = New System.Windows.Forms.Button()
        Me.FolderBrowserDialogExportar = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialogImportar = New System.Windows.Forms.OpenFileDialog()
        Me.EventLogDSC = New System.Diagnostics.EventLog()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTipConfig = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBoxExportar.SuspendLayout()
        Me.GroupBoxImportar.SuspendLayout()
        CType(Me.EventLogDSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxExportar
        '
        Me.GroupBoxExportar.Controls.Add(Me.btnExportar)
        Me.GroupBoxExportar.Controls.Add(Me.lblPastaExportar)
        Me.GroupBoxExportar.Controls.Add(Me.Label13)
        Me.GroupBoxExportar.Controls.Add(Me.btnPastaExportar)
        Me.GroupBoxExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxExportar.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxExportar.Name = "GroupBoxExportar"
        Me.GroupBoxExportar.Size = New System.Drawing.Size(565, 139)
        Me.GroupBoxExportar.TabIndex = 0
        Me.GroupBoxExportar.TabStop = False
        Me.GroupBoxExportar.Text = " Exportar "
        '
        'btnExportar
        '
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Location = New System.Drawing.Point(347, 88)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(191, 38)
        Me.btnExportar.TabIndex = 27
        Me.btnExportar.Text = "Exportar Configurações"
        Me.ToolTipConfig.SetToolTip(Me.btnExportar, "Exporta as configurações de cadastro do sistema MD para arquivo de backuup.")
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'lblPastaExportar
        '
        Me.lblPastaExportar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPastaExportar.BackColor = System.Drawing.SystemColors.Window
        Me.lblPastaExportar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPastaExportar.Location = New System.Drawing.Point(20, 47)
        Me.lblPastaExportar.Name = "lblPastaExportar"
        Me.lblPastaExportar.Size = New System.Drawing.Size(478, 23)
        Me.lblPastaExportar.TabIndex = 26
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 26)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 18)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Exportar Para:"
        '
        'btnPastaExportar
        '
        Me.btnPastaExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPastaExportar.Location = New System.Drawing.Point(504, 47)
        Me.btnPastaExportar.Name = "btnPastaExportar"
        Me.btnPastaExportar.Size = New System.Drawing.Size(34, 23)
        Me.btnPastaExportar.TabIndex = 3
        Me.btnPastaExportar.Text = "..."
        Me.ToolTipConfig.SetToolTip(Me.btnPastaExportar, "Selecionar a pasta de destino do backup.")
        Me.btnPastaExportar.UseVisualStyleBackColor = True
        '
        'GroupBoxImportar
        '
        Me.GroupBoxImportar.Controls.Add(Me.btnImportar)
        Me.GroupBoxImportar.Controls.Add(Me.lblPastaImportar)
        Me.GroupBoxImportar.Controls.Add(Me.lblImportarDe)
        Me.GroupBoxImportar.Controls.Add(Me.btnPastaImportar)
        Me.GroupBoxImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxImportar.Location = New System.Drawing.Point(12, 167)
        Me.GroupBoxImportar.Name = "GroupBoxImportar"
        Me.GroupBoxImportar.Size = New System.Drawing.Size(565, 151)
        Me.GroupBoxImportar.TabIndex = 1
        Me.GroupBoxImportar.TabStop = False
        Me.GroupBoxImportar.Text = " Importar "
        '
        'btnImportar
        '
        Me.btnImportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Location = New System.Drawing.Point(350, 93)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(191, 38)
        Me.btnImportar.TabIndex = 31
        Me.btnImportar.Text = "Importar Configurações"
        Me.ToolTipConfig.SetToolTip(Me.btnImportar, "Importar arquivo de backup com as configurações do sistema MD.")
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'lblPastaImportar
        '
        Me.lblPastaImportar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPastaImportar.BackColor = System.Drawing.SystemColors.Window
        Me.lblPastaImportar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPastaImportar.Location = New System.Drawing.Point(23, 51)
        Me.lblPastaImportar.Name = "lblPastaImportar"
        Me.lblPastaImportar.Size = New System.Drawing.Size(478, 23)
        Me.lblPastaImportar.TabIndex = 30
        '
        'lblImportarDe
        '
        Me.lblImportarDe.AutoSize = True
        Me.lblImportarDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportarDe.Location = New System.Drawing.Point(23, 28)
        Me.lblImportarDe.Name = "lblImportarDe"
        Me.lblImportarDe.Size = New System.Drawing.Size(90, 18)
        Me.lblImportarDe.TabIndex = 29
        Me.lblImportarDe.Text = "Importar De:"
        '
        'btnPastaImportar
        '
        Me.btnPastaImportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPastaImportar.Location = New System.Drawing.Point(507, 51)
        Me.btnPastaImportar.Name = "btnPastaImportar"
        Me.btnPastaImportar.Size = New System.Drawing.Size(34, 23)
        Me.btnPastaImportar.TabIndex = 28
        Me.btnPastaImportar.Text = "..."
        Me.ToolTipConfig.SetToolTip(Me.btnPastaImportar, "Selecionar o arquivo de importaçao do backup.")
        Me.btnPastaImportar.UseVisualStyleBackColor = True
        '
        'OpenFileDialogImportar
        '
        Me.OpenFileDialogImportar.DefaultExt = "reg"
        Me.OpenFileDialogImportar.FileName = "DSC-Backup-RA.reg"
        Me.OpenFileDialogImportar.Filter = "|*.reg"
        Me.OpenFileDialogImportar.RestoreDirectory = True
        Me.OpenFileDialogImportar.Title = "Selecione o arquivo de origem"
        '
        'EventLogDSC
        '
        Me.EventLogDSC.SynchronizingObject = Me
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(438, 338)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 38)
        Me.Button1.TabIndex = 32
        Me.Button1.Text = "Fechar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ToolTipConfig
        '
        Me.ToolTipConfig.IsBalloon = True
        Me.ToolTipConfig.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipConfig.ToolTipTitle = "DSC-MD - Importar/Exportar Configurações"
        '
        'frmImportarExportarRegistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBoxImportar)
        Me.Controls.Add(Me.GroupBoxExportar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportarExportarRegistro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DKP-MD - Importar/Exportar Configurações"
        Me.GroupBoxExportar.ResumeLayout(False)
        Me.GroupBoxExportar.PerformLayout()
        Me.GroupBoxImportar.ResumeLayout(False)
        Me.GroupBoxImportar.PerformLayout()
        CType(Me.EventLogDSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxExportar As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxImportar As System.Windows.Forms.GroupBox
    Friend WithEvents btnPastaExportar As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblPastaExportar As System.Windows.Forms.Label
    Friend WithEvents btnExportar As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents lblPastaImportar As System.Windows.Forms.Label
    Friend WithEvents lblImportarDe As System.Windows.Forms.Label
    Friend WithEvents btnPastaImportar As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialogExportar As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialogImportar As System.Windows.Forms.OpenFileDialog
    Friend WithEvents EventLogDSC As System.Diagnostics.EventLog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTipConfig As System.Windows.Forms.ToolTip
End Class
