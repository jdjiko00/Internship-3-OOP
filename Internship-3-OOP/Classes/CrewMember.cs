using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class CrewMember : Person
    {
        public CrewPosition Position { get; set; }
        public bool AssignedToCrew { get; set; }
        public static List<CrewMember> CrewMembers = new List<CrewMember>();

        public CrewMember(string name, string surname, DateOnly birthDay, Gender gender, CrewPosition position)
            : base(name, surname, birthDay, gender)
        {
            Position = position;
            AssignedToCrew = false;
        }

        public static void InitializeCrewMembers()
        {
            CrewMembers.Add(new CrewMember("Ivan", "Horvat", new DateOnly(1980, 5, 12), Gender.Male, CrewPosition.Pilot));
            CrewMembers.Add(new CrewMember("Ana", "Kovac", new DateOnly(1985, 3, 22), Gender.Female, CrewPosition.Copilot));
            CrewMembers.Add(new CrewMember("Petra", "Novak", new DateOnly(1990, 11, 15), Gender.Female, CrewPosition.FlightAttendant));
            CrewMembers.Add(new CrewMember("Marko", "Juric", new DateOnly(1992, 7, 9), Gender.Male, CrewPosition.FlightAttendant));

            CrewMembers.Add(new CrewMember("Luka", "Peric", new DateOnly(1988, 1, 30), Gender.Male, CrewPosition.Pilot));
            CrewMembers.Add(new CrewMember("Tomislav", "Radic", new DateOnly(1983, 12, 19), Gender.Male, CrewPosition.Copilot));
            CrewMembers.Add(new CrewMember("Maja", "Soldo", new DateOnly(1991, 6, 5), Gender.Female, CrewPosition.FlightAttendant));
            CrewMembers.Add(new CrewMember("Ivana", "Baric", new DateOnly(1994, 9, 10), Gender.Female, CrewPosition.FlightAttendant));

            CrewMembers.Add(new CrewMember("Nikola", "Babic", new DateOnly(1979, 3, 14), Gender.Male, CrewPosition.Pilot));
            CrewMembers.Add(new CrewMember("Marija", "Juric", new DateOnly(1986, 6, 5), Gender.Female, CrewPosition.Copilot));
            CrewMembers.Add(new CrewMember("Katarina", "Babic", new DateOnly(1995, 5, 12), Gender.Female, CrewPosition.FlightAttendant));
            CrewMembers.Add(new CrewMember("Ivan", "Soldo", new DateOnly(1992, 12, 1), Gender.Male, CrewPosition.FlightAttendant));

            CrewMembers.Add(new CrewMember("Petar", "Kovac", new DateOnly(1982, 7, 25), Gender.Male, CrewPosition.Pilot));
            CrewMembers.Add(new CrewMember("Filip", "Novak", new DateOnly(1984, 9, 11), Gender.Male, CrewPosition.Copilot));
            CrewMembers.Add(new CrewMember("Nikolina", "Peric", new DateOnly(1993, 2, 20), Gender.Female, CrewPosition.FlightAttendant));
            CrewMembers.Add(new CrewMember("Matej", "Horvat", new DateOnly(1990, 8, 17), Gender.Male, CrewPosition.FlightAttendant));
        }

        public static void AddCrewMembers()
        {
            Console.WriteLine("");
            Console.WriteLine("Unesite podatke za novu osobu!");
            Console.WriteLine("");

            string name = ValidationHelper.AllLettersStringValidation("Ime: ");
            string surname = ValidationHelper.AllLettersStringValidation("Prezime: ");
            DateOnly birthDay = ValidationHelper.DateOfBirthValidation("Unesite datum rodenja (YYYY-MM-DD): ");
            Console.WriteLine("");
            Gender gender = ValidationHelper.GenderValidation("Unesite 1 ili 2: ");
            Console.WriteLine("");
            CrewPosition position = ValidationHelper.PositionValidation("Unesite 1 ili 2 ili 3: ");

            if (!ValidationHelper.AnswerValidation($"Zelite li dodati osobu {name} - {surname} - {position} - {gender} - {birthDay} (DA/NE): "))
                return;

            CrewMembers.Add(new CrewMember(name, surname, birthDay, gender, position));

            Console.WriteLine("Osoba dodana!");

            Console.WriteLine("Pritisnite bilo koju tipku za nastavak...");
            Console.ReadKey();
        }
    }
}
