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

        public Network()
        {
            NetworkInitializer initializer = new NetworkInitializer();
            networkData = initializer.InitializeNetwork();
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

         
            try{
               foreach(Iline line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                    if(line.GetStation().CheckKeyExists(stationFrom&&line.GetName().FindItem(stationTo))){
                        line.GetStation[stationFrom].FindRecordValueWithKey(stationTo).SetDelay(time);
                    }
                    if (bothDirections){
                        line.GetStation[stationTo].FindRecordValueWithKey(stationFrom).SetDelay(time);
                    }

                }
               }

            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.message);
            }
        }

        //Boothdirection Attribute is added to this method as well as Delay could or could not be in both directions
        public void DeleteTimeDelay(ILine l, string stationFrom,string stationTo, bool bothDirections){
              try{
               foreach(Iline line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                        foreach (Station station in line.GetAllStations())
                        {
                            if (station.Equals( stationFrom)){
                            WeightedLinkedList<Station ,Track > connectedFrom = l.GetConnectedStations(stationFrom);
                            
                            Station stationToRemoveDelayFrom = new Station(stationTo);

                            WeightedListNode<Station,Track>? stationToRemoveDelay =connectedFrom.FindNodeWeight(stationToRemoveDelayFrom);

                            if(stationToRemoveDelay){
                            Track trackFrom = stationToRemoveDelayFrom.GetWeight();
                            trackFrom.SetDelay(0.0);
                            }
                            if (bothDirections){
                                WeightedLinkedList<Station ,Track > connectedTo = l.GetConnectedStations(stationTo);

                                Station stationToRemoveDelayTo = new Station(stationFrom);

                                WeightedListNode<Station,Track>? stationToRemoveDelay2 =connectedTo.FindNodeWeight(stationToRemoveDelayTo);

                                if(stationToremoveDelay2){
                                Track trackTo = stationToremoveDelayTo.GetWeight();
                                trackTo.SetDelay(0.0);
                                }
                                
                            }
                            }
                            }
                            }
                
    
            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.message);
            }}}


        //Removed time and bothdirection attribute 
        public void CloseTrack(ILine l, string stationFrom,string stationTo, bool bothDirections = false)
        {
        try{
               foreach(ILine line in lines){
                if (line.GetName()==l.GetName()){

                        foreach (Station station in line.GetAllStations())
                        {
                            if (station.Equals( stationFrom)){
                            WeightedLinkedList<Station ,Track > connectedFrom = l.GetConnectedStations(stationFrom);
                            
                            Station stationToCloseTrackFrom = new Station(stationTo);

                            WeightedListNode<Station,Track>? stationToCloseTrack =connectedFrom.FindNodeWeight(stationToCloseTrackFrom);

                            if(stationToCloseTrack ){
                            Track trackFrom = stationToCloseTrackFrom.SetIsOpen(false);
                            
                            }
                            if (bothDirections){
                                WeightedLinkedList<Station ,Track > connectedTo = l.GetConnectedStations(stationTo);
                                Station stationToCloseTrackTo = new Station(stationFrom);
                                WeightedListNode<Station,Track>? stationToCloseTrack2 =connectedTo.FindNodeWeight(stationToCloseTrackTo);

                                if(stationToCloseTrack2 ){
                                Track trackTo = stationToCloseTrack2 .SetIsOpen(false);
                                
                                }}
                            
                            }
                            }}}}
             
             catch(Exception ex){
                    Console.WriteLine("An error occured:",Ex.message);
            }
        }




        public void OpenTrack(ILine l, string stationFrom, string stationTo)
        {
              try
               foreach(ILine line in lines){
                if (line.GetName()==l.GetName()){

                        foreach (Station station in line.GetAllStations())
                        {
                            if (station.Equals( stationFrom)){
                            WeightedLinkedList<Station ,Track > connectedFrom = l.GetConnectedStations(stationFrom);
                            
                            Station stationToOpenTrackFrom = new Station(stationTo);

                            WeightedListNode<Station,Track>? stationToOpenTrack =connectedFrom.FindNodeWeight(stationToOpenTrackFrom);

                            if(stationToOpenTrack ){
                            Track trackFrom = stationToOpenTrackFrom.SetIsOpen(true);
                            
                            }
                            if (bothDirections){
                                WeightedLinkedList<Station ,Track > connectedTo = l.GetConnectedStations(stationTo);
                                Station stationToOpenTrackTo = new Station(stationFrom);
                                WeightedListNode<Station,Track>? stationToOpenTrack2 =connectedTo.FindNodeWeight(stationToOpenTrackTo);

                                if(stationToOpenTrack2){
                                Track trackTo = stationToOpenTrack2.SetIsOpen(true);
                                
                                }}
                            
                            }
                            }}}}
              
              
              
              
              
              catch(Exception ex){
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
