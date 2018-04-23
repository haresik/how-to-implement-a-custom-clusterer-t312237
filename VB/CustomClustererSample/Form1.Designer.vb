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
            Dim mapItemAttributeMapping1 As New DevExpress.XtraMap.MapItemAttributeMapping()
            Me.imageTilesLayer2 = New DevExpress.XtraMap.ImageLayer()
            Me.bingMapDataProvider2 = New DevExpress.XtraMap.BingMapDataProvider()
            Me.vectorItemsLayer2 = New DevExpress.XtraMap.VectorItemsLayer()
            Me.listSourceDataAdapter2 = New DevExpress.XtraMap.ListSourceDataAdapter()
            Me.map = New DevExpress.XtraMap.MapControl()
            CType(Me.map, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' imageTilesLayer2
            ' 
            Me.imageTilesLayer2.DataProvider = Me.bingMapDataProvider2
            ' 
            ' vectorItemsLayer2
            ' 
            Me.vectorItemsLayer2.Data = Me.listSourceDataAdapter2
            Me.vectorItemsLayer2.Name = "VectorLayer"
            ' 
            ' listSourceDataAdapter2
            ' 
            mapItemAttributeMapping1.Member = "LocationName"
            mapItemAttributeMapping1.Name = "LocationName"
            mapItemAttributeMapping1.ValueType = DevExpress.XtraMap.FieldValueType.String
            Me.listSourceDataAdapter2.AttributeMappings.Add(mapItemAttributeMapping1)
            Me.listSourceDataAdapter2.DefaultMapItemType = DevExpress.XtraMap.MapItemType.Dot
            Me.listSourceDataAdapter2.Mappings.Latitude = "Latitude"
            Me.listSourceDataAdapter2.Mappings.Longitude = "Longitude"
            ' 
            ' map
            ' 
            Me.map.Dock = System.Windows.Forms.DockStyle.Fill
            Me.map.Layers.Add(Me.imageTilesLayer2)
            Me.map.Layers.Add(Me.vectorItemsLayer2)
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
            CType(Me.map, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private map As DevExpress.XtraMap.MapControl
        Private imageTilesLayer2 As DevExpress.XtraMap.ImageLayer
        Private bingMapDataProvider2 As DevExpress.XtraMap.BingMapDataProvider
        Private vectorItemsLayer2 As DevExpress.XtraMap.VectorItemsLayer
        Private listSourceDataAdapter2 As DevExpress.XtraMap.ListSourceDataAdapter
    End Class
End Namespace

