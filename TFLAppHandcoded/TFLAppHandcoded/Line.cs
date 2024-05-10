using System;
using System.Collections.Generic;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
	public class Line
	{
		private string name;
        private string color;
        private Dict<Station,WeightedLinkedList<Station,Track>> stations;

        public Line(string name, string color )

        {
			this.name = name;
			this.color = color;
            stations = new Dict<Station, WeightedLinkedList<Station, Track>>();

        }

        public void AddStation(Station station, WeightedLinkedList<Station, Track> connections)
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

        public void SetColour(string color)
        {
            this.color = color;
        }

        public Station GetStation(string name)
		{
			Station[] allStations = GetAllStations();

			foreach (Station station in allStations)
			{
				if (station.GetName() == name) 
				{
					return station;
				}
			}

			return null;
		}

		public Station[] GetAllStations()
		{
			Station[] stationKeys = stations.GetRecordKeys();

			return stationKeys;

        }

		public Track GetDistance(Station start, Station destination)
		{
			// checks if start station exists
			if (stations.CheckKeyExists(start))
			{
                // gives us the all the connections associated station start
                WeightedLinkedList<Station, Track> connectedStations = stations.FindRecordValueWithKey(start);

                // finding the weight associated with destination station
                Track stationNode = connectedStations.FindNodeWeight(destination);

                return stationNode;
            }

			return null;

            
        }

		public WeightedLinkedList<Station, Track> GetConnectedStations(Station station)
		{
			if (stations.CheckKeyExists(station))
			{
                WeightedLinkedList<Station, Track> connectedStations = stations.FindRecordValueWithKey(station);

                return connectedStations;
            }

			return null;

        }
			
		public Dict<Station, LinkedList<Station>> GetDelayedTracks()
		{
			// create empty dictionary
            Dict<Station, LinkedList<Station>> delayedTracks = new Dict<Station, LinkedList<Station>>();

			// loop through station in dictionary
			foreach (Station station in stations.GetRecordKeys())
			{

				WeightedLinkedList<Station, Track> connectedStations = stations.FindRecordValueWithKey(station);

				//creating empty list for delayed tracks 
                LinkedList < Station > delayedStations = new LinkedList<Station>();

                ////loop through each node in weighted linked list
                WeightedListNode<Station, Track> currentNode = connectedStations.GetHead();
				while(currentNode !=null)
				{
                    Track track = currentNode.GetWeight();

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

		public Dict<Station, LinkedList<Station>> GetClosedTracks()
		{
			// create empty dictionaru for closed tracks 
            Dict<Station, LinkedList<Station>> closedTracks = new Dict<Station, LinkedList<Station>>();

            // loop through station in dictionary
            foreach (Station station in stations.GetRecordKeys())
            {
				//get connected stations for the station
                WeightedLinkedList<Station, Track> connectedStations = stations.FindRecordValueWithKey(station);

                //creating empty list for closed stations
                LinkedList<Station> closedStations = new LinkedList<Station>();

				//loop through each node in weighted linked list
                WeightedListNode<Station, Track> currentNode = connectedStations.GetHead();
				
                while (currentNode != null)
                {
                    Track track = currentNode.GetWeight();

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

