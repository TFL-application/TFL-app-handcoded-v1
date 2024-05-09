using System;

namespace TFLAppHandcoded.Interfaces
{
	public interface INetwork
    {
        ILine[] GetLines();
        IStation GetStation(string stationname);
        IStation[] GetAllStation(ILine line);
        void AddTimeDelay(string stationFrom, string stationTo, double time, bool bothDirections);
        void DeleteTimeDelay(ITrack track);
        void CloseTrack(string stationFrom, string stationTo, double time, bool bothDirections);
        void OpenTrack(ITrack track);
        WeightedLinkedList<IStation, double> FindShortestPath(IStation start, IStation destination);
    }
}

