using System;

namespace TFLAppHandcoded.Interfaces
{
	public interface INetwork
    {
        void GetLines();
        IStation GetStation(string stationname);
        IStation[] GetAllStation(string linename);
        void AddTimeDelay(ILine l, string stationFrom, string stationTo, double time, bool bothDirections);
        void DeleteTimeDelay(ILine l, string stationFrom, string stationTo, bool bothDirections);
        void CloseTrack(ILine l, string stationFrom, string stationTo, bool bothDirections);
        void OpenTrack(ILine l, string stationFrom, string stationTo);
        WeightedLinkedList<IStation, double> FindShortestPath(string startStation, string destinationStation);
    }
}

