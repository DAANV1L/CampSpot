namespace CampSpot.Models
{
    public class CampingLocation
    {
        public int CampingID { get; private set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public int PricePerNight { get; set; }
        public int CategoryID { get; set; }
    }
}
