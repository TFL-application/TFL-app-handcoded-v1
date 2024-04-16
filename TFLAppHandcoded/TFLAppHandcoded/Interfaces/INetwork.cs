using System;
using static System.Collections.Specialized.BitVector32;
using System.Xml.Linq;

namespace TFLAppHandcoded.Interfaces
{
	public interface INetwork
    {
        ILine[] GetLines();
        IStation GetStation(string name);
        DLinkedList GetAllStation(ILine line);
        void AddTimeDelay(string stationFrom, string stationTo, double time, bool bothDirections);
        void DeleteTimeDelay(ITrack track);
        void CloseTrack(string stationFrom, string stationTo, double time, bool bothDirections);
        void OpenTrack(ITrack track);
        LinkedList FindShortestPath(IStation start, IStation destination);
    }
}

