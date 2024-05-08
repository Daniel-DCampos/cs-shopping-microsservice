using Microsoft.AspNetCore.Identity;

namespace CSShopping.IdentityServer.ModelDatabase
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
