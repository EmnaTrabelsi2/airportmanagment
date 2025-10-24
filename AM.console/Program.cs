

using AM.applicationcore.domaine;
using AM.applicationcore.Services;
using AM.infra;
using AMapplicationcore;
using static System.Runtime.InteropServices.JavaScript.JSType;




FlightMethods flight=new FlightMethods();
flight.Flights = TestData.listFlights;
IList<DateTime> parisFlights = flight.GetFlightDates("Paris");
foreach (var date in parisFlights)
{
    Console.WriteLine(date);
}
Passenger pass2 = new Passenger()
{ FirstName = "test",
    LastName = "test",
    EmailAddress = "test"
};
pass2.UperFullName();

        Console.WriteLine(pass2.FirstName);
Console.WriteLine(pass2.LastName);
AMcontext ctx= new AMcontext();
//ctx.Planes.Add(TestData.Airbusplane);
//ctx.SaveChanges();
//Console.WriteLine("ajout avec sucee");
//ctx.Flghts.Add(TestData.flight2);
//ctx.SaveChanges();
//Console.WriteLine("ajout avec sucee"));
foreach (var item in ctx.Flghts )
{  Console.WriteLine(item.Destination,item.Planes.Capacity); }