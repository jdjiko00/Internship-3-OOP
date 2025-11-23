using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class Plane : Date
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateOnly ProductionYear { get; set; }
        public int FlightCount = 0;
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

        public static void PlaneMenu()
        {
            bool planeFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Prikaz svih aviona");
                Console.WriteLine("2 - Dodavanje novog aviona");
                Console.WriteLine("3 - Pretraživanje aviona");
                Console.WriteLine("4 - Brisanje aviona");
                Console.WriteLine("5 - Povratak na prethodni izbornik");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int appChoice))
                {
                    switch (appChoice)
                    {
                        case 1:
                            ShowPlanes();
                            break;
                        case 2:
                            //addCrew();
                            break;
                        case 3:
                            SearchPlanesMenu();
                            break;
                        case 4:
                            DeletePlanesMenu();
                            break;
                        case 5:
                            Console.WriteLine("Povratak u glavni izbornik...");
                            Console.WriteLine("");
                            planeFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            Console.WriteLine("");
                            break;
                    }
                }
            } while (!planeFinished);
        }

        public static void ShowPlanes()
        {
            Console.WriteLine("");
            foreach (var plane in Planes)
            {
                Console.WriteLine($"{plane.ID} - {plane.Name} - {plane.ProductionYear.Year} - Broj letova: {plane.FlightCount}");
            }
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void SearchPlanesMenu()
        {
            bool planeSearchFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("a - Pretrazi avione po ID-u");
                Console.WriteLine("b - Pretrazi avione po imenu");
                Console.WriteLine("c - Povratak na prethodni izbornik");
                Console.Write("\nOdabir: ");
                string input = Console.ReadLine().ToLower();
                if (char.TryParse(input, out char userChoice))
                {
                    switch (userChoice)
                    {
                        case 'a':
                            SearchPlanesByID();
                            break;
                        case 'b':
                            SearchPlanesByName();
                            break;
                        case 'c':
                            Console.WriteLine("Povratak u glavni izbornik za avione...");
                            Console.WriteLine("");
                            planeSearchFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            break;
                    }
                }
            } while(!planeSearchFinished);
        }

        public static void SearchPlanesByID()
        {
            Console.WriteLine("");
            Guid inputPlaneID = ValidationHelper.GuidValidation("Odaberite ID aviona kojeg zelite pretraziti: ");
            var plane = Planes.Find(plane => plane.ID == inputPlaneID);
            if (plane == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji avion s tim ID-em!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Avion kojeg trazite je:");
                Console.WriteLine($"{plane.Name} - {plane.ProductionYear.Year} - Broj letova: {plane.FlightCount}");
            }

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void SearchPlanesByName()
        {
            Console.WriteLine("");
            string inputPlaneName = ValidationHelper.NoEmptyStringValidation("Unesite ime aviona kojeg zelite pretraziti: ");
            var plane = Planes.Find(plane => plane.Name == inputPlaneName);
            if (plane == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji avion s tim imenom!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Avion kojeg trazite je:");
                Console.WriteLine($"{plane.Name} - {plane.ProductionYear.Year} - Broj letova: {plane.FlightCount}");
            }

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void DeletePlanesMenu()
        {
            bool planeDeleteFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("a - Izbrisi avione po ID-u");
                Console.WriteLine("b - Izbrisi avione po imenu");
                Console.WriteLine("c - Povratak na prethodni izbornik");
                Console.Write("\nOdabir: ");
                string input = Console.ReadLine().ToLower();
                if (char.TryParse(input, out char userChoice))
                {
                    switch (userChoice)
                    {
                        case 'a':
                            DeletePlanesByID();
                            break;
                        case 'b':
                            DeletePlanesByName();
                            break;
                        case 'c':
                            Console.WriteLine("Povratak u glavni izbornik za avione...");
                            Console.WriteLine("");
                            planeDeleteFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            break;
                    }
                }
            } while (!planeDeleteFinished);
        }

        public static void DeletePlanesByID()
        {
            Console.WriteLine("");
            foreach (var plane in Planes)
            {
                Console.WriteLine($"{plane.ID} - {plane.Name} - {plane.ProductionYear.Year} - Broj letova: {plane.FlightCount}");
            }
            Console.WriteLine("");
            Guid inputPlaneID = ValidationHelper.GuidValidation("Odaberite ID aviona kojeg zelite izbrisati: ");
            var planeToDelete = Planes.Find(plane => plane.ID == inputPlaneID);
            if (planeToDelete == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji avion s tim ID-em!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Avion kojeg zelite izbrisati je:");
                Console.WriteLine($"{planeToDelete.Name} - {planeToDelete.ProductionYear.Year} - Broj letova: {planeToDelete.FlightCount}");

                if (!ValidationHelper.AnswerValidation($"Zelite li izbrisati taj avion (DA/NE): "))
                    return;

                Planes.Remove(planeToDelete);
                Console.WriteLine("Avion je izbrisan!");
            }

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void DeletePlanesByName()
        {
            Console.WriteLine("");
            foreach (var plane in Planes)
            {
                Console.WriteLine($"{plane.ID} - {plane.Name} - {plane.ProductionYear.Year} - Broj letova: {plane.FlightCount}");
            }
            Console.WriteLine("");
            string inputPlaneName = ValidationHelper.NoEmptyStringValidation("Unesite ime aviona kojeg zelite izbrisati: ");
            var planeToDelete = Planes.Find(plane => plane.Name == inputPlaneName);
            if (planeToDelete == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji avion s tim imenom!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Avion kojeg zelite izbrisati je:");
                Console.WriteLine($"{planeToDelete.Name} - {planeToDelete.ProductionYear.Year} - Broj letova: {planeToDelete.FlightCount}");

                if (!ValidationHelper.AnswerValidation($"Zelite li izbrisati taj avion (DA/NE): "))
                    return;

                Planes.Remove(planeToDelete);
                Console.WriteLine("Avion je izbrisan!");
            }

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }
    }
}
