using System;
using System.Drawing;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace TFLAppHandcoded.Interfaces
{
	public interface ILine
    {
        void AddStation(IStation station, WeightedLinkedList<IStation, ITrack> connections);
        string GetName();
        void SetName(string name);
        string GetColor();
        void SetColor(string color);
        IStation GetStation(string name);
        IStation[] GetAllStations();
        ITrack GetDistance(IStation start, IStation destination);
        WeightedLinkedList<IStation, ITrack> GetConnectedStations(IStation station);
    }
}

