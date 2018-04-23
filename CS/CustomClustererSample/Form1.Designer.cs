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
            DevExpress.XtraMap.MapItemAttributeMapping mapItemAttributeMapping1 = new DevExpress.XtraMap.MapItemAttributeMapping();
            this.imageTilesLayer2 = new DevExpress.XtraMap.ImageLayer();
            this.bingMapDataProvider2 = new DevExpress.XtraMap.BingMapDataProvider();
            this.vectorItemsLayer2 = new DevExpress.XtraMap.VectorItemsLayer();
            this.listSourceDataAdapter2 = new DevExpress.XtraMap.ListSourceDataAdapter();
            this.map = new DevExpress.XtraMap.MapControl();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // imageTilesLayer2
            // 
            this.imageTilesLayer2.DataProvider = this.bingMapDataProvider2;
            // 
            // vectorItemsLayer2
            // 
            this.vectorItemsLayer2.Data = this.listSourceDataAdapter2;
            this.vectorItemsLayer2.Name = "VectorLayer";
            // 
            // listSourceDataAdapter2
            // 
            mapItemAttributeMapping1.Member = "LocationName";
            mapItemAttributeMapping1.Name = "LocationName";
            mapItemAttributeMapping1.ValueType = DevExpress.XtraMap.FieldValueType.String;
            this.listSourceDataAdapter2.AttributeMappings.Add(mapItemAttributeMapping1);
            this.listSourceDataAdapter2.DefaultMapItemType = DevExpress.XtraMap.MapItemType.Dot;
            this.listSourceDataAdapter2.Mappings.Latitude = "Latitude";
            this.listSourceDataAdapter2.Mappings.Longitude = "Longitude";
            // 
            // map
            // 
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.Layers.Add(this.imageTilesLayer2);
            this.map.Layers.Add(this.vectorItemsLayer2);
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
        private DevExpress.XtraMap.ImageLayer imageTilesLayer2;
        private DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider2;
        private DevExpress.XtraMap.VectorItemsLayer vectorItemsLayer2;
        private DevExpress.XtraMap.ListSourceDataAdapter listSourceDataAdapter2;
    }
}

