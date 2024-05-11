using System;
using TFLAppHandcoded.Interfaces;
using TFLAppHandcoded.Dictionary;

namespace TFLAppHandcoded
{
    public class NetworkData
    {
        public ILine[] network { get; }

        public NetworkData()
        {
            network = this.InitializeNetwork();
        }

        public ILine GetLine(string lineName)
        {
            if (lineName == null)
            {
                throw new ArgumentOutOfRangeException(nameof(lineName));
            }
            foreach (ILine line in network)
            {
                if (line.GetName() == lineName)
                {
                    return line;
                }
            }
            return null; // Line not found
        }

        public ILine SetLine(string linename, string linecolor, string[] stationnames, double[] distances)
        {
            var line = new Line(linename, linecolor);

            for (int i = 0; i < stationnames.Length; i++)
            {
                var newStation = new Station(stationnames[i], new IStation[0]);
                newStation.SetLine(line);
                var adjList = new WeightedLinkedList<IStation, ITrack>();

                if (i != 0)
                {
                    var track1 = new Track(distances[i - 1]);
                    var track2 = new Track(distances[i - 1]);
                    var previousStaion = line.GetAllStations()[i - 1];
                    adjList.InsertAtHead(previousStaion, track1);
                    line.GetConnectedStations(previousStaion).InsertAtHead(newStation, track2);
                }

                line.AddStation(newStation, adjList);
            }

            return line;
        }

        public void AddChangeBetweenStations(ILine[] lines, string stationName)
        {
            foreach (ILine line1 in lines)
            {
                var station1 = line1.GetStation(stationName);
                foreach (ILine line2 in lines)
                {
                    if (!line1.Equals(line2))
                    {
                        var station2 = line2.GetStation(stationName);
                        station1.AddChange(station2);
                    }
                }
            }
        }


        public ILine[] InitializeNetwork()
        {
            var jubileeLineStations = new string[]
            {
                "Stanmore",
                "Canons Park",
                "Queensbury",
                "Kingsbury",
                "Wembley Park",
                "Neasden",
                "Dollis Hill",
                "Willesden Green",
                "Kilburn",
                "West Hampstead",
                "Finchley Road & Frognal",
                "Swiss Cottage",
                "St. John's Wood",
                "Baker Street",
                "Bond Street",
                "Green Park",
                "Westminster",
                "Waterloo",
                "Southwark",
                "London Bridge",
                "Bermondsey",
                "Canada Water",
                "Canary Wharf",
                "North Greenwich",
                "Canning Town",
                "West Ham",
                "Stratford"
            };

            var jubileeLineDistances = new double[]
            {
                2.0,    // Stanmore           to Canons Park
                3.0,    // Canons Park        to Queensbury
                2.0,    // Queensbury         to Kingsbury
                4.0,    // Kingsbury          to Wembley Park
                3.0,    // Wembley Park       to Neasden
                2.0,    // Neasden            to Dollis Hill
                2.0,    // Dollis Hill        to Willesden Green
                2.0,    // Willesden Green    to Kilburn
                2.0,    // Kilburn            to West Hampstead
                1.0,    // West Hampstead     to Finchley Road
                2.0,    // Finchley Road      to Swiss Cottage
                2.0,    // Swiss Cottage      to St. John's Wood
                3.0,    // St. John's Wood    to Baker Street
                3.0,    // Baker Street       to Bond Street
                2.0,    // Bond Street        to Green Park
                3.0,    // Green Park         to Westminster
                2.0,    // Westminster        to Waterloo
                1.0,    // Waterloo           to Southwark
                2.0,    // Southwark          to London Bridge
                3.0,    // London Bridge      to Bermondsey
                2.0,    // Bermondsey         to Canada Water
                3.0,    // Canada Water       to Canary Wharf
                2.0,    // Canary Wharf       to North Greenwich
                3.0,    // North Greenwich    to Canning Town
                3.0,    // Canning Town       to West Ham
                3.0,    // West Ham           to Stratford
            };

            var victoriaLineStations = new string[]
            {
                "Brixton",
                "Stockwell",
                "Vauxhall",
                "Pimlico",
                "Victoria",
                "Green Park",
                "Oxford Circus",
                "Warren Street",
                "Euston",
                "King's Cross St. Pancras",
                "Highbury & Islington",
                "Finsbury Park",
                "Seven Sisters",
                "Tottenham Hale",
                "Blackhorse Road",
                "Walthamstow Central"
            };

            var victoriaLineDistances = new double[]
            {
                2.0,    // Brixton          to Stockwell
                3.0,    // Stockwell        to Vauxhall
                1.0,    // Vauxhall         to Pimlico
                2.0,    // Pimlico          to Victoria
                2.0,    // Victoria         to Green Park
                2.0,    // Green Park       to Oxford Circus
                2.0,    // Oxford Circus    to Warren Street
                1.0,    // Warren Street    to Euston
                2.0,    // Euston           to King's Cross St. Pancras
                3.0,    // King's Cross     to Highbury & Islington
                3.0,    // Highbury & Islington to Finsbury Park
                4.0,    // Finsbury Park    to Seven Sisters
                2.0,    // Seven Sisters    to Tottenham Hale
                2.0,    // Tottenham Hale   to Blackhorse Road
                2.0     // Blackhorse Road  to Walthamstow Central
            };

            var circleLineStations = new string[]
            {
                "Hammersmith",
                "Goldhawk Road",
                "Shepherd's Bush Market",
                "Wood Lane",
                "Latimer Road",
                "Ladbroke Grove",
                "Westbourne Park",
                "Royal Oak",
                "Paddington",
                "Edgware Road",
                "Baker Street",
                "Great Portland Street",
                "Euston Square",
                "King's Cross St. Pancras",
                "Farringdon",
                "Barbican",
                "Moorgate",
                "Liverpool Street",
                "Aldgate",
                "Tower Hill",
                "Monument",
                "Cannon Street",
                "Mansion House",
                "Blackfriars",
                "Temple",
                "Embankment",
                "Westminster",
                "St. James's Park",
                "Victoria",
                "Sloane Square",
                "South Kensington",
                "Gloucester Road",
                "High Street Kensington",
                "Notting Hill Gate",
                "Bayswater",
                "Paddington (inner)",
                "Edgware Road (inner)"
            };

            var circleLineDistances = new double[]
            {
                2.0,    // Hammersmith                to Goldhawk Road
                1.0,    // Goldhawk Road              to Shepherd's Bush Market
                1.0,    // Shepherd's Bush Market     to Wood Lane
                1.0,    // Wood Lane                  to Latimer Road
                1.0,    // Latimer Road               to Ladbroke Grove
                2.0,    // Ladbroke Grove             to Westbourne Park
                2.0,    // Westbourne Park            to Royal Oak
                1.0,    // Royal Oak                  to Paddington
                2.0,    // Paddington                 to Edgware Road (Circle)
                2.0,    // Edgware Road (Circle)      to Baker Street
                2.0,    // Baker Street               to Great Portland Street
                2.0,    // Great Portland Street      to Euston Square
                2.0,    // Euston Square              to King's Cross St. Pancras
                3.0,    // King's Cross St. Pancras   to Farringdon
                2.0,    // Farringdon                 to Barbican
                1.0,    // Barbican                   to Moorgate
                2.0,    // Moorgate                   to Liverpool Street
                2.0,    // Liverpool Street           to Aldgate
                2.0,    // Aldgate                    to Tower Hill
                2.0,    // Tower Hill                 to Monument
                1.0,    // Monument                   to Cannon Street
                1.0,    // Cannon Street              to Mansion House
                1.0,    // Mansion House              to Blackfriars
                2.0,    // Blackfriars                to Temple
                1.0,    // Temple                     to Embankment
                2.0,    // Embankment                 to Westminster
                1.0,    // Westminster                to St. James's Park
                2.0,    // St. James's Park           to Victoria
                2.0,    // Victoria                   to Sloane Square
                2.0,    // Sloane Square              to South Kensington
                2.0,    // South Kensington           to Gloucester Road
                3.0,    // Gloucester Road            to High Street Kensington
                2.0,    // High Street Kensington     to Notting Hill Gate
                2.0,    // Notting Hill Gate          to Bayswater
                2.0,    // Bayswater                  to Paddington (inner)
                2.0     // Paddington (inner)         to Edgware Road (inner)
            };

            var overgroundLineStations = new string[]
            {
                "Richmond",
                "Kew Gardens",
                "Gunnersbury",
                "South Acton",
                "Acton Central",
                "Willesden Junction",
                "Kensal Rise",
                "Brondesbury Park",
                "Brondesbury",
                "West Hampstead",
                "Finchley Road & Frognal",
                "Hampstead Heath",
                "Gospel Oak",
                "Kentish Town West",
                "Camden Road",
                "Caledonian Road & Barnsbury",
                "Highbury & Islington",
                "Canonbury",
                "Dalston Kingsland",
                "Hackney Central",
                "Homerton",
                "Hackney Wick",
                "Stratford"
            };

            var overgroundLineDistances = new double[]
            {
                3.0,    // Richmond                        to Kew Gardens
                3.0,    // Kew Gardens                     to Gunnersbury
                3.0,    // Gunnersbury                     to South Acton
                3.0,    // South Acton                     to Acton Central
                4.0,    // Acton Central                   to Willesden Junction
                3.0,    // Willesden Junction              to Kensal Rise
                2.0,    // Kensal Rise                     to Brondesbury Park
                2.0,    // Brondesbury Park                to Brondesbury
                1.0,    // Brondesbury                     to West Hampstead
                2.0,    // West Hampstead                  to Finchley Road & Frognal
                2.0,    // Finchley Road & Frognal         to Hampstead Heath
                2.0,    // Hampstead Heath                 to Gospel Oak
                2.0,    // Gospel Oak                      to Kentish Town West
                3.0,    // Kentish Town West               to Camden Road
                3.0,    // Camden Road                     to Caledonian Road & Barnsbury
                2.0,    // Caledonian Road & Barnsbury     to Highbury & Islington
                1.0,    // Highbury & Islington            to Canonbury
                2.0,    // Canonbury                       to Dalston Kingsland
                2.0,    // Dalston Kingsland               to Hackney Central
                2.0,    // Hackney Central                 to Homerton
                3.0,    // Homerton                        to Hackney Wick
                3.0,    // Hackney Wick                    to Stratford
            };

            var bakerlooLineStations = new string[]
            {
                "Embankment",
                "Charing Cross",
                "Piccadilly Circus",
                "Oxford Circus",
                "Regent's Park",
                "Baker Street"
            };

            var bakerlooLineDistances = new double[]
            {
                1.0,    // Embankment             to Charing Cross
                2.0,    // Charing Cross          to Piccadilly Circus
                2.0,    // Piccadilly Circus      to Oxford Circus
                2.0,    // Oxford Circus          to Regent's Park
                2.0     // Regent's Park          to Baker Street
            };

            var centralLineStations = new string[]
            {
                "White City",
                "Shepherd's Bush",
                "Holland Park",
                "Notting Hill Gate",
                "Queensway",
                "Lancaster Gate",
                "Marble Arch",
                "Bond Street",
                "Oxford Circus",
                "Tottenham Court Road",
                "Holborn",
                "Chancery Lane",
                "St. Paul's",
                "Bank",
                "Liverpool Street"
            };

            var centralLineDistances = new double[]
            {
                2.0,    // White City                to Shepherd's Bush
                2.0,    // Shepherd's Bush           to Holland Park
                1.0,    // Holland Park              to Notting Hill Gate
                2.0,    // Notting Hill Gate         to Queensway
                2.0,    // Queensway                 to Lancaster Gate
                2.0,    // Lancaster Gate            to Marble Arch
                1.0,    // Marble Arch               to Bond Street
                2.0,    // Bond Street               to Oxford Circus
                1.0,    // Oxford Circus             to Tottenham Court Road
                2.0,    // Tottenham Court Road      to Holborn
                2.0,    // Holborn                   to Chancery Lane
                2.0,    // Chancery Lane             to St. Paul's
                2.0,    // St. Paul's                to Bank
                2.0     // Bank                      to Liverpool Street
            };

            var piccadillyLineStations = new string[]
            {
                "Hammersmith",
                "Barons Court",
                "Earl's Court",
                "Gloucester Road",
                "South Kensington",
                "Knightsbridge",
                "Hyde Park Corner",
                "Green Park",
                "Piccadilly Circus",
                "Leicester Square",
                "Covent Garden",
                "Holborn",
                "Russell Square",
                "King's Cross St. Pancras"
            };

            var piccadillyLineDistances = new double[]
            {
                2.0,    // Hammersmith                  to Barons Court
                3.0,    // Barons Court                 to Earl's Court
                2.0,    // Earl's Court                 to Gloucester Road
                1.0,    // Gloucester Road              to South Kensington
                3.0,    // South Kensington             to Knightsbridge
                1.0,    // Knightsbridge                to Hyde Park Corner
                2.0,    // Hyde Park Corner             to Green Park
                1.0,    // Green Park                   to Piccadilly Circus
                2.0,    // Piccadilly Circus            to Leicester Square
                1.0,    // Leicester Square             to Covent Garden
                2.0,    // Covent Garden                to Holborn
                1.0,    // Holborn                      to Russell Square
                2.0     // Russell Square               to King's Cross St. Pancras
            };

            var northernLineWestStations = new string[]
            {
                "Euston",
                "Warren Street",
                "Goodge Street",
                "Tottenham Court Road",
                "Leicester Square",
                "Charing Cross",
                "Embankment"
            };

            var northernLineWestDistances = new double[]
            {
                1.0,    // Euston                    to Warren Street
                2.0,    // Warren Street             to Goodge Street
                1.0,    // Goodge Street             to Tottenham Court Road
                1.0,    // Tottenham Court Road      to Leicester Square
                2.0,    // Leicester Square          to Charing Cross
                1.0     // Charing Cross             to Embankment
            };
            var northernLineEastStations = new string[]
            {
                "Moorgate",
                "Bank"
            };

            var northernLineEastDistances = new double[]
            {
                2.0,    // Moorgate     to Bank
            };

            // Create lines
            var jubileeLine = SetLine("Jubilee", "gray", jubileeLineStations, jubileeLineDistances);
            var victoriaLine = SetLine("Victoria", "blue", victoriaLineStations, victoriaLineDistances);
            var circleLine = SetLine("Circle", "yellow", circleLineStations, circleLineDistances);
            var londonOverground = SetLine("Overground", "orange", overgroundLineStations, overgroundLineDistances);
            var bakerlooLine = SetLine("Bakerloo", "brown", bakerlooLineStations, bakerlooLineDistances);
            var centralLine = SetLine("Central", "red", centralLineStations, centralLineDistances);
            var piccadillyLine = SetLine("Piccadilly", "dark blue", piccadillyLineStations, piccadillyLineDistances);
            var northernLine = SetLine("Northern", "black", northernLineWestStations, northernLineWestDistances);

            var newStation1 = new Station(northernLineEastStations[0], new IStation[0]);
            var newStation2 = new Station(northernLineEastStations[1], new IStation[0]);
            newStation1.SetLine(northernLine);
            newStation2.SetLine(northernLine);
            var adjList1 = new WeightedLinkedList<IStation, ITrack>();
            var adjList2 = new WeightedLinkedList<IStation, ITrack>();
            var track1 = new Track(northernLineEastDistances[0]);
            var track2 = new Track(northernLineEastDistances[0]);
            adjList1.InsertAtHead(newStation2, track1);
            adjList2.InsertAtHead(newStation1, track2);
            northernLine.AddStation(newStation1, adjList1);
            northernLine.AddStation(newStation2, adjList2);


            centralLine.GetStation("White City").AddChange(circleLine.GetStation("Wood Lane"));
            circleLine.GetStation("Wood Lane").AddChange(centralLine.GetStation("White City"));
            northernLine.GetStation("Bank").AddChange(circleLine.GetStation("Monument"));
            circleLine.GetStation("Monument").AddChange(northernLine.GetStation("Bank"));
            circleLine.GetStation("Paddington (inner)").AddChange(circleLine.GetStation("Paddington"));
            circleLine.GetStation("Paddington").AddChange(circleLine.GetStation("Paddington (inner)"));
            circleLine.GetStation("Edgware Road (inner)").AddChange(circleLine.GetStation("Edgware Road"));
            circleLine.GetStation("Edgware Road").AddChange(circleLine.GetStation("Edgware Road (inner)"));
            AddChangeBetweenStations(new ILine[] { jubileeLine, victoriaLine, piccadillyLine }, "Green Park");
            AddChangeBetweenStations(new ILine[] { jubileeLine, circleLine, bakerlooLine }, "Baker Street");
            AddChangeBetweenStations(new ILine[] { jubileeLine, circleLine }, "Westminster");
            AddChangeBetweenStations(new ILine[] { victoriaLine, circleLine }, "Victoria");
            AddChangeBetweenStations(new ILine[] { victoriaLine, circleLine, piccadillyLine }, "King's Cross St. Pancras");
            AddChangeBetweenStations(new ILine[] { jubileeLine, londonOverground }, "West Hampstead");
            AddChangeBetweenStations(new ILine[] { jubileeLine, londonOverground }, "Finchley Road & Frognal");
            AddChangeBetweenStations(new ILine[] { jubileeLine, londonOverground }, "Stratford");
            AddChangeBetweenStations(new ILine[] { jubileeLine, londonOverground }, "Highbury & Islington");
            AddChangeBetweenStations(new ILine[] { bakerlooLine, victoriaLine, centralLine }, "Oxford Circus");
            AddChangeBetweenStations(new ILine[] { bakerlooLine, circleLine, northernLine }, "Embankment");
            AddChangeBetweenStations(new ILine[] { centralLine, jubileeLine }, "Bond Street");
            AddChangeBetweenStations(new ILine[] { centralLine, circleLine }, "Notting Hill Gate");
            AddChangeBetweenStations(new ILine[] { centralLine, circleLine }, "Liverpool Street");
            AddChangeBetweenStations(new ILine[] { piccadillyLine, circleLine }, "Hammersmith");
            AddChangeBetweenStations(new ILine[] { piccadillyLine, circleLine }, "South Kensington");
            AddChangeBetweenStations(new ILine[] { piccadillyLine, bakerlooLine }, "Piccadilly Circus");
            AddChangeBetweenStations(new ILine[] { piccadillyLine, centralLine }, "Holborn");
            AddChangeBetweenStations(new ILine[] { northernLine, victoriaLine }, "Warren Street");
            AddChangeBetweenStations(new ILine[] { northernLine, victoriaLine }, "Euston");
            AddChangeBetweenStations(new ILine[] { northernLine, bakerlooLine }, "Charing Cross");
            AddChangeBetweenStations(new ILine[] { northernLine, centralLine }, "Tottenham Court Road");
            AddChangeBetweenStations(new ILine[] { northernLine, piccadillyLine }, "Leicester Square");
            AddChangeBetweenStations(new ILine[] { northernLine, circleLine }, "Moorgate");
            AddChangeBetweenStations(new ILine[] { northernLine, centralLine }, "Bank");

            var lines = new ILine[]
            {
                jubileeLine,
                victoriaLine,
                circleLine,
                londonOverground,
                bakerlooLine,
                centralLine,
                piccadillyLine,
                northernLine
            };

            return lines;
        }
    }
}
	





