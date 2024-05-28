﻿using CampSpot.Models;
using CampSpot.Data;
using CampSpot.Controllers;

namespace CampSpot.Data
{
    public interface CampSpotDataContext
    {
        void AddUser(User user);
        IEnumerable<User> GetUsers();
        string GetUserType(int userTypeId);
        IEnumerable<UserTypeModel> GetUserTypes();
        void AddUserType(UserTypeModel userType);
        int LoginInstance(string emailpassword);
        void AddUserLocation(CampingLocation campingLocation);
        IEnumerable<CampingLocation> GetCampingLocations();
        void AddBooking(Booking booking);
        IEnumerable<Booking> GetBookings();
        IEnumerable<Booking> GetBookings(int id);
        IEnumerable<Booking> GetUserBookings(int id);
        CampingLocation GetImageData(int imgdata);
        IEnumerable<CampingReview> GetReviews();
        void AddReview(CampingReview review);
    }
}
