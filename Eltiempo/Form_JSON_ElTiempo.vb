Imports System.IO
Imports System.Net
Imports System.Text

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form_JSON_ElTiempo


  
    Public Const OpenWeatherMapAPIKey As String = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx7" ' ejemplo funciono en 2010+o- https://www.meteomatics.com/en/weather-api/
    Public Const OpenWeatherMapEndpoint As String = "https://api.openweathermap.org/data/2.5/weather"

    '//api.openweathermap.org/data/2.5/weather?q=London
    '//http://api.openweathermap.org/data/2.5/weather?q=Ibi,es&APPID=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx7
    '//{
    '//"coord":{"lon":-0.57,"lat":38.62},
    '//"weather":[{"id":802,"main":"Clouds","description":"scattered clouds","icon":"03d"}],
    '//"base":"stations",
    '//"main":{"temp":297.65,"pressure":1019,"humidity":78,"temp_min":294.82,"temp_max":300.37},"visibility":10000,
    '//"wind":{"speed":2.1,"deg":80},
    '//"clouds":{"all":40},"dt":1567423276,
    '//"sys":{"type":1,"id":6391,"message":0.0078,"country":"ES","sunrise":1567402329,"sunset":1567449150},"timezone":7200,"id":2516480,"name":"Ibi","cod":200
    '//}


    Private Sub Form_JSON_ElTiempo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim user As String
            Dim pass As String
            user = "Usuario"
            pass = "Pasword"

            Dim request As WebRequest = WebRequest.Create("http://domain.com/test.php")
            request.Method = "POST"
            Dim postData As String
            postData = "username=" & user & "&password=" & pass
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            If responseFromServer = "0" Then
                MsgBox("Login Failed")
            Else
                MsgBox("json data")
            End If
            reader.Close()
            dataStream.Close()
            response.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim user As String
        Dim pass As String

        Dim request As WebRequest = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?q=Ibi,es&APPID=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx7")
        request.Method = "POST"
        Dim postData As String
        postData = ""
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        Dim dataStream As Stream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()
        Dim response As WebResponse = request.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        '"{""coord"":{""lon"":-0.57,""lat"":38.63},
        '""weather"":[{""id"":800,""main"":""Clear"",""description"":""clear sky"",""icon"":""01d""}],
        '""base"":""stations"",
        '""main"":{""temp"":307.59,""feels_like"":308.34,""temp_min"":305.37,""temp_max"":309.82,""pressure"":1015,""humidity"":30},
        '""visibility"":10000,""wind"":{""speed"":0.89,""deg"":96,""gust"":1.79},
        '""clouds"":{""all"":0},
        '""dt"":1596369627,
        '""sys"":{""type"":3,""id"":2002242,""country"":""ES"",""sunrise"":1596344696,""sunset"":1596395519},
        '""timezone"":7200,""id"":2516480,""name"":""Ibi"",""cod"":200}"

        '    {"comments" [
        '              {
        '              "comment" : "some text",
        '              "date"    : "some date",
        '              "user"    : "user name"
        '              },
        '              {
        '              "comment" : "some text",
        '              "date"    : "some date",
        '              "user"    : "user name"
        '              }
        '            ],
        '"messages": [ .... ]
        '}
        If responseFromServer = "0" Then
            MsgBox("Login Failed")
        Else
            Dim json As String = responseFromServer
            Dim ser As JObject = JObject.Parse(json)
            Dim data As List(Of JToken) = ser.Children().ToList
            Dim output As String = ""
            Try


                For Each item As JProperty In data
                    item.CreateReader()
                    Select Case item.Name
                        Case "coord"
                            '"{""coord"":{""lon"":-0.57,""lat"":38.63},
                            output += "coord:" + vbCrLf
                            For Each coord As JProperty In item.Values
                                coord.CreateReader()
                                Dim u As String = coord("lon")
                                Dim d As String = coord("lat")
                                output += u + vbTab + d + vbTab + vbCrLf
                            Next

                        Case "weather"
                            '""weather"":[{""id"":800,""main"":""Clear"",""description"":""clear sky"",""icon"":""01d""}],
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("id")
                                Dim t As String = msg("main")
                                Dim d As String = msg("description")
                                Dim m As String = msg("icon")
                                output += f + vbTab + t + vbTab + d + vbTab + m + vbTab + vbCrLf
                            Next
                        Case "base"
                        'output += "base:" + vbCrLf
                        'For Each msg As JObject In item.Values
                        '    Dim f As String = msg("base")

                        '    output += f + vbTab + vbCrLf
                        'Next
                        Case "main"
                            '""main"":{""temp"":307.59,""feels_like"":308.34,""temp_min"":305.37,""temp_max"":309.82,""pressure"":1015,""humidity"":30},
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("temp")
                                Dim t As String = msg("feels_like")
                                Dim d As String = msg("temp_min")
                                Dim m As String = msg("temp_max")
                                Dim p As String = msg("pressure")
                                Dim h As String = msg("humidity")
                                output += f + vbTab + t + vbTab + d + vbTab + m + vbTab + p + vbTab + h + vbTab + vbCrLf
                            Next
                        Case "visibility"
                        '""visibility"":10000,
                        'output += "weather:" + vbCrLf
                        'For Each msg As JObject In item.Values
                        '    Dim f As String = msg("id")
                        '    Dim t As String = msg("main")
                        '    Dim d As String = msg("description")
                        '    Dim m As String = msg("icon")
                        '    output += f + vbTab + t + vbTab + d + vbTab + m + vbTab + vbCrLf
                        'Next
                        Case "wind"
                            '""wind"":{""speed"":0.89,""deg"":96,""gust"":1.79},
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("speed")
                                Dim t As String = msg("deg")
                                Dim d As String = msg("gust")
                                output += f + vbTab + t + vbTab + d + vbTab + vbCrLf
                            Next
                        Case "clouds"
                            '""clouds"":{""all"":0},
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("all")
                                output += f + vbTab + vbCrLf
                            Next

                        Case "dt"
                            '""dt"":1596369627,
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("dt")
                                output += f + vbTab + vbCrLf
                            Next

                        Case "sys"
                            '""sys"":{""type"":3,""id"":2002242,""country"":""ES"",""sunrise"":1596344696,""sunset"":1596395519},
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("type")
                                Dim t As String = msg("id")
                                Dim d As String = msg("country")
                                Dim m As String = msg("sunrise")
                                Dim p As String = msg("sunset")
                                output += f + vbTab + t + vbTab + d + vbTab + m + vbTab + p + vbTab + vbCrLf
                            Next

                        Case "timezone"
                            '""timezone"":7200,""id"":2516480,""name"":""Ibi"",""cod"":200}"
                            output += "weather:" + vbCrLf
                            For Each msg As JObject In item.Values
                                Dim f As String = msg("id")
                                Dim t As String = msg("name")
                                Dim d As String = msg("cod")
                                output += f + vbTab + t + vbTab + d + vbTab + vbCrLf
                            Next
                    End Select

                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            MsgBox(output)
        End If
        reader.Close()
        dataStream.Close()
        response.Close()
    End Sub




    'Dim _client As HttpListener
    'Public Sub New()
    '    _client = New HttpListener()

    'End Sub

    'Public Async Function GetWeatherDataAsync(uri As String) As Task(Of WeatherData)
    '    Dim weatherData As WeatherData = Nothing
    '    Try
    '        Dim response As HttpResponseMessage = Await _client.GetAsync(uri)
    '        If response.IsSuccessStatusCode Then
    '            Dim content As String = Await response.Content.ReadAsStringAsync()
    '            weatherData = JsonConvert.DeserializeObject(Of WeatherData)(content)
    '            Debug.WriteLine("" & vbTab & "Ok {0}", weatherData)
    '            Console.WriteLine("Save data: " & weatherData)

    '        End If

    '    Catch ex As Exception
    '        Debug.WriteLine("" & vbTab & "ERROR {0}", ex.Message)

    '    End Try

    '    Return weatherData

    'End Function


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim jsonURL As String = "http://mysafeinfo.com/api/data?list=englishmonarchs&format=json"
        Dim reader As StreamReader
        Dim errorMsg As String = Nothing

        Try
            Dim request As HttpWebRequest = CType(WebRequest.Create(jsonURL), HttpWebRequest)
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
            Dim jsonStr As String = reader.ReadToEnd()

            'Console.Writeline(jsonStr)

            printJSON(jsonStr)

        Catch ex As WebException
             Try
                Console.WriteLine("Error: " + ex.Message)
                errorMsg &= "Download failed. The response from the server was: " + CType(ex.Response, HttpWebResponse).StatusDescription
                Console.WriteLine("Error: " + errorMsg)
            Catch ex1 As Exception

            End Try
        End Try
    End Sub

    Private Sub printJSON(jsonStr As String)
        ' Deserialize our JSON string, then filter and print it

        ' Json.NET deserializer gives you a list of .NET objects
        Dim monarchs = JsonConvert.DeserializeObject(Of List(Of JSON_data))(jsonStr)

        ' Iterate over the objects and print each name property
        For Each monarch In monarchs
            Console.WriteLine(monarch.nm)
        Next

        ' Set up a LINQ statement to filter the monarchs list
        Dim monarchList = From monarch In monarchs Where monarch.nm.Contains("William") Select monarch

        ' Print the results of our LINQ query
        For Each monarch In monarchList
            Console.WriteLine("King or Queen: " + monarch.nm + ", Years: " + monarch.yrs)
        Next
    End Sub

    Public Class JSON_data
        Public nm As String
        Public cty As String
        Public hse As String
        Public yrs As String
        '[
        '  {
        '    "ID": 1,
        '    "Name": "Edward the Elder",
        '    "Country": "United Kingdom",
        '    "House": "House of Wessex",
        '    "Reign": "899-925"
        '  },
        '  {
        '    "ID": 2,
        '    "Name": "Athelstan",
        '    "Country": "United Kingdom",
        '    "House": "House of Wessex",
        '    "Reign": "925-940"
        '  },
        '  {
        '    "ID": 3,
        '    "Name": "Edmund",
        '    "Country": "United Kingdom",
        '    "House": "House of Wessex",
        '    "Reign": "940-946"
        '  },
        '  {
        '    "ID": 4,
        '    "Name": "Edred",
        '    "Country": "United Kingdom",
        '    "House": "House of Wessex",
        '    "Reign": "946-955"
        '  },
        '  {
        '    "ID": 5,
        '    "Name": "Edwy",
        '    "Country": "United Kingdom",
        '    "House": "House of Wessex",
        '    "Reign": "955-959"
        '  }
        ']
    End Class

End Class
