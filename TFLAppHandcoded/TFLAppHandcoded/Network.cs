using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
	public class Network
	{
        private double changeLineTime = 2.0;

		public Network()
		{
		}

        public WeightedLinkedList<IStation, double>? FindShortestPath(IStation startStation, IStation destinationStation)
		{
            return FastestPathAlgorithm.GetFastestPath(startStation, destinationStation, changeLineTime);
		}
    }
}

