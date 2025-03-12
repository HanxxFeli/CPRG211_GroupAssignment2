using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment2.Data
{
    public class Flight
    {
        public string FlightCode { get; set; }
        public string FlightName { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int Seat { get; set; }
        public  double Price { get; set; }

        public Flight(string flightCode, string flightName, string from, string to, string day, string time, int seat, double price)
        {
            FlightCode = flightCode;
            FlightName = flightName;
            From = from;
            To = to;
            Day = day;
            Time = time;
            Seat = seat;
            Price = price;
        }

        public override string ToString()
        {
            return $"{FlightCode},{FlightName},{From},{To},{Day},{Time},{Seat},{Price}";
        }
    }
}
