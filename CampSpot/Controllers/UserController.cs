using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CampSpot.Models;
using CampSpot.Data;
using Microsoft.AspNetCore.Cors;
using System.Buffers.Text;

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


        [HttpPost]
        [Route("Login")]
        [EnableCors("MyPolicy")]
        public ActionResult LoginInstance([FromBody] string emailpassword)
        {

            if (_Data.LoginInstance(emailpassword))
            {
                Console.WriteLine("Oke response send");
                return Ok(encodebasestringtostring(emailpassword));
            }
            else
            {
                Console.WriteLine("Not found response send");
                return NotFound();
            }
        }
        private string encodebasestringtostring(string base64)
        {
            byte[]? data = null;
            try
            {
                data = Convert.FromBase64String(base64);
                return "token="+System.Text.Encoding.UTF8.GetString(data).Split(":")[0];
            }
            catch { return ""; }
        }
    }

}
