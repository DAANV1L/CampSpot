using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CampSpot.Models;
using CampSpot.Data;
using Microsoft.AspNetCore.Cors;
using System.Buffers.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

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
                var token = GenerateJwtToken(encodebasestringtostring(emailpassword));
                return Ok(new { token });
            }
            else
            {
                Console.WriteLine("Not found response send");
                return Unauthorized();
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




        //generate login token
        private string GenerateJwtToken(string username)
        {
            // token met gebruik van mijn geheime key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key_1234567890123456789012345678901"));

            // Generate token credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create claims
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            // Create JWT token
            var token = new JwtSecurityToken(
                issuer: "localhost:5001",
                audience: "your_audience",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7), // Token expiration time
                signingCredentials: creds
            );

            // Serialize token to a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
