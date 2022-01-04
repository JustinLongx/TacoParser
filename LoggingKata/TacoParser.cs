namespace LoggingKata
{
    
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger(); 
        
        public ITrackable Parse(string line) //This method will return something that has a name and location.
            //taking a string.. and turning it into a taco bell with a name and location.
            //line its passing through will represent every single row in the .CSV file.
        {
            logger.LogInfo("Calculating Distance..."); //Will print to console "Calculating Distance...".

            // will split up every string when it sees a comma and turn it into an array of strings.
            //{"34.3453", "-84.2345", "Taco Bell Acwort..."} Indexed at {0, 1, 2}
            var cells = line.Split(',');

            // If the array.Length is less than 3, something went wrong.
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogWarning("less than three items. Incomplete data.");
                // Do not fail if one record parsing fails, return null
                return null; 
            }

            // grab the latitude from the array at index 0, parse the string as a double.
            var latitude = double.Parse(cells[0]);
            // grab the longitude from the array at index 1, parse the string as a double.
            var longitude = double.Parse(cells[1]);
            // grab the name from the array at index 2.
            var name = cells[2];


            // I created a TacoBell class that conforms to ITrackable.
            // Forcing each Taco Bell to have a Name and Location.
            

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;

            //I created a new object of the Taco Bell Class. 
            //Every Taco Bell will have a Name and Location.
            var tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;


            // Then, I returned the instance of my TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}