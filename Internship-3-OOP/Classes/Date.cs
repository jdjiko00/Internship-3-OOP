namespace Internship_3_OOP.Classes
{
    public abstract class Date
    {
        public DateTime CreatedDate {  get; set; }
        public DateTime UpdatedDate { get; set; }

        public Date()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        public void UpdateDate()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}
