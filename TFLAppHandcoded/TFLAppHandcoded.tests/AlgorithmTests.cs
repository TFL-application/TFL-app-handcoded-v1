using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using TFLAppHandcoded.Interfaces;

namespace TFLAppHandcoded.tests
{
    [TestClass]
    [TestSubject(typeof(FastestPathAlgorithm))]
    public class AlgorithmTests
    {
        [TestMethod]
        public void BenchmarkTestSimpleData()
        {
            var lines = TestData.GetSimpleTestData();

            var enbankmentCircle = lines[2].GetStation("Enbankment");
            var greenParkVictoria = lines[0].GetStation("Green Park");

            Stopwatch stopWatch = new Stopwatch();

            WeightedLinkedList<IStation, double> path = null;

            stopWatch.Start();
            for (int i = 0; i < 640000; i++)
                path = FastestPathAlgorithm.GetFastestPath(enbankmentCircle, greenParkVictoria, 2.0);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            var node = path.GetHead();
            while (node != null)
            {
                Console.WriteLine($"{node.GetItem().GetName()} {node.GetItem().GetLine().GetName()} {node.GetWeight()}");
                node = node.GetNext();
            }

            string elapsedTime = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        [TestMethod]
        public void BenchmarkTestRealData()
        {
            var data = new NetworkData();
            var lines = data.network;

            var canadaWaterJubilee = lines[0].GetStation("Canada Water");
            var shepherdsBush = lines[5].GetStation("Shepherd's Bush");

            Stopwatch stopWatch = new Stopwatch();

            WeightedLinkedList<IStation, double> path = null;

            stopWatch.Start();
            for (int i = 0; i < 64000; i++)
                path = FastestPathAlgorithm.GetFastestPath(canadaWaterJubilee, shepherdsBush, 2.0);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            var node = path.GetHead();
            while (node != null)
            {
                Console.WriteLine($"{node.GetItem().GetName()} {node.GetItem().GetLine().GetName()} {node.GetWeight()}");
                node = node.GetNext();
            }

            string elapsedTime = String.Format("{0:00}.{1:00}", ts.Seconds, ts.Milliseconds);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        [TestMethod]
        public void RandomStationsBenchmark()
        {
            int times = 64000;
            var data = new NetworkData();
            var lines = data.network;
            Random r = new Random();


            double sum = 0.0;

            for (int i = 0; i < times; i++)
            {
                Stopwatch stopWatch = new Stopwatch();
                var startLine = lines[r.Next(0, lines.Length)];
                var startStation = startLine.GetAllStations()[r.Next(0, startLine.GetAllStations().Length)];
                var endLine = lines[r.Next(0, lines.Length)];
                var endStation = endLine.GetAllStations()[r.Next(0, endLine.GetAllStations().Length)];
                stopWatch.Start();
                var path = FastestPathAlgorithm.GetFastestPath(startStation, endStation, 2.0);
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                sum += ts.TotalMilliseconds; // Corrected the calculation of elapsed time
            }

            //var node = path.GetHead();
            //while (node != null)
            //{
            //    Console.WriteLine($"{node.GetItem().GetName()} {node.GetItem().GetLine().GetName()} {node.GetWeight()}");
            //    node = node.GetNext();
            //}

            sum = sum / times; // Calculate average time
            string formattedAverageTime = $"{sum:00.000}s";
            Console.WriteLine("Average Runtime: " + formattedAverageTime);
        }

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

