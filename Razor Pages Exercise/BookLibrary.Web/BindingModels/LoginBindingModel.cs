namespace BookLibrary.Web.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class LoginBindingModel
    {
        [Required]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
