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
    public class PathLengthTests
    {
        [TestMethod]
        public void PathLength1()
        {
            var data = new NetworkData();
            var lines = data.network;

            var enbankmentCircle = lines[2].GetStation("Embankment");
            // var templeCircle = lines[2].GetStation("Temple");            // 2
            // var piccBakerloo = lines[4].GetStation("Piccadilly Circus"); // 4
            var bakerCircle = lines[2].GetStation("Baker Street");       // 8

            Stopwatch stopWatch = new Stopwatch();

            WeightedLinkedList<IStation, double> path = null;

            stopWatch.Start();
            for (int i = 0; i < 16000; i++)
                path = FastestPathAlgorithm.GetFastestPath(enbankmentCircle, bakerCircle, 2.0);

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
        public void PathLength2()
        {
            var data = new NetworkData();
            var lines = data.network;

            var brixtonVictoria = lines[1].GetStation("Brixton");
            var canningTownJubilee = lines[0].GetStation("Canning Town");         // 16

            Stopwatch stopWatch = new Stopwatch();

            WeightedLinkedList<IStation, double> path = null;

            stopWatch.Start();
            for (int i = 0; i < 16000; i++)
                path = FastestPathAlgorithm.GetFastestPath(brixtonVictoria, canningTownJubilee, 2.0);

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
        public void PathLength3()
        {
            var data = new NetworkData();
            var lines = data.network;

            var brixtonVictoria = lines[0].GetStation("Stratford");
            var canningTownJubilee = lines[6].GetStation("Hammersmith");         // 16
            // var bakerCircle = lines[2].GetStation("BHomerton");       // 32
            // var bakerCircle = lines[2].GetStation("Baker Street");       // 32

            Stopwatch stopWatch = new Stopwatch();

            WeightedLinkedList<IStation, double> path = null;

            stopWatch.Start();
            for (int i = 0; i < 16000; i++)
                path = FastestPathAlgorithm.GetFastestPath(brixtonVictoria, canningTownJubilee, 0.1);

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
    }
}

