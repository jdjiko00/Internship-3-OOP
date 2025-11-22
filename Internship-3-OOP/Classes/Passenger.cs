using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class Passenger : Person
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public static List<Passenger> Passengers = new List<Passenger>();

        public Passenger(string name, string surname, DateOnly birthDay, Gender gender, string email, string userName, string password)
            : base(name, surname, birthDay, gender)
        { 
            Email = email;
            UserName = userName;
            Password = password;
        }

        public static void InitializePassengers()
        {
            Passengers.Add(new Passenger("Ivan", "Horvat", new DateOnly(1990, 5, 12), Gender.Male, "ivan@mail.com", "ivan90", "ivan123"));
            Passengers.Add(new Passenger("Ana", "Kovač", new DateOnly(1985, 3, 22), Gender.Female, "ana@mail.com", "ana85", "ana456"));
            Passengers.Add(new Passenger("Petra", "Novak", new DateOnly(1992, 7, 9), Gender.Female, "petra@mail.com", "petra92", "petra789"));
            Passengers.Add(new Passenger("Marko", "Jurić", new DateOnly(1988, 11, 15), Gender.Male, "marko@mail.com", "marko88", "marko321"));
            Passengers.Add(new Passenger("Luka", "Perić", new DateOnly(1995, 1, 30), Gender.Male, "luka@mail.com", "luka95", "luka654"));
        }
    }
}

