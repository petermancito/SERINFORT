Imports Cryptograp.CEncriptaciones

Imports System.Data.OleDb
Imports Npgsql


Namespace LogicaNegocio

    Public Class CConexionSql
        Private dbConexion2 As NpgsqlConnection
        Private dbComando2 As NpgsqlCommand
        Private dbAdapter2 As NpgsqlDataAdapter

        Private dbDataset As DataSet
        Private dbDataTable As DataTable
        Private dbBuilder2 As NpgsqlCommandBuilder
        Public Property Servidor As String = IIf(My.Settings.myConfig.Length = 0, "", Decrypt(My.Settings.myConfig).Split(";")(0).Replace("Server=", ""))




        Public Function Conectar() As NpgsqlConnection
            Try

                Dim cadena As String
                cadena = Decrypt(My.Settings.myConfig)          '  "Server=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=CtrlEscBD;"
                dbConexion2 = New NpgsqlConnection(cadena)
                dbConexion2.Open()

                Return dbConexion2
            Catch ex As Exception
                Return dbConexion2
            End Try

        End Function


        Public Function ExecuteSql(ByRef cadena_sql As String) As Integer
            Try

                Dim resp As Integer

                dbComando2 = New NpgsqlCommand(cadena_sql, Conectar)
                dbComando2.CommandType = CommandType.Text
                resp = dbComando2.ExecuteNonQuery()
                Return resp
            Catch ex As Exception
                MsgBox(ex.Message)
                Return 0
            Finally
                'Me.CerrarConexion()
            End Try
        End Function

        Public Function ExecuteSql(ByRef cadena_sql As String, ByRef cnt As NpgsqlConnection) As Integer
            Try
                dbComando2 = New NpgsqlCommand(cadena_sql, cnt)
                dbComando2.CommandType = CommandType.Text
                dbComando2.ExecuteNonQuery()
                Return 1
            Catch ex As Exception
                Return 0
            Finally
                'Me.CerrarConexion()
            End Try
        End Function


        Public Function LlenarDataTable(ByRef cadena As String) As DataTable
            Try
                dbDataTable = New DataTable
                dbDataset = New DataSet
                dbAdapter2 = New NpgsqlDataAdapter(cadena, Conectar())
                dbBuilder2 = New NpgsqlCommandBuilder(dbAdapter2)
                dbAdapter2.Fill(dbDataset)

                dbDataTable = dbDataset.Tables(0)
                Return dbDataTable
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error al Llenar Lista", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return dbDataTable
            Finally
                CerrarConexion2()
            End Try
        End Function

        Public Sub CerrarConexion2()
            dbConexion2.Close()
        End Sub
    End Class

End Namespace
