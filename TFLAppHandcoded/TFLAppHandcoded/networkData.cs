namespace TFLAppHandcoded
{
    public class networkData
	{
		public Dictionary<string, Line> Lines { get; private set; }
		public List<Track> ClosedTracks { get; private set; }
		public List<Track> DelayedTracks { get; private set; }

		public networkData()
		{
			Lines = new Dictionary<string, Line>();
			ClosedTracks = new List<Track>();
			DelayedTracks = new List<Track>();

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

		public bool IsTrackCLosed(Track track)
		{
			return ClosedTracks.Contains(track);
		}
		public void ClosedTrack(Track track)
		{
			if(!ClosedTracks.Contains(track))
			{
				ClosedTracks.Add(track);
			}
		}

		public bool IsTrackDelayed(Track track)
		{
			return DelayedTracks.Contains(track);
		}
		public void AddDelayToTrack(Track track)
		{
			if(!DelayedTracks.Contains(track))
			{
				DelayedTracks.Add(track);
			}
		}

        //Method to remove closure from a track
		public void OpenTrack(Track track)
		{
			ClosedTracks.Remove(track);
        }

		// Method to remove delay from a track
        public void RemoveDelayFromTrack(Track track)
		{
			DelayedTracks.Remove(track);
		}
    }
}


