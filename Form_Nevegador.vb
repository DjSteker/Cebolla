Public Class Form_Nevegador

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label_Estado.Text = ""

            AddHandler WebBrowser1.Navigated, AddressOf EstadoNavigated
            AddHandler WebBrowser1.DockChanged, AddressOf EstadoDockChanged
            AddHandler WebBrowser1.DocumentCompleted, AddressOf EstadoDocumentCompleted
            AddHandler WebBrowser1.Navigating, AddressOf EstadoNavigating
            AddHandler WebBrowser1.ProgressChanged, AddressOf EstadoProgressChanged
            AddHandler WebBrowser1.FileDownload, AddressOf EstadoDescargado6
            AddHandler WebBrowser1.DocumentTitleChanged, AddressOf EstadoDocumentTitleChanged

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EstadoNavigating(sender As Object, e As WebBrowserNavigatingEventArgs)
        Try

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

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button_Browser_Click(sender As Object, e As EventArgs) Handles Button_Browser.Click
        Try
           ' WebBrowser1.Navigate(TextBox_URL.Text)
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
End Class
