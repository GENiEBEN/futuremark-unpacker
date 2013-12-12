Imports System.Environment
Imports System.IO

Module Module1

    Private m_XOR_MASK As Byte = 218
    Private Function Rotate(ByVal x As Byte) As Byte
        Return CByte(((x >> 4 Or x << 4) And 255))
    End Function

    Sub Main()
        Dim s() As String = GetCommandLineArgs()
        Dim filenameIn As String = Nothing
        Dim filenameOut As String = Nothing
        Dim optype As String = Nothing

        Dim i As Integer = 0

        optype = Mid(s(1), 2, Len(s(1)) - 1)
        filenameIn = Mid(s(2), 2, Len(s(2)) - 1)
        filenameOut = Mid(s(3), 2, Len(s(3)) - 1)

        'If s(4) <> Nothing Then
        '    m_XOR_MASK = Mid(s(4), 2, Len(s(4)) - 1)
        'End If

        Console.WriteLine("Reading " & filenameIn)

        Select Case optype
            Case "decrypt"
                Dim bytes() As Byte = IO.File.ReadAllBytes(filenameIn)
                Dim buf As Byte = CByte((Rotate(bytes(4)) Xor m_XOR_MASK))
                Dim FileVersion As String = buf.ToString

                If bytes(0) = &H99 And bytes(1) = &H88 And bytes(2) = &HB9 And bytes(3) = &HF9 Then
                    Console.WriteLine("Valid file found, version " & FileVersion)
                End If

                Do
                    bytes(i) = CByte((Rotate(bytes(i)) Xor m_XOR_MASK))
                    i = i + 1
                Loop While i < CInt(bytes.Length)

                Console.WriteLine("Saved as " & filenameOut)
                IO.File.WriteAllBytes(filenameOut, bytes)

            Case "encrypt"
                Dim bytes() As Byte = IO.File.ReadAllBytes(filenameIn)
                Dim buf As Byte = CByte((Rotate(bytes(4)) Xor m_XOR_MASK))
                Dim FileVersion As String = buf.ToString

                If bytes(0) = &H99 And bytes(1) = &H88 And bytes(2) = &HB9 And bytes(3) = &HF9 Then
                    Console.WriteLine("Valid file found, version " & FileVersion)
                End If

                Do
                    bytes(i) = Rotate(CByte((bytes(i) Xor m_XOR_MASK)))
                    i = i + 1
                Loop While i < CInt(bytes.Length)

                Console.WriteLine("Saved as " & filenameOut)
                IO.File.WriteAllBytes(filenameOut, bytes)
        End Select


        'OLD CODE:

        'For i As Integer = 0 To (bytes.Length - 1)


        ''Console.Write("{0}Decrypting {1}/{2}", vbCr, i, bytes.Length.ToString)


        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes(".")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("8")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("»")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("a")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("¹")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("A")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("‹")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("b")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("‰")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("B")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("›")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("c")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("™")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("C")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ë")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("d")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("é")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("D")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("û")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("e")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ù")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("E")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ë")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("f")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("É")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("F")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Û")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("g")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ù")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("G")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("h")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("J")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("+")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("h")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes(")")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("H")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("i")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("L")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes(";")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("i")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("9")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("I")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes(">")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("9")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("n")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("<")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("N")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes(">")(0)

        'If bytes(i) = &HB Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("j")(0) 'VT

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("K")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("n")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("k")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("l")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("K")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("N")(0)

        'If bytes(i) = &H1B Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("k")(0) 'ESC

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes(".")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("K")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("{")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("m")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("y")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("M")(0)

        'If bytes(i) = &H1A Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("{")(0) 'ESC

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("O")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes(".")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("o")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes(",")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("[")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("o")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Y")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("O")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ª")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("p")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("¨")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("P")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("º")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("q")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Š")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("r")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ˆ")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("R")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("š")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("s")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("˜")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("S")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ê")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("t")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("è")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("T")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ú")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("u")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ø")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("U")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ê")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("v")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("È")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("V")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ú")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("w")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ø")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("W")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("x")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("]")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("_")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("/")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("X")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("_")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("*")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("x")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("(")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("X")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes(":")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("y")(0)

        'If bytes(i) = &HE Then bytes(i) = System.Text.Encoding.ASCII.GetBytes(":")(0) 'E

        'If bytes(i) = &H8 Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("Z")(0) 'BS

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("z")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("}")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("®")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("0")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("¾")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("1")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ž")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("2")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("ž")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("3")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("î")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("4")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("þ")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("5")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Î")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("6")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Þ")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("7")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("J")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("\")(0)


        'If bytes(i) = &H1E Then bytes(i) = System.Text.Encoding.ASCII.GetBytes(";")(0) 'RS

        'If bytes(i) = &HF Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("*")(0) 'SI


        'If bytes(i) = &H7F Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("-")(0) 'DEL

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("^")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("?")(0)

        'If bytes(i) = &H18 Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("[")(0) 'CAN

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("¿")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("!")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("¯")(0) Then bytes(i) = &H20


        'If bytes(i) = &HA Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("z")(0)
        'If bytes(i) = &HD Then bytes(i) = &HA 'swap LF with CR

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("}")(0) Then bytes(i) = &HD 'CR

        'If bytes(i) = &H1F Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("=")(0) 'US

        'If bytes(i) = &H19 Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("K")(0) 'EM

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("~")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("=")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ÿ")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("#")(0)

        'If bytes(i) = System.Text.UnicodeEncoding.Default.GetBytes("Ï")(0) Then bytes(i) = System.Text.Encoding.ASCII.GetBytes("&")(0)


        'Next

        'Console.ReadKey()
    End Sub

End Module
