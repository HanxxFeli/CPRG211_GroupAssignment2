using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroupAssignment2.Data
{
    public class ReservationManager
    {
        private static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\Resources\Res\reservations.json");
        public static List<Reservation> reservations = new List<Reservation>();// static one copy of class 
        
        public ReservationManager() 
        {
            PopulateReservations();
        }

        public static void MakeReservation(string reservationCode, string name, string citizenship, Flight selectedflight)
        {
            Reservation reservation = new Reservation(reservationCode, selectedflight, name, citizenship);
            reservations.Add(reservation);
            SaveReservations(reservations);
        }

        public static List<Reservation> FindReservations(string resCode, string airline="", string custName ="")
        {
            List<Reservation> foundByResCode = new List<Reservation>(); // list with ResCode
            List<Reservation> foundByAirline = new List<Reservation>(); // list with Airline
            List<Reservation> foundByCustName = new List<Reservation>();// list with CustName
            
            //using ResCode
            foreach(Reservation reservation in reservations)
            {
                if(reservation.ReservationCode == resCode)
                {
                    foundByResCode.Add(reservation);
                    return foundByResCode;
                }
                //if(reservation.AirLine  == airline)
                //{
                //    foundByAirline.Add(reservation);
                //    return foundByAirline;
                //}
                if(reservation.Name == custName)
                {
                    foundByCustName.Add(reservation);
                    return foundByCustName;
                }
            }
            return foundByResCode;
        }
        /// <summary>
        /// Name:Enzo
        /// Generates Reservation Code When Called
        /// </summary>
        /// Generates a Code for reservations
        /// in the FORMAT LDDDD
        /// <returns></returns>
        /// returns Generated Code in LDDDD format for reservation
        public static string GenerateReservationCode()
        {
            Random rnd = new Random();
            string b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int length = 4;
            string random = "";
            for(int i = 0; i < 1; i++)
            {
                int a = rnd.Next(26);
                random = random + b.ElementAt(a);
            }
            for(int i = 0; i < length; i++)
            {
                int sz = rnd.Next(10);
                random += sz;
            }
            string randomCode = random.ToString();
            return randomCode;
        }
        /// <summary>
        /// Name:Enzo
        /// takes list of reservations objects
        /// and saves them for later use
        /// </summary>
        /// serializes objects to json
        /// <param name="res">list of objects</param>
        public static void SaveReservations(List<Reservation> res)
        {
            // serialization 1 : defining JsonSerializaerOptions
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented=true};
            //  serialize a list of objects to JSON
            string jsonString = JsonSerializer.Serialize(res, options);
            // 3 writing to json file for reservations
            File.WriteAllText(filePath, jsonString);
        }

        public void PopulateReservations()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
            var jsonData = File.ReadAllText(filePath);
            reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonData);
        }

        public static List<Reservation> GetReservations() {
            return reservations;
        }

        public static void CheckInformation(string name, string citizenship, Flight selectedFlight)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(citizenship))
            {
                throw new Exception("All fields must not be empty");
            }

            if (selectedFlight == null) {
                throw new Exception("Please select a flight");
            }
        }

        public static void CheckInformation(string name, string citizenship, string status, string code)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(citizenship) || string.IsNullOrEmpty(status))
            {
                throw new Exception("All fields must be filled");
            }

            foreach (Reservation reservation in reservations)
            {
                if (reservation.Name == name && reservation.Citizenship == citizenship && reservation.ReservationCode == code && reservation.Status == status)
                {
                    throw new Exception("Nothing change");
                }
            }
        }
    }
}
