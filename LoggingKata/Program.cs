using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    //This appilcation will calculate the two Taco Bell locations that are farthest apart.
    //Locations will be from a .CSV file.
    //Each location will be an object with a name, longitude and latitude.
    //Will use longitude and latitude to calculate distance.
    //will loop through all locations to find the two furthest apart.
    class Program
    {
        static readonly ILog logger = new TacoLogger(); //This will allow me to log. Log.Warning or log.info.
        const string csvPath = "TacoBell-US-AL.csv"; //Declaring my .CSV file as csvPath.

        static void Main(string[] args)
        {
            
            //Writes to console
            logger.LogInfo("Log initialized . . . .");

            
            
            var lines = File.ReadAllLines(csvPath); //Grabs all lines from my .CSV file.

            // Log and error if you get 0 lines and a warning if you get 1 line
            if (lines.Length == 0)
            {
                logger.LogError("file has no input");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("file only has one line of input");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser(); 

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //Select method - (Foreach line in lines, im going to parse lines and store it in locations).
            //Turns it into an array
            //Turns it into an ITrackable by storing it in locations.
            ITrackable[] locations = lines.Select(line => parser.Parse(line)).ToArray();

            

            // I Created two ITrackable variables with initial values of null.
            // These will be used to store the two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            // This will allow us to use cordinates


            // Did a loop for my locations to grab each location as the origin.
            for (int i = 0; i < locations.Length; i++)
            //j is nested in i, i will remain at 0 until j loops through all lines (237 times)
            //then i will increment too 1 and j will loop through all lines again.
            //each time comparing the distance between i and j.
            //at the end it will tell us the furthest apart.
            {

                var locA = locations[i]; //Whatever i is equal too will be location a.

                // Created a new corA Coordinate with your locA's lat and long
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                // Created another loop on the locations with the scope of your first loop, so you can grab the "destination" location.
                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    // Created a new Coordinate with my locB's lat and long
                    // Now, compare the two using `.GetDistanceTo()`,
                    // which looks at two locations with lat and long and gets the distance between them.
                    // which returns a double.

                    var corB = new GeoCoordinate();
                    corB.Latitude = locB.Location.Latitude;
                    corB.Longitude = locB.Location.Longitude;

                    // If the distance is greater than the currently saved distance,
                    // update the distance and the two `ITrackable` variables you set above
                    double distanceBetween = corA.GetDistanceTo(corB);
                    if (distanceBetween > distance)
                    {
                        distance = distanceBetween;
                        tacoBell1 = locA;
                        tacoBell2 = locB;
                    }
                }

                


            }


            // Once its looped through everything, its found the two Taco Bells farthest away from each other.

            logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are {Math.Round(distance * 0.00062)} miles apart.");



        }
    }
}
