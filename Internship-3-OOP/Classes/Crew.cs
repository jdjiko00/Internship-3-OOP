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
            {
                Crews[0].CrewMembers[i].AssignedToCrew = true;
            }

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
            {
                Crews[1].CrewMembers[i].AssignedToCrew = true;
            }

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
            {
                Crews[2].CrewMembers[i].AssignedToCrew = true;
            }
        }
    }
}
