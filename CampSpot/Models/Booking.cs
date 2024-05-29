namespace CampSpot.Models
{
    public class Booking
    {
        public int ID { get; private set; }
        public int UserID { get; set; }
        public int LocationID { get; set; }
        public int NumberOfNights { get; set; }
        public DateTime CheckInDate { get; set; }
    }
}
