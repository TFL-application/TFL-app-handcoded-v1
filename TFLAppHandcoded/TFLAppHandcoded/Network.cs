using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;
using System.Xml.Linq;

namespace TFLAppHandcoded{

    public class NetworkData
    {
        public Dictionary<string, Line> lines { get; private set; }

        public NetworkData()
        {
            lines = new Dictionary<string, Line>();
        }
    }

    public class Network: INetwork{

        private double changeLineTime = 2.0;

        private NetworkData networkData;
        private Line[]lines;
        private LinkedList<Track> closedTracks;
        private LinkedList<Track> delayedTracks;

        public Network(NetworkData networkData)
        {
            this.networkData = networkData;
            InitilizeNetwork(networkData);
        }

        private void InitilizeNetwork(NetworkData networkData)
        {
            var circleBakerStreet = new Station("Baker Street", null);
        }

        public Network(){}


        //return type void is added because it might be required for the menu to display line
        public void GetLines(){
            int lineLength=lines.Length;
            try{
                if(lineLength<=0){
                    throw new ArgumentException("No valid Data to Show");
                }

                for(int i=0;i<lineLength;i++){
                    Console.WriteLine($"Line : {lines[i].GetName()}");
                    Console.WriteLine($"Line : {lines[i].GetColor()}");
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



        }

        // Delete it if not used
        public IStation GetStation(string stationname){
            try
            {
                foreach (Line line in lines)
                {
                    foreach (Station station in line.GetAllStations())
                    {
                        if (station.GetName() == stationname)
                        {
                            return station;
                        }
                    }
                }

                throw new ArgumentException($"Station name : {stationname} doesnot falls on the line");
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occured:", ex.Message);
            }
            return null;

        }


        public IStation[] GetAllStation(string linename){

            try{
                foreach (Line line in lines){
                if(line.GetName()==linename){
                    return line.GetAllStations();
                    }
                    throw new ArgumentException($"Line name {line.GetName()} not Found");

                }
            }
            catch (Exception ex){
                Console.WriteLine("An error occured:",ex.Message);
            }
            return null;
        }

        //I have added Line attirbute:
        public void AddTimeDelay(ILine l, string stationFrom,string stationTo, double time, bool bothDirections){

            // FindRecordValueWithKey
            try{
               foreach(ILine line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                        foreach (Station station in line.GetAllStations())
                        {

                            if (line.GetStation().CheckKeyExists(stationFrom && line.GetName().FindItem(stationTo)))
                            {
                                line.GetStation[stationFrom].FindRecordValueWithKey(stationTo).SetDelay(time);
                            }
                            if (bothDirections)
                            {
                                line.GetStation[stationTo].FindRecordValueWithKey(stationFrom).SetDelay(time);
                            }
                        }

                }
               }

            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.Message);
            }


        }

        //Boothdirection Attribute is added to this method as well as Delay could or could not be in both directions
        public void DeleteTimeDelay(ILine l, string stationFrom,string stationTo, double time,bool bothDirections){
              try{
               foreach(ILine line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                    if(line.GetStation().CheckKeyExists(stationFrom&&line.GetName().FindItem(stationTo))){

                        //for removing time delay The previously set delay is set back to 0.0
                        line.GetStation[stationFrom].FindRecordValueWithKey(stationTo).SetDelay(0.0);
                    }
                    if (bothDirections){
                        line.GetStation[stationTo].FindRecordValueWithKey(stationFrom).SetDelay(0.0);
                    }

                }
               }

            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.message);
            }

        }


        //Removed time and bothdirection attribute 
        public void CloseTrack(ILine l, string stationFrom,string stationTo, bool bothDirections = false)
        {

             try{
               foreach(ILine line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                    if(line.GetStation().CheckKeyExists(stationFrom&&line.GetName().FindItem(stationTo))){
                        line.GetStation[stationFrom].FindRecordValueWithKey(stationTo).SetIsOpen(false);
                        line.GetStation[stationTo].FindRecordValueWithKey(stationFrom).SetIsOpen(false);
                    }
                    

                }
               }

            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.message);
            }
        }




        public void OpenTrack(ILine l, string stationFrom, string stationTo)
        {
              try{
               foreach(ILine line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                    if(line.GetStation().CheckKeyExists(stationFrom&&line.GetName().FindItem(stationTo))){
                        line.GetStation[stationFrom].FindRecordValueWithKey(stationTo).SetIsOpen(true);
                        line.GetStation[stationTo].FindRecordValueWithKey(stationFrom).SetIsOpen(true);
                    }
                    

                }
               }

            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.message);
            }

        }


        public WeightedLinkedList<IStation, double>? FindShortestPath(string startStation, string destinationStation)
		{
            IStation start = this.GetStation(startStation);
            IStation destination = this.GetStation(destinationStation);
            return FastestPathAlgorithm.GetFastestPath(start, destination, changeLineTime);
		}

        // Delete it if not used
        IStation[] GetAllStation(ILine line)
        {
            return null;
        }

    }
}
