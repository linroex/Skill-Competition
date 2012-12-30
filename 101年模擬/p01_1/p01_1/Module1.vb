Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in1.txt", "in2.txt"}
        For Each address In file_address
            Dim rep() As Char = {".", ";", ","}
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).Trim(rep).Split(vbCrLf)
            For i As Integer = 1 To content(0)
                Dim result() As String = content(i).Split(" ")
                Dim count As Integer = 0
                For ii As Integer = 0 To result.Length - 1
                    If Not result(i).Trim = "" Then
                        count += 1
                    End If
                Next
                My.Computer.FileSystem.WriteAllText("out.txt", count & vbCrLf, True)

            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
    End Sub

End Module
