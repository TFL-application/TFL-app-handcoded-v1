
using TFLAppHandcoded.Interfaces;

namespace TFLAppHandcoded
{

    public class Track : ITrack
    {
        private double time;
        private bool isOpen;
        private double delay;

        public Track(double time)
        {

            this.time = time;
            isOpen = true;
        }


        public double GetTravelTime()
        {

            return time + delay;
        }
        public double GetTime()
        {

            if (time <= 0)
            {
                throw new ArgumentException("Time cannot be negative.");
            }
            return time;
        }


        public void SetTime(double time)
        {
            this.time = time;
        }


        public bool GetIsOpen()
        {

            return isOpen;
        }

        public void SetIsOpen(bool isOpen)
        {
            this.isOpen = isOpen;
        }

        public double GetDelay()
        {
            return delay;
        }

        public void SetDelay(double delay)
        {
            if (delay < 0)
            {
                throw new ArgumentException("Time cannot be negative.");
            }
            this.delay = delay;
        }
    }
}

