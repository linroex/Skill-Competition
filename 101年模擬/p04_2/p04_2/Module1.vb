Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in1.txt", "in2.txt"}
        For Each address In file_address
            Dim rep() As Char = {"S", "H", "D", "C"}

            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).ToUpper.Replace("S", "").Replace("H", "").Replace("D", "").Replace("C", "").Split(vbCrLf)
            For i As Integer = 1 To content(0)
                Dim temp() As String = content(i).Split(" ")
                Dim sum As Integer = 0
                Dim one_c As Integer = 0

                For ii As Integer = 0 To temp.Length - 1
                    If temp(ii).Trim = "" Then
                        Continue For

                    End If
                    If temp(ii).Trim > 10 Then
                        sum += 10
                    ElseIf temp(ii).Trim = 1 Then
                        sum += 11
                        one_c += 1
                    Else
                        sum += temp(ii)
                    End If
                Next

                For ii As Integer = 0 To one_c - 1
                    If sum > 21 Then
                        sum -= 10
                    End If
                Next

                If sum > 21 Then
                    My.Computer.FileSystem.WriteAllText("out.txt", "F" & vbCrLf, True)
                Else
                    My.Computer.FileSystem.WriteAllText("out.txt", sum & vbCrLf, True)
                End If

            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)

        Next
    End Sub

End Module
