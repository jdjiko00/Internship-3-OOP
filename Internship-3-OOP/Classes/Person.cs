using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public abstract class Person : Date
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public Gender Gender { get; set; }

        public Person(int ID, string name, string surname, int birthYear, Gender gender)
        {
            this.ID = ID;
            this.Name = name;
            this.Surname = surname;
            this.BirthYear = birthYear;
            this.Gender = gender;
        }
    }
}
