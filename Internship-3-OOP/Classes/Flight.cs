namespace Internship_3_OOP.Classes
{
    public class Flight : Date
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DepartuePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public DateTime DepartueDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double Distance { get; set; }
        public Plane Plane { get; set; }
        public Crew Crew { get; set; }

        public Flight(int ID, string name, string departurePlace, string arrivalPlace, DateTime departueDate, DateTime arrivalDate, double distance, Plane plane, Crew crew)
        {
            this.ID = ID;
            this.Name = name;
            this.DepartuePlace = departurePlace;
            this.ArrivalPlace = arrivalPlace;
            this.DepartueDate = departueDate;
            this.ArrivalDate = arrivalDate;
            this.Distance = distance;
            this.Plane = plane;
            this.Crew = crew;
        }
    }
}
