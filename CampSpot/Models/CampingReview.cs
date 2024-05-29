namespace CampSpot.Models
{
    public class CampingReview
    {
        public int ID { get; private set; }
        public int LocationID { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int UserID { get; set; }
    }
}
