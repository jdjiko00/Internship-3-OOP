namespace Internship_3_OOP.Classes
{
    public class Crew : Date
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CrewMember Pilot { get; set; }
        public CrewMember Copilot { get; set; }
        public List<CrewMember> FlightAttendents { get; set; } = [];

        public Crew(int ID, string name, CrewMember pilot, CrewMember copilot)
        {
            this.ID = ID;
            this.Name = name;
            this.Pilot = pilot;
            this.Copilot = copilot;
        }
    }
}
