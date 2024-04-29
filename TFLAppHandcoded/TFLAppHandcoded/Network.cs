using System;
using TFLAppHandcoded.Interfaces;

namespace TFLAppHandcoded{

    public class NetworkData
    {
        public Dictionary<string, Line> Lines { get; private set; }
    }

    public class Network:INetwork{
        private NetworkData networkData;
        private Line[]lines;
        private LinkedList<Track> closedTracks;
        private LinkedList<Track> delayedTracks;

        public Network(NetworkData networkData)
        {
            this.networkData = networkData;
            InitilizeNetwork(networkData);
        }

        private void InitilizeNetwork(networkData)
        {
            var circleBakerStreet = new Station("Baker Street");
        }

        public Network(){}
        public Line GetLines(){}
        public string GetStation(string name){
            try{
                foreach(line in lines){
                    if(line.GetStation()==name){
                        return line.GetStation();
                }

            }}
             throw new ArgumentException($"Station name : {name} doesnot falls on the line");
            catch(Exception ex){
                 Console.WriteLine("An error occured:",ex.message);
            }
            
            }
        public IStation GetAllStation(ILine line){

            try{
                foreach (line in lines){
                if(this.line.GetName()==line.GetName()){
                    return line.GetAllStations();
                }
                
            }
            throw new ArgumentException($"Line name {line.GetName()} not Found");
            }
            catch (Exception ex){
                Console.WriteLine("An error occured:",ex.message);
            }
            
        }

        //I have added Line attirbute:
        public void AddTimeDelay(ILine l, string stationFrom,string stationTo, double time, bool bothDirections){

            // FindRecordValueWithKey
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
        public void DeleteTimeDelay(Track track){

        }

        public CloseTrack(string stationFrom,string stationTo,double time, bool bothDirections){

             try{
               foreach(Iline line in lines){

                //.CheckKey method taken from handcoded Dicitonary vand FInditem taken from weighted Linked list
                //Implementing checks to find if the stationTo exists as a record in Adjlist in Line Class and stationFrom exists as a value in connected station
                if (line.GetName()==l.GetName()){

                    if(line.GetStation().CheckKeyExists(stationFrom&&line.GetName().FindItem(stationTo))){
                        line.GetStation[stationFrom].FindRecordValueWithKey(stationTo).SetIsOpen(false);
                    }
                    if (bothDirections){
                        line.GetStation[stationTo].FindRecordValueWithKey(stationFrom).SetDelay(false);
                    }

                }
               }

            }catch(Exception ex){
                    Console.WriteLine("An error occured:",ex.message);
            }
        }
        public void OpenTrack(Track track){}
        public WeightedLinkedList<Station, double> FindShortestPath(Station start, Station destination){}

    }
}
