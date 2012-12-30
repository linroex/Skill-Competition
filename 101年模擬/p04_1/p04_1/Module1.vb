Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in1.txt", "in2.txt"}
        For Each address In file_address
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).Split(vbCrLf)

            For i As Integer = 1 To content(0)
                Dim result As String = ""
                content(i) = content(i).Trim

                For ii As Integer = 1 To content(i).Length Step 4

                    Dim t As Integer = 8
                    Dim temp As String = Mid(content(i), ii, 4).Trim
                    Dim sum As Integer = 0

                    For iii As Integer = 1 To 4
                        sum += Val(Mid(temp, iii, 1)) * t
                        t /= 2
                    Next
                    If sum > 9 Then
                        sum += 55
                        result &= Chr(sum)
                    Else
                        result &= Str(sum).Trim
                    End If

                Next
                My.Computer.FileSystem.WriteAllText("out.txt", result & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)

        Next
    End Sub

End Module
