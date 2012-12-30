Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in.txt", "in2.txt"}
        For Each address In file_address
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).ToUpper.Split(vbCrLf)
            For i As Integer = 1 To content(0)
                Dim str As String = content(i).Trim.Replace("11111", "F").Replace("11110", "E").Replace("1110", "D").Replace("110", "C").Replace("10", "B").Replace("0", "A")
                For ii As Integer = 1 To str.Length
                    If Asc(Mid(str, ii, 1)) < Asc("A") Or Asc(Mid(str, ii, 1)) > Asc("F") Then
                        str = "NULL"
                        Exit For

                    End If
                Next
                My.Computer.FileSystem.WriteAllText("out.txt", str & vbCrLf, True)
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)

        Next

    End Sub

End Module
