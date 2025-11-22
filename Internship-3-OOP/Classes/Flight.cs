namespace Internship_3_OOP.Classes
{
    public class Flight : Date
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DepartuePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public DateTime DepartueTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Distance { get; set; }
        public Plane Plane { get; set; }
        public Crew Crew { get; set; }
        public List<SeatCategory> CurrentFlightSeatCount = new List<SeatCategory>();
        public static List<Flight> Flights = new List<Flight>();

        public Flight(string name, string departurePlace, string arrivalPlace, DateTime departueTime, DateTime arrivalTime, double distance, Plane plane, Crew crew)
        {
            ID = Guid.NewGuid();
            Name = name;
            DepartuePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            DepartueTime = departueTime;
            DepartueTime = departueTime;
            Distance = distance;
            Plane = plane;
            Crew = crew;
        }
    }
}
