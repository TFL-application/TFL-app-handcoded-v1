using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
	public class Network
	{
		public Network()
		{
		}

		public LinkedList<IStation>? FindShortestPath(IStation startStation, IStation destinationStation)
		{
			Dict<LinkedList<IStation>, double> unknownStations = new Dict<LinkedList<IStation>, double>();
            Dict<LinkedList<IStation>, double> knownStations = new Dict<LinkedList<IStation>, double>();
            Dict<LinkedList<IStation>, double> connectedStations = new Dict<LinkedList<IStation>, double>();

			LinkedList<IStation> startStationList = new LinkedList<IStation>();
			startStationList.insertAtHead(startStation);

			unknownStations.AddRecord(startStationList, 0);

			while (unknownStations.GetLength() > 0)
            {
                LinkedList<IStation>? selectedStationPath = null;
                double minTime = -1;

				foreach (LinkedList<IStation> stationPath in unknownStations.GetRecordKeys())
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

				IStation selectedStation = selectedStationPath.GetHeadValue();

                if (selectedStationPath.GetHeadValue() == destinationStation)
					return selectedStationPath;

				unknownStations.DeleteRecordWithKey(selectedStationPath);
				knownStations.AddRecord(selectedStationPath, minTime);

				// Find next stations in line
				ILine selectedStationLine = selectedStation.GetLine();
				IStation[] connectedStationsLine = selectedStationLine.GetConnectedStations(selectedStation);
				foreach (IStation station in connectedStationsLine)
				{
					LinkedList<IStation> connectedStationList = new LinkedList<IStation> (); // TODO 
					connectedStationList.insertAtHead(station);
                    connectedStations.AddRecord(connectedStationList,
						minTime + selectedStationLine.GetDistance(selectedStation, station).GetTravelTime());
                }

                // Find changes
            }

            return null;
		}
    }
}

