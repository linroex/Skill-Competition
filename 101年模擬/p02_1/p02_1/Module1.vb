Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in1.txt", "in2.txt"}
        For Each address As String In file_address
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).Split(vbCrLf)
            Dim head() As String = content(0).Split(",")

            For i As Integer = 1 To head(0).Trim
                Dim temp() As String = content(i).Replace("  ", ";").Split(";")
                Dim info(temp(0) - 2, 1) As String
                Dim route As String = head(1).Trim
                Dim count As Integer = 1
                Dim target As String = head(1).Trim

                For ii As Integer = 0 To temp(0) - 2
                    Dim ca() As String = temp(ii + 1).Split(",")
                    info(ii, 0) = ca(0).Trim
                    info(ii, 1) = ca(1).Trim
                Next

               
                Do While target <> 0
                    target = info(target - 1, 1)
                    route &= "->" & target
                    count += 1
                Loop

                My.Computer.FileSystem.WriteAllText("out.txt", "路徑長度為：" & count & vbTab & route & vbCrLf, True)


            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
    End Sub

End Module
