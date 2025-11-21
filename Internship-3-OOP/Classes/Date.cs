namespace Internship_3_OOP.Classes
{
    public abstract class Date
    {
        public DateTime CreatedDate {  get; set; }
        public DateTime UpdatedDate { get; set; }

        public Date()
        {
            this.CreatedDate = DateTime.Now;
            this.UpdatedDate = DateTime.Now;
        }

        public void UpdateDate()
        {
            this.UpdatedDate = DateTime.Now;
        }
    }
}
