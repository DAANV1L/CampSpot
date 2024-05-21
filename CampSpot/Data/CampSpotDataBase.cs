using LiteDB;
using CampSpot.Models;
using CampSpot.Data;
using CampSpot.Controllers;
using System;
using Microsoft.AspNetCore.Mvc;

namespace CampSpot.Data
{
    public class CampSpotDataBase : CampSpotDataContext
    {
        LiteDatabase db = new LiteDatabase(@"Data.db");

        public bool LoginInstance(string emailpassword)
        {
            Console.WriteLine(emailpassword);
            byte[]? data = null;
            try
            {
                data = Convert.FromBase64String(emailpassword);
                emailpassword = System.Text.Encoding.UTF8.GetString(data);
            }
            catch {  }
            
            string email = emailpassword.Split(":")[0];
            string password = emailpassword.Split(":")[1];
            if (EmailExists(email))
            {
                var col = db.GetCollection<User>("users");
                foreach (var user in col.FindAll())
                {
                    if (user.Email == email)
                    {
                        if (user.Password == HashPassword(password))
                        {
                            Console.WriteLine("Login granted");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool EmailExists(string email)
        {
            var col = db.GetCollection<User>("users");
            foreach (var user in col.FindAll())
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }
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

        public void AddUserLocation(CampingLocation campingLocation)
        {
            var col = db.GetCollection<CampingLocation>("campingLocations");
            col.Insert(campingLocation);
        }

        public IEnumerable<CampingLocation> GetCampingLocations()
        {
            return db.GetCollection<CampingLocation>("campingLocations").FindAll();
        }
        
        public void AddBooking(Booking booking)
        {
            var col = db.GetCollection<Booking>("booking");
            col.Insert(booking);
        }
        public IEnumerable<Booking> GetBookings()
        {
            return db.GetCollection<Booking>("booking").FindAll();
        }
        public IEnumerable<Booking> GetBookings(int id)
        {
            return db.GetCollection<Booking>("booking").Find(b => b.LocationID == id);
        }
    }
}
