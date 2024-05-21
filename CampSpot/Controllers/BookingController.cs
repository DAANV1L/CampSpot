using CampSpot.Models;
using CampSpot.Data;
using Microsoft.AspNetCore.Mvc;



namespace CampSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController
    {
        private CampSpotDataContext _context;

        public BookingController(CampSpotDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void AddBooking(Booking booking)
        {
            _context.AddBooking(booking);
        }

        [HttpGet]
        public IEnumerable<Booking> GetBookings()
        {
            return _context.GetBookings();
        }
        [HttpGet]
        [Route("GetBooking{id}")]
        public IEnumerable<Booking> GetBookings(int id)
        {
            return _context.GetBookings().Where(b => b.LocationID == id);
        }
    }
}
