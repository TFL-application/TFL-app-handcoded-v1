using System;

namespace TFLAppHandcoded.Interfaces
{
	public interface IStation
    {
        IStation[] GetConnections();
        string GetName();
        void SetName(string name);
        ILine GetLine();
        void SetLine(ILine line);
        void AddChange(IStation toStation);
        void AddChanges(IStation[] stations);
    }
}

