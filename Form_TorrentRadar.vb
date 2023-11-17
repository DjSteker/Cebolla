
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.IO
Imports System.Web

Public Class Form_TorrentRadar
    Dim nav As XPathNavigator
    Dim docNav As XPathDocument
    Dim xmlDoc As New XmlDocument
    Dim NodeIter As XPathNodeIterator
    Dim strExpression As String
    Dim XPathNodeIterator As String
    Dim namespaces As XmlNamespaceManager = New XmlNamespaceManager(xmlDoc.NameTable)
    Dim category As String
    Dim quality As String

    'Thanks go out to Ian and Kris

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If RadioButton2.Checked = True Then
            category = " category:tv "
        Else
            category = " category:movies "
        End If

        'Build URL
        If RadioButton3.Checked = True And RadioButton3.Text = "HDTV" Then
            quality = "HDTV -720p -1080p -3D" 'need to fill this out with the not section of the search
        Else : quality = "3D -HDTV -720p -1080p" 'same as above
        End If

        If RadioButton4.Checked = True Then
            quality = "720p -HDTV -1080p -3D" 'add logic to restrict search (as above)
        End If

        If RadioButton5.Checked = True Then
            quality = "1080p -HDTV -720p -3D" 'add logic to restrict search (as above)
        End If
        If RadioButton1.Checked = True Then
            Try
                docNav = New XPathDocument("https://kickass.to/usearch/" + ComboBox1.Text + " category:movies " + quality + " seeds:1/?rss=1")
            Catch ex As Exception
            End Try

        Else
            Try
                docNav = New XPathDocument("https://kickass.to/usearch/" + ComboBox1.Text + " category:tv " + quality + " seeds:1/?rss=1")
            Catch ex As Exception
            End Try
        End If

        'add namespace to handle torrent: nodes
        namespaces.AddNamespace("torrent", "http://xmlns.ezrss.it/0.1/")

        'Set Name for each result NEED NULL HANDLING!!!
        Try
            LinkLabel1.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[1]/title").ToString()
        Catch ex As Exception
            LinkLabel1.Text = "No Results"
        End Try

        Try
            LinkLabel2.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[2]/title").ToString()
        Catch ex As Exception
            If LinkLabel1.Text = "No Results" Then
                LinkLabel2.Text = ""
            Else
                LinkLabel2.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel3.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[3]/title").ToString()
        Catch ex As Exception
            If LinkLabel2.Text = "No More Results" Or LinkLabel2.Text = "" Then
                LinkLabel3.Text = ""
            Else
                LinkLabel3.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel4.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[4]/title").ToString()
        Catch ex As Exception
            If LinkLabel3.Text = "No Results" Or LinkLabel3.Text = "" Then
                LinkLabel4.Text = ""
            Else
                LinkLabel4.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel5.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[5]/title").ToString()
        Catch ex As Exception
            If LinkLabel4.Text = "No Results" Or LinkLabel4.Text = "" Then
                LinkLabel5.Text = ""
            Else
                LinkLabel5.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel6.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[6]/title").ToString()
        Catch ex As Exception
            If LinkLabel5.Text = "No Results" Or LinkLabel5.Text = "" Then
                LinkLabel6.Text = ""
            Else
                LinkLabel6.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel7.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[7]/title").ToString()
        Catch ex As Exception
            If LinkLabel6.Text = "No Results" Or LinkLabel6.Text = "" Then
                LinkLabel7.Text = ""
            Else
                LinkLabel7.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel8.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[8]/title").ToString()
        Catch ex As Exception
            If LinkLabel7.Text = "No Results" Or LinkLabel7.Text = "" Then
                LinkLabel8.Text = ""
            Else
                LinkLabel8.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel9.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[9]/title").ToString()
        Catch ex As Exception
            If LinkLabel8.Text = "No Results" Or LinkLabel8.Text = "" Then
                LinkLabel9.Text = ""
            Else
                LinkLabel9.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel10.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[10]/title").ToString()
        Catch ex As Exception
            If LinkLabel9.Text = "No Results" Or LinkLabel9.Text = "" Then
                LinkLabel10.Text = ""
            Else
                LinkLabel10.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel11.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[11]/title").ToString()
        Catch ex As Exception
            If LinkLabel10.Text = "No Results" Or LinkLabel10.Text = "" Then
                LinkLabel11.Text = ""
            Else
                LinkLabel11.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel12.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[12]/title").ToString()
        Catch ex As Exception
            If LinkLabel11.Text = "No Results" Or LinkLabel11.Text = "" Then
                LinkLabel12.Text = ""
            Else
                LinkLabel12.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel13.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[13]/title").ToString()
        Catch ex As Exception
            If LinkLabel12.Text = "No Results" Or LinkLabel12.Text = "" Then
                LinkLabel13.Text = ""
            Else
                LinkLabel13.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel14.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[14]/title").ToString()
        Catch ex As Exception
            If LinkLabel13.Text = "No Results" Or LinkLabel13.Text = "" Then
                LinkLabel14.Text = ""
            Else
                LinkLabel14.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel15.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[15]/title").ToString()
        Catch ex As Exception
            If LinkLabel14.Text = "No Results" Or LinkLabel14.Text = "" Then
                LinkLabel15.Text = ""
            Else
                LinkLabel15.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel16.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[16]/title").ToString()
        Catch ex As Exception
            If LinkLabel15.Text = "No Results" Or LinkLabel15.Text = "" Then
                LinkLabel16.Text = ""
            Else
                LinkLabel16.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel17.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[17]/title").ToString()
        Catch ex As Exception
            If LinkLabel16.Text = "No Results" Or LinkLabel16.Text = "" Then
                LinkLabel17.Text = ""
            Else
                LinkLabel17.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel18.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[18]/title").ToString()
        Catch ex As Exception
            If LinkLabel17.Text = "No Results" Or LinkLabel17.Text = "" Then
                LinkLabel18.Text = ""
            Else
                LinkLabel18.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel19.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[19]/title").ToString()
        Catch ex As Exception
            If LinkLabel18.Text = "No Results" Or LinkLabel18.Text = "" Then
                LinkLabel19.Text = ""
            Else
                LinkLabel19.Text = "No More Results"
            End If
        End Try

        Try
            LinkLabel20.Text = docNav.CreateNavigator.SelectSingleNode("//channel/item[20]/title").ToString()
        Catch ex As Exception
            If LinkLabel9.Text = "No Results" Or LinkLabel19.Text = "" Then
                LinkLabel20.Text = ""
            Else
                LinkLabel20.Text = "No More Results"
            End If
        End Try

        'Hide controls
        Button1.Visible = False
        Label1.Visible = False
        GroupBox1.Visible = False
        ComboBox1.Visible = False
        RadioButton1.Visible = False
        RadioButton2.Visible = False
        RadioButton3.Visible = False
        RadioButton4.Visible = False
        RadioButton5.Visible = False

        'Show results
        LinkLabel1.Visible = True
        LinkLabel2.Visible = True
        LinkLabel3.Visible = True
        LinkLabel4.Visible = True
        LinkLabel5.Visible = True
        LinkLabel6.Visible = True
        LinkLabel7.Visible = True
        LinkLabel8.Visible = True
        LinkLabel9.Visible = True
        LinkLabel10.Visible = True
        LinkLabel11.Visible = True
        LinkLabel12.Visible = True
        LinkLabel13.Visible = True
        LinkLabel14.Visible = True
        LinkLabel15.Visible = True
        LinkLabel16.Visible = True
        LinkLabel17.Visible = True
        LinkLabel18.Visible = True
        LinkLabel19.Visible = True
        LinkLabel20.Visible = True
        Button2.Visible = True
        GroupBox1.Visible = False
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LinkLabel1.Visible = False
        LinkLabel2.Visible = False
        LinkLabel3.Visible = False
        LinkLabel4.Visible = False
        LinkLabel5.Visible = False
        LinkLabel6.Visible = False
        LinkLabel7.Visible = False
        LinkLabel8.Visible = False
        LinkLabel9.Visible = False
        LinkLabel10.Visible = False
        LinkLabel11.Visible = False
        LinkLabel12.Visible = False
        LinkLabel13.Visible = False
        LinkLabel14.Visible = False
        LinkLabel15.Visible = False
        LinkLabel16.Visible = False
        LinkLabel17.Visible = False
        LinkLabel18.Visible = False
        LinkLabel19.Visible = False
        LinkLabel20.Visible = False
        RadioButton1.Visible = True
        RadioButton2.Visible = True
        Button1.Visible = True
        Button2.Visible = False
        ComboBox1.Visible = True
        Label1.Visible = True
        GroupBox1.Visible = True
        RadioButton3.Visible = True
        RadioButton4.Visible = True
        RadioButton5.Visible = True
        clearResults()


    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=7AVK7F4YNAN8Y&lc=US&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donate_LG%2egif%3aNonHosted")
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.Click
        RadioButton2.Checked = False
        RadioButton3.Text = "3D"

        'RadioButton1.Checked = True
        RadioButton2.Checked = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.Click
        RadioButton3.Text = "HDTV"
        ComboBox1.Visible = True
        RadioButton1.Checked = False
        'RadioButton2.Checked = True
    End Sub

    Private Sub LinkLabel1_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[1]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel2_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[2]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel3_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[3]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel4_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[4]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel5_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[5]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel6_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[6]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel7_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[7]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel8_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[8]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel9_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[9]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel10_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[10]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel11_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[11]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel12_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[12]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel13_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[13]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel14_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[14]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel15_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[15]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel17_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[16]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel16_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[17]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel18_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[18]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel19_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[19]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel20_LinkClicked_1(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        Try
            Process.Start(docNav.CreateNavigator.SelectSingleNode("//channel/item[20]/torrent:magnetURI", namespaces).ToString())
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True And RadioButton3.Text = "HDTV" Then
            quality = "HDTV -720p -1080p -3D" 'need to fill this out with the not section of the search
        Else : quality = "3D -HDTV -720p -1080p" 'same as above
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            quality = "720p -HDTV -1080p -3D" 'add logic to restrict search (as above)
        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            quality = "1080p -HDTV -720p -3D" 'add logic to restrict search (as above)
        End If
    End Sub

    Private Sub PToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PToolStripMenuItem.Click

    End Sub
    Sub clearResults()
        LinkLabel1.Text = " "
        LinkLabel2.Text = " "
        LinkLabel3.Text = " "
        LinkLabel4.Text = " "
        LinkLabel5.Text = " "
        LinkLabel6.Text = " "
        LinkLabel7.Text = " "
        LinkLabel8.Text = " "
        LinkLabel9.Text = " "
        LinkLabel10.Text = " "
        LinkLabel11.Text = " "
        LinkLabel12.Text = " "
        LinkLabel13.Text = " "
        LinkLabel14.Text = " "
        LinkLabel15.Text = " "
        LinkLabel16.Text = " "
        LinkLabel17.Text = " "
        LinkLabel18.Text = " "
        LinkLabel19.Text = " "
        LinkLabel20.Text = " "
    End Sub
End Class
