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
            return Ok(campingLocation.ID);
        }
        [HttpGet]
        [Route("GetLocation{id}")]
        public ActionResult GetLocation(int id)
        {
            try
            {
                var col = _Data.GetCampingLocations();
                foreach (var location in col)
                {
                    if (location.ID == id)
                    {
                        return Ok(location);
                    }
                }
                return NotFound();

            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("GetImageData{LocationID}")]
        public string GetImageData(int LocationID)
        {
            var data = _Data.GetImageData(LocationID);
            if (data != null)
            {
                return data.ImageData.ToString();
            }
            return "No Picture found!";
        }
        [HttpPut]
        [Route("UpdateLocation")]
        public ActionResult UpdateLocation([FromBody] CampingLocation campingLocation, int id)
        {
            _Data.UpdateLocation(campingLocation, id);
            return Ok(campingLocation);
        }
        [HttpDelete]
        [Route("RemoveLocation")]
        public ActionResult RemoveLocation(int id)
        {
            _Data.RemoveLocation(id);
            return Ok();
        }
    }
}
