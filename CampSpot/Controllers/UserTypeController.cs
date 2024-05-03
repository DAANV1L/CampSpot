using Microsoft.AspNetCore.Mvc;
using CampSpot.Models;
using CampSpot.Data;
using Microsoft.AspNetCore.Cors;

namespace CampSpot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private CampSpotDataContext _Data;
        public UserTypeController(CampSpotDataContext Data)
        {
            _Data = Data;
        }


        // get usertype by ID
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<string> Get(int userTypeId)
        {
            return Ok(_Data.GetUserType(userTypeId));
        }

        //// get all usertypes
        //[HttpGet]
        //[EnableCors("MyPolicy")]
        //public ActionResult<IEnumerable<UserTypeModel>> Get()
        //{
        //    return Ok(_Data.GetUserTypes());
        //}



        // add usertypes
        [HttpPost]
        [EnableCors("MyPolicy")]
        public ActionResult<UserTypeModel> Post([FromBody] UserTypeModel userType)
        {
            _Data.AddUserType(userType);
            return userType;
        }

        
    }
}
