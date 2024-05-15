namespace CampSpot.Models
{
    public class CampingLocation
    {
        public int ID { get; private set; }
        public string ImageData { get; set; }
        public int UserID { get; set; }
        public string LocationName { get; set; }
        public string Description { get; set; }
        public int PricePerNight { get; set; }
        public int CategoryID { get; set; }
    }
}
