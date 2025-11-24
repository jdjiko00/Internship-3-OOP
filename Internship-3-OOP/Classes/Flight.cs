using System.Numerics;

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
        public TimeSpan TotalTime { get; set; }
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
            ArrivalTime = arrivalTime;
            Distance = distance;
            Plane = plane;
            Crew = crew;

            TotalTime = ArrivalTime - DepartueTime;
            plane.FlightCount++;
            foreach (var seat in plane.PlaneSeatCount)
            {
                CurrentFlightSeatCount.Add(new SeatCategory(seat.Category, 0));
            }
        }

        public static void InitializeFlights()
        {
            Flights.Add(new Flight(
                "FL-001",
                "Sarajevo",
                "Bec",
                new DateTime(2025, 1, 10, 8, 30, 0),
                new DateTime(2025, 1, 10, 10, 10, 0),
                600,
                Plane.Planes[0],
                Crew.Crews[0]
            ));

            Flights.Add(new Flight(
                "FL-002",
                "Beograd",
                "Istanbul",
                new DateTime(2025, 1, 11, 7, 45, 0),
                new DateTime(2025, 1, 11, 9, 20, 0),
                810,
                Plane.Planes[1],
                Crew.Crews[1]
            ));

            Flights.Add(new Flight(
                "FL-003",
                "Zagreb",
                "Frankfurt",
                new DateTime(2025, 1, 12, 14, 0, 0),
                new DateTime(2025, 1, 12, 16, 0, 0),
                720,
                Plane.Planes[2],
                Crew.Crews[2]
            ));

            Flights.Add(new Flight(
                "FL-004",
                "Sarajevo",
                "Doha",
                new DateTime(2025, 1, 15, 2, 10, 0),
                new DateTime(2025, 1, 15, 9, 00, 0),
                3600,
                Plane.Planes[3],
                Crew.Crews[1]
            ));

            Flights.Add(new Flight(
                "FL-005",
                "Beograd",
                "New York",
                new DateTime(2025, 1, 20, 11, 30, 0),
                new DateTime(2025, 1, 20, 19, 20, 0),
                7400,
                Plane.Planes[2],
                Crew.Crews[0]
            ));
        }

        public static void FlightMenu()
        {
            bool flightFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Prikaz svih letova");
                Console.WriteLine("2 - Dodavanje leta");
                Console.WriteLine("3 - Pretraživanje letova");
                Console.WriteLine("4 - Uređivanje leta");
                Console.WriteLine("5 - Brisanje leta");
                Console.WriteLine("6 - Povratak na prethodni izbornik");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int appChoice))
                {
                    switch (appChoice)
                    {
                        case 1:
                            ShowFlights();
                            break;
                        case 2:
                            break;
                        case 3:
                            SearchFlightsMenu();
                            break;
                        case 4:
                            EditFlights();
                            break;
                        case 5:
                            break;
                        case 6:
                            Console.WriteLine("Povratak u glavni izbornik...");
                            Console.WriteLine("");
                            flightFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            Console.WriteLine("");
                            break;
                    }
                }
            } while (!flightFinished);
        }

        public static void ShowFlights()
        {
            Console.WriteLine("");
            foreach (var flight in Flights)
            {
                Console.WriteLine($"{flight.ID} - {flight.Name} - {flight.DepartueTime} - {flight.ArrivalTime} - {flight.Distance} km - {flight.TotalTime} h");
            }
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void SearchFlightsMenu()
        {
            bool flightSearchFinished = false;
            do
            {
                Console.WriteLine("");
                foreach (var flight in Flights)
                {
                    Console.WriteLine($"{flight.ID} - {flight.Name}");
                }
                Console.WriteLine("");
                Console.WriteLine("a - Pretrazi letove po ID-u");
                Console.WriteLine("b - Pretrazi letove po imenu");
                Console.WriteLine("c - Povratak na prethodni izbornik");
                Console.Write("\nOdabir: ");
                string input = Console.ReadLine().ToLower();
                if (char.TryParse(input, out char userChoice))
                {
                    switch (userChoice)
                    {
                        case 'a':
                            SearchFlightsByID();
                            break;
                        case 'b':
                            SearchFlightsByName();
                            break;
                        case 'c':
                            Console.WriteLine("Povratak u glavni izbornik za letove...");
                            Console.WriteLine("");
                            flightSearchFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            break;
                    }
                }
            } while (!flightSearchFinished);
        }

        public static void SearchFlightsByID()
        {
            Console.WriteLine("");
            Guid inputFlightID = ValidationHelper.GuidValidation("Odaberite ID leta kojeg zelite pretraziti: ");
            var flight = Flights.Find(flight => flight.ID == inputFlightID);
            if (flight == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji let s tim ID-em!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Let kojeg trazite je:");
                Console.WriteLine("");
                Console.WriteLine($"{flight.ID} - {flight.Name} \n{flight.DepartuePlace} {flight.DepartueTime} -> {flight.ArrivalPlace} {flight.ArrivalTime} \nUdaljenost: {flight.Distance} km \nVrijeme putovanja: {flight.TotalTime}\nAvion: {flight.Plane.Name} \nPosada: {flight.Crew.Name}");
            }
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void SearchFlightsByName()
        {
            Console.WriteLine("");
            string inputFlightName = ValidationHelper.NoEmptyStringValidation("Unesite ime leta kojeg zelite pretraziti: ");
            var flight = Flights.Find(flight => flight.Name == inputFlightName);
            if (flight == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji let s tim imenom!");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Let kojeg trazite je:");
                Console.WriteLine("");
                Console.WriteLine($"{flight.ID} - {flight.Name} \n{flight.DepartuePlace} {flight.DepartueTime} -> {flight.ArrivalPlace} {flight.ArrivalTime} \nUdaljenost: {flight.Distance} km \nVrijeme putovanja: {flight.TotalTime}\nAvion: {flight.Plane.Name} \nPosada: {flight.Crew.Name}");
            }
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void EditFlights()
        {
            Console.WriteLine("");
            Console.WriteLine("Mozete promijeniti vrijeme polaska i dolaska leta, te mozete promijeniti posadu!");
            Console.WriteLine("");
            foreach (var flightToShow in Flights)
            {
                Console.WriteLine($"{flightToShow.ID} - {flightToShow.Name}\n{flightToShow.DepartueTime} - {flightToShow.ArrivalTime}\nPosada: {flightToShow.Crew.Name}");
                Console.WriteLine("");
            }

            Guid inputFlightID = ValidationHelper.GuidValidation("Odaberite ID leta kojeg zelite pretraziti: ");
            var flight = Flights.Find(flight => flight.ID == inputFlightID);
            if (flight == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji let s tim ID-em!");
                Console.WriteLine("");
                return;
            }

            DateTime newDepartureTime = ValidationHelper.FlightTimeValidation($"Unesite novo vrijeme polaska (YYYY-MM-DD HH:mm) (ENTER za zadrzati '{flight.DepartueTime:yyyy-MM-dd HH:mm}): ", flight.DepartueTime);
            DateTime newArrivalTime = ValidationHelper.FlightTimeValidation($"Unesite novo vrijeme dolaska (YYYY-MM-DD HH:mm) (ENTER za zadrzati '{flight.ArrivalTime:yyyy-MM-dd HH:mm}): ", newDepartureTime, flight.ArrivalTime);
            Console.WriteLine("");
            Console.WriteLine($"Posada koja je na ovo letu: {flight.Crew.Name}");
            Console.WriteLine("");
            Console.WriteLine("Posade s kojima je mozete zamijeniti:");
            Console.WriteLine("");
            foreach (var crew in Crew.Crews)
            {
                if (crew.ID == flight.Crew.ID)
                    continue;
                Console.WriteLine($"{crew.ID} - {crew.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("Ako zelite zamijeniti postojecu posadu s novom, unesite ID ponudenih posada!");
            Console.WriteLine("");
            Guid inputCrewID = ValidationHelper.GuidValidation("Odaberite ID posade kojeu zelite dodati na let (ENTER za zadrzati): ");
            var crewToPut = Crew.Crews.Find(crewToPut => crewToPut.ID == inputCrewID);
            if (crewToPut == null)
            {
                Console.WriteLine("");
                crewToPut = flight.Crew;
            }

            if (!ValidationHelper.AnswerValidation($"Zelite li urediti taj let (DA/NE): "))
                return;

            Console.WriteLine("");
            if (newDepartureTime != flight.DepartueTime || newArrivalTime != flight.ArrivalTime || crewToPut != flight.Crew)
            {
                flight.DepartueTime = newDepartureTime;
                flight.ArrivalTime = newArrivalTime;
                flight.Crew = crewToPut;
                flight.UpdateDate();
            }

            Console.WriteLine($"Let nakon promjene:\n{flight.ID} - {flight.Name}\n{flight.DepartueTime} - {flight.ArrivalTime}\nPosada: {flight.Crew.Name}");
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }
    }
}
