Public Class Form_ExploradorWeb
    Private Sub Form_ExploradorWeb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label_Estado.Text = ""

            AddHandler WebBrowser1.Navigated, AddressOf EstadoNavigated
            AddHandler WebBrowser1.DockChanged, AddressOf EstadoDockChanged
            AddHandler WebBrowser1.DocumentCompleted, AddressOf EstadoDocumentCompleted
            AddHandler WebBrowser1.Navigating, AddressOf EstadoNavigating
            AddHandler WebBrowser1.ProgressChanged, AddressOf EstadoProgressChanged
            AddHandler WebBrowser1.FileDownload, AddressOf EstadoDescargado6



            AddHandler WebBrowser1.DocumentTitleChanged, AddressOf EstadoDocumentTitleChanged
            AddHandler WebBrowser1.ProgressChanged, AddressOf Estaduado

            WebBrowser1.ScriptErrorsSuppressed = True
            
            Dim proxy As New System.Net.WebProxy("http://proxyserver:80", True)
            proxy.Credentials = New System.Net.NetworkCredential("username", "password")
            System.Net.WebRequest.DefaultWebProxy = proxy
            
        Catch ex As Exception

        End Try
    End Sub



    Private Sub TextBox_URL_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox_URL.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                WebBrowser1.Navigate(TextBox_URL.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button_Nevegar_Click(sender As Object, e As EventArgs) Handles Button_Nevegar.Click
        Try
            'WebBrowser1.EncryptionLevel = WebBrowserEncryptionLevel.Mixed

            WebBrowser1.Navigate(TextBox_URL.Text)
            If CheckBox_Rellamar.Checked Then
                Timer1.Enabled = True
            Else
                Timer1.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            WebBrowser1.Navigate(TextBox_URL.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox_TiempoRefreco_TextChanged(sender As Object, e As EventArgs) Handles TextBox_TiempoRefreco.TextChanged
        Try
            Timer1.Interval = TextBox_TiempoRefreco.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WebBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        Try
            Label_Encriptacion.Text = WebBrowser1.EncryptionLevel.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label_DNS_Click(sender As Object, e As EventArgs) Handles Label_DNS.Click

    End Sub

    Private Sub SetDns(ByVal hostName As String, ByVal dnsServer As String)
        Dim processStartInfo As New ProcessStartInfo("cmd.exe")
        processStartInfo.Arguments = "/c netsh interface ip set dns """ & hostName & """ static " & dnsServer & " primary"
        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(processStartInfo).WaitForExit()
    End Sub

#Region ""


    Private Sub Estaduado(sender As Object, e As WebBrowserProgressChangedEventArgs)
        Try
            Dim valorMax As Integer = e.MaximumProgress
            Dim valor As Integer = e.CurrentProgress
            Label_Estado.Text = ((valor / valorMax) * 100) & "%"
            ProgressBar_Web.Maximum = valorMax
            ProgressBar_Web.Value = valor
        Catch ex As Exception

        End Try

    End Sub

    Private Sub EstadoNavigating(sender As Object, e As WebBrowserNavigatingEventArgs)
        Try
            Label_Estado.Visible = True
            ProgressBar_Web.Visible = True
        Catch ex As Exception

        End Try
        Try
            SetDns(e.Url.Host, TextBox_DNS.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDocumentTitleChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDescargado6(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs)
        Try
            Dim valorMax As Integer = e.MaximumProgress
            Dim valor As Integer = e.CurrentProgress
            Label_Estado.Text = ((valor / valorMax)*100) & "%"
            ProgressBar_Web.Maximum = valorMax
            ProgressBar_Web.Value = valor
        Catch ex As Exception

        End Try
    End Sub



    Private Sub EstadoDocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDockChanged(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoNavigated(sender As Object, e As WebBrowserNavigatedEventArgs)
        Try
            Label_Estado.Visible = False
            ProgressBar_Web.Visible = False
            Label_Encriptacion.Text = WebBrowser1.EncryptionLevel
        Catch ex As Exception

        End Try
    End Sub



    Private Sub EstadoTitulo()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoActuliza()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoNabegado()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoDescargado()
        Try

        Catch ex As Exception

        End Try
    End Sub


#End Region

End Class
