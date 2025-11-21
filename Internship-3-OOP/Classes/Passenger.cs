using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class Passenger : Person
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Flight> Flights { get; set; } = [];

        public Passenger(int ID, string name, string surname, int birthYear, Gender gender, string email, string userName, string password)
            : base(ID, name, surname, birthYear, gender)
        { 
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
        }
    }
}

