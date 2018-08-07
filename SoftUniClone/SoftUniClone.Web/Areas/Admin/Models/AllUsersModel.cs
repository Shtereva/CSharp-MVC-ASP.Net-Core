namespace SoftUniClone.Web.Areas.Admin.Models
{
    using Infrastructure;
    using SoftUniClone.Models;
    public class AllUsersModel : IMapFrom<User>
    {
        public string Username { get; set; }
        
    }
}
