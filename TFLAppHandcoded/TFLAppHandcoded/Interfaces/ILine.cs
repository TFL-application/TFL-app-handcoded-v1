using System;

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

