namespace CampSpot.Models
{
    public class User
    {
        public int ID { get; private set; }
        public int UserType { get; private set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        //public DateOnly DateOfBirth { get; set; }
        //public DateTime DateCreated { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; } 
        public bool IsDeleted { get; private set; }



    }

    
}
