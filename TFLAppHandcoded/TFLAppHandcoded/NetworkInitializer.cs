namespace TFLAppHandcoded
{
    public class NetworkInitializer
    {

        public NetworkData InitializeNwtwork()
        {
            NetworkData networkData = new NetworkData();

            //circle line stations
            Station[] circleLineStation = new Station[]
            {
                    new Station("Hammersmith"),
                    new Station("Goldhawk Road"),
                    new Station("Shepherd's Bush"),
                    new Station("Latimer Road"),
                    new Station("Ladbroke Grove"),
                    new Station("Westbourne Park"),
                    new Station("Royal Oak"),
                    new Station("Paddington"),
                    new Station("Baker Street"),
                    new Station("Great Portland Street"),
                    new Station("Euston Square"),
                    new Station("King's Cross St. Pancras"),
                    new Station("Farringdon"),
                    new Station("Barbican"),
                    new Station("Moorgate"),
                    new Station("Liverpool Street"),
                    new Station("Aldgate"),
                    new Station("Tower Hill"),
                    new Station("Monument"),
                    new Station("Cannon Street"),
                    new Station("Mansion House"),
                    new Station("Blackfairs"),
                    new Station("Temple"),
                    new Station("Embankment"),
                    new Station("Westminster"),
                    new Station("St. James's Park"),
                    new Station("Victoria"),
                    new Station("Sloan Square"),
                    new Station("South Kensington"),
                    new Station("Gloucester Road"),
                    new Station("High Street Kensington"),
                    new Station("Notting Hill Gate"),
                    new Station("Bayswater"),
                    new Station("Edgware Road"),
            };


            //jubilee line stations
            Station[] jubileeLineStation = new Station[]
            {
                    new Station("Stanmore"),
                    new Station("Canons Park"),
                    new Station("Queensbury"),
                    new Station("Kingsbury"),
                    new Station("Wembley Park"),
                    new Station("Neasden"),
                    new Station("Dollis Hill"),
                    new Station("Willesden Green"),
                    new Station("Kilburn"),
                    new Station("West Hampstead"),
                    new Station("Finchley Road"),
                    new Station("Swiss Cottage"),
                    new Station("St. John's Wood"),
                    new Station("Baker Street"),
                    new Station("Bond Street"),
                    new Station("Green Park"),
                    new Station("Westminster"),
                    new Station("Waterloo"),
                    new Station("Southwark"),
                    new Station("London Bridge"),
                    new Station("Bermondsey"),
                    new Station("Canada Water"),
                    new Station("Canary Wharf"),
                    new Station("North Greenwich"),
                    new Station("Canning Town"),
                    new Station("West Ham"),
                    new Station("Stratford"),
            };
            //overground line stations
            Station[] overgroundLineStation = new Station[]
            {
                    new Station("Richmond"),
                    new Station("Kew Gardens"),
                    new Station("Gunnersbury"),
                    new Station("South Acton"),
                    new Station("Acton Central"),
                    new Station("Willesden Junction"),
                    new Station("Kensal Rise"),
                    new Station("Brondesbury Park"),
                    new Station("Brondesbury"),
                    new Station("West Hampstead"),
                    new Station("Finchley Road & Frognal"),
                    new Station("Hampstead Heath"),
                    new Station("Gospel Oak"),
                    new Station("Kentish Town West"),
                    new Station("Camden Road"),
                    new Station("Caledonian Road & Barnsbury"),
                    new Station("Highbury & Islington"),
                    new Station("Canonbury"),
                    new Station("Dalston Kingsland"),
                    new Station("Hackney Central"),
                    new Station("Homerton"),
                    new Station("Hackney Wick"),
                    new Station("Stratford"),
            };

            //victoria line stations
            Station[] victoriaLineStations = new Station[]
            {
                    new Station("Walthamstow Central"),
                    new Station("Blackhorse Road"),
                    new Station("Tottenham Hale"),
                    new Station("Seven Sisters"),
                    new Station("Finsbury Park"),
                    new Station("Highbury & Islington"),
                    new Station("King's Cross St Pancras"),
                    new Station("Euston"),
                    new Station("Warren Street"),
                    new Station("Oxford Circus"),
                    new Station("Green Park"),
                    new Station("Victoria"),
                    new Station("Pimlico"),
                    new Station("Vauxhall"),
                    new Station("Stockwell"),
                    new Station("Brixton"),
            };

            
            Line circleLine = new Line("Circle", "Yellow", circleLineStation);
            Line jubileeLine = new Line("Jubilee", "grey", jubileeLineStation);
            Line overgroundLine = new Line("Overground", "orange", overgroundLineStation);
            Line victoriaLine = new Line("Victoria", "Blue", victoriaLineStations);





            return networkData;
    
        
        }
    }
}

