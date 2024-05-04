using LiteDB;
using CampSpot.Models;
using CampSpot.Data;
using CampSpot.Controllers;
using System;

namespace CampSpot.Data
{
    public class CampSpotDataBase : CampSpotDataContext
    {
        LiteDatabase db = new LiteDatabase(@"Data.db");
        public void AddUser(User user)
        {
            //hash the password
            // generate a sha256 hash from the password
            user.Password = HashPassword(user.Password);
            var col = db.GetCollection<User>("users");
            col.Insert(user);
        }

        public IEnumerable<User> GetUsers()
        {
            Console.WriteLine("2");
            return db.GetCollection<User>("users").FindAll();
        }

        public string GetUserType(int userTypeId)
        {
            var usertypes = db.GetCollection<UserTypeModel>("userTypes").FindAll();
            foreach (var userType in usertypes)
            {
                if (userType.TypeID == userTypeId)
                {
                    return userType.TypeName.ToString();
                }
            }
            return "User Type Not Found";
        }

        public void AddUserType(UserTypeModel userType)
        {
            var col = db.GetCollection<UserTypeModel>("userTypes");
            col.Insert(userType);
        }



        private string HashPassword(string password)
        {
            // generate a sha256 hash from the password
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return System.Convert.ToBase64String(hashedBytes);
            }
        }

        IEnumerable<UserTypeModel> CampSpotDataContext.GetUserTypes()
        {
            return db.GetCollection<UserTypeModel>("userTypes").FindAll();
        }
    }
}
