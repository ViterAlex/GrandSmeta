Imports System.Runtime.CompilerServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Module Helpers

    <Extension()>
    Public Function Stringify(jo As JObject) As String
        Return JsonConvert.SerializeObject(jo)
    End Function

    <Extension()>
    Public Function Stringify(jo As JToken) As String
        Return JsonConvert.SerializeObject(jo)
    End Function

End Module