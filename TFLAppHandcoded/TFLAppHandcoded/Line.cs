using System;

namespace TFLAppHandcoded
{
	public class Line
	{
		private string name;
        private string color;
        private Dictionary<Station,LinkedList<Station,Track>> stations;

		public Line(string name, string color, Station[] stations)

        {
			this.name = name;
			this.color = color;
			this.stations = stations;
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

