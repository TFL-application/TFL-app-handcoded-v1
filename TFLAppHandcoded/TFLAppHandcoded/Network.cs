using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{

    public class Network : INetwork
    {
        private double changeLineTime = 2.0;
        private ILine[] lines;

        public Network()
        {
            NetworkData data = new NetworkData();
            lines = (data.network);
        }

        //return type void is added because it might be required for the menu to display line
        public string[] GetLines()
        {
            var lineArray = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                lineArray[i] = lines[i].GetName();
            }
            return lineArray;
        }

        public IStation GetStation(string stationname)
        {
            try
            {
                foreach (ILine line in lines)
                {
                    foreach (IStation station in line.GetAllStations())
                    {
                        if (station.GetName() == stationname)
                        {
                            return station;
                        }
                    }
                }

                throw new ArgumentException($"Station name : {stationname} does not falls on the line");
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }

            return null;
        }

        public IStation GetStation(string stationname, string linename)
        {
            try
            {
                foreach (ILine line in lines)
                {
                    if (line.GetName() == linename)
                    {
                        return line.GetStation(stationname);
                    }
                }

                throw new ArgumentException($"Station name : {stationname} does not falls on the line");
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }

            return null;
        }


        public string[] GetAllStations(string linename)
        {
            try
            {
                foreach (ILine line in lines)
                {
                    if (line.GetName() == linename)
                    {
                        var stations = line.GetAllStations();
                        var stationArray = new string[stations.Length];
                        for (int i = 0; i < stations.Length; i++)
                        {
                            Console.WriteLine(stations[i].GetName());
                            stationArray[i] = stations[i].GetName();
                        }
                        return stationArray;
                    }
                }
                throw new ArgumentException($"Line name {linename} not Found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }
            return null;
        }

        //I have added Line attirbute:
        public void AddTimeDelay(string line, string stationFrom, string stationTo, double time, bool bothDirections)
        {
            try
            {
                foreach (ILine l in this.lines)
                {
                    // CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                    // Implementing checks to find if the stationTo exists as a record in Adjlist in
                    // Line Class and stationFrom exists as a value in connected station
                    if (l.GetName() == line)
                    {
                        IStation stationFromObject = l.GetStation(stationFrom);
                        WeightedLinkedList<IStation, ITrack> connectedFrom = l.GetConnectedStations(stationFromObject);

                        IStation stationToObject = l.GetStation(stationTo);
                        ITrack trackTo = connectedFrom.FindNodeWeight(stationToObject);

                        if (trackTo != null)
                        {
                            trackTo.SetDelay(time);
                        }
                        if (bothDirections)
                        {
                            WeightedLinkedList<IStation, ITrack> connectedTo = l.GetConnectedStations(stationToObject);
                            ITrack trackFrom = connectedTo.FindNodeWeight(stationFromObject);

                            if (trackFrom != null)
                            {
                                trackFrom.SetDelay(time);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }
        }

        //Boothdirection Attribute is added to this method as well as Delay could or could not be in both directions
        public void DeleteTimeDelay(string line, string stationFrom, string stationTo, bool bothDirections)
        {
            try
            {
                foreach (ILine l in lines)
                {
                    //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                    //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                    if (l.GetName() == line)
                    {
                        IStation stationFromObject = l.GetStation(stationFrom);
                        WeightedLinkedList<IStation, ITrack> connectedFrom = l.GetConnectedStations(stationFromObject);

                        IStation stationToObject = l.GetStation(stationTo);
                        ITrack trackTo = connectedFrom.FindNodeWeight(stationToObject);

                        if (trackTo != null)
                        {
                            trackTo.SetDelay(0.0);
                        }
                        if (bothDirections)
                        {
                            WeightedLinkedList<IStation, ITrack> connectedTo = l.GetConnectedStations(stationToObject);
                            ITrack trackFrom = connectedTo.FindNodeWeight(stationFromObject);

                            if (trackFrom != null)
                            {
                                trackFrom.SetDelay(0.0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }
        }


        //Removed time and bothdirection attribute 
        public void CloseTrack(string line, string stationFrom, string stationTo, bool bothDirections)
        {
            try
            {
                foreach (ILine l in this.lines)
                {
                    if (l.GetName() == line)
                    {
                        IStation stationFromObject = l.GetStation(stationFrom);
                        WeightedLinkedList<IStation, ITrack> connectedFrom = l.GetConnectedStations(stationFromObject);

                        IStation stationToObject = l.GetStation(stationTo);
                        ITrack trackTo = connectedFrom.FindNodeWeight(stationToObject);

                        if (trackTo != null)
                        {
                            trackTo.SetIsOpen(false);
                        }
                        if (bothDirections)
                        {
                            WeightedLinkedList<IStation, ITrack> connectedTo = l.GetConnectedStations(stationToObject);
                            ITrack trackFrom = connectedTo.FindNodeWeight(stationFromObject);

                            if (trackFrom != null)
                            {
                                trackFrom.SetIsOpen(false);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }
        }




        public void OpenTrack(string line, string stationFrom, string stationTo, bool bothDirections)
        {
            try
            {
                foreach (ILine l in lines)
                {
                    if (l.GetName() == line)
                    {
                        IStation stationFromObject = l.GetStation(stationFrom);
                        WeightedLinkedList<IStation, ITrack> connectedFrom = l.GetConnectedStations(stationFromObject);

                        IStation stationToObject = l.GetStation(stationTo);
                        ITrack trackTo = connectedFrom.FindNodeWeight(stationToObject);

                        if (trackTo != null)
                        {
                            trackTo.SetIsOpen(true);
                        }
                        if (bothDirections)
                        {
                            WeightedLinkedList<IStation, ITrack> connectedTo = l.GetConnectedStations(stationToObject);
                            ITrack trackFrom = connectedTo.FindNodeWeight(stationFromObject);

                            if (trackFrom != null)
                            {
                                trackFrom.SetIsOpen(true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }
        }


        public WeightedLinkedList<IStation, double>? FindShortestPath(string stationFrom, string lineFrom, string stationTo, string lineTo)
        {
            IStation start = this.GetStation(stationFrom, lineFrom);
            IStation destination = this.GetStation(stationTo, lineTo);
            return FastestPathAlgorithm.GetFastestPath(start, destination, changeLineTime);
        }
    }
}
