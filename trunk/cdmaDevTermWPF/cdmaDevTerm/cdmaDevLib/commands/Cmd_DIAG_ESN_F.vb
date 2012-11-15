﻿Public Class Cmd_DIAG_ESN_F
    Inherits Command
    Sub New(ByVal qcdm As Qcdm.Cmd, ByVal qcData As Byte(), ByVal debuggingTextIn As String)
        MyBase.New(qcdm, qcData, debuggingTextIn)
    End Sub
    Public Overrides Sub decode()
        Try

            ''Dim stringFromPacket As String = cdmaTerm.AtReturnCmdBox.Text
            Dim stringFromPacket As String = Me.bytesRxd.ToHexString()

            Dim DecodedString As String = ""


            DecodedString += stringFromPacket(8) + stringFromPacket(9) & _
            stringFromPacket(6) + stringFromPacket(7) & _
            stringFromPacket(4) + stringFromPacket(5) & _
            stringFromPacket(2) + stringFromPacket(3)



            cdmaTerm.thePhone.Esn = DecodedString
            cdmaTerm.thePhoneRxd.Esn = DecodedString


        Catch
            logger.add("No esn(diag_esn_f) found", logger.LogType.msg)

        End Try
    End Sub
End Class
