namespace Internship_3_OOP.Classes
{
    public class Passenger
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Passenger(string name, string surname, string email, string userName, string password)
        { 
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
        }
    }
}

