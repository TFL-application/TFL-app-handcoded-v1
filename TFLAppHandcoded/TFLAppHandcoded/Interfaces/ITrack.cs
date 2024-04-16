using System;
namespace TFLAppHandcoded.Interfaces
{
	public interface ITrack
    {
        double GetTravelTime();
        double GetTime();
        void SetTime(double time);
        bool GetIsOpen();
        void SetIsOpen(bool isOpen);
        double GetDelay();
        void SetDelay(double delay);
    }
}

