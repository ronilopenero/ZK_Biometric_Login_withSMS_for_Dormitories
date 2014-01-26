Imports zkemkeeper
Imports System.IO
Imports System.Threading


Public Class Zkem
    Dim zkem As New zkemkeeper.CZKEM
    Dim sqlBuilder As New ConnectDB
    Dim machineNumber As Integer = 102
    Sub connect()
        zkem.Connect_USB(machineNumber)
    End Sub

    Sub connect(ByVal machineNumber As Integer) 'Overloaded Function
        Me.machineNumber = machineNumber
        zkem.Connect_USB(machineNumber)
    End Sub

    Sub StoreUserIds()
        Dim EnNum, MN, BN, MP, EN As Integer
        sqlBuilder.connectionOpen()
        While ((zkem.GetAllUserID(machineNumber, EnNum, MN, BN, MP, EN)) = True)
            sqlBuilder.insertId(EnNum, MN, BN, MP, EN)
        End While
        sqlBuilder.connectionClose()
    End Sub

    Sub UpdateUserIds()
        sqlBuilder.connectionOpen()
        sqlBuilder.updateUsers()
        sqlBuilder.connectionClose()
    End Sub

    Sub GetLogs()
        Dim writer As New StreamWriter("C:/Users/PENERO/Desktop/log.txt")
        Dim TMN, EN, EMN, VM, IO, YR, MONTH, DAY, HR, MIN As Integer
        While (zkem.GetGeneralLogData(machineNumber, TMN, EN, EMN, VM, IO, YR, MONTH, DAY, HR, MIN) = True)
            writer.WriteLine(TMN & "-" & EN & "-" & EMN & "-" & VM & "-" & IO & "-" & YR & "-" & MONTH & "-" & DAY & "-" & HR & "-" & MIN)
        End While
        Thread.Sleep(3000)
    End Sub
End Class
