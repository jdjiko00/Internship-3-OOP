using Internship_3_OOP.Classes;

namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Passenger> passengers = new List<Passenger>();

            Console.WriteLine("APLIKACIJA ZA UPRAVLJANJE AERODROMOM");
            bool appFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Putnici");
                Console.WriteLine("2 - Letovi");
                Console.WriteLine("3 - Avioni");
                Console.WriteLine("4 - Posada");
                Console.WriteLine("5 - Izlaz iz programa");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int appChoice))
                {
                    switch (appChoice)
                    {
                        case 1:
                            passengerMenu(passengers);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            Console.WriteLine("Izlazak iz aplikacije...");
                            Console.WriteLine("");
                            appFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            Console.WriteLine("");
                            break;
                    }
                }
            } while (!appFinished);
        }

        static string onlyLettersValidation(string message)
        {
            string value = "";

            while (string.IsNullOrWhiteSpace(value) || !value.All(char.IsLetter))
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("Unos ne smije biti prazan!");

                else if (!value.All(char.IsLetter))
                    Console.WriteLine("Unos može sadržavati samo slova!");
            }

            return value;
        }

        static string otherStringsValidation(string message)
        {
            string value = "";

            while (string.IsNullOrWhiteSpace(value))
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("Unos ne smije biti prazan!");
            }

            return value;
        }

        static void registration(List<Passenger> passengers)
        {
            Console.WriteLine("");
            int ID = passengers.Count;
            foreach (var passenger in passengers)
            {
                if (ID == 0)
                {
                    ID = 1;
                    break;
                }
                else if (passenger.ID == ID)
                    ID++;
            }

            Console.WriteLine("Unesite svoje podatke:");

            string name = onlyLettersValidation("Ime: ");
            string surname = onlyLettersValidation("Prezime: ");
            string email = otherStringsValidation("Email: ");
            string userName = otherStringsValidation("Korisnicko ime: ");
            string password = otherStringsValidation("Lozinka: ");

            passengers.Add(new Passenger(ID, name, surname, email, userName, password));

            Console.WriteLine("");
            Console.WriteLine($"Registriran korisnik: {userName}");
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();

            Console.WriteLine("");
        }

        static void passengerFlightMenu(Passenger passenger)
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
                if (int.TryParse(Console.ReadLine(), out int passengerChoice))
                {
                    switch (passengerChoice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            Console.WriteLine("Povratak na izbornik od putnika...");
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

        static void login(List<Passenger> passengers)
        {
            Console.WriteLine("");
            bool dataCheck = true;
            Console.WriteLine("Unesite svoje podatke:");

            while (dataCheck)
            {
                string email = otherStringsValidation("Email: ");
                string password = otherStringsValidation("Lozinka: ");

                foreach (var passenger in passengers)
                {
                    if (email == passenger.Email && password == passenger.Password)
                    {
                        passengerFlightMenu(passenger);
                        dataCheck = false;
                        break;
                    }
                }

                if (dataCheck)
                {
                    Console.WriteLine("Email ili lozinka nisu ispravni. Pokusajte ponovno!");
                }
            }
        }

        static void passengerMenu(List<Passenger> passengers)
        {
            bool passengerFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Registracija");
                Console.WriteLine("2 - Prijava");
                Console.WriteLine("3 - Povratak na glavni izbornik");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int passengerChoice))
                {
                    switch (passengerChoice)
                    {
                        case 1:
                            registration(passengers);
                            break;
                        case 2:
                            login(passengers);
                            break;
                        case 3:
                            Console.WriteLine("Povratak na glavni izbornik...");
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
    }
}
