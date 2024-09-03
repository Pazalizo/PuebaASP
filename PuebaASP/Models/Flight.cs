namespace PuebaASP.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime FlightDate { get; set; }

        //Relation - Airport
        public int AirportOriginId { get; set; }
        public int AirportDestinationId { get; set; }

        //Navegation - Airport
        public Airport AirportOrigin { get; set; }
        public Airport AirportDestination { get; set; }

        //Relation - Plane
        public int PlaneId { get; set; }

        //Navegation - Plane
        public Plane Plane { get; set; }

        //Relation - Crew
        public int CrewId { get; set; }
        
        //Navegation - Crew
        public Crew Crew { get; set; }

    }

}
