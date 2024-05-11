using System;
using TFLAppHandcoded.Interfaces;

namespace TFLAppHandcoded
{

    // Concrete implementation of a station
    public class Station : IStation,IEquatable<Station>
    {
        private string name;
        private ILine line;
        private IStation[] changes;

        // Constructor to initialize the station
        public Station(string name, IStation[] changes, NetworkData networkData = null)
        {
            this.name = name;
            this.changes = changes;
        }

        public IStation[] GetConnections()
        {
            return changes;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public ILine GetLine()
        {
            return line;
        }

        public void SetLine(ILine line)
        {
            this.line = line;
        }

        //Adds a single station to the list of connected stations. 
        public void AddChange(IStation toStation)
        {
            int newLength = changes.Length + 1; // Calculate the new length of the array by adding one more element.
            IStation[] newChanges = new IStation[newLength]; // Create a new array of IStation with the new length.
            changes.CopyTo(newChanges, 0); // Copy the existing connections into the new array.
            newChanges[newLength - 1] = toStation; // Add the new station at the last index of the new array.
            changes = newChanges; // Replace the old array with the new array that now includes the new station.
        }

        //Adds multiple stations at once to the list
        public void AddChanges(IStation[] stations)
        {
            int currentLength = changes.Length; // Current number of connections.
            int additionalLength = stations.Length; // Number of new stations to add.
            int newLength = currentLength + additionalLength; // Total length of the new array.
            IStation[] newChanges = new IStation[newLength]; // Create a new array with the new total length.
            changes.CopyTo(newChanges, 0); // Copy existing connections to the new array.
            Array.Copy(stations, 0, newChanges, currentLength, additionalLength); // Copy new stations into the new array starting at the index of the current length.
            changes = newChanges; // Update the changes array to the new array with all connections.
        }

      public bool Equals(Station stationName)
        {
            if (stationName == null)
                return false;
            
            return name == stationName.name;
        }



    }
}

