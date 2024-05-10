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
    public class AlgorithmTests
    {
        [TestMethod]
        public void SimpleDataTest1()
        {
            var lines = TestData.GetSimpleTestData();
            var westminsterJubilee = lines[1].GetStation("Westminster");
            var westminsterCircle = lines[2].GetStation("Westminster");
            var enbankmentCircle = lines[2].GetStation("Enbankment");

            // Test
            var path = FastestPathAlgorithm.GetFastestPath(westminsterJubilee, enbankmentCircle, 2.0);
            Assert.AreEqual(path.GetLength(), 3);

            var node = path.GetHead();
            //while (node != null)
            //{
            //    Console.WriteLine($"{node.GetItem().GetName()} {node.GetItem().GetLine().GetName()} {node.GetWeight()}");
            //    node = node.GetNext();
            //}
            //node = node.GetNext();

            Assert.AreEqual(node.GetItem(), westminsterJubilee);
            Assert.AreEqual(node.GetWeight(), 0.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), westminsterCircle);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), enbankmentCircle);
            Assert.AreEqual(node.GetWeight(), 2.5);
            node = node.GetNext();

            Assert.IsNull(node);
        }

        [TestMethod]
        public void SimpleDataTest2()
        {
            var lines = TestData.GetSimpleTestData();
            var enbankmentCircle = lines[2].GetStation("Enbankment");
            var westminsterCircle = lines[2].GetStation("Westminster");
            var westminsterJubilee = lines[1].GetStation("Westminster");
            var greenParkJubilee = lines[1].GetStation("Green Park");
            var greenParkVictoria = lines[0].GetStation("Green Park");

            // Test with change 2.0
            var path = FastestPathAlgorithm.GetFastestPath(enbankmentCircle, greenParkVictoria, 2.0);
            Assert.AreEqual(path.GetLength(), 5);

            var node = path.GetHead();
            //while (node != null)
            //{
            //    Console.WriteLine($"{node.GetItem().GetName()} {node.GetLine().GetItem().GetName()} {node.GetWeight()}");
            //    node = node.GetNext();
            //}
            //node = node.GetNext();

            Assert.AreEqual(node.GetItem(), enbankmentCircle);
            Assert.AreEqual(node.GetWeight(), 0.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), westminsterCircle);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), westminsterJubilee);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), greenParkJubilee);
            Assert.AreEqual(node.GetWeight(), 3.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), greenParkVictoria);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.IsNull(node);
        }

        [TestMethod]
        public void SimpleDataTest3()
        {
            var lines = TestData.GetSimpleTestData();

            var enbankmentCircle = lines[2].GetStation("Enbankment");
            var westminsterCircle = lines[2].GetStation("Westminster");
            var stJamesCircle = lines[2].GetStation("St James Park");
            var victoriaCircle = lines[2].GetStation("Victoria");
            var victoriaVictoria = lines[0].GetStation("Victoria");
            var greenParkVictoria = lines[0].GetStation("Green Park");

            // Test with change 3.0
            var path = FastestPathAlgorithm.GetFastestPath(enbankmentCircle, greenParkVictoria, 3.0);
            Assert.AreEqual(path.GetLength(), 6);

            var node = path.GetHead();
            //while (node != null)
            //{
            //    Console.WriteLine($"{node.GetItem().GetName()} {node.GetItem().GetLine().GetName()} {node.GetWeight()}");
            //    node = node.GetNext();
            //}
            //node = node.GetNext();

            Assert.AreEqual(node.GetItem(), enbankmentCircle);
            Assert.AreEqual(node.GetWeight(), 0.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), westminsterCircle);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), stJamesCircle);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), victoriaCircle);
            Assert.AreEqual(node.GetWeight(), 1.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), victoriaVictoria);
            Assert.AreEqual(node.GetWeight(), 3.0);
            node = node.GetNext();

            Assert.AreEqual(node.GetItem(), greenParkVictoria);
            Assert.AreEqual(node.GetWeight(), 2.0);
            node = node.GetNext();

            Assert.IsNull(node);
        }

        [TestMethod]
        public void RealDataTestRandom()
        {
            var lines = TestData.GetTestData();
            Random r = new Random();
            var startLine = lines[r.Next(0, lines.Length)];
            var startStation = startLine.GetAllStations()[r.Next(0, startLine.GetAllStations().Length)];
            var endLine = lines[r.Next(0, lines.Length)];
            var endStation = endLine.GetAllStations()[r.Next(0, endLine.GetAllStations().Length)];

            var path = FastestPathAlgorithm.GetFastestPath(startStation, endStation, 2.0);
            //Assert.AreEqual(path.GetLength(), 6);

            Console.WriteLine($"Trip from {startStation.ToString()} to {endStation.ToString()}");
            var node = path.GetHead();
            while (node != null)
            {
                Console.WriteLine($"{node.GetItem().GetName()} {node.GetItem().GetName()} {node.GetWeight()}");
                node = node.GetNext();
            }
        }
    }
}

