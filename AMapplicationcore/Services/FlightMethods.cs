using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using AM.applicationcore.domaine;
using AM.applicationcore.Interfaces;

namespace AM.applicationcore.Services
{
    public class FlightMethods: IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IList<DateTime> GetFlightDates(string destination)
        {            //IList<DateTime> dates = new List<DateTime>();

            // Boucle for - on contrôle l'index
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //  Flight currentFlight = Flights[i];

            //if (currentFlight.Destination == destination)
            //{
            //  dates.Add(currentFlight.FlightDate);
            //}
            //}

            //return dates;
            //IList<DateTime> dates = new List<DateTime>();
            //foreach (Flight f in Flights)
            //{

            //    if (f.Destination == destination)
            //    {
            //        dates.Add(f.FlightDate);
            //    }
            //}
            //return dates;
            //linq
            var query = from f in Flights
                        where f.Destination == destination
                        select f.FlightDate;
            return query.ToList();
            //lambda 
            // (item=>expression)
           // return Flights.Where(f=>f.Destination==destination).Select(a=>a.FlightDate).ToList();
        }
        public void GetFlights(string filterType, string filterValue)
        {
            Console.WriteLine($"=== Vols filtrés par {filterType} = '{filterValue}' ===");

            foreach (Flight flight in Flights)
            {
                bool matches = false;

                switch (filterType.ToLower())
                {
                    case "destination":
                        matches = flight.Destination == filterValue;
                        break;

                    case "departure":
                        matches = flight.Departure == filterValue;
                        break;

                    case "flightid":
                        matches = flight.Flightid.ToString() == filterValue;
                        break;

                    case "estimatedduration":
                        matches = flight.EstimatedDuration.ToString() == filterValue;
                        break;

                    case "flightdate":
                        matches = flight.FlightDate.ToString("yyyy-MM-dd") == filterValue;
                        break;

                    default:
                        Console.WriteLine($"❌ Type de filtre non supporté: {filterType}");
                        return;
                }

                if (matches)
                {
                    DisplayFlightInfo(flight);
                }
            }
        }

        private void DisplayFlightInfo(Flight flight)
        {
            Console.WriteLine($"✈️ Vol ID: {flight.Flightid}");
            Console.WriteLine($"   Départ: {flight.Departure} → Destination: {flight.Destination}");
            Console.WriteLine($"   Date: {flight.FlightDate:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"   Durée estimée: {flight.EstimatedDuration} minutes");
            Console.WriteLine($"   Arrivée effective: {flight.EffectiveArrival:dd/MM/yyyy HH:mm}");
            Console.WriteLine("   ---");
        }
        public void ShowFlight(Plane P)
        {
            var query = from f in Flights
                        where f.Planes == P
                        select new { f.FlightDate, f.Destination };
            foreach (var item in query)
            {
                Console.Write("->Destination : " + item.Destination, ", Date: " + item.FlightDate);
            }
            // var req= Flights.Where (f=> f.Plane == P).select(f=> new { f.FlightDate, f.Destination });
            //foreach (var f in req)
            //{
              //  Console.Write("->Destination : " + f.Destination, ", Date: " + f.FlightDate);
            //}

        }

        public int GetFlightCount(DateTime date)
        {


            // Count flights within 7 days starting from 'date'
            var query = from f in Flights
                       // where DateTime.Compare(f.FlightDate, date) >= 0
                       //&& (f.FlightDate - date).TotalDays <= 7

                        where f.FlightDate >= date
                           && f.FlightDate < date.AddDays(7)
                        select f;
            return query.Count();
            //return Flights.Count(DateTime.Compare(f.FlightDate, date) >= 0
            //&& (f.FlightDate - date).TotalDays <= 7);
        }

        public double GetAverageDuration(string destination)
        {
            var query = from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDuration;
            return query.Average();
            //return Flights.where(f=>f.Destination == destination).Average(f=>f.EstimatedDuration);
        }

        public IEnumerable<Flight> GetFlightsOrderedByDuration()
        {
            var query = from f in Flights
                        orderby f.EstimatedDuration descending
                        select f;

            return query;
            //return Flights.OrderbyDescending(f => f.EstimatedDuration)
        }
     
        //on travaille avec linumeable<liste> car structure imodifiable
        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from p in flight.Passengers.OfType<Traveller>()
                        orderby p.BirthDate ascending
                        select p;

            return query.Take(3);
            //return flight.Passengers.OfType<Traveller>().OrderBy(a => a.BirthDate).Take(3);
        }

        public void ShowFlightsGroupedByDestination()
        {
            var query = from f in Flights
                        group f by f.Destination;

            foreach (var group in query)
            {
                Console.WriteLine($"Destination {group.Key}");
                foreach (var flight in group)
                {
                    Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
                }
            }
        }

        

        public void Showflight(Plane P)
        {
            throw new NotImplementedException();
        }
    }
    //lambda 
       // (item=>expression)
}
