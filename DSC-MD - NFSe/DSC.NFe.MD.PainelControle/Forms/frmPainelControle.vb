Imports System.IO

Public Class frmPainelControle

    Private Const CONST_BAKCUP_MD As String = "Importar/Exportar Configurações"
    Private Const CONST_NOVO_CNPJ As String = "Adiciona CNPJ"
    Private Const CONST_CONFIGURACOES_MD As String = "Configurações Padrão"
    Private Const CONST_INSTALACAO_CERTIFICADO_DIGITAL As String = "Instalação de Certificado Digital"
    Private Const CONST_CONFIGURA_SMTP As String = "Configuração SMTP"
    Private Const CONST_CONFIGURA_PROGRESS As String = "Configuração de acesso ao Progress"
    Private Const CONST_SELECIONA_CERTIFICADO As String = "Selecão de Certificado Digital"
    Private Const CONST_CHECK_LIST As String = "Check List"
    Private Const CONST_EXCLUI_CNPJ As String = "Exclui CNPJ"
    Private Const CONST_CONFIGURACAO As String = "Configurações"

    Private Sub lvPainel_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPainel.ItemActivate

        Try

            If Not IsNothing(lvPainel.FocusedItem) Then
                Select Case lvPainel.FocusedItem.Text

                    Case CONST_BAKCUP_MD
                        frmImportarExportarRegistro.ShowDialog()

                    Case CONST_NOVO_CNPJ
                        frmNovoCNPJ.ShowDialog()

                    Case CONST_EXCLUI_CNPJ

                        Dim cnpj As Long = lvPainel.FocusedItem.Tag

                        If MessageBox.Show("Deseja realmente excluir o CNPJ " & String.Format("{0:00\.000\.000\/0000\-00}", cnpj) & "?", CP_CaptionMessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Global.DSC.NFe.MD.ClientController.DeleteClientKey(cnpj.ToString)
                            AtualizaTela()
                        End If

                    Case CONST_CONFIGURACOES_MD
                        frmMDConfiguracoes.ShowDialog()

                    Case CONST_INSTALACAO_CERTIFICADO_DIGITAL
                        frmInstalaCertificado.ShowDialog()

                    Case CONST_CONFIGURA_SMTP
                        Dim frmConfiguracaoSMTP As New frmConfiguracaoSMTP(lvPainel.FocusedItem.Tag)
                        frmConfiguracaoSMTP.ShowDialog()

                    Case CONST_CONFIGURA_PROGRESS
                        Dim frmConfiguracaoProgress As New frmConfiguracaoProgress(lvPainel.FocusedItem.Tag)
                        frmConfiguracaoProgress.ShowDialog()

                    Case CONST_SELECIONA_CERTIFICADO
                        Dim frmSelecaoCertificadoDigital As New frmSelecaoCertificadoDigital(lvPainel.FocusedItem.Tag)
                        frmSelecaoCertificadoDigital.ShowDialog()

                    Case CONST_CHECK_LIST
                        frmCheckListNew.ShowDialog()

                    Case CONST_CONFIGURACAO
                        Dim frmConfiguracoes As New frmConfiguracoes(lvPainel.FocusedItem.Tag)
                        frmConfiguracoes.ShowDialog()

                End Select

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmPainelControle_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        AtualizaTela()
    End Sub

    Private Sub AtualizaTela()

        Dim lvg As ListViewGroup
        Dim lvi As ListViewItem

        lvPainel.BeginUpdate()

        lvPainel.Items.Clear()

        ' Adicionando Grupo "Configurações Padrão"

        lvg = New ListViewGroup("Configurações Padrão")

        lvg.Name = "Configurações Padrão"
        lvg.Header = "Configurações Padrão MD"
        lvg.Tag = "GRUPO_CONFIGURACAO_PADRAO"

        lvPainel.Groups.Add(lvg)

        ' Adicionando Item "Configurações Padrão"

        lvi = New ListViewItem(lvg)

        lvi.ImageKey = "Configurações.png"
        lvi.Tag = "ITEM_CONFIGURACOES_PADRAO"
        lvi.Text = CONST_CONFIGURACOES_MD
        lvi.ForeColor = Color.DarkGreen
        lvi.ToolTipText = "Configurações Padrão"

        lvPainel.Items.Add(lvi)

        ' Adicionando Item "Adiciona CNPJ"

        lvi = New ListViewItem(lvg)

        lvi.ImageKey = "AdicionaCNPJ.png"
        lvi.Tag = "ITEM_NOVO_CNPJ"
        lvi.Text = CONST_NOVO_CNPJ
        lvi.ForeColor = Color.DarkGreen
        lvi.ToolTipText = "Adicionar um nvo CNPJ para o Manifestação do Destinatário"

        lvPainel.Items.Add(lvi)

        ' Adicionando Item "Instalação do Certificado Digital"

        lvi = New ListViewItem(lvg)

        lvi.ImageKey = "InstalacaoCertificadoDigital.png"
        lvi.Tag = "ITEM_INSTALACAO_CERTIFICADO_DIGITAL"
        lvi.Text = CONST_INSTALACAO_CERTIFICADO_DIGITAL
        lvi.ForeColor = Color.DarkGreen

        lvPainel.Items.Add(lvi)

        ' Importar/Exportar Configurações MD

        lvi = New ListViewItem(lvg)

        lvi.ImageKey = "System-Registry-icon.png"
        lvi.ToolTipText = "Importar/Exportar Configurações MD"
        lvi.Tag = "ITEM_BACKUP_MD"
        lvi.Text = CONST_BAKCUP_MD
        lvi.ForeColor = Color.DarkGreen

        lvPainel.Items.Add(lvi)

        ' Adicionando Item "Check List"

        lvi = New ListViewItem(lvg)

        lvi.ImageKey = "CheckList.png"
        lvi.ToolTipText = CONST_CHECK_LIST
        lvi.Tag = "ITEM_CHECK_LIST"
        lvi.Text = CONST_CHECK_LIST

        lvPainel.Items.Add(lvi)

        For Each MD As Global.DSC.NFe.MD.PainelControleController In ClientController.GetMDRegistry

            lvg = New ListViewGroup()

            Dim cnpj As Long = MD.Client.ClientKey

            lvg.Name = MD.Client.ClientName
            lvg.Header = MD.Client.ClientName & " (" & String.Format("{0:00\.000\.000\/0000\-00}", cnpj) & ")"
            lvg.Tag = MD.Client.ClientKey

            lvPainel.Groups.Add(lvg)

            ' Adicionando Item "Exclusão de CNPJ"

            lvi = New ListViewItem(lvg)

            lvi.ImageKey = "AdicionaCNPJ.png"
            lvi.ToolTipText = CONST_EXCLUI_CNPJ
            lvi.Tag = MD.Client.ClientKey
            lvi.Text = CONST_EXCLUI_CNPJ

            lvPainel.Items.Add(lvi)

            ' Adicionando Item "Configuração SMTP"

            lvi = New ListViewItem(lvg)

            lvi.ImageKey = "ConfiguraEmail.png"
            lvi.ToolTipText = CONST_CONFIGURA_SMTP
            lvi.Tag = MD.Client.ClientKey
            lvi.Text = CONST_CONFIGURA_SMTP

            lvPainel.Items.Add(lvi)

            ' Adicionando Item "Configuração de Progress"

            lvi = New ListViewItem(lvg)

            lvi.ImageKey = "ConfiguraEmail.png"
            lvi.ToolTipText = CONST_CONFIGURA_PROGRESS
            lvi.Tag = MD.Client.ClientKey
            lvi.Text = CONST_CONFIGURA_PROGRESS

            lvPainel.Items.Add(lvi)

            ' Adicionando Item "Seleção de Certificado Digital"

            lvi = New ListViewItem(lvg)

            lvi.ImageKey = "CertificadoDigital.png"
            lvi.ToolTipText = CONST_SELECIONA_CERTIFICADO
            lvi.Tag = MD.Client.ClientKey
            lvi.Text = CONST_SELECIONA_CERTIFICADO

            lvPainel.Items.Add(lvi)

            ' Adicionando Item "Configuração Padrão"

            lvi = New ListViewItem(lvg)

            lvi.ImageKey = "Configurações.png"
            lvi.ToolTipText = CONST_CONFIGURACAO
            lvi.Tag = MD.Client.ClientKey
            lvi.Text = CONST_CONFIGURACAO

            lvPainel.Items.Add(lvi)

        Next

        lvPainel.EndUpdate()

    End Sub

    Private Sub frmPainelControle_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        With My.Application.Info.Version
            'tsslPainel.Text = "Versão " & .Major & "." & .Minor & "." & .Build & "." & .Revision
            tsslPainel.Text = "Versão 7.2020.01.01"
        End With

#If Demo Then
        Try

            Dim Trial As TrialModel

            Trial = TrialController.GetTrial()

            Dim dataInstalacao As Date
            Dim dataExpiracao As Date
            Dim cultInfo As New System.Globalization.CultureInfo("pt-BR")

            If Date.TryParse(Trial.dMsDc, cultInfo, Globalization.DateTimeStyles.AssumeUniversal, dataInstalacao) Then

                dataExpiracao = DateAdd(DateInterval.Day, 60, dataInstalacao.Date)

                If Now.Date > dataExpiracao Then
                    MessageBox.Show("A versão de avaliação do MD expirou em: " & dataExpiracao, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End
                Else
                    Me.Text = "DSC-MD - Painel de Controle - Versão Trial expira em: " & dataExpiracao
                End If

            Else
                MessageBox.Show("Erro ao executar versão de avaliação do MD", CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, CP_CaptionMessageBox, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End

        End Try
#End If

    End Sub

    Private Sub frmPainelControle_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If (Me.WindowState = FormWindowState.Minimized) Then
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIcon1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Me.Show()
        Me.WindowState = FormWindowState.Maximized
    End Sub

End Class