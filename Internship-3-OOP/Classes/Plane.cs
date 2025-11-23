using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class Plane : Date
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateOnly ProductionYear { get; set; }
        public List<SeatCategory> PlaneSeatCount = new List<SeatCategory>();
        public static List<Plane> Planes = new List<Plane>();

        public Plane(string name, DateOnly productionYear, List<SeatCategory> seatCount)
        {
            ID = Guid.NewGuid();
            Name = name;
            ProductionYear = productionYear;
            PlaneSeatCount = seatCount;
        }

        public static void InitializePlanes()
        {
            Planes.Add(new Plane("Boeing 737", new DateOnly(2010, 1, 1), new List<SeatCategory>
            {
                new SeatCategory(Category.Standard, 120),
                new SeatCategory(Category.Business, 24),
                new SeatCategory(Category.VIP, 6)
            }));

            Planes.Add(new Plane("Airbus A320", new DateOnly(2012, 5, 1), new List<SeatCategory>
            {
                new SeatCategory(Category.Standard, 150),
                new SeatCategory(Category.Business, 30),
                new SeatCategory(Category.VIP, 8)
            }));

            Planes.Add(new Plane("Embraer E190", new DateOnly(2015, 3, 15), new List<SeatCategory>
            {
                new SeatCategory(Category.Standard, 90),
                new SeatCategory(Category.Business, 10),
                new SeatCategory(Category.VIP, 0)
            }));

            Planes.Add(new Plane("Boeing 777", new DateOnly(2018, 7, 20), new List<SeatCategory>
            {
                new SeatCategory(Category.Standard, 250),
                new SeatCategory(Category.Business, 50),
                new SeatCategory(Category.VIP, 20)
            }));

            Planes.Add(new Plane("Airbus A350", new DateOnly(2020, 9, 10), new List<SeatCategory>
            {
                new SeatCategory(Category.Standard, 280),
                new SeatCategory(Category.Business, 60),
                new SeatCategory(Category.VIP, 30)
            }));
        }

        public static void ShowPlanes()
        {

        }
    }
}
