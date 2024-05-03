using CampSpot.Models;
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
    }
}
