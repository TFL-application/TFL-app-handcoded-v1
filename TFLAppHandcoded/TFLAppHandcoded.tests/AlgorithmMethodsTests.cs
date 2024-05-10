using System;
using System.Xml.Linq;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TFLAppHandcoded.Interfaces;

namespace TFLAppHandcoded.tests
{

    [TestClass]
    [TestSubject(typeof(FastestPathAlgorithm))]
    public class AlgorithmMethodsTests
    {

        [TestMethod]
        public void AlgorithNodeDeclarationtTest()
        {
            var node = new Station("Station", null);
            var cost = 2.0;
            WeightedLinkedList<IStation, double> nodePath = null;
            Assert.IsTrue(FastestPathAlgorithm.TestAlgorithmNode(node, cost, nodePath));
        }

        [TestMethod]
        public void FindSmallestCostNodeTest()
        {
            for (int times = 0; times < 10; times++)
            {
                var length = 10;

                Random r = new Random();

                var nodes = new IStation[length];
                var cost = new double[length];
                var nodePath = new WeightedLinkedList<IStation, double>[length];

                for (int i = 0; i < length; i++)
                {
                    nodes[i] = new Station("Station", null);
                    cost[i] = Math.Round(r.NextDouble() * 100, 2);
                    nodePath[i] = new WeightedLinkedList<IStation, double>();
                }

                var min = cost.Min();
                var result = FastestPathAlgorithm.TestFindSmallestCostNode(nodes, cost, nodePath);

                Assert.AreEqual(min, result);
            }

        }

        [TestMethod]
        public void AddNewNodeTest()
        {
            var node = new Station("Station", null);
            var weight = 20.2;
            var previousNode = new WeightedLinkedList<IStation, double>(node, weight);

            var result = FastestPathAlgorithm.TestAddNewNode(node, weight, previousNode);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FindConnectedNodesTest()
        {
            // 1. Create a line
            var victoriaLine = new Line("Victoria", "blue");
            // 2. Create stations
            var greenPark1 = new Station("Green Park", new IStation[0]);
            var victoria = new Station("Victoria", new IStation[0]);
            // 3. Set station's line
            greenPark1.SetLine(victoriaLine);
            victoria.SetLine(victoriaLine);
            // 4. Create tracks betweeen stations both ways
            var victoriaGPTrack = new Track(2.0);
            var GPCictoriaTrack = new Track(2.0);
            // 5. Create adjacency lists for the stations
            var victoriaAdj = new WeightedLinkedList<IStation, ITrack>(greenPark1, victoriaGPTrack);
            var gpAdj = new WeightedLinkedList<IStation, ITrack>(victoria, GPCictoriaTrack);
            // 6. Add station to the line
            victoriaLine.AddStation(victoria, victoriaAdj);
            victoriaLine.AddStation(greenPark1, gpAdj);
            // 7. Add connections
            // None for the first line

            // 1. Create a line
            var jubileeLine = new Line("Jubilee", "gray");
            // 2. Create stations
            var greenPark2 = new Station("Green Park", new IStation[0]);
            var westminster = new Station("Westminster", new IStation[0]);
            var waterloo = new Station("Waterloo", new IStation[0]);
            // 3. Set station's line
            greenPark2.SetLine(jubileeLine);
            westminster.SetLine(jubileeLine);
            waterloo.SetLine(jubileeLine);
            // 4. Create tracks betweeen stations both ways
            var GPWestminsterTrack = new Track(3.0);
            var westminsterGPTrack = new Track(3.0);
            var westminsterWaterlooTrack = new Track(3.0);
            var waterlooWestminsterTrack = new Track(3.0);
            // 5. Create adjacency lists for the stations
            var gp2Adj = new WeightedLinkedList<IStation, ITrack>(westminster, GPWestminsterTrack);
            var westminsterAdj = new WeightedLinkedList<IStation, ITrack>(greenPark2, westminsterGPTrack);
            westminsterAdj.InsertAtHead(waterloo, westminsterWaterlooTrack);
            var waterlooAdj = new WeightedLinkedList<IStation, ITrack>(westminster, waterlooWestminsterTrack);
            // 6. Add station to the line
            jubileeLine.AddStation(greenPark2, gp2Adj);
            jubileeLine.AddStation(westminster, westminsterAdj);
            jubileeLine.AddStation(waterloo, waterlooAdj);
            // 7. Add connections - in pairs
            greenPark2.AddChange(greenPark1);
            greenPark1.AddChange(greenPark2);

            // 1. Create a line
            var circle = new Line("Circle", "yellow");
            // 2. Create stations
            var victoria2 = new Station("Victoria", new IStation[0]);
            var stjames = new Station("St James Park", new IStation[0]);
            var westminster2 = new Station("Westminster", new IStation[0]);
            var enbankment = new Station("Enbankment", new IStation[0]);
            // 3. Set station's line
            victoria2.SetLine(circle);
            stjames.SetLine(circle);
            westminster2.SetLine(circle);
            enbankment.SetLine(circle);
            // 4. Create tracks betweeen stations both ways
            var victoriaStJamesTrack = new Track(1.0);
            var stJamesVictoriaTrack = new Track(1.0);
            var stJamesWestminsterTrack = new Track(2.0);
            var westminsterStJamesTrack = new Track(2.0);
            var westminsterEnbankmentTrack = new Track(2.0);
            var enbankmentWestminsterTrack = new Track(2.5);
            // 5. Create adjacency lists for the stations
            var victoria2Adj = new WeightedLinkedList<IStation, ITrack>(stjames, victoriaStJamesTrack);
            var stJamesAdj = new WeightedLinkedList<IStation, ITrack>(victoria2, stJamesVictoriaTrack);
            stJamesAdj.InsertAtHead(westminster2, stJamesWestminsterTrack);
            var westminster2Adj = new WeightedLinkedList<IStation, ITrack>(stjames, westminsterStJamesTrack);
            westminster2Adj.InsertAtHead(enbankment, westminsterEnbankmentTrack);
            var enbankmentAdj = new WeightedLinkedList<IStation, ITrack>(westminster2, enbankmentWestminsterTrack);
            // 6. Add station to the line
            circle.AddStation(victoria2, victoria2Adj);
            circle.AddStation(stjames, stJamesAdj);
            circle.AddStation(westminster2, westminster2Adj);
            circle.AddStation(enbankment, enbankmentAdj);
            // 7. Add connections
            westminster2.AddChange(westminster);
            westminster.AddChange(westminster2);
            victoria2.AddChange(victoria);
            victoria.AddChange(victoria2);

            // Test 1
            var connections = FastestPathAlgorithm.TestFindConnectedNodes(greenPark1);
            Assert.IsTrue(connections.GetLength() == 2);

            var connectedStaton = connections.GetHead();
            while (connectedStaton != null)
            {
                Assert.IsTrue(connectedStaton.GetItem().GetName() == victoria.GetName()
                    || connectedStaton.GetItem().GetName() == greenPark2.GetName());
                Assert.IsTrue(connectedStaton.GetItem().GetLine().Equals(victoria.GetLine())
                    || connectedStaton.GetItem().GetLine().Equals(greenPark2.GetLine()));
                Assert.IsTrue(connectedStaton.GetItem().Equals(victoria) 
                    || connectedStaton.GetItem().Equals(greenPark2));
                connectedStaton = connectedStaton.GetNext();
            }

            // Test 2
            var connections2 = FastestPathAlgorithm.TestFindConnectedNodes(enbankment);
            Assert.IsTrue(connections2.GetLength() == 1);

            var connectedStaton2 = connections2.GetHead();
            Assert.IsTrue(connectedStaton2.GetItem().Equals(westminster2) && connectedStaton2.GetWeight() == 2.5);

            // Test 3
            var connections3 = FastestPathAlgorithm.TestFindConnectedNodes(westminster);
            Assert.IsTrue(connections3.GetLength() == 3);

            var connectedStaton3 = connections3.GetHead();
            while (connectedStaton3 != null)
            {
                Assert.IsTrue
                (
                    connectedStaton3.GetItem().Equals(greenPark2) && connectedStaton3.GetWeight() == 3.0 ||
                    connectedStaton3.GetItem().Equals(waterloo) && connectedStaton3.GetWeight() == 3.0 ||
                    connectedStaton3.GetItem().Equals(westminster2) && connectedStaton3.GetWeight() == 2.0
                );
                connectedStaton3 = connectedStaton3.GetNext();
            }
        }
    }
}

