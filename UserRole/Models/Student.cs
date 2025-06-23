using Microsoft.AspNetCore.Identity;

namespace UserRoles.Models
{

    public class Student : IdentityUser
    {


        public string FullName { get; set; }


    }
}