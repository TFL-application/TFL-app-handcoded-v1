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


        //return type void is added because it might be required for the menu to display line
        public void GetLines(){
            int lineLength=lines.length();
            try{
                if(lineLength<=0){
                    throw new ArgumentException("No valid Data to Show");
                }

                for(int i=0;i<lineLength;i++){
                    Console.Writeline($"Line : {lines[i].name}");
                    Console.Writeline($"Line : {lines[i].color}");
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }



        }


        public string GetStation(string linename){
            try{
                foreach(Line line in lines){
                    if(line.GetStation().GetName()==linename){
                        return line.GetStation();
                }

            }}
             throw new ArgumentException($"Station name : {name} doesnot falls on the line");
            catch(Exception ex){
                 Console.WriteLine("An error occured:",ex.message);
            }
            
            }

        
        public IStation GetAllStation(string linename){

            try{
                foreach (Line line in lines){
                if(this.line.GetName()==linename){
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

        //Boothdirection Attribute is added to this method as well as Delay could or could not be in both directions
        public void DeleteTimeDelay(ILine l, string stationFrom,string stationTo, double time,bool bothDirections){
              try{
               foreach(Iline line in lines){

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
        public CloseTrack(string stationFrom,string stationTo){

             try{
               foreach(Iline line in lines){

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




        public void OpenTrack(line: ILine, stationFrom: string, stationTo: string){
              try{
               foreach(Iline line in lines){

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



        public WeightedLinkedList<Station, double> FindShortestPath(Station start, Station destination){}

    }
}
