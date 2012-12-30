Module Module1

    Sub Main()
        My.Computer.FileSystem.WriteAllText("out.txt", "", False)

        Dim file_address() As String = {"in1.txt", "in2.txt"}
        For Each address In file_address
            Dim content() As String = My.Computer.FileSystem.ReadAllText(address).Split(vbCrLf)

            For i As Integer = 1 To content(0).Trim
                Dim temp() As String = content(i).Replace("  ", ";").Split(";")
                Dim info(temp.Length - 1, 2) As String
                Dim route As New ArrayList
                Dim list As String = ""
                Dim flag As Boolean = False

                For ii As Integer = 0 To temp.Length - 1
                    Dim ca() As String = temp(ii).Split(",")
                    info(ii, 0) = ca(0).Trim
                    info(ii, 1) = ca(1).Trim
                    list &= ca(0).Trim & ca(1).Trim
                    If info(ii, 0) = info(ii, 1) And Not ii = temp.Length - 1 Then
                        flag = False
                        info(ii, 2) = True
                    Else

                        info(ii, 2) = False
                    End If
                Next

                If temp.Length = 1 And (info(0, 0) = "0" And info(0, 1) = "0") Then
                    flag = True
                End If

                list = get_distinct(list)
                route.Add(info(0, 0))

                For ii As Integer = 0 To temp.Length - 1
                    For iii As Integer = 0 To temp.Length - 1
                        If info(iii, 2) = False Then
                            If ii >= route.Count Then
                                flag = False
                                Exit For
                            End If
                            If info(iii, 0) = route(ii) Or info(iii, 1) = route(ii) Then
                                If info(iii, 0) = 0 And info(iii, 1) = 0 Then
                                    Exit For
                                End If
                                info(iii, 2) = True
                                If info(iii, 0) = route(ii) Then
                                    route.Add(info(iii, 1))
                                ElseIf info(iii, 1) = route(ii) Then
                                    route.Add(info(iii, 0))
                                End If
                            End If
                        End If
                    Next
                Next
                If flag = True Then
                    My.Computer.FileSystem.WriteAllText("out.txt", "T" & vbCrLf, True)
                ElseIf list.Length = route.Count Then
                    My.Computer.FileSystem.WriteAllText("out.txt", "T" & vbCrLf, True)
                Else
                    My.Computer.FileSystem.WriteAllText("out.txt", "F" & vbCrLf, True)

                End If
            Next
            My.Computer.FileSystem.WriteAllText("out.txt", vbCrLf, True)
        Next
    End Sub

    Function get_distinct(ByVal x As String) As String
        x = x.Trim
        Dim result As String = ""
        For i As Integer = 1 To x.Trim.Length - 1
            If result.IndexOf(Mid(x, i, 1)) = -1 Then
                result &= Mid(x, i, 1)
            End If
        Next
        Return result

    End Function

End Module
