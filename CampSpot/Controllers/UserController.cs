using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CampSpot.Models;
using CampSpot.Data;
using Microsoft.AspNetCore.Cors;

namespace CampSpot.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private CampSpotDataContext _Data;

        public UserController(CampSpotDataContext Data)
        {
            _Data = Data;
        }
        
        //give me all aplicants
        [HttpGet]
        [EnableCors("MyPolicy")]
        public ActionResult<IEnumerable<User>> Get()
        {
            Console.WriteLine("1");
            return Ok(_Data.GetUsers());
        }

        //post me a new applicant
        [HttpPost]
        [EnableCors("MyPolicy")]
        public ActionResult<User> Post([FromBody] User user)
        {
            _Data.AddUser(user);
            return user;
        }

        
    }
}
