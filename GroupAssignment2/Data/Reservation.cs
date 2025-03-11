using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignment2.Data
{
    public class Reservation
    {
        private string reservationCode;
        private Flight flight;
        private string name;
        private string citizenship;
        private string status;

        public string ReservationCode { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }

        public Flight Flight { get; set; }
        public string Status { get; set; }

        public Reservation(string reservationCode, Flight flight, string name, string citizenship, string status = "Active")
        {
            ReservationCode = reservationCode;
            Flight = flight;
            Name = name;
            Citizenship = citizenship;
            Status = status;
        }

        public override string ToString()
        {
            return $"{ReservationCode},{Flight.FlightCode},{Name},{Citizenship},{Status}";
        }
    }
}
