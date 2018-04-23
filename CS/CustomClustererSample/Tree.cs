using System;

namespace CustomClustererSample {
    class Tree {
        string locationName;

        public Tree() {
            locationName = "";
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationName {
            get { return this.locationName; }
            set {
                if (value == null) throw new ArgumentNullException("LocationName");
                if (value.Equals(this.locationName)) return;
                this.locationName = value;
            }
        }
    }
}
