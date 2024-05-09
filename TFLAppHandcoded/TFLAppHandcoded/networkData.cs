using System;
namespace TFLAppHandcoded
{
	public class networkData
	{
		public Dictionary<string, Line> Lines { get; private set; }

		public networkData()
		{
			Lines = new Dictionary<string, Line>();

		}

		public void AddLine(Line line)
			{
			Lines.Add(line.GetName(), line);
			}
	}
}


