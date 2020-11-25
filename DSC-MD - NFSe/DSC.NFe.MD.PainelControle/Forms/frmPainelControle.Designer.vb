<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPainelControle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPainelControle))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Configurações Padrão", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Empresa 1", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Empresa 2", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Adiciona CNPJ", "New Window.png")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Check List", "Panel Setting.png")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Configuração", "Connexion internet 2.png")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Configuração da caixa de recebimento do XML da NF-e", "Mail3.png")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Configuração de e-mail", "TESTE"}, "My-Network.png")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Configuração do Progress (ODBC)", "Computer.png")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Importar/Exportar Configurações", "System-Registry-icon.png")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Instalação do Certificado Digital", "Net Folder.png")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Seleção de Certificado Digital", "My-Docs.png")
        Dim ListViewItem10 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Serviços", "Connexion internet 2.png")
        Dim ListViewItem11 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Testa conexão com Sefaz", "Mail (5).png")
        Dim ListViewItem12 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Visualizador de Eventos"}, "My-Computer.png", System.Drawing.Color.DarkGreen, System.Drawing.Color.Empty, Nothing)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.lvPainel = New System.Windows.Forms.ListView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslPainel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "AdicionaCNPJ.png")
        Me.ImageList1.Images.SetKeyName(1, "ButtonDelete.png")
        Me.ImageList1.Images.SetKeyName(2, "ButtonError.png")
        Me.ImageList1.Images.SetKeyName(3, "ButtonExclamation.png")
        Me.ImageList1.Images.SetKeyName(4, "ButtonHelp.png")
        Me.ImageList1.Images.SetKeyName(5, "ButtonInformation.png")
        Me.ImageList1.Images.SetKeyName(6, "ButtonOK.png")
        Me.ImageList1.Images.SetKeyName(7, "Folder.png")
        Me.ImageList1.Images.SetKeyName(8, "FolderDownload.png")
        Me.ImageList1.Images.SetKeyName(9, "FolderXmlRejected.png")
        Me.ImageList1.Images.SetKeyName(10, "FolderFinished.png")
        Me.ImageList1.Images.SetKeyName(11, "FolderXmlNFe.png")
        Me.ImageList1.Images.SetKeyName(12, "FolderOK.png")
        Me.ImageList1.Images.SetKeyName(13, "FolderProgress.png")
        Me.ImageList1.Images.SetKeyName(14, "FolderTrash.png")
        Me.ImageList1.Images.SetKeyName(15, "FolderZip.png")
        Me.ImageList1.Images.SetKeyName(16, "Logo RA 1.png")
        Me.ImageList1.Images.SetKeyName(17, "Logo RA.png")
        Me.ImageList1.Images.SetKeyName(18, "PainelControle.png")
        Me.ImageList1.Images.SetKeyName(19, "CheckList.png")
        Me.ImageList1.Images.SetKeyName(20, "InstalacaoCertificadoDigital.png")
        Me.ImageList1.Images.SetKeyName(21, "CertificadoDigital.png")
        Me.ImageList1.Images.SetKeyName(22, "ConfiguraEmail.png")
        Me.ImageList1.Images.SetKeyName(23, "Configurações.png")
        Me.ImageList1.Images.SetKeyName(24, "System-Registry-icon.png")
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.BalloonTipText = "DSC - Recebimento Automático"
        Me.NotifyIcon1.BalloonTipTitle = "Teste"
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "DSC - Recebimento Automático"
        Me.NotifyIcon1.Visible = True
        '
        'lvPainel
        '
        Me.lvPainel.AccessibleDescription = "Recebimento Automático"
        Me.lvPainel.AccessibleName = "DSC-MD - Painel de Controle"
        Me.lvPainel.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvPainel.AutoArrange = False
        Me.lvPainel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lvPainel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvPainel.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPainel.ForeColor = System.Drawing.Color.DarkGreen
        ListViewGroup1.Header = "Configurações Padrão"
        ListViewGroup1.Name = "Configurações Padrão"
        ListViewGroup1.Tag = "ConfiguracoesPadrao"
        ListViewGroup2.Header = "Empresa 1"
        ListViewGroup2.Name = "Empresa 1"
        ListViewGroup2.Tag = "Empresa1"
        ListViewGroup3.Header = "Empresa 2"
        ListViewGroup3.Name = "Empresa 2"
        ListViewGroup3.Tag = "Empresa2"
        Me.lvPainel.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.lvPainel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        ListViewItem1.StateImageIndex = 0
        ListViewItem1.Tag = "ITEM_NOVO_CNPJ"
        ListViewItem2.StateImageIndex = 0
        ListViewItem3.StateImageIndex = 0
        ListViewItem4.StateImageIndex = 0
        ListViewItem5.StateImageIndex = 0
        ListViewItem6.StateImageIndex = 0
        ListViewItem8.StateImageIndex = 0
        ListViewItem9.StateImageIndex = 0
        ListViewItem10.StateImageIndex = 0
        ListViewItem11.StateImageIndex = 0
        ListViewItem12.StateImageIndex = 0
        Me.lvPainel.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3, ListViewItem4, ListViewItem5, ListViewItem6, ListViewItem7, ListViewItem8, ListViewItem9, ListViewItem10, ListViewItem11, ListViewItem12})
        Me.lvPainel.LabelWrap = False
        Me.lvPainel.LargeImageList = Me.ImageList1
        Me.lvPainel.Location = New System.Drawing.Point(0, 0)
        Me.lvPainel.Margin = New System.Windows.Forms.Padding(5)
        Me.lvPainel.MultiSelect = False
        Me.lvPainel.Name = "lvPainel"
        Me.lvPainel.ShowItemToolTips = True
        Me.lvPainel.Size = New System.Drawing.Size(1064, 341)
        Me.lvPainel.SmallImageList = Me.ImageList1
        Me.lvPainel.TabIndex = 0
        Me.lvPainel.TileSize = New System.Drawing.Size(400, 75)
        Me.lvPainel.UseCompatibleStateImageBehavior = False
        Me.lvPainel.View = System.Windows.Forms.View.Tile
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lvPainel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 79)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1064, 341)
        Me.Panel2.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1064, 79)
        Me.Panel1.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1064, 79)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslPainel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 398)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1064, 22)
        Me.StatusStrip1.TabIndex = 10
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslPainel
        '
        Me.tsslPainel.Name = "tsslPainel"
        Me.tsslPainel.Size = New System.Drawing.Size(60, 17)
        Me.tsslPainel.Text = "Versão xyz"
        '
        'frmPainelControle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1064, 420)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPainelControle"
        Me.Text = "DKP-MD - Painel de Controle"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents lvPainel As System.Windows.Forms.ListView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslPainel As System.Windows.Forms.ToolStripStatusLabel
End Class
