using Internship_3_OOP.Classes;

namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrewMember.InitializeCrewMembers();
            Crew.InitializeCrews();
            Plane.InitializePlanes();

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
                            break;
                        case 2:
                            break;
                        case 3:
                            Plane.PlaneMenu();
                            break;
                        case 4:
                            Crew.CrewMenu();
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
    }
}
