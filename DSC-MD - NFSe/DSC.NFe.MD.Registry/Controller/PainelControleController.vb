Public Class PainelControleController

    Public Property Client As ClientModel
    Public Property MDConfiguration As MDConfigurationModel
    Public Property DigitalCertificate As DigitalCertificateModel
    Public Property ProgressConfiguration As ProgressConfigurationModel
    Public Property SMTPConfiguration As SMTPConfigurationModel
    Public Property DefaultConfiguration As DefaultConfigurationModel

    Public Sub New()
        Client = New ClientModel
        MDConfiguration = New MDConfigurationModel
        DigitalCertificate = New DigitalCertificateModel
        ProgressConfiguration = New ProgressConfigurationModel
        SMTPConfiguration = New SMTPConfigurationModel
        DefaultConfiguration = New DefaultConfigurationModel
    End Sub

End Class
