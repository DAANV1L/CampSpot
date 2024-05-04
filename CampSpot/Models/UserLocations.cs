namespace CampSpot.Models
{
    public class UserLocations
    {
        public int UserLocationsID { get; private set; }
        public int UserID { get; set; }
        public int CampingID { get; set; }
    }
}
