//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FoodyExpressApp.Models
//{
//    class User
//    {
//    }
//}
using System;

namespace FoodyExpressApp.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username => $"{FirstName.ToLower()}.{LastName.ToLower()}";
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
    }
}

