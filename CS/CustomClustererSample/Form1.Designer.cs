namespace CustomClustererSample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DevExpress.XtraMap.ImageTilesLayer imageTilesLayer2 = new DevExpress.XtraMap.ImageTilesLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider2 = new DevExpress.XtraMap.BingMapDataProvider();
            DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer2 = new DevExpress.XtraMap.VectorItemsLayer();
            DevExpress.XtraMap.ListSourceDataAdapter listSourceDataAdapter2 = new DevExpress.XtraMap.ListSourceDataAdapter();
            DevExpress.XtraMap.MapItemAttributeMapping mapItemAttributeMapping2 = new DevExpress.XtraMap.MapItemAttributeMapping();
            this.map = new DevExpress.XtraMap.MapControl();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            imageTilesLayer2.DataProvider = bingMapDataProvider2;
            mapItemAttributeMapping2.Member = "LocationName";
            mapItemAttributeMapping2.Name = "LocationName";
            mapItemAttributeMapping2.ValueType = DevExpress.XtraMap.FieldValueType.String;
            listSourceDataAdapter2.AttributeMappings.Add(mapItemAttributeMapping2);
            listSourceDataAdapter2.DefaultMapItemType = DevExpress.XtraMap.MapItemType.Dot;
            listSourceDataAdapter2.Mappings.Latitude = "Latitude";
            listSourceDataAdapter2.Mappings.Longitude = "Longitude";
            vectorItemsLayer2.Data = listSourceDataAdapter2;
            vectorItemsLayer2.Name = "VectorLayer";
            this.map.Layers.Add(imageTilesLayer2);
            this.map.Layers.Add(vectorItemsLayer2);
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(1264, 681);
            this.map.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.map);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl map;
    }
}

