Public Class Form1

    Dim NAVEGADOR As New WebBrowser 'PARA NAVEGAR
    Dim GENERAL As ArrayList 'PARA LOS DATOS GENERALES (DIA, FECHA, MAX,MIN,LLUVIA,VIENTO,AMANECE,ANOCHECE)
    Dim DETALLES As ArrayList 'PARA LOS DATOS DETALLADOS (08:00, 14:00, 20:00)
    Dim ICONOS As ArrayList 'PARA LAS IMAGENES

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Try
            AddHandler NAVEGADOR.Navigated, AddressOf Cargado
        Catch ex As Exception

        End Try

        Try
            NAVEGADOR.ScriptErrorsSuppressed = True 'PARA EVITAR ERRORES DE SCRIP EN EL HTML

            CAPTURA() 'CAPTURA TODOS LOS DATOS 

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Cargado(sender As Object, e As WebBrowserNavigatedEventArgs)
        Try

            'INICIALIZA LOS ARRAYS
            GENERAL = New ArrayList
            DETALLES = New ArrayList
            ICONOS = New ArrayList

            'RECORRE LOS ELEMENTOS DIV DE LA PAGINA Y CAPTURA LOS DATOS NECESARIOS
            For Each ELEMENTO As HtmlElement In NAVEGADOR.Document.GetElementsByTagName("DIV")

                If ELEMENTO.GetAttribute("CLASSNAME").Contains("m_table_weather_day_") And
                    ELEMENTO.GetAttribute("CLASSNAME").Contains("hide") = False And
                    ELEMENTO.GetAttribute("CLASSNAME").Contains("header") = False And
                    ELEMENTO.GetAttribute("CLASSNAME").Contains("wrapper") = False Then

                    ' DATOS GENERALES
                    If ELEMENTO.InnerText <> " " Then
                        If ELEMENTO.GetAttribute("CLASSNAME").Contains("date") Then
                            GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(0).Trim)
                            GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

                        ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("max_min") Then
                            GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(0).Trim)
                            GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

                        ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("rain") Then
                            GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

                        ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("wind") Then
                            GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

                        ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("dawn") Then
                            GENERAL.Add(ELEMENTO.InnerText.Trim)

                        ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("nightfall") Then
                            GENERAL.Add(ELEMENTO.InnerText.Trim)
                        End If
                    End If

                    'DATOS DETALLES
                ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("m_table_weather_day_temp_wrapper") Then
                    DETALLES.Add(ELEMENTO.InnerText)
                End If
            Next

            'RECORRE LOS ELEMENTOS I DE LA PAGINA Y CAPTURA LOS DATOS PARA LAS IMAGENES
            For Each ELEMENTO As HtmlElement In NAVEGADOR.Document.GetElementsByTagName("I")

                If ELEMENTO.GetAttribute("CLASSNAME").Contains("icon_weather_m") Then
                    Dim DATO As String = ELEMENTO.GetAttribute("CLASSNAME")
                    DATO = DATO.Replace("icon_weather_m ", "")
                    DATO = DATO.Replace("night-", "")
                    ICONOS.Add(DATO.Trim)
                End If
            Next

            PRESENTACION() 'PRESENTA LOS DATOS (GENERALES, DETALLES, IMAGENES)

            LinkLabel1.Text = NAVEGADOR.Url.ToString 'PONE EN EL LINKLABEL LA URL DE LA PAGINA
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Exclamation, "Error al obtener información del servidor ")
        End Try
    End Sub

    Friend Function ObtenerIdProvincia(ByVal Provinvia As String) As String

        Dim IdInt As String = 0
        Select Case Provinvia
            Case "A CORUÑA"
                IdInt = 15
            Case "ALACANT/ALICANTE"
                IdInt = 3
            Case "ALBACETE"
                IdInt = 2
            Case "ALMERÍA"
                IdInt = 4
            Case "ARABA/ÁLAVA"
                IdInt = 1
            Case "ASTURIAS"
                IdInt = 33
            Case "ÁVILA"
                IdInt = 5
            Case "BADAJOZ"
                IdInt = 6
            Case "BARCELONA"
                IdInt = 8
            Case "BIZKAIA"
                IdInt = 48
            Case "BURGOS"
                IdInt = 9
            Case "CÁCERES"
                IdInt = 10
            Case "CÁDIZ"
                IdInt = 11
            Case "CANTABRIA"
                IdInt = 39
            Case "CASTELLÓ/CASTELLÓN"
                IdInt = 12
            Case "CEUTA"
                IdInt = 51
            Case "CIUDAD REAL"
                IdInt = 13
            Case "CÓRDOBA"
                IdInt = 14
            Case "CUENCA"
                IdInt = 16
            Case "GIPUZKOA"
                IdInt = 20
            Case "GIRONA"
                IdInt = 17
            Case "GRANADA"
                IdInt = 18
            Case "GUADALAJARA"
                IdInt = 19
            Case "HUELVA"
                IdInt = 21
            Case "HUESCA"
                IdInt = 22
            Case "ILLES BALEARS"
                IdInt = 7
            Case "JAÉN"
                IdInt = 23
            Case "LA RIOJA"
                IdInt = 26
            Case "LAS PALMAS"
                IdInt = 35
            Case "LEÓN"
                IdInt = 24
            Case "LLEIDA"
                IdInt = 25
            Case "LUGO"
                IdInt = 27
            Case "MADRID"
                IdInt = 28
            Case "MÁLAGA"
                IdInt = 29
            Case "MELILLA"
                IdInt = 52
            Case "MURCIA"
                IdInt = 30
            Case "NAVARRA"
                IdInt = 31
            Case "OURENSE"
                IdInt = 32
            Case "PALENCIA"
                IdInt = 34
            Case "PONTEVEDRA"
                IdInt = 36
            Case "SALAMANCA"
                IdInt = 37
            Case "SANTA CRUZ DE TENERIFE"
                IdInt = 38
            Case "SEGOVIA"
                IdInt = 40
            Case "SEVILLA"
                IdInt = 41
            Case "SORIA"
                IdInt = 42
            Case "TARRAGONA"
                IdInt = 43
            Case "TERUEL"
                IdInt = 44
            Case "TOLEDO"
                IdInt = 45
            Case "VALÈNCIA/VALENCIA"
                IdInt = 46
            Case "VALLADOLID"
                IdInt = 47
            Case "ZAMORA"
                IdInt = 49
            Case "ZARAGOZA"
                IdInt = 50
            Case Else

        End Select


        Return IdInt
    End Function

    Private Sub ComboBox_Provinvias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox_Provinvias.SelectedIndexChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CAPTURA() 'CAPTURA TODOS LOS DATOS 

        Try
            Dim CIUDAD As String = TextBox_Municipio.Text.ToLower 'PREPARA EL NOMBRE DE LA CIUDAD
            CIUDAD = CIUDAD.Replace(" ", "-")


            'NAVEGADOR.Navigate("https://www.eltiempo.es/" & CIUDAD & ".html") 'NAVEGA A LA PAGINA DE LA CIUDAD
            NAVEGADOR.Navigate("https://www.el-tiempo.net/api/json/v1/provincias/" & ObtenerIdProvincia(ComboBox_Provinvias.Text.ToString.Trim)) 'https://www.el-tiempo.net/api/json/v1/provincias/
            'ESPERA(3000) 'PARA DAR TIEMPO A QUE CARGUE LA PAGINA

            ''INICIALIZA LOS ARRAYS
            'GENERAL = New ArrayList
            'DETALLES = New ArrayList
            'ICONOS = New ArrayList

            ''RECORRE LOS ELEMENTOS DIV DE LA PAGINA Y CAPTURA LOS DATOS NECESARIOS
            'For Each ELEMENTO As HtmlElement In NAVEGADOR.Document.GetElementsByTagName("DIV")

            '    If ELEMENTO.GetAttribute("CLASSNAME").Contains("m_table_weather_day_") And
            '        ELEMENTO.GetAttribute("CLASSNAME").Contains("hide") = False And
            '        ELEMENTO.GetAttribute("CLASSNAME").Contains("header") = False And
            '        ELEMENTO.GetAttribute("CLASSNAME").Contains("wrapper") = False Then

            '        ' DATOS GENERALES
            '        If ELEMENTO.InnerText <> " " Then
            '            If ELEMENTO.GetAttribute("CLASSNAME").Contains("date") Then
            '                GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(0).Trim)
            '                GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

            '            ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("max_min") Then
            '                GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(0).Trim)
            '                GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

            '            ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("rain") Then
            '                GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

            '            ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("wind") Then
            '                GENERAL.Add(ELEMENTO.InnerText.Split(vbCrLf)(2).Trim)

            '            ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("dawn") Then
            '                GENERAL.Add(ELEMENTO.InnerText.Trim)

            '            ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("nightfall") Then
            '                GENERAL.Add(ELEMENTO.InnerText.Trim)
            '            End If
            '        End If

            '        'DATOS DETALLES
            '    ElseIf ELEMENTO.GetAttribute("CLASSNAME").Contains("m_table_weather_day_temp_wrapper") Then
            '        DETALLES.Add(ELEMENTO.InnerText)
            '    End If
            'Next

            ''RECORRE LOS ELEMENTOS I DE LA PAGINA Y CAPTURA LOS DATOS PARA LAS IMAGENES
            'For Each ELEMENTO As HtmlElement In NAVEGADOR.Document.GetElementsByTagName("I")

            '    If ELEMENTO.GetAttribute("CLASSNAME").Contains("icon_weather_m") Then
            '        Dim DATO As String = ELEMENTO.GetAttribute("CLASSNAME")
            '        DATO = DATO.Replace("icon_weather_m ", "")
            '        DATO = DATO.Replace("night-", "")
            '        ICONOS.Add(DATO.Trim)
            '    End If
            'Next

            'PRESENTACION() 'PRESENTA LOS DATOS (GENERALES, DETALLES, IMAGENES)

            'LinkLabel1.Text = NAVEGADOR.Url.ToString 'PONE EN EL LINKLABEL LA URL DE LA PAGINA

        Catch ex As Exception
            'POR SI NO ENCUENTRA LA PAGINA
            MsgBox(ex, MsgBoxStyle.Exclamation, "Error al obtener información del formulario")
        End Try
    End Sub

    Public Sub ESPERA(ByVal INTERVALO As Integer) 'PARA DAR TIEMPO A QUE CARGUE LA PAGINA

        Dim PARADA As New Stopwatch
        PARADA.Start()
        Do While PARADA.ElapsedMilliseconds < INTERVALO
            Application.DoEvents()
        Loop
        PARADA.Stop()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Process.Start(LinkLabel1.Text) 'ABRE LA PAGINA EN EL NAVEGADOR PREDETERMINADO

    End Sub

    Private Sub TextBoxCIUDAD_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox_Municipio.KeyDown

        'SI SE PULSA ENTER EN EL TEXTBOX REINICIA LA CAPTURA 
        If e.KeyCode = Keys.Enter Then
            CAPTURA() 'CAPTURA TODOS LOS DATOS 
        End If

    End Sub

    Public Sub PRESENTACION() 'PRESENTA LOS DATOS (GENERALES, DETALLES, IMAGENES)

        LabelDIA1.Text = GENERAL(0)
        LabelFECHA1.Text = GENERAL(1)
        LabelMAX1.Text = GENERAL(2)
        LabelMIN1.Text = GENERAL(3)
        LabelLLUVIA1.Text = GENERAL(4)
        LabelVIENTO1.Text = GENERAL(5)
        LabelAMANECE1.Text = GENERAL(6)
        LabelANOCHECE1.Text = GENERAL(7)

        LabelDIA2.Text = GENERAL(8)
        LabelFECHA2.Text = GENERAL(9)
        LabelMAX2.Text = GENERAL(10)
        LabelMIN2.Text = GENERAL(11)
        LabelLLUVIA2.Text = GENERAL(12)
        LabelVIENTO2.Text = GENERAL(13)
        LabelAMANECE2.Text = GENERAL(14)
        LabelANOCHECE2.Text = GENERAL(15)

        LabelDIA3.Text = GENERAL(16)
        LabelFECHA3.Text = GENERAL(17)
        LabelMAX3.Text = GENERAL(18)
        LabelMIN3.Text = GENERAL(19)
        LabelLLUVIA3.Text = GENERAL(20)
        LabelVIENTO3.Text = GENERAL(21)
        LabelAMANECE3.Text = GENERAL(22)
        LabelANOCHECE3.Text = GENERAL(23)

        LabelDIA4.Text = GENERAL(24)
        LabelFECHA4.Text = GENERAL(25)
        LabelMAX4.Text = GENERAL(26)
        LabelMIN4.Text = GENERAL(27)
        LabelLLUVIA4.Text = GENERAL(28)
        LabelVIENTO4.Text = GENERAL(29)
        LabelAMANECE4.Text = GENERAL(30)
        LabelANOCHECE4.Text = GENERAL(31)

        LabelDIA5.Text = GENERAL(32)
        LabelFECHA5.Text = GENERAL(33)
        LabelMAX5.Text = GENERAL(34)
        LabelMIN5.Text = GENERAL(35)
        LabelLLUVIA5.Text = GENERAL(36)
        LabelVIENTO5.Text = GENERAL(37)
        LabelAMANECE5.Text = GENERAL(38)
        LabelANOCHECE5.Text = GENERAL(39)

        LabelDIA6.Text = GENERAL(40)
        LabelFECHA6.Text = GENERAL(41)
        LabelMAX6.Text = GENERAL(42)
        LabelMIN6.Text = GENERAL(43)
        LabelLLUVIA6.Text = GENERAL(44)
        LabelVIENTO6.Text = GENERAL(45)
        LabelAMANECE6.Text = GENERAL(46)
        LabelANOCHECE6.Text = GENERAL(47)

        LabelDIA7.Text = GENERAL(48)
        LabelFECHA7.Text = GENERAL(49)
        LabelMAX7.Text = GENERAL(50)
        LabelMIN7.Text = GENERAL(51)
        LabelLLUVIA7.Text = GENERAL(52)
        LabelVIENTO7.Text = GENERAL(53)
        LabelAMANECE7.Text = GENERAL(54)
        LabelANOCHECE7.Text = GENERAL(55)

        Label_81.Text = DETALLES(3)
        Label_141.Text = DETALLES(4)
        Label_201.Text = DETALLES(5)

        Label_82.Text = DETALLES(6)
        Label_142.Text = DETALLES(7)
        Label_202.Text = DETALLES(8)

        Label_83.Text = DETALLES(9)
        Label_143.Text = DETALLES(10)
        Label_203.Text = DETALLES(11)

        Label_84.Text = DETALLES(12)
        Label_144.Text = DETALLES(13)
        Label_204.Text = DETALLES(14)

        Label_85.Text = DETALLES(15)
        Label_145.Text = DETALLES(16)
        Label_205.Text = DETALLES(17)

        Label_86.Text = DETALLES(18)
        Label_146.Text = DETALLES(19)
        Label_206.Text = DETALLES(20)

        Label_87.Text = DETALLES(21)
        Label_147.Text = DETALLES(22)
        Label_207.Text = DETALLES(23)

        PictureBox_81.ImageLocation = "IMAGENES\" & ICONOS(0) & ".png"
        PictureBox_141.ImageLocation = "IMAGENES\" & ICONOS(1) & ".png"
        PictureBox_201.ImageLocation = "IMAGENES\" & ICONOS(2) & ".png"

        PictureBox_82.ImageLocation = "IMAGENES\" & ICONOS(3) & ".png"
        PictureBox_142.ImageLocation = "IMAGENES\" & ICONOS(4) & ".png"
        PictureBox_202.ImageLocation = "IMAGENES\" & ICONOS(5) & ".png"

        PictureBox_83.ImageLocation = "IMAGENES\" & ICONOS(6) & ".png"
        PictureBox_143.ImageLocation = "IMAGENES\" & ICONOS(7) & ".png"
        PictureBox_203.ImageLocation = "IMAGENES\" & ICONOS(8) & ".png"

        PictureBox_84.ImageLocation = "IMAGENES\" & ICONOS(9) & ".png"
        PictureBox_144.ImageLocation = "IMAGENES\" & ICONOS(10) & ".png"
        PictureBox_204.ImageLocation = "IMAGENES\" & ICONOS(11) & ".png"

        PictureBox_85.ImageLocation = "IMAGENES\" & ICONOS(12) & ".png"
        PictureBox_145.ImageLocation = "IMAGENES\" & ICONOS(13) & ".png"
        PictureBox_205.ImageLocation = "IMAGENES\" & ICONOS(14) & ".png"

        PictureBox_86.ImageLocation = "IMAGENES\" & ICONOS(15) & ".png"
        PictureBox_146.ImageLocation = "IMAGENES\" & ICONOS(16) & ".png"
        PictureBox_206.ImageLocation = "IMAGENES\" & ICONOS(17) & ".png"

        PictureBox_87.ImageLocation = "IMAGENES\" & ICONOS(18) & ".png"
        PictureBox_147.ImageLocation = "IMAGENES\" & ICONOS(19) & ".png"
        PictureBox_207.ImageLocation = "IMAGENES\" & ICONOS(20) & ".png"

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As System.EventArgs) Handles Me.MouseMove

        'SI SE MUEVE EL MOUSE SOBRE LOS PICTUREBOXES PRESENTA EL NOMBRE DE LA IMAGEN EN EL TOOLTIP
        Try
            For Each CONTROL In Me.Controls
                If TypeOf (CONTROL) Is PictureBox Then

                    Select Case CONTROL.NAME

                        Case "PictureBox_81"
                            ToolTip1.SetToolTip(PictureBox_81, ICONOS(0))
                        Case "PictureBox_141"
                            ToolTip1.SetToolTip(PictureBox_141, ICONOS(1))
                        Case "PictureBox_201"
                            ToolTip1.SetToolTip(PictureBox_201, ICONOS(2))

                        Case "PictureBox_82"
                            ToolTip1.SetToolTip(PictureBox_82, ICONOS(3))
                        Case "PictureBox_142"
                            ToolTip1.SetToolTip(PictureBox_142, ICONOS(4))
                        Case "PictureBox_202"
                            ToolTip1.SetToolTip(PictureBox_202, ICONOS(5))

                        Case "PictureBox_83"
                            ToolTip1.SetToolTip(PictureBox_83, ICONOS(6))
                        Case "PictureBox_143"
                            ToolTip1.SetToolTip(PictureBox_143, ICONOS(7))
                        Case "PictureBox_203"
                            ToolTip1.SetToolTip(PictureBox_203, ICONOS(8))

                        Case "PictureBox_84"
                            ToolTip1.SetToolTip(PictureBox_84, ICONOS(9))
                        Case "PictureBox_144"
                            ToolTip1.SetToolTip(PictureBox_144, ICONOS(10))
                        Case "PictureBox_204"
                            ToolTip1.SetToolTip(PictureBox_204, ICONOS(11))

                        Case "PictureBox_85"
                            ToolTip1.SetToolTip(PictureBox_85, ICONOS(12))
                        Case "PictureBox_145"
                            ToolTip1.SetToolTip(PictureBox_145, ICONOS(13))
                        Case "PictureBox_205"
                            ToolTip1.SetToolTip(PictureBox_205, ICONOS(14))

                        Case "PictureBox_86"
                            ToolTip1.SetToolTip(PictureBox_86, ICONOS(15))
                        Case "PictureBox_146"
                            ToolTip1.SetToolTip(PictureBox_146, ICONOS(16))
                        Case "PictureBox_206"
                            ToolTip1.SetToolTip(PictureBox_206, ICONOS(17))

                        Case "PictureBox_87"
                            ToolTip1.SetToolTip(PictureBox_87, ICONOS(18))
                        Case "PictureBox_147"
                            ToolTip1.SetToolTip(PictureBox_147, ICONOS(19))
                        Case "PictureBox_207"
                            ToolTip1.SetToolTip(PictureBox_207, ICONOS(20))

                    End Select

                End If
            Next
        Catch ex As Exception
        End Try

    End Sub


End Class
