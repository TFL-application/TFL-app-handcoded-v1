using System;
using TFLAppHandcoded.Dictionary;
using TFLAppHandcoded.Interfaces;

namespace TFLAppHandcoded.tests
{
	public static class TestData
	{
        public static ILine[] GetSimpleTestData()
        {
            // 1. Create a line
            var victoriaLine = new Line("Victoria", "blue");
            // 2. Create stations
            var greenPark1 = new Station("Green Park", new IStation[0]);
            var victoria = new Station("Victoria", new IStation[0]);
            // 3. Set station's line
            greenPark1.SetLine(victoriaLine);
            victoria.SetLine(victoriaLine);
            // 4. Create tracks betweeen stations both ways
            var victoriaGPTrack = new Track(2.0);
            var GPCictoriaTrack = new Track(2.0);
            // 5. Create adjacency lists for the stations
            var victoriaAdj = new WeightedLinkedList<IStation, ITrack>(greenPark1, victoriaGPTrack);
            var gpAdj = new WeightedLinkedList<IStation, ITrack>(victoria, GPCictoriaTrack);
            // 6. Add station to the line
            victoriaLine.AddStation(victoria, victoriaAdj);
            victoriaLine.AddStation(greenPark1, gpAdj);
            // 7. Add connections
            // None for the first line

            // 1. Create a line
            var jubileeLine = new Line("Jubilee", "gray");
            // 2. Create stations
            var greenPark2 = new Station("Green Park", new IStation[0]);
            var westminster = new Station("Westminster", new IStation[0]);
            var waterloo = new Station("Waterloo", new IStation[0]);
            // 3. Set station's line
            greenPark2.SetLine(jubileeLine);
            westminster.SetLine(jubileeLine);
            waterloo.SetLine(jubileeLine);
            // 4. Create tracks betweeen stations both ways
            var GPWestminsterTrack = new Track(3.0);
            var westminsterGPTrack = new Track(3.0);
            var westminsterWaterlooTrack = new Track(3.0);
            var waterlooWestminsterTrack = new Track(3.0);
            // 5. Create adjacency lists for the stations
            var gp2Adj = new WeightedLinkedList<IStation, ITrack>(westminster, GPWestminsterTrack);
            var westminsterAdj = new WeightedLinkedList<IStation, ITrack>(greenPark2, westminsterGPTrack);
            westminsterAdj.InsertAtHead(waterloo, westminsterWaterlooTrack);
            var waterlooAdj = new WeightedLinkedList<IStation, ITrack>(westminster, waterlooWestminsterTrack);
            // 6. Add station to the line
            jubileeLine.AddStation(greenPark2, gp2Adj);
            jubileeLine.AddStation(westminster, westminsterAdj);
            jubileeLine.AddStation(waterloo, waterlooAdj);
            // 7. Add connections - in pairs
            greenPark2.AddChange(greenPark1);
            greenPark1.AddChange(greenPark2);

            // 1. Create a line
            var circle = new Line("Circle", "yellow");
            // 2. Create stations
            var victoria2 = new Station("Victoria", new IStation[0]);
            var stjames = new Station("St James Park", new IStation[0]);
            var westminster2 = new Station("Westminster", new IStation[0]);
            var enbankment = new Station("Enbankment", new IStation[0]);
            // 3. Set station's line
            victoria2.SetLine(circle);
            stjames.SetLine(circle);
            westminster2.SetLine(circle);
            enbankment.SetLine(circle);
            // 4. Create tracks betweeen stations both ways
            var victoriaStJamesTrack = new Track(1.0);
            var stJamesVictoriaTrack = new Track(1.0);
            var stJamesWestminsterTrack = new Track(2.0);
            var westminsterStJamesTrack = new Track(2.0);
            var westminsterEnbankmentTrack = new Track(2.5);
            var enbankmentWestminsterTrack = new Track(2.0);
            // 5. Create adjacency lists for the stations
            var victoria2Adj = new WeightedLinkedList<IStation, ITrack>(stjames, victoriaStJamesTrack);
            var stJamesAdj = new WeightedLinkedList<IStation, ITrack>(victoria2, stJamesVictoriaTrack);
            stJamesAdj.InsertAtHead(westminster2, stJamesWestminsterTrack);
            var westminster2Adj = new WeightedLinkedList<IStation, ITrack>(stjames, westminsterStJamesTrack);
            westminster2Adj.InsertAtHead(enbankment, westminsterEnbankmentTrack);
            var enbankmentAdj = new WeightedLinkedList<IStation, ITrack>(westminster2, enbankmentWestminsterTrack);
            // 6. Add station to the line
            circle.AddStation(victoria2, victoria2Adj);
            circle.AddStation(stjames, stJamesAdj);
            circle.AddStation(westminster2, westminster2Adj);
            circle.AddStation(enbankment, enbankmentAdj);
            // 7. Add connections
            westminster2.AddChange(westminster);
            westminster.AddChange(westminster2);
            victoria2.AddChange(victoria);
            victoria.AddChange(victoria2);

            var lines = new ILine[3];
            lines[0] = victoriaLine;
            lines[1] = jubileeLine;
            lines[2] = circle;

            return lines;
        }

        public static ILine SetLine(string linename, string linecolor, string[] stationnames, double[] distances)
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

        public static ILine[] GetTestData()
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
                1.5,    // Canons Park        to Queensbury
                1.0,    // Queensbury         to Kingsbury
                1.0,    // Kingsbury          to Wembley Park
                1.0,    // Wembley Park       to Neasden
                1.0,    // Neasden            to Dollis Hill
                1.0,    // Dollis Hill        to Willesden Green
                1.0,    // Willesden Green    to Kilburn
                1.0,    // Kilburn            to West Hampstead
                1.0,    // West Hampstead     to Finchley Road
                0.5,    // Finchley Road      to Swiss Cottage
                0.5,    // Swiss Cottage      to St. John's Wood
                1.0,    // St. John's Wood    to Baker Street
                0.5,    // Baker Street       to Bond Street
                1.0,    // Bond Street        to Green Park
                1.0,    // Green Park         to Westminster
                1.0,    // Westminster        to Waterloo
                1.0,    // Waterloo           to Southwark
                1.0,    // Southwark          to London Bridge
                1.0,    // London Bridge      to Bermondsey
                1.0,    // Bermondsey         to Canada Water
                1.0,    // Canada Water       to Canary Wharf
                1.0,    // Canary Wharf       to North Greenwich
                1.0,    // North Greenwich    to Canning Town
                1.0,    // Canning Town       to West Ham
                1.0,    // West Ham           to Stratford
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
                1.5,    // Stockwell        to Vauxhall
                1.0,    // Vauxhall         to Pimlico
                1.0,    // Pimlico          to Victoria
                1.0,    // Victoria         to Green Park
                1.0,    // Green Park       to Oxford Circus
                0.5,    // Oxford Circus    to Warren Street
                1.0,    // Warren Street    to Euston
                0.5,    // Euston           to King's Cross St. Pancras
                1.0,    // King's Cross     to Highbury & Islington
                1.5,    // Highbury & Islington to Finsbury Park
                1.0,    // Finsbury Park    to Seven Sisters
                1.0,    // Seven Sisters    to Tottenham Hale
                1.5,    // Tottenham Hale   to Blackhorse Road
                1.5     // Blackhorse Road  to Walthamstow Central
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
                1.0,    // Hammersmith                to Goldhawk Road
                1.0,    // Goldhawk Road              to Shepherd's Bush Market
                1.0,    // Shepherd's Bush Market     to Wood Lane
                1.0,    // Wood Lane                  to Latimer Road
                1.0,    // Latimer Road               to Ladbroke Grove
                1.0,    // Ladbroke Grove             to Westbourne Park
                1.0,    // Westbourne Park            to Royal Oak
                1.0,    // Royal Oak                  to Paddington
                1.0,    // Paddington                 to Edgware Road (Circle)
                0.5,    // Edgware Road (Circle)      to Baker Street
                0.5,    // Baker Street               to Great Portland Street
                0.5,    // Great Portland Street      to Euston Square
                1.0,    // Euston Square              to King's Cross St. Pancras
                1.0,    // King's Cross St. Pancras   to Farringdon
                1.0,    // Farringdon                 to Barbican
                1.0,    // Barbican                   to Moorgate
                1.0,    // Moorgate                   to Liverpool Street
                1.0,    // Liverpool Street           to Aldgate
                1.0,    // Aldgate                    to Tower Hill
                1.0,    // Tower Hill                 to Monument
                1.0,    // Monument                   to Cannon Street
                1.0,    // Cannon Street              to Mansion House
                1.0,    // Mansion House              to Blackfriars
                1.0,    // Blackfriars                to Temple
                1.0,    // Temple                     to Embankment
                1.0,    // Embankment                 to Westminster
                1.0,    // Westminster                to St. James's Park
                1.0,    // St. James's Park           to Victoria
                1.0,    // Victoria                   to Sloane Square
                1.0,    // Sloane Square              to South Kensington
                1.0,    // South Kensington           to Gloucester Road
                1.0,    // Gloucester Road            to High Street Kensington
                1.0,    // High Street Kensington     to Notting Hill Gate
                1.0,    // Notting Hill Gate          to Bayswater
                1.0,    // Bayswater                  to Paddington (inner)
                0.5     // Paddington (inner)         to Edgware Road (inner)
            };

            var overgroundLineStations = new string[]
            {
                "Richmond",
                "Kew Gardens",
                "Gunnersbury",
                "South Acton",
                "Acton Central",
                "Willesden Junction",
                "Kensal Green",
                "Queens Park",
                "Kilburn High Road",
                "South Hampstead",
                "West Hampstead",
                "Finchley Road & Frognal",
                "Hampstead Heath",
                "Gospel Oak",
                "Kentish Town West",
                "Camden Road",
                "Caledonian Road & Barnsbury",
                "Highbury & Islington",
                "Canonbury",
                "Dalston Junction",
                "Hackney Central",
                "Homerton",
                "Hackney Wick",
                "Stratford"
            };

            var overgroundLineDistances = new double[]
            {
                1.0,    // Richmond                        to Kew Gardens
                1.0,    // Kew Gardens                     to Gunnersbury
                1.0,    // Gunnersbury                     to South Acton
                1.0,    // South Acton                     to Acton Central
                1.0,    // Acton Central                   to Willesden Junction
                1.0,    // Willesden Junction              to Kensal Green
                1.0,    // Kensal Green                    to Queens Park
                1.0,    // Queens Park                     to Kilburn High Road
                1.0,    // Kilburn High Road               to South Hampstead
                1.0,    // South Hampstead                 to West Hampstead
                1.0,    // West Hampstead                  to Finchley Road & Frognal
                1.0,    // Finchley Road & Frognal         to Hampstead Heath
                1.0,    // Hampstead Heath                 to Gospel Oak
                1.0,    // Gospel Oak                      to Kentish Town West
                1.0,    // Kentish Town West               to Camden Road
                1.0,    // Camden Road                     to Caledonian Road & Barnsbury
                1.0,    // Caledonian Road & Barnsbury     to Highbury & Islington
                1.0,    // Highbury & Islington            to Canonbury
                1.0,    // Canonbury                       to Dalston Junction
                1.0,    // Dalston Junction                to Hackney Central
                1.0,    // Hackney Central                 to Homerton
                1.0,    // Homerton                        to Hackney Wick
                1.0,    // Hackney Wick                    to Stratford
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
                0.5,    // Embankment             to Charing Cross
                0.5,    // Charing Cross          to Piccadilly Circus
                0.5,    // Piccadilly Circus      to Oxford Circus
                0.5,    // Oxford Circus          to Regent's Park
                0.5     // Regent's Park          to Baker Street
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
                1.0,    // White City                to Shepherd's Bush
                1.0,    // Shepherd's Bush           to Holland Park
                1.0,    // Holland Park              to Notting Hill Gate
                1.0,    // Notting Hill Gate         to Queensway
                1.0,    // Queensway                 to Lancaster Gate
                1.0,    // Lancaster Gate            to Marble Arch
                1.0,    // Marble Arch               to Bond Street
                1.0,    // Bond Street               to Oxford Circus
                1.0,    // Oxford Circus             to Tottenham Court Road
                1.0,    // Tottenham Court Road      to Holborn
                1.0,    // Holborn                   to Chancery Lane
                1.0,    // Chancery Lane             to St. Paul's
                1.0,    // St. Paul's                to Bank
                1.0     // Bank                      to Liverpool Street
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
                0.5,    // Hammersmith                  to Barons Court
                0.5,    // Barons Court                 to Earl's Court
                0.5,    // Earl's Court                 to Gloucester Road
                0.5,    // Gloucester Road              to South Kensington
                0.5,    // South Kensington             to Knightsbridge
                0.5,    // Knightsbridge                to Hyde Park Corner
                0.5,    // Hyde Park Corner             to Green Park
                0.5,    // Green Park                   to Piccadilly Circus
                0.5,    // Piccadilly Circus            to Leicester Square
                0.5,    // Leicester Square             to Covent Garden
                0.5,    // Covent Garden                to Holborn
                0.5,    // Holborn                      to Russell Square
                0.5     // Russell Square               to King's Cross St. Pancras
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
                0.5,    // Euston                    to Warren Street
                0.5,    // Warren Street             to Goodge Street
                0.5,    // Goodge Street             to Tottenham Court Road
                0.5,    // Tottenham Court Road      to Leicester Square
                0.5,    // Leicester Square          to Charing Cross
                0.5     // Charing Cross             to Embankment
            };
            var northernLineEastStations = new string[]
            {
                "Moorgate",
                "Bank"
            };

            var northernLineEastDistances = new double[]
            {
                0.5,    // Moorgate     to Bank
            };

            // Create lines
            // Jubilee
            var jubileeLine = SetLine("Jubilee", "gray", jubileeLineStations, jubileeLineDistances);

            // Victoria
            var victoriaLine = SetLine("Victoria", "blue", victoriaLineStations, victoriaLineDistances);

            victoriaLine.GetStation("Green Park").AddChange(jubileeLine.GetStation("Green Park"));
            jubileeLine.GetStation("Green Park").AddChange(victoriaLine.GetStation("Green Park"));

            // Circle
            var circleLine = SetLine("Circle", "yellow", circleLineStations, circleLineDistances);

            circleLine.GetStation("Baker Street").AddChange(jubileeLine.GetStation("Baker Street"));
            jubileeLine.GetStation("Baker Street").AddChange(circleLine.GetStation("Baker Street"));
            circleLine.GetStation("Westminster").AddChange(jubileeLine.GetStation("Westminster"));
            jubileeLine.GetStation("Westminster").AddChange(circleLine.GetStation("Westminster"));

            circleLine.GetStation("Victoria").AddChange(victoriaLine.GetStation("Victoria"));
            victoriaLine.GetStation("Victoria").AddChange(circleLine.GetStation("Victoria"));
            circleLine.GetStation("King's Cross St. Pancras").AddChange(victoriaLine.GetStation("King's Cross St. Pancras"));
            victoriaLine.GetStation("King's Cross St. Pancras").AddChange(circleLine.GetStation("King's Cross St. Pancras"));

            // Overground
            var londonOverground = SetLine("Overground", "orange", overgroundLineStations, overgroundLineDistances);

            londonOverground.GetStation("West Hampstead").AddChange(jubileeLine.GetStation("West Hampstead"));
            jubileeLine.GetStation("West Hampstead").AddChange(londonOverground.GetStation("West Hampstead"));
            londonOverground.GetStation("Finchley Road & Frognal").AddChange(jubileeLine.GetStation("Finchley Road & Frognal"));
            jubileeLine.GetStation("Finchley Road & Frognal").AddChange(londonOverground.GetStation("Finchley Road & Frognal"));
            londonOverground.GetStation("Finchley Road & Frognal").AddChange(jubileeLine.GetStation("Finchley Road & Frognal"));
            jubileeLine.GetStation("Stratford").AddChange(londonOverground.GetStation("Stratford"));

            londonOverground.GetStation("Highbury & Islington").AddChange(victoriaLine.GetStation("Highbury & Islington"));
            victoriaLine.GetStation("Highbury & Islington").AddChange(londonOverground.GetStation("Highbury & Islington"));

            // Bakerloo
            var bakerlooLine = SetLine("Bakerloo", "brown", bakerlooLineStations, bakerlooLineDistances);

            bakerlooLine.GetStation("Baker Street").AddChange(jubileeLine.GetStation("Baker Street"));
            jubileeLine.GetStation("Baker Street").AddChange(bakerlooLine.GetStation("Baker Street"));

            bakerlooLine.GetStation("Oxford Circus").AddChange(victoriaLine.GetStation("Oxford Circus"));
            victoriaLine.GetStation("Oxford Circus").AddChange(bakerlooLine.GetStation("Oxford Circus"));

            bakerlooLine.GetStation("Baker Street").AddChange(circleLine.GetStation("Baker Street"));
            circleLine.GetStation("Baker Street").AddChange(bakerlooLine.GetStation("Baker Street"));
            bakerlooLine.GetStation("Embankment").AddChange(circleLine.GetStation("Embankment"));
            circleLine.GetStation("Embankment").AddChange(bakerlooLine.GetStation("Embankment"));

            // Central
            var centralLine = SetLine("Central", "red", centralLineStations, centralLineDistances);

            centralLine.GetStation("Bond Street").AddChange(jubileeLine.GetStation("Bond Street"));
            jubileeLine.GetStation("Bond Street").AddChange(centralLine.GetStation("Bond Street"));

            centralLine.GetStation("Oxford Circus").AddChange(victoriaLine.GetStation("Oxford Circus"));
            victoriaLine.GetStation("Oxford Circus").AddChange(centralLine.GetStation("Oxford Circus"));

            centralLine.GetStation("White City").AddChange(circleLine.GetStation("Wood Lane"));
            circleLine.GetStation("Wood Lane").AddChange(centralLine.GetStation("White City"));
            centralLine.GetStation("Notting Hill Gate").AddChange(circleLine.GetStation("Notting Hill Gate"));
            circleLine.GetStation("Notting Hill Gate").AddChange(centralLine.GetStation("Notting Hill Gate"));
            centralLine.GetStation("Liverpool Street").AddChange(circleLine.GetStation("Liverpool Street"));
            circleLine.GetStation("Liverpool Street").AddChange(centralLine.GetStation("Liverpool Street"));

            centralLine.GetStation("Oxford Circus").AddChange(bakerlooLine.GetStation("Oxford Circus"));
            bakerlooLine.GetStation("Oxford Circus").AddChange(centralLine.GetStation("Oxford Circus"));

            // Picadilly
            var picadillyLine = SetLine("Piccadilly", "dark blue", piccadillyLineStations, piccadillyLineDistances);

            picadillyLine.GetStation("Green Park").AddChange(jubileeLine.GetStation("Green Park"));
            jubileeLine.GetStation("Green Park").AddChange(picadillyLine.GetStation("Green Park"));

            picadillyLine.GetStation("Green Park").AddChange(victoriaLine.GetStation("Green Park"));
            victoriaLine.GetStation("Green Park").AddChange(picadillyLine.GetStation("Green Park"));
            picadillyLine.GetStation("King's Cross St. Pancras").AddChange(victoriaLine.GetStation("King's Cross St. Pancras"));
            victoriaLine.GetStation("King's Cross St. Pancras").AddChange(picadillyLine.GetStation("King's Cross St. Pancras"));

            picadillyLine.GetStation("Hammersmith").AddChange(circleLine.GetStation("Hammersmith"));
            circleLine.GetStation("Hammersmith").AddChange(picadillyLine.GetStation("Hammersmith"));
            picadillyLine.GetStation("King's Cross St. Pancras").AddChange(circleLine.GetStation("King's Cross St. Pancras"));
            circleLine.GetStation("King's Cross St. Pancras").AddChange(picadillyLine.GetStation("King's Cross St. Pancras"));
            picadillyLine.GetStation("South Kensington").AddChange(circleLine.GetStation("South Kensington"));
            circleLine.GetStation("South Kensington").AddChange(picadillyLine.GetStation("South Kensington"));

            picadillyLine.GetStation("Piccadilly Circus").AddChange(bakerlooLine.GetStation("Piccadilly Circus"));
            bakerlooLine.GetStation("Piccadilly Circus").AddChange(picadillyLine.GetStation("Piccadilly Circus"));

            picadillyLine.GetStation("Holborn").AddChange(centralLine.GetStation("Holborn"));
            centralLine.GetStation("Holborn").AddChange(picadillyLine.GetStation("Holborn"));

            // Nothern East
            var northernLineWest = SetLine("Northern", "black", northernLineWestStations, northernLineWestDistances);

            northernLineWest.GetStation("Warren Street").AddChange(victoriaLine.GetStation("Warren Street"));
            victoriaLine.GetStation("Warren Street").AddChange(northernLineWest.GetStation("Warren Street"));
            northernLineWest.GetStation("Euston").AddChange(victoriaLine.GetStation("Euston"));
            victoriaLine.GetStation("Euston").AddChange(northernLineWest.GetStation("Euston"));

            northernLineWest.GetStation("Embankment").AddChange(circleLine.GetStation("Embankment"));
            circleLine.GetStation("Embankment").AddChange(northernLineWest.GetStation("Embankment"));

            northernLineWest.GetStation("Charing Cross").AddChange(bakerlooLine.GetStation("Charing Cross"));
            bakerlooLine.GetStation("Charing Cross").AddChange(northernLineWest.GetStation("Charing Cross"));

            northernLineWest.GetStation("Tottenham Court Road").AddChange(centralLine.GetStation("Tottenham Court Road"));
            centralLine.GetStation("Tottenham Court Road").AddChange(northernLineWest.GetStation("Tottenham Court Road"));

            northernLineWest.GetStation("Leicester Square").AddChange(picadillyLine.GetStation("Leicester Square"));
            picadillyLine.GetStation("Leicester Square").AddChange(northernLineWest.GetStation("Leicester Square"));

            // Nothern West
            var northernLineEast = SetLine("Northern", "black", northernLineEastStations, northernLineEastDistances);

            northernLineEast.GetStation("Moorgate").AddChange(circleLine.GetStation("Moorgate"));
            circleLine.GetStation("Moorgate").AddChange(northernLineEast.GetStation("Moorgate"));
            northernLineEast.GetStation("Bank").AddChange(circleLine.GetStation("Monument"));
            circleLine.GetStation("Monument").AddChange(northernLineEast.GetStation("Bank"));

            northernLineEast.GetStation("Bank").AddChange(centralLine.GetStation("Bank"));
            centralLine.GetStation("Bank").AddChange(northernLineEast.GetStation("Bank"));

            var lines = new ILine[]
            {
                jubileeLine,
                victoriaLine,
                circleLine,
                londonOverground,
                bakerlooLine,
                centralLine,
                picadillyLine,
                northernLineWest,
                northernLineEast
            };

            return lines;
        }
    }
}

