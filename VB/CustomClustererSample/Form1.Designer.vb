Namespace CustomClustererSample
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim imageTilesLayer2 As New DevExpress.XtraMap.ImageTilesLayer()
            Dim bingMapDataProvider2 As New DevExpress.XtraMap.BingMapDataProvider()
            Dim vectorItemsLayer2 As New DevExpress.XtraMap.VectorItemsLayer()
            Dim listSourceDataAdapter2 As New DevExpress.XtraMap.ListSourceDataAdapter()
            Dim mapItemAttributeMapping2 As New DevExpress.XtraMap.MapItemAttributeMapping()
            Me.map = New DevExpress.XtraMap.MapControl()
            DirectCast(Me.map, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' map
            ' 
            Me.map.Dock = System.Windows.Forms.DockStyle.Fill
            imageTilesLayer2.DataProvider = bingMapDataProvider2
            mapItemAttributeMapping2.Member = "LocationName"
            mapItemAttributeMapping2.Name = "LocationName"
            mapItemAttributeMapping2.ValueType = DevExpress.XtraMap.FieldValueType.String
            listSourceDataAdapter2.AttributeMappings.Add(mapItemAttributeMapping2)
            listSourceDataAdapter2.DefaultMapItemType = DevExpress.XtraMap.MapItemType.Dot
            listSourceDataAdapter2.Mappings.Latitude = "Latitude"
            listSourceDataAdapter2.Mappings.Longitude = "Longitude"
            vectorItemsLayer2.Data = listSourceDataAdapter2
            vectorItemsLayer2.Name = "VectorLayer"
            Me.map.Layers.Add(imageTilesLayer2)
            Me.map.Layers.Add(vectorItemsLayer2)
            Me.map.Location = New System.Drawing.Point(0, 0)
            Me.map.Name = "map"
            Me.map.Size = New System.Drawing.Size(1264, 681)
            Me.map.TabIndex = 0
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1264, 681)
            Me.Controls.Add(Me.map)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.map, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private map As DevExpress.XtraMap.MapControl
    End Class
End Namespace

