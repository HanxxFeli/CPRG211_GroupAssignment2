using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment2.Data
{
    public static class FlightManager
    {
        
        //To read the flights in the flights.csv 
        public static List<Flight> AddFlights()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\flights.csv");
            List<Flight> flights = new List<Flight>();
            using (StreamReader sw = new StreamReader(filePath))
            {

                string line;
                string[] parts;
                Flight flight;
                while (!sw.EndOfStream)
                {
                    line = sw.ReadLine();
                    parts = line.Split(',');
                    flight = new Flight(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], Convert.ToInt32(parts[6]), Convert.ToDouble(parts[7]));
                    flights.Add(flight);
                }
                
            }

            return flights;
        }

        //To write editted flights in the flights.csv file
        public static void WriteFlight(List<Flight>flights)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\flights.csv");
            using (StreamWriter sw= new StreamWriter(filePath))
            {
                foreach (Flight f in flights)
                {
                    sw.WriteLine(f.ToString());
                }
            }

        }

        //Used to reduce seat number by 1 when reservation is made
        public static void ReduceSeat(string flightCode, List<Flight>flights)
        {
            foreach (Flight f in flights)
            {
                if (f.FlightCode.Equals(flightCode))
                {
                    f.Seat--;
                    break;//To stop the loop when the change is made
                }
            }
        }

        //Used to add seat number by 1 when a reservation is marked as inactive
        public static void AddSeat(string flightCode, List<Flight> flights)
        {
            foreach (Flight f in flights)
            {
                if (f.FlightCode.Equals(flightCode))
                {
                    f.Seat++;
                    break;//To stop the loop when the change is made
                }
            }
        }

        //To find flights according to departures, arrivals and day
        public static List<Flight> FindFlights(string from, string to, string day)
        {
            List<Flight> flights = FlightManager.AddFlights();
            List<Flight> foundFromFlights = new List<Flight>();
            List<Flight> foundToFlights = new List<Flight>();
            List<Flight> foundDayFlights = new List<Flight>();

            //Filter out departures
            foreach (Flight flight in flights)
            {
                if (flight.From.Equals(from))
                {
                    foundFromFlights.Add(flight);
                }
                else if (from.Equals("Any"))
                {
                    foundFromFlights.Add(flight);
                }
                
            }

            //Filter out arrivals
            foreach (Flight flight in foundFromFlights)
            {
                if (flight.To.Equals(to))
                {
                    foundToFlights.Add(flight);
                }
                else if (to.Equals("Any"))
                {
                    foundToFlights.Add(flight);
                }

            }

            //Filter out days
            foreach (Flight flight in foundToFlights)
            {
                if (flight.Day.Equals(day))
                {
                    foundDayFlights.Add(flight);
                }
                else if (day.Equals("Any"))
                {
                    foundDayFlights.Add(flight);
                }

            }
            if (foundDayFlights.Count == 0)
            {
                throw new Exception("No Flight was Found");
            }

            return foundDayFlights;
        }

        public static HashSet<string> GetAirlines()
        {
            HashSet<string> airlines = new HashSet<string>();
            foreach (Flight flight in AddFlights())
            {
                airlines.Add(flight.FlightName);
            }
            return airlines;
        }
    }
}
