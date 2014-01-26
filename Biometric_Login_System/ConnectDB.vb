Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class ConnectDB
    Dim connectionStr As String = "Data Source=(LocalDB)\v11.0;AttachDbFilename=" & Chr(34) & "c:\users\penero\documents\visual studio 2013\Projects\Biometric_Login_System\Biometric_Login_System\Biometric.mdf" & Chr(34) & ";Integrated Security=True"
    Dim connection As SqlConnection = New SqlConnection(connectionStr)

    Sub connectionOpen()
        connection.Open()
        Dim commandStr As String = "DROP TABLE USER_ID"
        Dim command As SqlCommand = New SqlCommand(commandStr, connection)
        command.ExecuteNonQuery()
        commandStr = "CREATE TABLE [dbo].[USER_ID] ([ENROLLMENT_NUM] INT NOT NULL, [MACHINE_NUM] INT NOT NULL, [BACKUP_NUM] INT NOT NULL, [MACHINE_PRIVELEGE] INT NOT NULL, [ENABLE] INT NOT NULL, PRIMARY KEY CLUSTERED ([ENROLLMENT_NUM] ASC));"
        command = New SqlCommand(commandStr, connection)
        command.ExecuteNonQuery()
    End Sub

    Sub connectionClose()
        connection.Close()
    End Sub

    Sub updateUsers()
        Dim commandStr As String = "DROP TABLE USER_ID"
        Dim command As SqlCommand = New SqlCommand(commandStr, connection)
        command.ExecuteNonQuery()
        commandStr = "CREATE TABLE [dbo].[USER_ID] ([ENROLLMENT_NUM] INT NOT NULL, [MACHINE_NUM] INT NOT NULL, [BACKUP_NUM] INT NOT NULL, [MACHINE_PRIVELEGE] INT NOT NULL, [ENABLE] INT NOT NULL, PRIMARY KEY CLUSTERED ([ENROLLMENT_NUM] ASC));"
        command = New SqlCommand(commandStr, connection)
        command.ExecuteNonQuery()
    End Sub

    Sub insertId(ByVal EnNum As Integer, ByVal MN As Integer, ByVal BN As Integer, ByVal MP As Integer, ByVal EN As Integer)
        Try
            Dim commandStr As String = "INSERT INTO USER_ID VALUES('" + EnNum.ToString + "', '" + MN.ToString + "', '" + BN.ToString + "', '" + MP.ToString + "', '" + EN.ToString + "');"
            Dim command As SqlCommand = New SqlCommand(commandStr, connection)
            command.ExecuteNonQuery()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub insertUserInfo(ByVal EnNum As Integer, ByVal Name As String, ByVal Gender As Char, ByVal Age As Integer, ByVal Number As String)
        Try
            connectionOpen()
            Dim commandStr As String = "INSERT INTO USER_INFO VALUES('" + EnNum.ToString + "', '" + Name + "', '" + Age.ToString + "', '" + Number + "', '" + Gender.ToString + "');"
            Dim command As SqlCommand = New SqlCommand(commandStr, connection)
            command.ExecuteNonQuery()
            connectionClose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
