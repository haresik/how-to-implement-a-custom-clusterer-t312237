Imports System

Namespace CustomClustererSample
    Friend Class Tree

        Private locationName_Renamed As String

        Public Sub New()
            locationName_Renamed = ""
        End Sub
        Public Property Latitude() As Double
        Public Property Longitude() As Double
        Public Property LocationName() As String
            Get
                Return Me.locationName_Renamed
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    Throw New ArgumentNullException("LocationName")
                End If
                If value.Equals(Me.locationName_Renamed) Then
                    Return
                End If
                Me.locationName_Renamed = value
            End Set
        End Property
    End Class
End Namespace
