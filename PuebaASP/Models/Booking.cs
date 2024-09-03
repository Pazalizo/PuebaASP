namespace PuebaASP.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int Code { get; set; }

        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

    }
}
