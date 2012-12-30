Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)
        Dim file() As String = {"in1.txt", "in2.txt"}
        For Each address In file
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).Replace(";", " ").Replace(".", " ").Replace(",", " ").Replace(vbCrLf, " ").ToLower.Split(" ")
            Dim count As Integer = 0
            For i As Integer = 1 To content.Length - 1
                If content(i).Trim = "eof" Then
                    Exit For
                ElseIf content(i).Trim = content(0).Trim Then
                    count += 1
                End If
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", count & vbCrLf & vbCrLf, True)
        Next
    End Sub

End Module
