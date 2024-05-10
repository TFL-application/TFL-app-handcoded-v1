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

            public override string ToString()
            {
                return $"\t{this.node.ToString()},\t{this.cost},\t{this.nodePath.ToString()}";
            }
        }

        // Main method
        public static WeightedLinkedList<IStation, double>? GetFastestPath(IStation start, IStation destination, double changeLineTime)
        {
            // 0. Set up structures for the algorithm
            var unknownVertices = new Dict<IStation, AlgorithmNode>();
            var knownVertices   = new Dict<IStation, AlgorithmNode>();

            // 1. Put start node to unknown vertices
            // Set start node cost = 0 and node path = the node itself
            unknownVertices = AddNewNode(start, 0.0 ,
                new AlgorithmNode(start, 0.0, new WeightedLinkedList<IStation, double>()), unknownVertices);


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
                            var selectedConnectedVertexCost
                                = selectedConnectedVertex.GetWeight() + selectedVertex.cost;

                            if (isUnknown == null || selectedConnectedVertexCost < isUnknown.cost)
                            {
                                if (isUnknown != null)
                                    unknownVertices.DeleteRecordWithKey(selectedConnectedVertexItem);

                                unknownVertices = AddNewNode(selectedConnectedVertexItem,
                                    selectedConnectedVertex.GetWeight(),
                                    selectedVertex, unknownVertices);
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
            var minCost = 1000000.0;
            var minPath = 1000000;
            AlgorithmNode smallestCostNode = null;

            foreach (var node in nodeDict.GetRecordKeys())
            {
                var nodeInfo = nodeDict.FindRecordValueWithKey(node);

                if (nodeInfo.cost < minCost || (nodeInfo.cost == minCost && nodeInfo.nodePath.GetLength() < minPath))
                {
                    minCost = nodeInfo.cost;
                    minPath = nodeInfo.nodePath.GetLength();
                    smallestCostNode = nodeInfo;
                }
            }

            return smallestCostNode;
        }


        private static Dict<IStation, AlgorithmNode> AddNewNode(IStation node, double weight,
            AlgorithmNode previousNode, Dict<IStation, AlgorithmNode> nodeDict)
        {
            
            var connectedStationList = new WeightedLinkedList<IStation, double> (node, weight);
            var currentNode = previousNode.nodePath.GetHead();

            while (currentNode != null)
            {
                var currentNodeWeight = currentNode.GetWeight();
                connectedStationList.InsertAtHead(currentNode.GetItem(), currentNodeWeight);
                currentNode = currentNode.GetNext();
            }

            connectedStationList.ReverseList();

            var nodeInfo = new AlgorithmNode(node, previousNode.cost + weight, connectedStationList);

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

        // A public methods that uses the private class and methods used for unit test
        public static bool TestAlgorithmNode(IStation node, double cost, WeightedLinkedList<IStation, double>? nodePath)
        {
            AlgorithmNode newNode = new AlgorithmNode(node, cost, nodePath);
            if (newNode.node == node && newNode.cost == cost && newNode.nodePath == nodePath)
                return true;
            else
                return false;
        }


        public static double? TestFindSmallestCostNode(IStation[] nodes, double[] cost, WeightedLinkedList<IStation, double>[]? nodePath)
        {
            if (nodes.Length != cost.Length || cost.Length != nodePath.Length || nodePath.Length != nodes.Length)
                return null;

            var newDict = new Dict<IStation, AlgorithmNode>();
            for (int i = 0; i < nodes.Length; i++)
                newDict.AddRecord(nodes[i], new AlgorithmNode(nodes[i], cost[i], nodePath[i]));

            var foundValue = FindSmallestCostNode(newDict);
            return foundValue.cost;
        }


        public static bool TestAddNewNode(IStation node, double weight, WeightedLinkedList<IStation, double> previousNodePath)
        {
            var dict = new Dict<IStation, AlgorithmNode>();
            Random r = new Random();

            var length1 = r.Next(10);
            for (int i = 0; i < length1; i++)
            {
                var station = new Station($"Station {i}", null);
                double cost = i;
                var list = new WeightedLinkedList<IStation, double>(station, cost);
                dict.AddRecord(station, new AlgorithmNode(station, cost, list));
            }

            dict = AddNewNode(node, weight, new AlgorithmNode(node, 0.0, previousNodePath), dict);

            var length2 = r.Next(10);
            for (int i = 0; i < length2; i++)
            {
                var station = new Station($"Station {i}", null);
                double cost = i;
                var list = new WeightedLinkedList<IStation, double>(station, cost);
                dict.AddRecord(station, new AlgorithmNode(station, cost, list));
            }

            foreach (IStation station in dict.GetRecordKeys())
            {
                var value = dict.FindRecordValueWithKey(station);

                if (station.GetName() == node.GetName() && value.node.Equals(node)
                    && value.cost == weight && value.nodePath.GetLength() == previousNodePath.GetLength() + 1)
                    return true;
            }

            return false;
        }


        public static WeightedLinkedList<IStation, double> TestFindConnectedNodes(IStation station)
        {
            return FindConnectedNodes(station, 2.0);
        }
    }
}