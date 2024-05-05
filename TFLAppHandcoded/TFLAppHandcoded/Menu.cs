TFLAppHandcoded/TFLAppHandcoded/Menu.cs
@@ -0,0 +1,291 @@
namespace TFLAppHandcoded{


    public class Menu{

        private INetwork network;
          public void Display_menu()
		{
			
			Console.WriteLine("**************************************************************************");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                            WELCOME                                   **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**                               TO                                     **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**                       Transport For London                           **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**************************************************************************");


        }
        public  int Tfl_menu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**              Please choose from options below:                       **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    1. Customer                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    2. Engineer                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("**    3. Exit                                                           **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int Choice = Convert.ToInt32(Console.ReadLine());
            return Choice;

        }




        // THis method will return choice of operation Cutomer wants to perform
        public int Customer_Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome To TFL ");
            Console.WriteLine("Enter your Name Customer");
            string? name= Console.ReadLine();
            Console.WriteLine("**************************************************************************");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine($"           Hello {name} !How we May help you?                          **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** Enter Options from 1-4                                               **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("** 1. Choose Station by Line                                            **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 2. Choose Journey by Station Name                                    **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 3. Exit to Main Menu                                                 **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }
         
        // This method will return choice of operation Engineer wants to perform
        public int Engineer_Menu()
        {
            Console.WriteLine();
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** Enter Options from 1-4                                               **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("** 1. Add Delay                                                         **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 2. Remove Delay                                                      **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 3. Close Track                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 4. Open  Track                                                       **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** 5. Exit To Main Menu                                                 **");
            Console.WriteLine("**                                                                      **");
            Console.WriteLine("** ---------------------------------------------------------------------**");
            Console.WriteLine("**************************************************************************");

            int choice = Convert.ToInt32(Console.ReadLine());
            return choice;
        }

        public void Customer_Operation(int option){
        do{
        if (option < 1 || option > 4)
        {
            Console.WriteLine("Invalid option Entered");
        }

        INetwork network = new Network(); 

        switch (option)
        {
            // Case when customer chooses to decide Journey from choosing Line 
            case 1:
                Console.WriteLine("Choose Line Name");
                network.GetLines();
                string lineName = Console.ReadLine();
                network.GetAllStation(lineName);
                Console.WriteLine("Enter Start Journey Station");
                string StationTo = Console.ReadLine();
                Console.WriteLine("Enter Destination Station");
                string StationFrom = Console.ReadLine();
                network.FindShortestPath(StationTo, StationFrom);
                break;

            // Case when customer chooses to decide Journey from choosing Station
            case 2:
                Console.WriteLine("Enter Start Journey Station");
                string StationStart = Console.ReadLine();
                Console.WriteLine("Enter Destination Station");
                string StationEnd = Console.ReadLine();
                network.FindShortestPath(StationStart, StationEnd); 
                break;

            case 3:
            // Exiting back to main menu
                int menuChoice=Tfl_menu();
                StartJourney(menuChoice);
                break;

            default:
                Console.WriteLine("Invalid Option Entered! Please choose Valid Option");
                int choice=Customer_menu();
                CustomerOperations(choice);
                break;
        }
        } while (option < 1 || option > 4);
         
        }


        //Engineer Options
        public void Engineer_Operation(int choice){
        do{
        if (choice < 1 || choice > 5)
        {
            Console.WriteLine("Invalid option Entered");
        }

        INetwork network = new Network(); 

        switch (choice)
        {
            //Case When Engineer chooses to Add Delay
            case 1:
                Console.WriteLine("Enter Line name to Add delay");
                string linename=Console.ReadLine();

                Console.WriteLine("Enter Station name to Add Delay From");
                string StationStart = Console.ReadLine();

                Console.WriteLine("Enter Station name to add Delay To ");
                string StationEnd = Console.ReadLine();

                Console.WriteLine("Enter Time Delay");
                double TimeDelay=Convert.Todouble("Enter Time Delay");

                Console.WriteLine("is the Delay in both DIrections? choose between true or false");
                //calling boolvalue function
                bool direction=boolValue();

                network.AddTimeDelay(linename,StationStart,StationEnd,TImeDelay,direction);
                break;


            //Case When Engineer chooses to Remove Delay
            case 2:
               Console.WriteLine("Enter Line name to Remove delay");
                string linename1=Console.ReadLine();

                Console.WriteLine("Enter Station name to Remove Delay From");
                string FromStation = Console.ReadLine();

                Console.WriteLine("Enter Station name to Remove Delay To ");
                string ToStation = Console.ReadLine();

                Console.WriteLine("Enter Time Delay");
                double timeDelay=Convert.Todouble(COnsole.ReadLine());

                Console.WriteLine("is the Delay in both DIrections? choose between true or false");
                //calling boolvalue function
                bool directionVal=boolValue();

                network.DeleteTimeDelay(linename,FromStation,ToStation,TImeDelay,directionVal);
                break;

            //Case when Enginner chooses to close Track
            case 3:
               
                Console.WriteLine("Enter Line name to close track");
                string linename1=Console.ReadLine();

                Console.WriteLine("Enter Station name to Close From");
                string StationA = Console.ReadLine();

                Console.WriteLine("Enter Station name to Close Track  To ");
                string StationB = Console.ReadLine();
                network.CloseTrack(StationA,StationB);
                break;


             //Case when Enginner chooses to Open Track
             case 4:
                Console.WriteLine("Enter Line name to open track");
                string Linename=Console.ReadLine();

                Console.WriteLine("Enter Station name to Add Delay From");
                string stationA = Console.ReadLine();

                Console.WriteLine("Enter Station name to add Dealy To ");
                string stationB = Console.ReadLine();

                network.OpenTrack(Linename,stationA,stationB);
                break;

             
                case 5:
                int menuChoice=Tfl_menu();
                StartJourney(menuChoice);
                break;

            default:
                Console.WriteLine("Invalid Option Entered! Please choose Valid Option");
                int choice=Engineer_menu();
                Engineer_Operation(choice);
                break;
        }
        } while (choice < 1 || choice > 5);


        }


        //utility function to get valid bool value as an console input

      
        private bool boolValue()
        {
            string input;
            do
            {
                Console.WriteLine("Enter 'true' or 'false' ");
                input = Console.ReadLine().ToLower();
            } while (input != "true" && input != "false");
            
            return input == "yes";
        }


        public void StartJourney(int choice){

            switch(choice){

                case 1:
                int customerChoice=Customer_Menu();
                // starting customer opetations
                Customer_Operation(customerChoice);
                break;

                case 2:
                int EngineerChoice=Engineer_Menu();
                Engineer_Operation(EngineerChoice);
                break;

            }

            
        }


    }
}