using Microsoft.AspNetCore.Mvc;
using CampSpot.Models;
using CampSpot.Data;

namespace CampSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController
    {
        private CampSpotDataContext _context;

        public ReviewController(CampSpotDataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void AddReview(CampingReview review)
        {
            _context.AddReview(review);
        }

        [HttpGet]
        public IEnumerable<CampingReview> GetReviews()
        {
            return _context.GetReviews();
        }
    }
}
