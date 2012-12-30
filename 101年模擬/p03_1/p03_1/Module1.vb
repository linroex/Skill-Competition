Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in1.txt", "in2.txt"}
        For Each address In file_address
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).ToUpper.Split(vbCrLf)
            For i As Integer = 1 To content(0).Trim
                content(i) = content(i).Trim
                Dim sum As Integer = 0
                For ii As Integer = 8 To 1 Step -1
                    sum += Mid(content(i), 10 - ii, 1) * ii

                Next
                sum += Mid(content(i), 10, 1) + get_stat(content(i))
                If sum Mod 10 = 0 Then
                    My.Computer.FileSystem.WriteAllText("out.txt", "T" & vbCrLf, True)
                Else
                    My.Computer.FileSystem.WriteAllText("out.txt", "F" & vbCrLf, True)
                End If
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)

        Next
    End Sub

    Function get_stat(ByVal x As String) As Integer
        Dim str As String = "ABCDEFGHJKLMNPQRSTUVXYWZIO"
        Dim result As Integer = (InStr(str, Mid(x.Trim, 1, 1)) + 9) \ 10 + ((InStr(str, Mid(x.Trim, 1, 1)) + 9) Mod 10) * 9
        Return result
    End Function
End Module
