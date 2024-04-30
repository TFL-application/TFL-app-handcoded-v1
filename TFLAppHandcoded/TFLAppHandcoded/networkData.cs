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
			if (line == null)
			{
				throw new ArgumentNullException(nameof(line));
			}
			Lines.Add(line.GetName(), line);
		}

		public Line GetLine(string lineName)
		{
			if (lineName == null)
			{
				throw new ArgumentOutOfRangeException(nameof(lineName));
			}
			Lines.TryGetValue(lineName, out Line line);
			return line;
		}
	}
}


