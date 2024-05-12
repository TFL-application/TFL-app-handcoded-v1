using System;

namespace TFLAppHandcoded.Interfaces
{
	public interface INetwork
    {
        string[] GetLines();
        IStation GetStation(string stationname);
        string[] GetAllStations(string linename);
        void AddTimeDelay(string line, string stationFrom, string stationTo, double time, bool bothDirections);
        void DeleteTimeDelay(string line, string stationFrom, string stationTo, bool bothDirections);
        void CloseTrack(string line, string stationFrom, string stationTo, bool bothDirections);
        void OpenTrack(string line, string stationFrom, string stationTo, bool bothDirections);
        WeightedLinkedList<IStation, double>? FindShortestPath(string stationFrom, string lineFrom, string stationTo, string lineTo);
    }
}

