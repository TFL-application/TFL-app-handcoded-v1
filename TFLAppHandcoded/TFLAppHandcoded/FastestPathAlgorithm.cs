using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
	public static class FastestPathAlgorithm
    {
        // Inner class used for algorithm
        private class AlgorithmNode 
        {
            public IStation node { get; set; }
            public double   cost { get; set; }
            public WeightedLinkedList<IStation, double> nodePath { get; set; }

            public AlgorithmNode(IStation node, double cost, WeightedLinkedList<IStation, double>? nodePath)
            {
                this.node       = node;
                this.cost       = cost;
                this.nodePath   = nodePath;
            }
        }

        // A public method that uses the private class used for unit test
        //public static AlgorithmNode AddAlgorithmNode(IStation node, double cost, WeightedLinkedList<IStation, double>? nodePath)
        //{
        //    return new AlgorithmNode(node, cost, nodePath);
        //}

        // Main method
        public static WeightedLinkedList<IStation, double>? GetFastestPath(IStation start, IStation destination, double changeLineTime)
        {
            // 0. Set up structures for the algorithm
            var unknownVertices = new Dict<IStation, AlgorithmNode>();
            var knownVertices   = new Dict<IStation, AlgorithmNode>();

            // 1. Put start node to unknown vertices
            // Set start node cost = 0 and node path = the node itself
            unknownVertices = AddNewNode(start, 0.0 , new WeightedLinkedList<IStation, double>(), unknownVertices);

            while (unknownVertices.GetLength() > 0)                         // Start the cycle over unknown vertices
            {
                var selectedVertex = FindSmallestCostNode(unknownVertices); // 2. Find the station in unknown stations with the smallest cost
                var selectedVertexItem = selectedVertex.node;               // 3. Check if the found station = destination

                if (selectedVertexItem.Equals(destination))
                {
                    selectedVertex.nodePath.ReverseList();
                    return selectedVertex.nodePath;                         // >> IF YES - EXIT from the algorithm
                }

                // 4. Move it from unknown stations to known stations
                unknownVertices.DeleteRecordWithKey(selectedVertexItem);
                knownVertices.AddRecord(selectedVertexItem, selectedVertex);

                // 5. Find to which vertices the selected station is connected
                var connectedVertices = FindConnectedNodes(selectedVertexItem, changeLineTime);

                if (connectedVertices.GetLength() > 0)
                {
                    var selectedConnectedVertex = connectedVertices.GetHead();
                    while (selectedConnectedVertex != null)
                    {
                        var selectedConnectedVertexItem = selectedConnectedVertex.GetItem();
                        var isKnown = knownVertices.FindRecordValueWithKey(selectedConnectedVertexItem);

                        if (isKnown == null)
                        {
                            // 9.Check if it is in unknown stations
                            // 10. Check if its cost in connected vertices < the cost
                            // of the in the unknown stations
                            var isUnknown = unknownVertices.FindRecordValueWithKey(selectedConnectedVertexItem);
                            var selectedConnectedVertexCost = selectedConnectedVertex.GetWeight() + selectedVertex.cost;

                            if (isUnknown == null || selectedConnectedVertexCost < isUnknown.cost)
                            {
                                if (isUnknown != null)
                                    unknownVertices.DeleteRecordWithKey(selectedConnectedVertexItem);

                                unknownVertices = AddNewNode(selectedConnectedVertexItem,
                                    selectedConnectedVertex.GetWeight(), selectedVertex.nodePath, unknownVertices);
                            }
                        }

                        selectedConnectedVertex = selectedConnectedVertex.GetNext();
                    }
                }
            }

            return null;
        }

        private static AlgorithmNode FindSmallestCostNode(Dict<IStation, AlgorithmNode> nodeDict)
        {
            var minCost = 1000000;
            var minPath = 1000000;
            AlgorithmNode smallestCostNode = null;

            foreach (var node in nodeDict.GetRecordKeys())
            {
                var nodeInfo = nodeDict.FindRecordValueWithKey(node);

                if (nodeInfo.cost < minCost || nodeInfo.cost == minCost && nodeInfo.nodePath.GetLength() < minPath)
                    smallestCostNode = nodeInfo;
            }

            return smallestCostNode;
        }

        private static Dict<IStation, AlgorithmNode> AddNewNode(IStation node, double weight,
            WeightedLinkedList<IStation, double> previousNodePath, Dict<IStation, AlgorithmNode> nodeDict)
        {
            var connectedStationList = new WeightedLinkedList<IStation, double> (node, weight);
            connectedStationList.GetHead().SetNext(previousNodePath.GetHead());

            var nodeInfo = new AlgorithmNode(node, weight, connectedStationList);

            // Put it to unknown stations
            nodeDict.AddRecord(node, nodeInfo);

            return nodeDict;
        }

        private static WeightedLinkedList<IStation, double> FindConnectedNodes(IStation station, double changeLineTime)
        {
            var line = station.GetLine();
            var connectedStationsOnTheLine = line.GetConnectedStations(station);
            var connectedNodes = new WeightedLinkedList<IStation, double>();

            var onTheLine = connectedStationsOnTheLine.GetHead();
            while (onTheLine != null)
            {
                if (onTheLine.GetWeight().GetIsOpen())
                    connectedNodes.InsertAtHead(onTheLine.GetItem(), onTheLine.GetWeight().GetTravelTime());

                onTheLine = onTheLine.GetNext();
            }

            var otherLines = station.GetConnections();
            foreach (var connection in otherLines)
                connectedNodes.InsertAtHead(connection, changeLineTime);

            return connectedNodes;
        }
    }
}