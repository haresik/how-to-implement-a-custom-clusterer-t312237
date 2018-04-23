using DevExpress.Map;
using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CustomClustererSample {
    class CureClusterer : IClusterer {
        bool isBusy;
        int clusterCount = 10;
        MapItemCollection currentItems;
        IMapDataAdapter owner;

        public CureClusterer() {
            isBusy = false;
        }

        public bool IsBusy {
            get {
                return isBusy;
            }
        }

        public MapItemCollection Items {
            get {
                return currentItems;
            }
        }

        public int ClusterCount {
            get { return clusterCount; }
            set {
                if (value < 1) throw new ArgumentOutOfRangeException("The ClusterCount should be larger than 1.");
                ClusterCount = value;
            }
        }

        public void Clusterize(IEnumerable<MapItem> sourceItems, MapViewport viewport, bool sourceChanged) {
            Thread clusteringThread = new Thread(() => {
                isBusy = true;
                if (sourceChanged) {
                    currentItems = ClusterizeImpl(sourceItems);
                    owner.OnClustered();
                }
                isBusy = false;
            });
            clusteringThread.Start();
        }

        public void SetOwner(IMapDataAdapter owner) {
            this.owner = owner;
        }

        MapItemCollection ClusterizeImpl(IEnumerable<MapItem> sourceItems) {
            // Separate localizable and non localizable items.
            List<MapItem> nonLocalizableItems = new List<MapItem>();
            List<Cluster> clusters = new List<Cluster>();
            foreach (MapItem item in sourceItems) {
                ISupportCoordLocation localizableItem = item as ISupportCoordLocation;
                if (localizableItem != null)
                    clusters.Add(Cluster.Initialize(localizableItem));
                else
                    nonLocalizableItems.Add(item);
            }

            // Arrange initial clusters in increasing order of distance to a closest cluster.
            clusters = Arrange(clusters);

            // Aggregate localizable items.
            while (clusters.Count > ClusterCount) {
                MergeCloserstClusters(ref clusters);
            }

            // Convert internal cluster helpers to Map items.
            MapItemCollection clusterRepresentatives = new MapItemCollection(owner);
            for (int i = 0; i < clusters.Count; ++i) {
                Cluster cluster = clusters[i];
                MapDot representative = new MapDot() { Location = new GeoPoint(cluster.CenterPoint.Y, cluster.CenterPoint.X), Size = 100 };
                representative.ClusteredItems = cluster.Items.Select(item => item as MapItem).ToList();
                representative.TitleOptions.Pattern = representative.ClusteredItems.Count.ToString();
                clusterRepresentatives.Add(representative);
            }
            clusterRepresentatives.AddRange(nonLocalizableItems);
            return clusterRepresentatives;
        }

        static List<Cluster> Arrange(List<Cluster> clusters) {
            List<Cluster> arrangedClusters = new List<Cluster>();
            for (int i = 0; i < clusters.Count; ++i) {
                Cluster cluster = clusters[i];
                AssignClosest(cluster, clusters);
                // Inserts depending on distance to closest.
                Insert(arrangedClusters, cluster);
            }
            return arrangedClusters;
        }

        static void AssignClosest(Cluster cluster, List<Cluster> clusters) {
            if (clusters.Count < 2) throw new ArgumentOutOfRangeException("Clusters count should be larger than 2.");
            Cluster distancableCluster = clusters[0];
            if (distancableCluster == cluster)
                distancableCluster = clusters[1];
            cluster.ClosestCluster = distancableCluster;

            for (int i = 0; i < clusters.Count; ++i) {
                distancableCluster = clusters[i];
                if (distancableCluster == cluster) continue;
                double distance = cluster.DistanceTo(distancableCluster);
                if (distance < cluster.DistanceToClosest)
                    cluster.ClosestCluster = distancableCluster;
            }
        }

        static void Insert(List<Cluster> clusters, Cluster cluster) {
            for (int i = 0; i < clusters.Count; ++i) {
                if (clusters[i].DistanceToClosest > cluster.DistanceToClosest) {
                    clusters.Insert(i, cluster);
                    return;
                }
            }
            clusters.Add(cluster);
        }

        static void MergeCloserstClusters(ref List<Cluster> clusters) {
            if (clusters.Count < 2) throw new ArgumentOutOfRangeException("Clusters count should be larger than 2.");
            Cluster cluster1 = clusters[0];
            Cluster cluster2 = cluster1.ClosestCluster;
            clusters.RemoveAt(0);
            clusters.Remove(cluster2);
            Cluster newCluster = Cluster.Merge(cluster1, cluster2);
            clusters.Add(newCluster);
            clusters = Arrange(clusters);
        }
    }

    class Cluster {
        MapPoint centerPoint;
        List<ISupportCoordLocation> items;
        Cluster closestCluster;
        double distanceToClosest;

        public Cluster(List<ISupportCoordLocation> items) {
            this.items = items;
            centerPoint = CalculateCenterPoint(items);
        }


        public static Cluster Initialize(ISupportCoordLocation item) {
            List<ISupportCoordLocation> items = new List<ISupportCoordLocation>();
            items.Add(item);
            return new Cluster(items);
        }

        public MapPoint CenterPoint { get { return this.centerPoint; } }
        public List<ISupportCoordLocation> Items { get { return this.items; } }

        public Cluster ClosestCluster {
            get { return this.closestCluster; }
            set {
                this.closestCluster = value;
                distanceToClosest = DistanceTo(closestCluster);
            }
        }

        public double DistanceToClosest { get { return distanceToClosest; } }

        public double DistanceTo(Cluster h) {
            return Math.Sqrt((h.CenterPoint.X - CenterPoint.X) * (h.CenterPoint.X - CenterPoint.X) +
                             (h.CenterPoint.Y - CenterPoint.Y) * (h.CenterPoint.Y - CenterPoint.Y));
        }

        public static Cluster Merge(Cluster cluster1, Cluster cluster2) {
            List<ISupportCoordLocation> newItems = new List<ISupportCoordLocation>(cluster1.Items);
            newItems.AddRange(cluster2.Items);

            return new Cluster(newItems);
        }

        public static MapPoint CalculateCenterPoint(List<ISupportCoordLocation> items) {
            double meanX = 0;
            double meanY = 0;
            foreach (ISupportCoordLocation item in items) {
                meanX += item.Location.GetX();
                meanY += item.Location.GetY();
            }
            meanX /= items.Count;
            meanY /= items.Count;
            return new MapPoint(meanX, meanY);
        }
    }
}
