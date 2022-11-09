Public Class Form1
    Dim Qcaja1 As New Queue(Of clientesClase)
    Dim Qcaja2 As New Queue(Of clientesClase)
    Dim Qcaja3 As New Queue(Of clientesClase)
    Dim Sgarage As New Stack(Of clientesClase)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        redondearBoton(pagarcaja1)
        redondearBoton(pagarcaja2)
        redondearBoton(pagarcaja3)

        redondearBoton(llegarcaja1)
        redondearBoton(llegarcaja2)
        redondearBoton(llegarcaja3)

        redondearBoton(salir)
        redondearBoton(abrircaja)

        readtxt()
    End Sub

    Sub readtxt()
        Dim clientes As String() = IO.File.ReadAllLines("C:\Users\marus\source\repos\supermercado-laboratorio\supermercado-laboratorio\My Project\clientestxt.txt")

        For i = 0 To clientes.Length - 1
            Dim client As New clientesClase(clientes(i))

            If client.destino = "Caja 1" Then
                Qcaja1.Enqueue(client)
            Else
                Qcaja2.Enqueue(client)
            End If
        Next

        listrefresh()
    End Sub

    Sub listrefresh()
        TextBox1.Text = String.Empty

        caja1.Items.Clear()
        caja2.Items.Clear()
        caja3.Items.Clear()
        garage.Items.Clear()

        For Each i As clientesClase In Qcaja1
            caja1.Items.Add(i.description)
        Next

        For Each i As clientesClase In Qcaja2
            caja2.Items.Add(i.description)
        Next

        For Each i As clientesClase In Qcaja3
            caja3.Items.Add(i.description)
        Next

        For Each i As clientesClase In Sgarage
            garage.Items.Add(i.description)
        Next
    End Sub

    Function redondearBoton(btn As Button) As Button
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.Tan
        btn.ForeColor = Color.White
        btn.Cursor = Cursors.Hand

        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()

        Raduis.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)

        Raduis.AddLine(10, 0, btn.Width - 20, 0)

        Raduis.AddArc(New Rectangle(btn.Width - 20, 0, 20, 20), -90, 90)

        Raduis.AddLine(btn.Width, 20, btn.Width, btn.Height - 10)

        Raduis.AddArc(New Rectangle(btn.Width - 25, btn.Height - 25, 25, 25), 0, 90)

        Raduis.AddLine(btn.Width - 10, btn.Width, 20, btn.Height)

        Raduis.AddArc(New Rectangle(0, btn.Height - 20, 20, 20), 90, 90)

        Raduis.CloseFigure()

        btn.Region = New Region(Raduis)

        Return btn
    End Function

    Private Sub abrircaja_Click(sender As Object, e As EventArgs) Handles abrircaja.Click
        llegarcaja3.Enabled() = True
    End Sub

    Private Sub llegarcaja1_Click(sender As Object, e As EventArgs) Handles llegarcaja1.Click
        If TextBox1.Text.Trim = String.Empty Then
            MessageBox.Show("Campos vacíos, por favor rellenar antes de enviar a una caja.",
                            "Error",
                            MessageBoxButtons.OK)
        Else
            Dim clientebienuwu As New clientesClase(TextBox1.Text.Trim)
            Qcaja1.Enqueue(clientebienuwu)

            listrefresh()
        End If
    End Sub

    Private Sub llegarcaja2_Click(sender As Object, e As EventArgs) Handles llegarcaja2.Click
        If TextBox1.Text.Trim = String.Empty Then
            MessageBox.Show("Campos vacíos, por favor rellenar antes de enviar a una caja.",
                            "Error",
                            MessageBoxButtons.OK)
        Else
            Dim clientebienuwu As New clientesClase(TextBox1.Text.Trim)
            Qcaja2.Enqueue(clientebienuwu)

            listrefresh()
        End If
    End Sub

    Private Sub llegarcaja3_Click(sender As Object, e As EventArgs) Handles llegarcaja3.Click
        If TextBox1.Text.Trim = String.Empty Then
            MessageBox.Show("Campos vacíos, por favor rellenar antes de enviar a una caja.",
                            "Error",
                            MessageBoxButtons.OK)
        Else
            If rbtarjeta.Checked() = True Then
                MessageBox.Show("Esta caja solo permite pagos en efectivo.",
                                "Error",
                                MessageBoxButtons.OK)
            Else
                Dim clientebienuwu As New clientesClase(TextBox1.Text.Trim)
                Qcaja3.Enqueue(clientebienuwu)

                listrefresh()
            End If
        End If
    End Sub

    Private Sub pagarcaja1_Click(sender As Object, e As EventArgs) Handles pagarcaja1.Click
        If caja1.Items.Count = 0 Then
            MessageBox.Show("La caja actualmente se encuentra vacía.",
                            "Error",
                             MessageBoxButtons.OK)
        Else
            Sgarage.Push(Qcaja1.Dequeue())

            listrefresh()
        End If
    End Sub

    Private Sub pagarcaja2_Click(sender As Object, e As EventArgs) Handles pagarcaja2.Click
        If caja2.Items.Count = 0 Then
            MessageBox.Show("La caja actualmente se encuentra vacía.",
                            "Error",
                             MessageBoxButtons.OK)
        Else
            Sgarage.Push(Qcaja2.Dequeue())

            listrefresh()
        End If
    End Sub

    Private Sub pagarcaja3_Click(sender As Object, e As EventArgs) Handles pagarcaja3.Click
        If caja3.Items.Count = 0 Then
            MessageBox.Show("La caja actualmente se encuentra vacía.",
                            "Error",
                             MessageBoxButtons.OK)
        Else
            Sgarage.Push(Qcaja3.Dequeue())

            listrefresh()
        End If
    End Sub

    Private Sub salir_Click(sender As Object, e As EventArgs) Handles salir.Click
        If garage.Items.Count = 0 Then
            MessageBox.Show("El garage actualmente se encuentra vacío.",
                            "Error",
                             MessageBoxButtons.OK)
        Else
            Sgarage.Pop()

            listrefresh()
        End If
    End Sub

End Class
