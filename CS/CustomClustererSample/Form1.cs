using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CustomClustererSample {
    public partial class Form1 : Form {
        VectorItemsLayer VectorLayer { get { return (VectorItemsLayer)map.Layers["VectorLayer"]; } }
        ListSourceDataAdapter DataAdapter { get { return (ListSourceDataAdapter)VectorLayer.Data; } }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            VectorLayer.DataLoaded += (obj, args) => { map.ZoomToFitLayerItems(); };

            DataAdapter.DataSource = LoadData();
            DataAdapter.Clusterer = new CureClusterer();
        }

        List<Tree> LoadData() {
            List<Tree> trees = new List<Tree>();
            XDocument doc = XDocument.Load("Data\\treesCl.xml");
            foreach (XElement xTree in doc.Element("RowSet").Elements("Row"))
                trees.Add(new Tree {
                    Latitude = Convert.ToDouble(xTree.Element("lat").Value),
                    Longitude = Convert.ToDouble(xTree.Element("lon").Value),
                    LocationName = xTree.Element("location").Value
                });
            return trees;
        }
    }
}
