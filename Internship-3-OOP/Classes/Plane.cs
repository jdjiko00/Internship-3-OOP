namespace Internship_3_OOP.Classes
{
    public class Plane : Date
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public List<SeatCategory> SeatCount { get; set; } = [];

        public Plane(int ID, string name, int productionYear, List<SeatCategory> seatCount)
        {
            this.ID = ID;
            this.Name = name;
            this.ProductionYear = productionYear;
            this.SeatCount = seatCount;
        }
    }
}
