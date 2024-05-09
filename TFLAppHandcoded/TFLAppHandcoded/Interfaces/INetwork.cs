using System;

namespace TFLAppHandcoded.Interfaces
{
	public interface INetwork
    {
        ILine[] GetLines();
        IStation GetStation(string stationname);
        IStation[] GetAllStation(ILine line);
        void AddTimeDelay(ILine l, string stationFrom, string stationTo, double time, bool bothDirections);
        void DeleteTimeDelay(ILine l, string stationFrom, string stationTo, double time, bool bothDirections);
        void CloseTrack(ILine l, string stationFrom, string stationTo, bool bothDirections);
        void OpenTrack(ILine l, string stationFrom, string stationTo);
        WeightedLinkedList<IStation, double> FindShortestPath(string start, string destination);
    }
}

