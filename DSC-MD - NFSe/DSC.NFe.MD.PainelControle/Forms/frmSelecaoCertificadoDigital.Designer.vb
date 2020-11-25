<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelecaoCertificadoDigital
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelecaoCertificadoDigital))
        Me.btnMostraCertificado = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudDiasAviso = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIssuerName = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblFriendlyName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbValidade = New System.Windows.Forms.GroupBox()
        Me.lblIssuedTo = New System.Windows.Forms.Label()
        Me.lblSimpleName = New System.Windows.Forms.Label()
        Me.lblValidateTo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblValidateFrom = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSelecionaCertificado = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.mtxtEmail = New System.Windows.Forms.MaskedTextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudDiasAviso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbValidade.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnMostraCertificado
        '
        Me.btnMostraCertificado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMostraCertificado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostraCertificado.Location = New System.Drawing.Point(18, 203)
        Me.btnMostraCertificado.Name = "btnMostraCertificado"
        Me.btnMostraCertificado.Size = New System.Drawing.Size(180, 30)
        Me.btnMostraCertificado.TabIndex = 11
        Me.btnMostraCertificado.Text = "Mostra Certificado"
        Me.ToolTip.SetToolTip(Me.btnMostraCertificado, "Clique aqui para visalizar o Certificado Digital.")
        Me.btnMostraCertificado.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnCancela)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.btnOK)
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.btnMostraCertificado)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.nudDiasAviso)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblIssuerName)
        Me.GroupBox2.Controls.Add(Me.lblSerialNumber)
        Me.GroupBox2.Controls.Add(Me.lblFriendlyName)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.gbValidade)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.btnSelecionaCertificado)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(665, 244)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'btnCancela
        '
        Me.btnCancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Location = New System.Drawing.Point(568, 203)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 32)
        Me.btnCancela.TabIndex = 17
        Me.btnCancela.Text = "Cancela"
        Me.ToolTip.SetToolTip(Me.btnCancela, "Clique aqui para cancelar as alterações.")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 185)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(201, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "obs.: separar os e-mail por vírgual"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(477, 203)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 32)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "OK"
        Me.ToolTip.SetToolTip(Me.btnOK, "Clique aqui para salvar as alterações.")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(16, 158)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(631, 24)
        Me.txtEmail.TabIndex = 34
        Me.ToolTip.SetToolTip(Me.txtEmail, "Informe o e-mail para receber um alerta sobre a expiração do certificado digital." &
        "")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(424, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 18)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "dias de antecedência,  no e-mail"
        '
        'nudDiasAviso
        '
        Me.nudDiasAviso.Location = New System.Drawing.Point(373, 129)
        Me.nudDiasAviso.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudDiasAviso.Name = "nudDiasAviso"
        Me.nudDiasAviso.Size = New System.Drawing.Size(45, 24)
        Me.nudDiasAviso.TabIndex = 32
        Me.nudDiasAviso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip.SetToolTip(Me.nudDiasAviso, "Informe o número de dias antes de expirar seu certificado digital que quer recebe" &
        "r um alerta por e-mail.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 18)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Receber aviso de expiração do certificado digital com "
        '
        'lblIssuerName
        '
        Me.lblIssuerName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIssuerName.BackColor = System.Drawing.SystemColors.Window
        Me.lblIssuerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIssuerName.Location = New System.Drawing.Point(81, 81)
        Me.lblIssuerName.Name = "lblIssuerName"
        Me.lblIssuerName.Size = New System.Drawing.Size(566, 41)
        Me.lblIssuerName.TabIndex = 30
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSerialNumber.BackColor = System.Drawing.SystemColors.Window
        Me.lblSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSerialNumber.Location = New System.Drawing.Point(81, 49)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(566, 23)
        Me.lblSerialNumber.TabIndex = 29
        '
        'lblFriendlyName
        '
        Me.lblFriendlyName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFriendlyName.BackColor = System.Drawing.SystemColors.Window
        Me.lblFriendlyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFriendlyName.Location = New System.Drawing.Point(81, 19)
        Me.lblFriendlyName.Name = "lblFriendlyName"
        Me.lblFriendlyName.Size = New System.Drawing.Size(537, 23)
        Me.lblFriendlyName.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 18)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Emissor:"
        '
        'gbValidade
        '
        Me.gbValidade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbValidade.Controls.Add(Me.lblIssuedTo)
        Me.gbValidade.Controls.Add(Me.lblSimpleName)
        Me.gbValidade.Controls.Add(Me.lblValidateTo)
        Me.gbValidade.Controls.Add(Me.Label10)
        Me.gbValidade.Controls.Add(Me.lblValidateFrom)
        Me.gbValidade.Controls.Add(Me.Label8)
        Me.gbValidade.Controls.Add(Me.Label7)
        Me.gbValidade.Controls.Add(Me.Label11)
        Me.gbValidade.Location = New System.Drawing.Point(16, 199)
        Me.gbValidade.Name = "gbValidade"
        Me.gbValidade.Size = New System.Drawing.Size(641, 105)
        Me.gbValidade.TabIndex = 26
        Me.gbValidade.TabStop = False
        Me.gbValidade.Visible = False
        '
        'lblIssuedTo
        '
        Me.lblIssuedTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuedTo.Location = New System.Drawing.Point(106, 75)
        Me.lblIssuedTo.Name = "lblIssuedTo"
        Me.lblIssuedTo.Size = New System.Drawing.Size(475, 19)
        Me.lblIssuedTo.TabIndex = 30
        Me.lblIssuedTo.Text = "Emitido para"
        '
        'lblSimpleName
        '
        Me.lblSimpleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSimpleName.Location = New System.Drawing.Point(106, 47)
        Me.lblSimpleName.Name = "lblSimpleName"
        Me.lblSimpleName.Size = New System.Drawing.Size(417, 22)
        Me.lblSimpleName.TabIndex = 29
        Me.lblSimpleName.Text = "Emitido por"
        '
        'lblValidateTo
        '
        Me.lblValidateTo.AutoSize = True
        Me.lblValidateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidateTo.Location = New System.Drawing.Point(269, 20)
        Me.lblValidateTo.Name = "lblValidateTo"
        Me.lblValidateTo.Size = New System.Drawing.Size(90, 18)
        Me.lblValidateTo.TabIndex = 28
        Me.lblValidateTo.Text = "99/99/9999"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(235, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 18)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "até"
        '
        'lblValidateFrom
        '
        Me.lblValidateFrom.AutoSize = True
        Me.lblValidateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidateFrom.Location = New System.Drawing.Point(139, 20)
        Me.lblValidateFrom.Name = "lblValidateFrom"
        Me.lblValidateFrom.Size = New System.Drawing.Size(90, 18)
        Me.lblValidateFrom.TabIndex = 26
        Me.lblValidateFrom.Text = "99/99/9999"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 18)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Emitido para:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 18)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Emitido por:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 18)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Válido a partir de:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(30, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(49, 18)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Serial:"
        '
        'btnSelecionaCertificado
        '
        Me.btnSelecionaCertificado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSelecionaCertificado.Location = New System.Drawing.Point(617, 19)
        Me.btnSelecionaCertificado.Name = "btnSelecionaCertificado"
        Me.btnSelecionaCertificado.Size = New System.Drawing.Size(30, 24)
        Me.btnSelecionaCertificado.TabIndex = 15
        Me.btnSelecionaCertificado.Text = "..."
        Me.ToolTip.SetToolTip(Me.btnSelecionaCertificado, "Clique aqui para selecionar o Certificado Digital para acesso ao Sefaz.")
        Me.btnSelecionaCertificado.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 18)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Nome:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'mtxtEmail
        '
        Me.mtxtEmail.Location = New System.Drawing.Point(16, 159)
        Me.mtxtEmail.Name = "mtxtEmail"
        Me.mtxtEmail.Size = New System.Drawing.Size(641, 20)
        Me.mtxtEmail.TabIndex = 34
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "DSC-MD - Seleção de Certificado Digital"
        '
        'frmSelecaoCertificadoDigital
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancela
        Me.ClientSize = New System.Drawing.Size(665, 248)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelecaoCertificadoDigital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DKP-MD - Seleção de Certificado Digital"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudDiasAviso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbValidade.ResumeLayout(False)
        Me.gbValidade.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMostraCertificado As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gbValidade As System.Windows.Forms.GroupBox
    Friend WithEvents lblIssuedTo As System.Windows.Forms.Label
    Friend WithEvents lblSimpleName As System.Windows.Forms.Label
    Friend WithEvents lblValidateTo As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblValidateFrom As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnSelecionaCertificado As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFriendlyName As System.Windows.Forms.Label
    Friend WithEvents lblSerialNumber As System.Windows.Forms.Label
    Friend WithEvents lblIssuerName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudDiasAviso As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents mtxtEmail As System.Windows.Forms.MaskedTextBox
    Private WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
