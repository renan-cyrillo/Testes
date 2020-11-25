Public Interface IEmailClient

#Region "Properties"

    ''' <summary>
    ''' The host internet address.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property host As String

    ''' <summary>
    ''' The server port to connect to
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property port As Integer

    ''' <summary>
    ''' The e-mail account user to log in
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property user As String

    ''' <summary>
    ''' The e-mail account password to log in
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property pass As String

    ''' <summary>
    ''' set if the server requires SSL security or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SSL As Boolean

    ''' <summary>
    ''' Enables or disables the LOG functionality
    ''' </summary>
    ''' <value>True enable the LOG
    ''' False disable the LOG
    ''' </value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property enableLog As Boolean

#End Region

#Region "Events"

    Event logChanged(ByVal text As String)

#End Region

#Region "Métodos Públicos"

    ''' <summary>
    ''' Connects to the server an log in using HOST, PORT, USER, PASS and SSL specified
    ''' </summary>
    ''' <remarks></remarks>
    Sub connectAndLogin()

    ''' <summary>
    ''' Create a new folder on the IMAP server.
    ''' </summary>
    ''' <param name="folderName">CASE SENSITIVE
    ''' The name of the folder to be created.
    ''' This name must or not be absolute. Depending of the server.
    ''' The folder's name separator is the '.' character. ex: INBOX.folderName
    ''' </param>
    ''' <remarks></remarks>
    Sub createNewFolder(ByVal folderName As String)

    ''' <summary>
    ''' Verify if this client is connected to the server.
    ''' </summary>
    ''' <returns>Returns TRUE if the user is connected to the server and FALSE if the user is NOT connected</returns>
    ''' <remarks></remarks>
    Function isConnected() As Boolean

    ''' <summary>
    ''' Verify if the client is connected to the server and logged in
    ''' </summary>
    ''' <returns>Returns TRUE if the user is logged in and FALSE if the user is NOT logged in</returns>
    ''' <remarks></remarks>
    Function isLoggedIn() As Boolean

    ''' <summary>
    ''' Log out from the server
    ''' </summary>
    ''' <remarks></remarks>
    Sub logout()

    ''' <summary>
    ''' Move messages between folders
    ''' </summary>
    ''' <param name="MessageUID">Message UID (Unique ID assigned to the message) to be moved. CASE SENSITIVE</param>
    ''' <param name="folderName">CASE SENSITIVE
    ''' Folder name to move the message To</param>
    ''' <remarks></remarks>
    Sub moveMessageToFolder(ByVal MessageUID As String, ByVal folderName As String)

    ''' <summary>
    ''' Delete a message from the server
    ''' If you are using a POP client, you need to logout to the DELETE command take effect on next time ou login
    ''' </summary>
    ''' <param name="MessageUID">UID (Unique ID assigned to the message) to be deleted</param>
    ''' <remarks></remarks>
    Sub deleteMessage(ByVal MessageUID As String)

    ''' <summary>
    ''' Returns an array of String containing all messages UID on the server
    ''' </summary>
    ''' <returns>A array of String containing the messages UID </returns>
    ''' <remarks></remarks>
    Function getAllMessagesUID() As List(Of String)

    ''' <summary>
    ''' Return a IMAP.email object containing informations about the message
    ''' </summary>
    ''' <param name="UID">The message UID(Unique ID assigned to the message) to get</param>
    ''' <returns>A IMAP.email object filled with message info.</returns>
    ''' <remarks></remarks>
    Function getMessage(ByVal UID As String) As EmailMessage

#End Region

End Interface
