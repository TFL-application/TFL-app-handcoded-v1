﻿using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace TFLAppHandcoded
{
	public class Network
	{
        private double changeLineTime = 2.0;

		public Network()
		{
		}

		public WeightedLinkedList<IStation, double>?
			FindShortestPath(IStation startStation, IStation destinationStation)
		{
			// 0. Set up structures for the algorithms
			Dict<WeightedLinkedList<IStation, double>, double> unknownStations
				= new Dict<WeightedLinkedList<IStation, double>, double>();

            Dict<WeightedLinkedList<IStation, double>, double> knownStations
				= new Dict<WeightedLinkedList<IStation, double>, double>();

            Dict<WeightedLinkedList<IStation, double>, double> connectedStations
				= new Dict<WeightedLinkedList<IStation, double>, double>();

            // 1. Put start station to unknown stations
            // Set start station node cost = 0 and previous nodes list = empty list
            WeightedLinkedList<IStation, double> startStationList
				= new WeightedLinkedList<IStation, double>();
            startStationList.InsertAtHead(startStation, 0.0);
			unknownStations.AddRecord(startStationList, 0);

			// Start the cycle over unknown stations
			while (unknownStations.GetLength() > 0)
            {
                // 2. Find the station in unknown stations with the smallest cost
                WeightedLinkedList<IStation, double>? selectedStationPath = null;
                double minTime = -1;

				foreach (WeightedLinkedList<IStation, double> stationPath
					in unknownStations.GetRecordKeys())
				{
					double stationPathTime = unknownStations.FindRecordValueWithKey(stationPath);

                    if (stationPathTime > minTime)
					{
                        selectedStationPath = stationPath;
						minTime = stationPathTime;
                    }
					else if (stationPathTime == minTime
						&& selectedStationPath is not null
						&& stationPath.GetLength() < selectedStationPath.GetLength())
					{
                        selectedStationPath = stationPath;
                        minTime = stationPathTime;
					}
				}

                // 3. Check if the found station = destination
                IStation selectedStation = selectedStationPath.GetHead().GetItem();

                if (selectedStation == destinationStation)
					return selectedStationPath;             // >> EXIT from the algorithm

                // 4. Move it from unknown stations to known stations
                unknownStations.DeleteRecordWithKey(selectedStationPath);
				knownStations.AddRecord(selectedStationPath, minTime);

                // 5. Find to which vertices the selected station is connected
                // Set their costs = cost of selected station + distances between them
                // and put them in connected vertices

                // 5.1. Find next stations in line
                ILine selectedStationLine = selectedStation.GetLine();
                WeightedLinkedList<IStation, ITrack> connectedStationsOnTheLine
					= selectedStationLine.GetConnectedStations(selectedStation);

                // Start the cycle over connected stations
				WeightedListNode<IStation, ITrack>? selectedConnectedStationOnTheLine
					= connectedStationsOnTheLine.GetHead();

                while (selectedConnectedStationOnTheLine != null)
				{
                    if (selectedConnectedStationOnTheLine.GetWeight().GetIsOpen())
					{
                        IStation selectedConnectedStation = selectedConnectedStationOnTheLine.GetItem();
                        double selectedConnectedStationTime = selectedConnectedStationOnTheLine.GetWeight().GetTravelTime();

                        WeightedLinkedList<IStation, double> connectedStationList
                            = new WeightedLinkedList<IStation, double>();

                        connectedStationList.InsertAtHead(selectedConnectedStation, selectedConnectedStationTime);
                        connectedStationList.GetHead().SetNext(selectedStationPath.GetHead());
                        connectedStations.AddRecord(connectedStationList, minTime + selectedConnectedStationTime);
                    }

                    selectedConnectedStationOnTheLine = selectedConnectedStationOnTheLine.GetNext();
                }

                // 5.b. Find changes
                IStation[] connectedStationsOtherLines = selectedStation.GetConnections();
                foreach (IStation station in connectedStationsOtherLines)
                {
                    WeightedLinkedList<IStation, double> connectedStationList
                            = new WeightedLinkedList<IStation, double>();

                    connectedStationList.InsertAtHead(station, this.changeLineTime);
                    connectedStationList.GetHead().SetNext(selectedStationPath.GetHead());

                    connectedStations.AddRecord(connectedStationList, minTime + this.changeLineTime);
                }

                ////
                if (connectedStations.GetLength() > 0)
                {
                    foreach (WeightedLinkedList<IStation, double> path in connectedStations.GetRecordKeys())
                    {

                    }
                }
            }

            return null;
		}
    }
}

