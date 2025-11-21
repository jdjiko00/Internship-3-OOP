using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class CrewMember : Person
    {
        public CrewPosition Position { get; set; }
        public bool AssignedToCrew { get; set; }

        public CrewMember(int ID, string name, string surname, int birthYear, Gender gender, CrewPosition position)
            : base(ID, name, surname, birthYear, gender)
        {
            this.Position = position;
            this.AssignedToCrew = false;
        }
    }
}
