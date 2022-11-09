Public Class clientesClase
    Private _description As String
    Private _destino As String

    Public Shared caja As String = "Caja 2"

    Public Sub New(z As String)
        description = z

        If caja = "Caja 1" Then
            caja = "Caja 2"
        Else
            caja = "Caja 1"
        End If

        destino = caja
    End Sub

    Public Property description As String
        Get
            Return _description
        End Get
        Set(value As String)
            _description = value
        End Set
    End Property

    Public Property destino As String
        Get
            Return _destino
        End Get
        Set(value As String)
            _destino = value
        End Set
    End Property
End Class
