using Microsoft.AspNetCore.Identity;

namespace Api
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherId { get; set; }
        public string SchoolSystem { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string SchoolName { get; set; }
        public bool IsWorldonePassword { get; set; } = false;
        public string WorldonePassword { get; set; } = null;
    }
}