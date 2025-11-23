using System.Xml.Linq;

namespace Internship_3_OOP.Classes
{
    public class Crew : Date
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public List<CrewMember> CrewMembers = new List<CrewMember>();
        public static List<Crew> Crews = new List<Crew>();

        public Crew(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }

        public static void InitializeCrews()
        {
            Crews.Add(new Crew("Alpha Crew")
            {
                CrewMembers =
                {
                    CrewMember.CrewMembers[0],
                    CrewMember.CrewMembers[1],
                    CrewMember.CrewMembers[2],
                    CrewMember.CrewMembers[3]
                }
            });

            for (int i = 0; i < Crews[0].CrewMembers.Count; i++)
                Crews[0].CrewMembers[i].AssignedToCrew = true;

            Crews.Add(new Crew("Bravo Crew")
            {
                CrewMembers =
                {
                    CrewMember.CrewMembers[4],
                    CrewMember.CrewMembers[5],
                    CrewMember.CrewMembers[6],
                    CrewMember.CrewMembers[7]
                }
            });

            for (int i = 0; i < Crews[1].CrewMembers.Count; i++)
                Crews[1].CrewMembers[i].AssignedToCrew = true;

            Crews.Add(new Crew("Charlie Crew")
            {
                CrewMembers =
                {
                    CrewMember.CrewMembers[8],
                    CrewMember.CrewMembers[9],
                    CrewMember.CrewMembers[10],
                    CrewMember.CrewMembers[11]
                }
            });

            for (int i = 0; i < Crews[2].CrewMembers.Count; i++)
                Crews[2].CrewMembers[i].AssignedToCrew = true;
        }

        public static void CrewMenu()
        {
            bool crewFinished = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("1 - Prikaz svih posada");
                Console.WriteLine("2 - Kreiranje nove posade");
                Console.WriteLine("3 - Dodavanje osobe");
                Console.WriteLine("4 - Izlaz iz programa");
                Console.Write("\nOdabir: ");
                if (int.TryParse(Console.ReadLine(), out int appChoice))
                {
                    switch (appChoice)
                    {
                        case 1:
                            showCrews();
                            break;
                        case 2:
                            addCrew();
                            break;
                        case 3:
                            CrewMember.AddCrewMembers();
                            break;
                        case 4:
                            Console.WriteLine("Povratak u glavni izbornik...");
                            Console.WriteLine("");
                            crewFinished = true;
                            break;
                        default:
                            Console.WriteLine("Krivi odabir!");
                            Console.WriteLine("");
                            break;
                    }
                }
            } while (!crewFinished);
        }

        public static void showCrews()
        {
            Console.WriteLine("");
            foreach (var crew in Crews)
            {
                Console.WriteLine($"Posada: {crew.Name}");
                Console.WriteLine("Clanovi: ");
                foreach (var member in crew.CrewMembers)
                {
                    Console.WriteLine($"{member.Name} - {member.Surname} - {member.Position} - {member.Gender} - {member.BirthDay}");
                }

                Console.WriteLine("");
            }

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }

        public static void addCrew()
        {
            Console.WriteLine("");
            int numberOfCrews = Crews.Count;
            string crewName = ValidationHelper.NoEmptyStringValidation("Unesite ime posade: ");
            Crews.Add(new Crew(crewName));
            Console.WriteLine("");

            Console.WriteLine("Mogu biti 4 osobe po posadi (1 pilot, 1 kopilot, 2 stjuardese/stjuarda)!");
            while (true)
            {
                if (Crews[numberOfCrews].CrewMembers.Count == 4)
                {
                    Console.WriteLine("Posada je napunjena!");
                    Console.WriteLine("");
                    break;
                }

                int numOfFreeCrewMembers = 0;
                Console.WriteLine("Dostupne osobe koje nisu u nekoj posadi:");
                foreach (var crewMember in CrewMember.CrewMembers)
                {
                    if (!crewMember.AssignedToCrew)
                    {
                        Console.WriteLine($"{crewMember.ID} - {crewMember.Name} - {crewMember.Surname} - {crewMember.Position}");
                        numOfFreeCrewMembers++;
                    }
                }

                if (numOfFreeCrewMembers == 0)
                {
                    Console.WriteLine("Nema osoba koji nisu u posadi!");
                    Console.WriteLine("");
                    break;
                }

                Console.WriteLine("");
                Guid inputMemberID = ValidationHelper.GuidValidation("Odaberite ID osobe koju zelite dodati u posadu: ");
                bool pilotPositionTaken = false;
                int numOfFlightAttendants = 0;

                var member = CrewMember.CrewMembers.Find(member => member.ID == inputMemberID);
                if (member == null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Neispravno!");
                    Console.WriteLine("");
                    continue;
                }    
                if (member.AssignedToCrew)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Ta osoba je vec pridodijeljena posadi!");
                    Console.WriteLine("");
                    continue;
                }

                foreach (var crewMember in Crews[numberOfCrews].CrewMembers)
                {
                    if ((crewMember.Position == Enums.CrewPosition.Pilot && member.Position == Enums.CrewPosition.Pilot) || (crewMember.Position == Enums.CrewPosition.Copilot && member.Position == Enums.CrewPosition.Copilot))
                        pilotPositionTaken = true;
                    else if (crewMember.Position == Enums.CrewPosition.FlightAttendant && member.Position == Enums.CrewPosition.FlightAttendant)
                        numOfFlightAttendants++;
                }

                if (pilotPositionTaken)
                {
                    Console.WriteLine("");  
                    Console.WriteLine($"U ovoj posadi vec postoji clan koji je {member.Position}");
                    Console.WriteLine("");
                    continue;
                }
                else if (numOfFlightAttendants == 2)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"U ovoj posadi vec postoje 2 clana koji su {member.Position}");
                    Console.WriteLine("");
                    continue;
                }

                if (ValidationHelper.AnswerValidation($"Zelite li dodati osobu {member.Name} - {member.Surname} - {member.Position} u posadu {Crews[numberOfCrews].Name} (DA/NE): "))
                {
                    member.AssignedToCrew = true;
                    Crews[numberOfCrews].CrewMembers.Add(member);
                }

                if (!ValidationHelper.AnswerValidation($"Zelite li dodati jos osoba u posadu {Crews[numberOfCrews].Name} (DA/NE): "))
                    break; ;

                Console.WriteLine("");
            }

            Console.WriteLine($"Dodana posada '{Crews[numberOfCrews].Name}' s clanovima:");
            foreach (var crewMember in Crews[numberOfCrews].CrewMembers)
            {
                Console.WriteLine($"{crewMember.Name} - {crewMember.Surname} - {crewMember.Position} - {crewMember.Gender} - {crewMember.BirthDay}");
            }
            Console.WriteLine("");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }
    }
}
