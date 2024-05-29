using System.Text;

namespace CampSpot.Models
{
    public class User
    {
        public int ID { get; private set; }
        public int UserType { get; set; }
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: ");
            sb.Append(ID);
            sb.Append(" UserType: ");
            sb.Append(UserType);
            sb.Append(" Email: ");
            sb.Append(Email);
            sb.Append(" UserName: ");
            sb.Append(UserName);
            sb.Append(" FirstName: ");
            sb.Append(FirstName);
            sb.Append(" LastName: ");
            sb.Append(LastName);
            sb.Append(" Password: ");
            sb.Append(Password);
            //sb.Append(" DateOfBirth: ");
            //sb.Append(DateOfBirth);
            //sb.Append(" DateCreated: ");
            //sb.Append(DateCreated);
            sb.Append(" Address: ");
            sb.Append(Address);
            sb.Append(" PhoneNumber: ");
            sb.Append(PhoneNumber);
            sb.Append(" IsDeleted: ");
            sb.Append(IsDeleted);
            return sb.ToString();
        }
    }
    

    
}
