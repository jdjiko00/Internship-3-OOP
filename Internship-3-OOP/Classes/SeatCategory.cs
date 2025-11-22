using Internship_3_OOP.Classes.Enums;

namespace Internship_3_OOP.Classes
{
    public class SeatCategory : Date
    {
        public Category Category { get; set; }
        public int NumberOfSeats { get; set; }

        public SeatCategory(Category category, int numberOfSeats)
        {
            Category = category;
            NumberOfSeats = numberOfSeats;
        }
    }
}
