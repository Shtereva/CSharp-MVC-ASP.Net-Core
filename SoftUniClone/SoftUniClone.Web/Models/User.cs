namespace SoftUniClone.Web.Models
{
    using Microsoft.AspNetCore.Identity;
    public class User : IdentityUser
    {
        public string AvatarUrl { get; set; }
    }
}
