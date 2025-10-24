using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.applicationcore.domaine
{
    public class Ticket

    {
        public int  siege{ get; set; }
        public float prix{ get; set; }
        public string VIP{ get; set; }
        public virtual Passenger passenger { get; set; }
        public virtual Flight flight { get; set; }
        [ForeignKey("flight")]
        public int flight_fk { get; set; }
        [ForeignKey("passenger")]

        public  string passenger_fk { get; set; }

    }
}
