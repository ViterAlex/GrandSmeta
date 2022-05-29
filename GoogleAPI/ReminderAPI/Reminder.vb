Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class Reminder
    Private Const BASE_URI As String = "https://reminders-pa.clients6.google.com/v1internalOP/reminders/"
    Public Property Id() As String

    <DisplayName("Заголовок")>
    Public Property Title() As String

    <DisplayName("Время")>
    Public Property RemindAt() As DateTimeOffset

    <DisplayName("Создан")>
    Public Property CreatedAt() As DateTimeOffset

    <DisplayName("Выполнено")>
    Public Property Done() As Boolean

    <DisplayName("Весь день")>
    Public Property AllDay() As Boolean

    Private Shared gapi As GoogleAPI
    Private Shared token As String

    Public Overrides Function ToString() As String
        Return $"{NameOf(Title)}: {Title}{vbCrLf}" &
            $"{NameOf(RemindAt)}: {RemindAt:G}{vbCrLf}" &
            $"{NameOf(CreatedAt)}: {CreatedAt:G}{vbCrLf}" &
            $"{NameOf(Done)}: {Done}{vbCrLf}" &
            $"{NameOf(AllDay)}: {AllDay}{vbCrLf}" &
            $"{NameOf(Id)}: {Id}"
    End Function

    Public Shared Function NewId() As String
        Return $"client-reminder-{DateTimeOffset.Now.ToUnixTimeMilliseconds}"
    End Function

    Private ReadOnly Property CreateRequestBody As String
        Get
            Dim jo = JObject.Parse("{'2':{'1':7},'3':{'2':'id'},'4':{'1':{'2':'id'},'3':'title','5':{'1':'year','2':'month','3':'day','4':{'1':'hour','2':'minute','3':'second'}},'8':0}}")

            jo("3")("2") = Id
            jo("4")("1")("2") = Id
            jo("4")("3") = Title
            jo("4")("5")("1") = RemindAt.ToString("yyyy")
            jo("4")("5")("2") = RemindAt.ToString("MM")
            jo("4")("5")("3") = RemindAt.ToString("dd")
            'TODO: AllDay?
            jo("4")("5")("4")("1") = RemindAt.ToString("HH")
            jo("4")("5")("4")("2") = RemindAt.ToString("mm")
            jo("4")("5")("4")("3") = RemindAt.ToString("ss")

            Return jo.Stringify()
        End Get
    End Property

    Private ReadOnly Property GetRequestBody As String
        Get
            Dim jo = JObject.Parse("{'2':[{'2':''}]}")
            jo("2")(0)("2") = Id
            Return jo.Stringify()
        End Get
    End Property

    Private ReadOnly Property UpdateRequestBody As String
        Get
            Dim jo = JObject.Parse("{'2':{'2':'id'},'4':{'1':{'2':'id'},'3':'title','5':{'1':'year','2':'month','3':'day','4':{'1':'hour','2':'minute','3':'second'}},'8':0,'18':'createdAt_ms'},'7':{'1':[0,3]}}")
            If AllDay Then
                DirectCast(jo("4")("5"), JObject).Property("4").Remove()
                jo("4")("5")("9") = 1
            Else
                jo("4")("5")("4")("1") = RemindAt.ToString("HH")
                jo("4")("5")("4")("2") = RemindAt.ToString("mm")
                jo("4")("5")("4")("3") = RemindAt.ToString("ss")
            End If
            If Done Then
                jo("4")("8") = 1
                jo("4")("11") = DateTimeOffset.Now.ToUnixTimeMilliseconds
                jo("7")("1")(0) = 1
                jo("7")("1")(1) = 10
                DirectCast(jo("7")("1"), JArray).Add(3)
            End If
            jo("2")("2") = Id
            jo("4")("1")("2") = Id
            jo("4")("3") = Title
            jo("4")("5")("1") = RemindAt.ToString("yyyy")
            jo("4")("5")("2") = RemindAt.ToString("MM")
            jo("4")("5")("3") = RemindAt.ToString("dd")
            jo("4")("18") = CreatedAt.ToUnixTimeMilliseconds()
            Return jo.Stringify()
        End Get
    End Property

    Private ReadOnly Property DeleteRequestBody As String
        Get
            Dim jo = JObject.Parse("{'2':[{'2':''}]}")
            jo("2")(0)("2") = Id
            Return jo.Stringify()
        End Get
    End Property

    Private Shared Function ListRequestBody() As String
        Dim max_timestamp_msec As Integer
        'Empirically, when requesting with a certain timestamp, reminders with the given timestamp
        'or even a bit smaller timestamp are not returned.
        'Therefore we increase the timestamp by 15 hours, which seems to solve this...  ~~voodoo~~
        '(I wish Google had a normal API for reminders)
        If max_timestamp_msec <> 0 Then
            max_timestamp_msec += 15 * 3600 * 1000
        End If

        Dim jo = New JObject()

        jo("5") = 1
        jo("6") = 500
        jo("16") = max_timestamp_msec

        Return jo.Stringify()

    End Function

    Public Sub New()

    End Sub

    Public Sub New(path As String)
        gapi = New GoogleAPI(path)
    End Sub

    Public Async Function Connect() As Task(Of Boolean)
        token = Await gapi.Connect("reminder")
        Return True
    End Function

    Public Function Create(title As String, delayMinutes As Integer, Optional id As String = "") As Reminder
        Me.Title = title
        Me.RemindAt = Now.AddMinutes(delayMinutes)
        Me.Id = IIf(String.IsNullOrEmpty(id), NewId(), id)
        Dim body = CreateRequestBody

        If Execute("create", body) Then
            Return [Get](id)
        End If

        Return Nothing

    End Function

    Public Function Update() As Boolean
        Dim body = UpdateRequestBody
        Return Execute("update", body)
    End Function

    Public Function Delete(id As String) As Boolean
        Me.Id = id
        Dim body = DeleteRequestBody
        Return Execute("delete", body)
    End Function

    Public Function [Get](id As String) As Reminder
        Me.Id = id
        Dim body = GetRequestBody
        If Execute("get", body) Then
            Return Parse(body)
        End If
        Return Nothing
    End Function

    Public Shared Function List() As IList(Of Reminder)
        Dim body = ListRequestBody()

        If Execute("list", body) Then
            Dim jo = JObject.Parse(body)
            If jo("1") Is Nothing Then
                Return Enumerable.Empty(Of Reminder).ToList()
            End If
            Dim ja = jo("1").
                Value(Of JArray).
                AsEnumerable().
                Select(Function(j)
                           Return Parse(j.Stringify())
                       End Function).
                       OrderBy(Function(r)
                                   Return r.RemindAt
                               End Function).
                               ToList()
            Return ja
        End If
        Return Enumerable.Empty(Of Reminder).ToList()
    End Function

    Private Shared Function Execute(action As String, ByRef body As String) As Boolean
        Dim url = $"{BASE_URI}{action}?access_token={token}"
        Dim xhr As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
        Dim buffer = Encoding.UTF8.GetBytes(body)
        xhr.Method = "POST"
        xhr.ContentType = "application/json+protobuf"
        xhr.ContentLength = buffer.Length.ToString()

        Using s As Stream = xhr.GetRequestStream()
            s.Write(buffer, 0, buffer.Length)
        End Using

        Dim resp As HttpWebResponse
        Try
            resp = DirectCast(xhr.GetResponse(), HttpWebResponse)
        Catch ex As Exception
            body = ex.Message
            Return False
        End Try

        If resp.StatusCode = HttpStatusCode.OK Then
            Using s As Stream = resp.GetResponseStream()
                Using sr As New StreamReader(s)
                    body = sr.ReadToEnd()
                    Return True
                End Using
            End Using
        End If
        body = resp.StatusCode.ToString()
        Return False
    End Function

    Private Shared Function Parse(json As String) As Reminder
        Dim jo = JObject.Parse(json)
        Try
            jo = jo("1")(0)
        Catch

        End Try
        Dim id = jo("1")("2").Value(Of String)
        Dim year, month, day, hour, minute, second As Integer
        Dim remindat As DateTimeOffset
        Dim allday As Boolean
        If jo("5") IsNot Nothing Then
            'Если напоминание было перемещено из выполненных, то в нём нет блока времени
            year = jo("5")("1").Value(Of Integer)
            month = jo("5")("2").Value(Of Integer)
            day = jo("5")("3").Value(Of Integer)
            allday = jo("5")("9") IsNot Nothing AndAlso jo("5")("9").Value(Of Integer) = 1
            If Not allday Then
                'AllDay is not set
                'read hours, minutes, seconds
                hour = jo("5")("4")("1").Value(Of Integer)
                minute = jo("5")("4")("2").Value(Of Integer)
                second = jo("5")("4")("3").Value(Of Integer)
            End If
            remindat = New DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero)
        Else
            remindat = DateTimeOffset.Now()
        End If

        Return New Reminder With {
            .Id = jo("1")("2").Value(Of String),
            .RemindAt = remindat,
            .CreatedAt = DateTimeOffset.FromUnixTimeMilliseconds(jo("18").Value(Of Long)).ToLocalTime(),
            .AllDay = allday,
            .Title = jo("3"),
            .Done = jo("8") IsNot Nothing AndAlso jo("8").Value(Of Integer) = 1
            }
    End Function

End Class