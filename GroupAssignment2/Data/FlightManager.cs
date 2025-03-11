using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment2.Data
{
    class FlightManager
    {
        
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\flights.csv");
        public List<Flight> AddFlights()
        {
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
}
