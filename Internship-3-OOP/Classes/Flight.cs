using System.Xml.Linq;

namespace Internship_3_OOP.Classes
{
    public class Flight
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Distance { get; set; }
        public TimeSpan FlightTime { get; set; }

        public Flight(int ID, string title, DateTime startDate, DateTime endDate, double distance, TimeSpan flightTime)
        {
            this.ID = ID;
            this.Title = title;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Distance = distance;
            this.FlightTime = flightTime;
        }
    }
}
