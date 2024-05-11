using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
    // This class provides a static method to find the
    // fastest path between two stations
    public static class FastestPathAlgorithm
    {
        // Inner class representing a node used for algorithm
        private class AlgorithmNode 
        {
            public IStation node { get; set; }          // The station associated with this node
            public double   cost { get; set; }          // The cost accumulated to reach this node
            public WeightedLinkedList<IStation, double> nodePath { get; set; }  // The path from the starting station to this node

            // Constructor to initialize the AlgorithmNode
            public AlgorithmNode(IStation node, double cost, WeightedLinkedList<IStation, double>? nodePath)
            {
                this.node       = node;
                this.cost       = cost;
                this.nodePath   = nodePath;
            }

            // Method used for testing
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

            // 1. Put start node to unknown stations
            // 2. Set start node cost = 0 and node path = the node itself
            unknownVertices = AddNewNode(start, 0.0 ,
                new AlgorithmNode(start, 0.0, new WeightedLinkedList<IStation, double>()), unknownVertices);

            // 3. Check if there stations in unknown stations
            while (unknownVertices.GetLength() > 0)                         // Start the cycle over unknown vertices
            {
                // 4.Find the station in unknown stations with the smallest cost
                var selectedVertex = FindSmallestCostNode(unknownVertices); 
                var selectedVertexItem = selectedVertex.node;

                // 5. Check if the found station = destination
                if (selectedVertexItem.Equals(destination))
                {
                    selectedVertex.nodePath.ReverseList();
                    return selectedVertex.nodePath;                         // >> IF YES - EXIT from the algorithm
                }

                // 6. Move it from unknown stations to known stations
                unknownVertices.DeleteRecordWithKey(selectedVertexItem);
                knownVertices.AddRecord(selectedVertexItem, selectedVertex);

                // 7. Find to which stations it is connected and put them in connected stations
                var connectedVertices = FindConnectedNodes(selectedVertexItem, changeLineTime);

                // 8. Select the first station in connected stations
                var connectedVertexListNode = connectedVertices.GetHead();

                // 9. Check if the selected connected station != null
                while (connectedVertexListNode != null)                 // Start the cycle over connected stations
                {
                    var connectedVertexItem = connectedVertexListNode.GetItem();

                    // 10.Check if it is in known stations
                    var isKnown = knownVertices.FindRecordValueWithKey(connectedVertexItem);
                    if (isKnown == null)
                    {
                        // 11.Check if it is in unknown stations
                        var isUnknown = unknownVertices.FindRecordValueWithKey(connectedVertexItem);
                        var selectedConnectedVertexCost
                            = connectedVertexListNode.GetWeight() + selectedVertex.cost;

                        // 12. If it is in unknown - check if its cost
                        // + selected station cost < the cost of the in the unknown stations
                        if (isUnknown == null || selectedConnectedVertexCost < isUnknown.cost)
                        {
                            // 13.Delete old record from unknown stations if it was in unknown
                            if (isUnknown != null)
                                unknownVertices.DeleteRecordWithKey(connectedVertexItem);

                            unknownVertices = AddNewNode(connectedVertexItem,
                                connectedVertexListNode.GetWeight(),
                                selectedVertex, unknownVertices);
                        }
                    }

                    // 18. Select the next station in connected stations
                    connectedVertexListNode = connectedVertexListNode.GetNext();
                }
            }

            return null;
        }

        // Method to find the node with the smallest cost in the dictionary
        private static AlgorithmNode FindSmallestCostNode(Dict<IStation, AlgorithmNode> nodeDict)
        {
            var minCost = 1000000.0;
            var minPath = 1000000;
            AlgorithmNode smallestCostNode = null;

            foreach (var node in nodeDict.GetRecordKeys())
            {
                var nodeInfo = nodeDict.FindRecordValueWithKey(node);

                // 4a. If more than one - choose the one with the shortest previous nodes list
                if (nodeInfo.cost < minCost || (nodeInfo.cost == minCost && nodeInfo.nodePath.GetLength() < minPath))
                {
                    minCost = nodeInfo.cost;
                    minPath = nodeInfo.nodePath.GetLength();
                    smallestCostNode = nodeInfo;
                }
            }

            return smallestCostNode;
        }

        // Method to add a new node to the dictionary of nodes
        private static Dict<IStation, AlgorithmNode> AddNewNode(IStation node, double weight,
            AlgorithmNode previousNode, Dict<IStation, AlgorithmNode> nodeDict)
        {
            // 15. Create path list for the connected station,
            // starting with the connected node, and add the selected node path to it
            var connectedStationList = new WeightedLinkedList<IStation, double> (node, weight);
            var currentNode = previousNode.nodePath.GetHead();
            while (currentNode != null)
            {
                var currentNodeWeight = currentNode.GetWeight();
                connectedStationList.InsertAtHead(currentNode.GetItem(), currentNodeWeight);
                currentNode = currentNode.GetNext();
            }
            connectedStationList.ReverseList();

            // 16. Set connected station cost = track travel time
            // + cost of the selected station
            var nodeInfo = new AlgorithmNode(node, previousNode.cost + weight, connectedStationList);

            // 17. Put connected station to unknown stations
            nodeDict.AddRecord(node, nodeInfo);

            return nodeDict;
        }

        // Method to find the connected nodes to a given station
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

        // TEST METHODS
        // Below are public methods that uses the private class and methods used for unit tests
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