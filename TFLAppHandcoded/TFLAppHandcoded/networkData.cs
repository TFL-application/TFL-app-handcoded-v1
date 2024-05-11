namespace TFLAppHandcoded
{
    public class NetworkData
    {
        private LinkedList<Line> lines;

        public NetworkData()
        {
            lines = new LinkedList<Line>();
        }

        public LinkedList<Line> Lines => lines; // Expose the linked list (read-only)

        public void AddLine(Line line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line));
            }
            lines.AddLast(line); // Add the Line object to the end of the linked list
        }

        public Line GetLine(string lineName)
        {
            if (lineName == null)
            {
                throw new ArgumentOutOfRangeException(nameof(lineName));
            }
            foreach (Line line in lines)
            {
                if (line.GetName() == lineName)
                {
                    return line;
                }
            }
            return null; // Line not found
        }
    }
}
	





