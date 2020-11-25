<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDConfiguracoes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMDConfiguracoes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSelecionaPastaLog = New System.Windows.Forms.Button()
        Me.lblPastaLog = New System.Windows.Forms.Label()
        Me.rbGravaLogAT = New System.Windows.Forms.RadioButton()
        Me.rbGravaLogEV = New System.Windows.Forms.RadioButton()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnSelecionaPastaLog)
        Me.GroupBox1.Controls.Add(Me.lblPastaLog)
        Me.GroupBox1.Controls.Add(Me.rbGravaLogAT)
        Me.GroupBox1.Controls.Add(Me.rbGravaLogEV)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(877, 86)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'btnSelecionaPastaLog
        '
        Me.btnSelecionaPastaLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelecionaPastaLog.Location = New System.Drawing.Point(821, 46)
        Me.btnSelecionaPastaLog.Name = "btnSelecionaPastaLog"
        Me.btnSelecionaPastaLog.Size = New System.Drawing.Size(34, 26)
        Me.btnSelecionaPastaLog.TabIndex = 30
        Me.btnSelecionaPastaLog.Text = "..."
        Me.ToolTip.SetToolTip(Me.btnSelecionaPastaLog, "Clique aqui para selecionar a pasta para gravar o Log.")
        Me.btnSelecionaPastaLog.UseVisualStyleBackColor = True
        '
        'lblPastaLog
        '
        Me.lblPastaLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPastaLog.BackColor = System.Drawing.SystemColors.Window
        Me.lblPastaLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPastaLog.Location = New System.Drawing.Point(291, 48)
        Me.lblPastaLog.Name = "lblPastaLog"
        Me.lblPastaLog.Size = New System.Drawing.Size(530, 23)
        Me.lblPastaLog.TabIndex = 29
        '
        'rbGravaLogAT
        '
        Me.rbGravaLogAT.AutoSize = True
        Me.rbGravaLogAT.Location = New System.Drawing.Point(15, 47)
        Me.rbGravaLogAT.Name = "rbGravaLogAT"
        Me.rbGravaLogAT.Size = New System.Drawing.Size(280, 22)
        Me.rbGravaLogAT.TabIndex = 28
        Me.rbGravaLogAT.Text = "Grava Log em Arquivo Texto na Pasta:"
        Me.ToolTip.SetToolTip(Me.rbGravaLogAT, "Selecione esta opção para gravar o Log em Arquivo Texto")
        Me.rbGravaLogAT.UseVisualStyleBackColor = True
        '
        'rbGravaLogEV
        '
        Me.rbGravaLogEV.AutoSize = True
        Me.rbGravaLogEV.Checked = True
        Me.rbGravaLogEV.Location = New System.Drawing.Point(15, 17)
        Me.rbGravaLogEV.Name = "rbGravaLogEV"
        Me.rbGravaLogEV.Size = New System.Drawing.Size(205, 22)
        Me.rbGravaLogEV.TabIndex = 27
        Me.rbGravaLogEV.TabStop = True
        Me.rbGravaLogEV.Text = "Grava Log no Event Viewer"
        Me.ToolTip.SetToolTip(Me.rbGravaLogEV, "Selecione esta opção para gravar o Log no Event Viewer")
        Me.rbGravaLogEV.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(689, 92)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 32)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "OK"
        Me.ToolTip.SetToolTip(Me.btnOK, "Clique aqui para salvar as alterações.")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Location = New System.Drawing.Point(780, 92)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 32)
        Me.btnCancela.TabIndex = 15
        Me.btnCancela.Text = "Cancela"
        Me.ToolTip.SetToolTip(Me.btnCancela, "Clique aqui para cancelar as alterações.")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "DSC-RA - Configurações Padrão"
        '
        'frmMDConfiguracoes
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancela
        Me.ClientSize = New System.Drawing.Size(877, 136)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancela)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMDConfiguracoes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DKP-MD - Configurações Padrão"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents btnSelecionaPastaLog As System.Windows.Forms.Button
    Friend WithEvents lblPastaLog As System.Windows.Forms.Label
    Friend WithEvents rbGravaLogAT As System.Windows.Forms.RadioButton
    Friend WithEvents rbGravaLogEV As System.Windows.Forms.RadioButton
End Class
