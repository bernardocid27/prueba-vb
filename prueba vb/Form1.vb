Imports System.Data.SqlClient

Public Class Form1

    Dim connection As New SqlConnection("Server=DESKTOP-R3DPSGI\SQLEXPRESS; Database = prueba; Integrated Security = true")
    Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click

        Dim insertQuery As String = "INSERT INTO persona (nombre,apellido,edad) VALUES ('" & txtnombre.Text & "','" & txtapellido.Text & "','" & txtedad.Text & "')"

        ExecuteQuery(insertQuery)

        MessageBox.Show("Insertados correctamente")

        txtnombre.Clear()
        txtapellido.Clear()
        txtedad.Clear()


    End Sub

    Public Sub ExecuteQuery(query As String)
        Dim command As New SqlCommand(query, connection)

        connection.Open()

        command.ExecuteNonQuery()

        connection.Close()

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        Dim updateQuery As String = "UPDATE persona SET nombre='" & txtnombre.Text & "', apellido='" & txtapellido.Text & "', edad='" & txtedad.Text & "' WHERE id=" & txtid.Text & " "

        ExecuteQuery(updateQuery)

        MessageBox.Show("Datos actualizados")

        txtid.Clear()
        txtnombre.Clear()
        txtapellido.Clear()
        txtedad.Clear()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click

        Dim deleteQuery As String = "DELETE FROM persona WHERE id=" & txtid.Text

        ExecuteQuery(deleteQuery)

        MessageBox.Show("Datos Eliminados")

        txtid.Clear()
        txtnombre.Clear()
        txtapellido.Clear()
        txtedad.Clear()
    End Sub

    Private Sub txtBuscar_Click(sender As Object, e As EventArgs) Handles txtBuscar.Click

        Dim command As New SqlCommand("SELECT * FROM persona WHERE id= @id", connection)

        command.Parameters.Add("@id", SqlDbType.Int).Value = txtid.Text

        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() > 0 Then

            txtnombre.Text = table(0)(1).ToString()
            txtapellido.Text = table(0)(2).ToString()
            txtedad.Text = table(0)(3).ToString()

        Else

            MessageBox.Show("No Existe Datos")


            txtnombre.Clear()
            txtapellido.Clear()
            txtedad.Clear()

        End If




    End Sub
End Class
