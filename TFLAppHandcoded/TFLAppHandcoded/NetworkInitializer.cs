namespace TFLAppHandcoded
{
    public class NetworkInitializer
	{
        NetworkData networkData = new NetworkData();

        
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

            //jubilee line stations
            Station stanmore = new Station("Stanmore");
            Station canonsPark = new Station("Canons Park");
            Station queensbury = new Station("Queensbury");
            Station kingsbury = new Station("Kingsbury");
            Station wembleyPark = new Station("Wembley Park");
            Station neasden = new Station("Neasden");
            Station dollisHill = new Station("Dollis Hill");
            Station willesdenGreen = new Station("Willesden Green");
            Station kilburn = new Station("Kilburn");
            Station JwestHampstead = new Station("West Hampstead");
            Station finchleyRoad = new Station("Finchley Road");
            Station swissCottage = new Station("Swiss Cottage");
            Station stJohnsWood = new Station("St. John's Wood");
            Station JbakerStreet = new Station("Baker Street");
            Station bondStreet = new Station("Bond Street");
            Station JgreenPark = new Station("Green Park");
            Station Jwestminster = new Station("Westminster");
            Station waterloo = new Station("Waterloo");
            Station southwark = new Station("Southwark");
            Station londonBridge = new Station("London Bridge");
            Station bermondsey = new Station("Bermondsey");
            Station canadaWater = new Station("Canada Water");
            Station canaryWharf = new Station("Canary Wharf");
            Station northGreenwich = new Station("North Greenwich");
            Station canningTown = new Station("Canning Town");
            Station westHam = new Station("West Ham");
            Station Jstratford = new Station("Stratford");

            //circle line stations
            Station hammersmith = new Station("Hammersmith");
            Station goldhawkRoad = new Station("Goldhawk Road");
            Station shepherdsBush = new Station("Shepherd's Bush");
            Station latimerRoad = new Station("Latimer Road");
            Station ladbrokeGrove = new Station("Ladbroke Grove");
            Station westbournePark = new Station("Westbourne Park");
            Station royalOak = new Station("Royal Oak");
            Station paddington = new Station("Paddington");
            Station CbakerStreet = new Station("Baker Street");
            Station greatPortlandStreet = new Station("Great Portland Street");
            Station eustonSquare = new Station("Euston Square");
            Station CkingsCrossStPancras = new Station("King's Cross St. Pancras");
            Station farringdon = new Station("Farringdon");
            Station barbican = new Station("Barbican");
            Station moorgate = new Station("Moorgate");
            Station liverpoolStreet = new Station("Liverpool Street");
            Station aldgate = new Station("Aldgate");
            Station towerHill = new Station("Tower Hill");
            Station monument = new Station("Monument");
            Station cannonStreet = new Station("Cannon Street");
            Station mansionHouse = new Station("Mansion House");
            Station blackfairs = new Station("Blackfairs");
            Station temple = new Station("Temple");
            Station embankment = new Station("Embankment");
            Station Cwestminster = new Station("Westminster");
            Station stJamessPark = new Station("St. James's Park");
            Station Cvictoria = new Station("Victoria");
            Station sloanSquare = new Station("Sloan Square");
            Station southKensington = new Station("South Kensington");
            Station gloucesterRoad = new Station("Gloucester Road");
            Station highStreetKensington = new Station("High Street Kensington");
            Station nottingHillGate = new Station("Notting Hill Gate");
            Station bayswater = new Station("Bayswater");
            Station edgwareRoad = new Station("Edgware Road");

            //overground line stations
            Station richmond = new Station("Richmond");
            Station kewGardens = new Station("Kew Gardens");
            Station gunnersbury = new Station("Gunnersbury");
            Station southActon = new Station("South Acton");
            Station actonCentral = new Station("Acton Central");
            Station willesdenJunction = new Station("Willesden Junction");
            Station kensalRise = new Station("Kensal Rise");
            Station brondesburyPark = new Station("Brondesbury Park");
            Station brondesbury = new Station("Brondesbury");
            Station OwestHampstead = new Station("West Hampstead");
            Station finchleyRoadNFrognal = new Station("Finchley Road & Frognal");
            Station hampsteadHeath = new Station("Hampstead Heath");
            Station gospelOak = new Station("Gospel Oak");
            Station kentishTownWest = new Station("Kentish Town West");
            Station camdenRoad = new Station("Camden Road");
            Station caledonianRoadNBarnsbury = new Station("Caledonian Road & Barnsbury");
            Station OhighburyNIslington = new Station("Highbury & Islington");
            Station canonbury = new Station("Canonbury");
            Station dalstonKingsland = new Station("Dalston Kingsland");
            Station hackneyCentral = new Station("Hackney Central");
            Station homerton = new Station("Homerton");
            Station hackneyWick = new Station("Hackney Wick");
            Station Ostratford = new Station("Stratford");



            Line victoriaLine = new Line("Victoria", "Blue", new List<Station>()
            {
                walthamstowCentral,
                blackhorseRoad,
                tottenhamHale,
                sevenSisters,
                finsburyPark,
                VhighburyNIslington,
                VkingsCrossStPancras,
                euston,
                warrenStreet,
                oxfordCircus,
                VgreenPark,
                Vvictoria,
                pimlico,
                vauxhall,
                stockwell,
                brixton,
            });

            Line jubileeLine = new Line("Jubilee", "grey", new List<Station>()
            {
                stanmore,
                canonsPark,
                queensbury,
                kingsbury,
                wembleyPark,
                neasden,
                dollisHill,
                willesdenGreen,
                kilburn,
                JwestHampstead,
                finchleyRoad,
                swissCottage,
                stJohnsWood,
                JbakerStreet,
                bondStreet,
                JgreenPark,
                Jwestminster,
                waterloo,
                southwark,
                londonBridge,
                bermondsey,
                canadaWater,
                canaryWharf,
                northGreenwich,
                canaryWharf,
                westHam,
                Jstratford,

            });

            Line circleLine = new Line("Circle", "yellow", new List<Station>()
            {
                hammersmith,
                goldhawkRoad,
                shepherdsBush,
                latimerRoad,
                ladbrokeGrove,
                westbournePark,
                royalOak,
                paddington,
                CbakerStreet,
                greatPortlandStreet,
                eustonSquare,
                CkingsCrossStPancras,
                farringdon,
                barbican,
                moorgate,
                liverpoolStreet,
                aldgate,
                towerHill,
                monument,
                cannonStreet,
                mansionHouse,
                blackfairs,
                temple,
                embankment,
                Cwestminster,
                stJamessPark,
                Cvictoria,
                sloanSquare,
                southKensington,
                gloucesterRoad,
                highStreetKensington,
                nottingHillGate,
                bayswater,
                edgwareRoad,



            });

            Line overgroundLine = new Line("Overground", "Orange", new List<Station>()
            {
                richmond,
                kewGardens,
                gunnersbury,
                southActon,
                actonCentral,
                willesdenJunction,
                kensalRise,
                brondesbury,
                brondesburyPark,
                OwestHampstead,
                finchleyRoadNFrognal,
                hampsteadHeath,
                gospelOak,
                kentishTownWest,
                camdenRoad,
                caledonianRoadNBarnsbury,
                OhighburyNIslington,
                canonbury,
                dalstonKingsland,
                hackneyCentral,
                homerton,
                hackneyWick,
                Ostratford,
            });

            NetworkData.AddLine(victoriaLine);
            NetworkData.AddLine(jubileeLine);
            NetworkData.AddLine(circleLine);
            NetworkData.AddLine(overgroundLine);



            return NetworkData;
internal NetworkData? InitializeNetwork()
        {
            throw new NotImplementedException();
        }
    }
        
    }
}

