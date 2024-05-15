using Microsoft.AspNetCore.Mvc;
using CampSpot.Models;
using CampSpot.Data;

namespace CampSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private CampSpotDataContext _Data;

        public LocationController(CampSpotDataContext Data)
        {
            _Data = Data;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_Data.GetCampingLocations());
        }

        [HttpPost]
        public ActionResult Post([FromBody] CampingLocation campingLocation)
        {
            _Data.AddUserLocation(campingLocation);
            return Ok(campingLocation.ToString());
        }
        [HttpGet]
        [Route("GetLocation{id}")]
        public ActionResult GetLocation(int id)
        {
            if (id != 0) { id = id -1; }
            try
            {
                return Ok(_Data.GetCampingLocations().ElementAt(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
