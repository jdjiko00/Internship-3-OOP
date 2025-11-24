using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class Passenger : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Flight> Flights = new List<Flight>();
        public static List<Passenger> Passengers = new List<Passenger>();

        public Passenger(string name, string surname, DateOnly birthDay, Gender gender, string email, string password)
            : base(name, surname, birthDay, gender)
        { 
            Email = email;
            Password = password;
        }

        public static void InitializePassengers()
        {
            Passengers.Add(new Passenger("Ivan", "Horvat", new DateOnly(1990, 5, 12), Gender.Male, "ivan@mail.com", "ivan123"));
            Passengers[0].Flights.Add(Flight.Flights[0]);
            Flight.Flights[0].CurrentFlightSeatCount[0].NumberOfSeats++;
            Passengers[0].Flights.Add(Flight.Flights[1]);
            Flight.Flights[1].CurrentFlightSeatCount[0].NumberOfSeats++;
            Passengers.Add(new Passenger("Ana", "Kovač", new DateOnly(1985, 3, 22), Gender.Female, "ana@mail.com", "ana456"));
            Passengers[1].Flights.Add(Flight.Flights[2]);
            Flight.Flights[2].CurrentFlightSeatCount[1].NumberOfSeats++;
            Passengers[1].Flights.Add(Flight.Flights[3]);
            Flight.Flights[3].CurrentFlightSeatCount[0].NumberOfSeats++;
            Passengers.Add(new Passenger("Petra", "Novak", new DateOnly(1992, 7, 9), Gender.Female, "petra@mail.com", "petra789"));
            Passengers[2].Flights.Add(Flight.Flights[4]);
            Flight.Flights[4].CurrentFlightSeatCount[2].NumberOfSeats++;
            Passengers.Add(new Passenger("Marko", "Jurić", new DateOnly(1988, 11, 15), Gender.Male, "marko@mail.com", "marko321"));
            Passengers.Add(new Passenger("Luka", "Perić", new DateOnly(1995, 1, 30), Gender.Male, "luka@mail.com", "luka654"));
            Passengers[4].Flights.Add(Flight.Flights[0]);
            Flight.Flights[0].CurrentFlightSeatCount[0].NumberOfSeats++;
            Passengers[4].Flights.Add(Flight.Flights[2]);
            Flight.Flights[2].CurrentFlightSeatCount[1].NumberOfSeats++;
            Passengers[4].Flights.Add(Flight.Flights[4]);
            Flight.Flights[4].CurrentFlightSeatCount[2].NumberOfSeats++;
        }

        public static void RegistrationAndLogin()
        {
            Console.WriteLine("");
            Console.WriteLine("1 - Registracija");
            Console.WriteLine("2 - Prijava");
            Console.WriteLine("3 - Povratak na prethodni izbornik");
            Console.Write("\nOdabir: ");
            if (int.TryParse(Console.ReadLine(), out int appChoice))
            {
                switch (appChoice)
                {
                    case 1:
                        Registration();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        Console.WriteLine("Povratak u glavni izbornik...");
                        Console.WriteLine("");
                        return;
                    default:
                        Console.WriteLine("Krivi odabir!");
                        Console.WriteLine("");
                        break;
                }
            }
        }

        public static void Registration()
        {
            Console.WriteLine("");
            Console.WriteLine("Unesite podatke za registraciju!");
            Console.WriteLine("");
            int numOfPassengers = Passengers.Count;

            string name = ValidationHelper.AllLettersStringValidation("Ime: ");
            string surname = ValidationHelper.AllLettersStringValidation("Prezime: ");
            DateOnly birthDay = ValidationHelper.DateOfBirthValidation("Unesite datum rodenja (YYYY-MM-DD): ");
            Console.WriteLine("");
            Gender gender = ValidationHelper.GenderValidation("Unesite 1 ili 2: ");
            Console.WriteLine("");

            bool mailExists = true;
            string email = "";
            while (mailExists)
            {
                email = ValidationHelper.EmailValidation("Unesite svoj mail (mora zavrsiti s '@mail.com'): ");
                var passengerToRegister = Passengers.Find(passengerToRegister => passengerToRegister.Email == email);
                if (passengerToRegister != null)
                {
                    Console.WriteLine("Postoji vec putnik s tom email adresom!");
                    continue;
                }
                else mailExists = false;
            }
            string password = ValidationHelper.NoEmptyStringValidation("Unesite svoju lozinku: ");

            Passengers.Add(new Passenger(name, surname, birthDay, gender, email, password));

            Console.WriteLine("");
            Console.WriteLine("Registrirani ste s podatcima:");
            Console.WriteLine($"{Passengers[numOfPassengers].ID} - {Passengers[numOfPassengers].Name} - {Passengers[numOfPassengers].Surname} - {Passengers[numOfPassengers].BirthDay} - {Passengers[numOfPassengers].Gender} - {Passengers[numOfPassengers].Email}");

            Console.WriteLine("");
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void Login()
        {
            Console.WriteLine("");
            bool loginValid = false;
            string email = "";
            string password = "";
            Passenger passengerToLogin;
            do
            {
                email = ValidationHelper.EmailValidation("Email: ");
                passengerToLogin = Passengers.Find(passengerToLogin => passengerToLogin.Email == email);
                if (passengerToLogin == null)
                {
                    password = ValidationHelper.NoEmptyStringValidation("Lozinka: ");
                    Console.WriteLine("Neispravan email ili lozinka!");
                    Console.WriteLine("");
                    continue;
                }
                else
                {
                    password = ValidationHelper.NoEmptyStringValidation("Lozinka: ");
                    if (password != passengerToLogin.Password)
                    {
                        Console.WriteLine("Neispravan email ili lozinka!");
                        Console.WriteLine("");
                        continue;
                    }
                    else loginValid = true;
                }
            } while (!loginValid);

            PassengerMenu(passengerToLogin);
        }

        public static void PassengerMenu(Passenger passenger)
        {
            bool passengerFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Prikaz svih letova");
                Console.WriteLine("2 - Odabir leta");
                Console.WriteLine("3 - Pretrazivanje letova");
                Console.WriteLine("4 - Otkazivanje leta");
                Console.WriteLine("5 - Povratak na prethodni izbornik");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int appChoice))
                {
                    switch (appChoice)
                    {
                        case 1:
                            ShowPassengerFlights(passenger);
                            break;
                        case 2:
                            ReservPassengerFlight(passenger);
                            break;
                        case 3:
                            SearchPassengerFlights(passenger);
                            break;
                        case 4:
                            CancelPassengerFlight(passenger);
                            break;
                        case 5:
                            Console.WriteLine("Povratak u glavni izbornik...");
                            Console.WriteLine("");
                            passengerFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            Console.WriteLine("");
                            break;
                    }
                }
            } while (!passengerFinished);
        }

        public static void ShowPassengerFlights(Passenger passenger)
        {
            Console.WriteLine("");
            if (passenger.Flights.Count == 0)
            {
                Console.WriteLine("Putnik nema rezerviran ni jedan let!");
                return;
            }
            else
            {
                Console.WriteLine("Rezervirani letovi:");
                foreach (var flight in passenger.Flights)
                {
                    Console.WriteLine($"{flight.ID} - {flight.Name} - {flight.DepartueTime} - {flight.ArrivalTime} - {flight.Distance} km - {flight.TotalTime} h");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void ReservPassengerFlight(Passenger passenger)
        {
            Console.WriteLine("");
            Console.WriteLine("Dostupni letovi za rezervaciju:");
            foreach (var flight in Flight.Flights)
            {
                var flightReserved = passenger.Flights.Find(flightReserved => flightReserved.ID == flight.ID);
                if (flightReserved != null)
                    continue;

                Console.WriteLine($"{flight.ID} - {flight.Name} - {flight.DepartueTime} - {flight.ArrivalTime} - {flight.Distance} km - {flight.TotalTime} h");
            }

            Guid inputflightID = ValidationHelper.GuidValidation("Odaberite ID leta kojeg zelite rezervirati: ");
            var flightToReserv = Flight.Flights.Find(flightToReserv => flightToReserv.ID == inputflightID);
            if (flightToReserv == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Neispravan ID leta!");
                return;
            }

            int category = ValidationHelper.CategoryIntValidation("Unesite 1 ili 2 ili 3: ");
            if (flightToReserv.Plane.PlaneSeatCount[category].NumberOfSeats - flightToReserv.CurrentFlightSeatCount[category].NumberOfSeats >= 1)
            {
                flightToReserv.CurrentFlightSeatCount[category].NumberOfSeats++;
            }
            else
            {
                Console.WriteLine("Kategorija napunjena na letu!");
                return;
            }

            if (!ValidationHelper.AnswerValidation($"Zelite li rezervirati taj let (DA/NE): "))
            {
                flightToReserv.CurrentFlightSeatCount[category].NumberOfSeats--;
                return;
            }

            passenger.Flights.Add(flightToReserv);

            Console.WriteLine("Let rezerviran!");

            Console.WriteLine("");
            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void SearchPassengerFlights(Passenger passenger)
        {
            bool passengerFlightSearchFinished = false;
            do
            {
                Console.WriteLine("");
                foreach (var flight in passenger.Flights)
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
                            SearchPassengerFlightsByID(passenger);
                            break;
                        case 'b':
                            SearchPassengerFlightsByName(passenger);
                            break;
                        case 'c':
                            Console.WriteLine("Povratak u glavni izbornik za letove...");
                            Console.WriteLine("");
                            passengerFlightSearchFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            break;
                    }
                }
            } while (!passengerFlightSearchFinished);
        }

        public static void SearchPassengerFlightsByID(Passenger passenger)
        {
            Console.WriteLine("");
            Guid inputFlightID = ValidationHelper.GuidValidation("Odaberite ID leta kojeg zelite pretraziti: ");
            var flight = passenger.Flights.Find(flight => flight.ID == inputFlightID);
            if (flight == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji let s tim ID-em!");
            }
            else
            {
                Console.WriteLine("Let kojeg trazite je:");
                Console.WriteLine("");
                Console.WriteLine($"{flight.ID} - {flight.Name} \n{flight.DepartuePlace} {flight.DepartueTime} -> {flight.ArrivalPlace} {flight.ArrivalTime} \nUdaljenost: {flight.Distance} km \nVrijeme putovanja: {flight.TotalTime} h\nAvion: {flight.Plane.Name} \nPosada: {flight.Crew.Name}");
            }
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void SearchPassengerFlightsByName(Passenger passenger)
        {
            Console.WriteLine("");
            string inputFlightName = ValidationHelper.NoEmptyStringValidation("Unesite ime leta kojeg zelite pretraziti: ");
            var flight = passenger.Flights.Find(flight => flight.Name == inputFlightName);
            if (flight == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji let s tim imenom!");
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

        public static void CancelPassengerFlight(Passenger passenger)
        {
            Console.WriteLine("");
            foreach (var flight in passenger.Flights)
            {
                Console.WriteLine($"{flight.ID} - {flight.Name}\nVrijeme letenja: {flight.TotalTime}\nPosada: {flight.Crew.Name}\nAvion: {flight.Plane.Name}");
            }
            Console.WriteLine("");

            Guid inputFlightID = ValidationHelper.GuidValidation("Odaberite ID leta kojeg zelite izbrisati: ");
            var flightToDelete = passenger.Flights.Find(flightToDelete => flightToDelete.ID == inputFlightID);
            if (flightToDelete == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ne postoji let s tim ID-em!");
            }
            else
            {
                DateTime currentTime = DateTime.Now;
                TimeSpan difference = currentTime - flightToDelete.DepartueTime;
                double timeDifference = Math.Abs(difference.TotalHours);

                if (timeDifference < 24)
                {
                    Console.WriteLine("Let je za manje od 24 h i ne mozete ga otkazati!");
                    Console.WriteLine("");
                    return;
                }
                Console.WriteLine($"Let kojeg zelite otkazati je: ");
                Console.WriteLine($"{flightToDelete.ID} - {flightToDelete.Name}\nVrijeme letenja: {flightToDelete.TotalTime}\nPosada: {flightToDelete.Crew.Name}\nAvion: {flightToDelete.Plane.Name}");

                if (!ValidationHelper.AnswerValidation($"Zelite li otkazati taj let (DA/NE): "))
                    return;

                passenger.Flights.Remove(flightToDelete);
                Console.WriteLine("Let je izbrisan!");
            }

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }
    }
}

