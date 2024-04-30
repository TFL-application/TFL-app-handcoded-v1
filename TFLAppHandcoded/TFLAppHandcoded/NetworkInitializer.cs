namespace TFLAppHandcoded
{
    public class NetworkInitializer
	{
        public networkData InitializeNetwork()
        {
            //victoria line stations
            Station walthamstowCentral = new Station("Walthamstow Central");
            Station blackhorseRoad = new Station("Blackhorse Road");
            Station tottenhamHale = new Station("Tottenham Hale");
            Station sevenSisters = new Station("Seven Sisters");
            Station finsburyPark = new Station("Finsbury Park");
            Station highburyNislington = new Station("Highbury & Islington");
            Station kingsCrossStPancras = new Station("King's Cross St Pancras");
            Station euston = new Station("Euston");
            Station warrenStreet = new Station("Warren Street");
            Station oxfordCircus = new Station("Oxford Circus");
            Station greenPark = new Station("Green Park");
            Station victoria = new Station("Victoria");
            Station pimlico = new Station("Pimlico");
            Station vauxhall = new Station("Vauxhall");
            Station stockwell = new Station("Stockwell");
            Station brixton = new Station("Brixton");

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
            Station westHampstead = new Station("West Hampstead");
            Station finchleyRoad = new Station("Finchley Road");
            Station swissCottage = new Station("Swiss Cottage");
            Station stJohnsWood = new Station("St. John's Wood");
            Station bakerStreet = new Station("Baker Street");
            Station bondStreet = new Station("Bond Street");
            Station greenPark = new Station("Green Park");
            Station westminster = new Station("Westminster");
            Station waterloo = new Station("Waterloo");
            Station southwark = new Station("Southwark");
            Station londonBridge = new Station("London Bridge");
            Station bermondsey = new Station("Bermondsey");
            Station canadaWater = new Station("Canada Water");
            Station canaryWharf = new Station("Canary Wharf");
            Station northGreenwich = new Station("North Greenwich");
            Station canningTown = new Station("Canning Town");
            Station westHam = new Station("West Ham");
            Station stratford = new Station("Stratford");



            Line victoriaLine = new Line("Victoria", "Blue", new List<Station>()
            {
                walthamstowCentral,
                blackhorseRoad,
                tottenhamHale,
                sevenSisters,
                finsburyPark,
                highburyNislington,
                kingsCrossStPancras,
                euston,
                warrenStreet,
                oxfordCircus,
                greenPark,
                victoria,
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
                westHampstead,
                finchleyRoad,
                swissCottage,
                stJohnsWood,
                bakerStreet,
                bondStreet,
                greenPark,
                westminster,
                waterloo,
                southwark,
                londonBridge,
                bermondsey,
                canadaWater,
                canaryWharf,
                northGreenwich,
                canaryWharf,
                westHam,
                stratford,

            });

            networkData.AddLine(victoriaLine);
            networkData.AddLine(jubileeLine);

        }
    }
}

