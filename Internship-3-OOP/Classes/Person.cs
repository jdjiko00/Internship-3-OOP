using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public abstract class Person : Date
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDay { get; set; }
        public Gender Gender { get; set; }

        public Person(string name, string surname, DateOnly birthDay, Gender gender)
        {
            ID = Guid.NewGuid();
            Name = name;
            Surname = surname;
            BirthDay = birthDay;
            Gender = gender;
        }
    }
}
