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

        static string stringValidation(string message)
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

            string name = stringValidation("Ime: ");
            string surname = stringValidation("Prezime: ");
            string email = stringValidation("Email: ");
            string userName = stringValidation("Korisnicko ime: ");
            string password = stringValidation("Lozinka: ");

            passengers.Add(new Passenger(name, surname, email, userName, password));

            Console.WriteLine("");
            Console.WriteLine($"Registriran korisnik: {userName}");
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();

            Console.WriteLine("");
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
                            break;
                        case 3:
                            Console.WriteLine("Izlazak iz izbornika za putnike...");
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
