<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNovoCNPJ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNovoCNPJ))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUF = New System.Windows.Forms.ComboBox()
        Me.txtNomeFantasia = New System.Windows.Forms.TextBox()
        Me.lblNomeFantasia = New System.Windows.Forms.Label()
        Me.mtxtNPJ = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboUF)
        Me.GroupBox1.Controls.Add(Me.txtNomeFantasia)
        Me.GroupBox1.Controls.Add(Me.lblNomeFantasia)
        Me.GroupBox1.Controls.Add(Me.mtxtNPJ)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(441, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 18)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "UF:"
        '
        'cboUF
        '
        Me.cboUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUF.FormattingEnabled = True
        Me.cboUF.Location = New System.Drawing.Point(479, 20)
        Me.cboUF.Name = "cboUF"
        Me.cboUF.Size = New System.Drawing.Size(69, 21)
        Me.cboUF.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.cboUF, "Informe a UF da empresa.")
        '
        'txtNomeFantasia
        '
        Me.txtNomeFantasia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomeFantasia.Location = New System.Drawing.Point(125, 47)
        Me.txtNomeFantasia.Name = "txtNomeFantasia"
        Me.txtNomeFantasia.Size = New System.Drawing.Size(424, 24)
        Me.txtNomeFantasia.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.txtNomeFantasia, "Informe um nome para identificar a empresa.")
        '
        'lblNomeFantasia
        '
        Me.lblNomeFantasia.AutoSize = True
        Me.lblNomeFantasia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomeFantasia.Location = New System.Drawing.Point(6, 50)
        Me.lblNomeFantasia.Name = "lblNomeFantasia"
        Me.lblNomeFantasia.Size = New System.Drawing.Size(113, 18)
        Me.lblNomeFantasia.TabIndex = 2
        Me.lblNomeFantasia.Text = "Nome Fantasia:"
        '
        'mtxtNPJ
        '
        Me.mtxtNPJ.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtNPJ.Location = New System.Drawing.Point(125, 17)
        Me.mtxtNPJ.Mask = "00,000,000/0000-00"
        Me.mtxtNPJ.Name = "mtxtNPJ"
        Me.mtxtNPJ.Size = New System.Drawing.Size(154, 24)
        Me.mtxtNPJ.TabIndex = 0
        Me.ToolTip.SetToolTip(Me.mtxtNPJ, "Informe o CNPJ.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(67, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CNPJ:"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(374, 99)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.ToolTip.SetToolTip(Me.btnOK, "Clique aqui para salvar as alterações.")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Location = New System.Drawing.Point(465, 99)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(85, 32)
        Me.btnCancela.TabIndex = 3
        Me.btnCancela.Text = "Cancela"
        Me.ToolTip.SetToolTip(Me.btnCancela, "Clique aqui para cancelar as alterações.")
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'ToolTip
        '
        Me.ToolTip.IsBalloon = True
        Me.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip.ToolTipTitle = "DSC-MD - Cadastro de Novo CNPJ"
        '
        'frmNovoCNPJ
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancela
        Me.ClientSize = New System.Drawing.Size(550, 129)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNovoCNPJ"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DKP-MD - Cadastro de Novo CNPJ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNomeFantasia As System.Windows.Forms.TextBox
    Friend WithEvents lblNomeFantasia As System.Windows.Forms.Label
    Friend WithEvents mtxtNPJ As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Private WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboUF As System.Windows.Forms.ComboBox
End Class
