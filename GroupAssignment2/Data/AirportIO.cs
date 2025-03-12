using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment2.Data
{
    public class AirportManager
    {
        // File path where airports.csv is stored
        private const string PATH = @"..\..\..\..\Resources\res\airports.csv";

        // csv separator
        private const char sep = ',';

        private static List<Airport> airports = new List<Airport>();
        public AirportManager()
        {
            PopulateAirports();
        }

        public static List<Airport> GetAirports()
        {
            return airports;
        }

        public void AddAirport(Airport airport)
        {
            airports.Add(airport);
        }


        /// <summary>
        /// Reads the airports.csv file and returns a list of the airport codes and names
        /// </summary>
        /// <returns>List of Airport objects</returns>
        /// 

        private void PopulateAirports()
        {
            airports.Clear();

            FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            string[] fields;
            Airport airport;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine()!;
                fields = line.Split(sep);
                airport = new Airport(fields[0], fields[1]); // create the airport object
                airports.Add(airport); // add airport object to list
            }

            sr.Close();
        } // IO 
    } // class
} // namespace
