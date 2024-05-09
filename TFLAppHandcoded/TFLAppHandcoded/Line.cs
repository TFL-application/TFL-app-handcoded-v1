using System;

namespace TFLAppHandcoded
{
	public class Line
	{
		private string name;
        private string color;
        private Dictionary<Station,WeightedLinkedList<Station,Track>> stations;

		public Line(string name, string color)

        {
			this.name = name;
			this.color = color;
		}

		public string GetName()
		{
			return name;
        }

		public void SetName(string name)
		{
            this.name = name;
        }

		public string GetColor()
		{
			return color;
		}

        public void SetColour(string color)
        {
            this.color = color;
        }

		public Station GetStation (string station)
		{
			return station;
		}

		public Station[] GetAllStations()
		{
			return Station;
		}

		public Track GetDistance(Station start, Station destination)
		{

			return Track;
		}


    }
}

