using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.domaine
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int Flightid { get; set; }
        [ForeignKey("Plane")]
        public int PlaneFK { get; set; }

        public virtual Plane Planes { get; set; }
        public  virtual ICollection<Ticket> ticket { get; set; }
        //public string airline { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }

        public override string ToString()
        {
            return
                   $"From {Departure} to {Destination} " +
                   $"on {FlightDate:dd/MM/yyyy} " +
                   $"(Arrives: {EffectiveArrival:dd/MM/yyyy HH:mm}, " +
                   $"Duration: {EstimatedDuration}h) " +
                   $"\nPlane: {Planes} ";
        }
    }
}