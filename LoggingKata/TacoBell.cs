using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    // Here I created a TacoBell class that conforms to ITrackable.
    // Forcing each Taco Bell to have a Name and Location.
    class TacoBell : ITrackable
    {
        public TacoBell()
        {

        }
        public string Name { get; set; }
        public Point Location { get; set; }

    }
}
