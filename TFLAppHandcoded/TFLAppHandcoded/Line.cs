using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
	public class Line : ILine
	{
		private string name;
        private string color;
        private Dict<IStation,WeightedLinkedList<IStation,ITrack>> stations;

        public Line(string name, string color )
        {
			this.name = name;
			this.color = color;
            stations = new Dict<IStation, WeightedLinkedList<IStation, ITrack>>();

        }

        public void AddStation(IStation station, WeightedLinkedList<IStation, ITrack> connections)
		{
			stations.AddRecord(station, connections);
		}

        public string GetName()
		{
			return name;
        }

		public void SetName(string name)
		{
            this.name = name;
        }

		public string GetColor()
		{
			return color;
		}

        public void SetColor(string color)
        {
            this.color = color;
        }

        public IStation GetStation(string name)
		{
			IStation[] allStations = GetAllStations();

			foreach (IStation station in allStations)
			{
				if (station.GetName() == name) 
				{
					return station;
				}
			}

			return null;
		}

		public IStation[] GetAllStations()
		{
			IStation[] stationKeys = stations.GetRecordKeys();

			return stationKeys;

        }

		public ITrack GetDistance(IStation start, IStation destination)
		{
			// checks if start station exists
			if (stations.CheckKeyExists(start))
			{
                // gives us the all the connections associated station start
                WeightedLinkedList<IStation, ITrack> connectedStations = stations.FindRecordValueWithKey(start);

                // finding the weight associated with destination station
                ITrack stationNode = connectedStations.FindNodeWeight(destination);

                return stationNode;
            }

			return null;

            
        }

		public WeightedLinkedList<IStation, ITrack> GetConnectedStations(IStation station)
		{
			if (stations.CheckKeyExists(station))
			{
                WeightedLinkedList<IStation, ITrack> connectedStations = stations.FindRecordValueWithKey(station);

                return connectedStations;
            }

			return null;

        }
			
		public Dict<IStation, LinkedList<IStation>> GetDelayedTracks()
		{
			// create empty dictionary
            Dict<IStation, LinkedList<IStation>> delayedTracks = new Dict<IStation, LinkedList<IStation>>();

			// loop through station in dictionary
			foreach (IStation station in stations.GetRecordKeys())
			{

				WeightedLinkedList<IStation, ITrack> connectedStations = stations.FindRecordValueWithKey(station);

				//creating empty list for delayed tracks 
                LinkedList < IStation > delayedStations = new LinkedList<IStation>();

                ////loop through each node in weighted linked list
                WeightedListNode<IStation, ITrack> currentNode = connectedStations.GetHead();
				while(currentNode !=null)
				{
                    ITrack track = currentNode.GetWeight();

					if(track.GetDelay() > 0) // check if there is a delay
                    {

						delayedStations.InsertAtHead(currentNode.GetItem()); // add track to list
                    }

                    currentNode = currentNode.GetNext(); // go to next node in list 

                }

				delayedTracks.AddRecord(station, delayedStations); // add delayed stations to station in dictionary

            }

			return delayedTracks; //return to dictionary

        }

		public Dict<IStation, LinkedList<IStation>> GetClosedTracks()
		{
			// create empty dictionaru for closed tracks 
            Dict<IStation, LinkedList<IStation>> closedTracks = new Dict<IStation, LinkedList<IStation>>();

            // loop through station in dictionary
            foreach (IStation station in stations.GetRecordKeys())
            {
				//get connected stations for the station
                WeightedLinkedList<IStation, ITrack> connectedStations = stations.FindRecordValueWithKey(station);

                //creating empty list for closed stations
                LinkedList<IStation> closedStations = new LinkedList<IStation>();

				//loop through each node in weighted linked list
                WeightedListNode<IStation, ITrack> currentNode = connectedStations.GetHead();
				
                while (currentNode != null)
                {
                    ITrack track = currentNode.GetWeight();

                    if (track.GetIsOpen() == false) // check if track is closed 
                    {

                        closedStations.InsertAtHead(currentNode.GetItem()); // add track to list
                    }

                    currentNode = currentNode.GetNext(); // go to next node in list

                }

                closedTracks.AddRecord(station, closedStations); // add closed station to station in dictionary

            }

            return closedTracks; // return dictionary 

        }


    }
}

