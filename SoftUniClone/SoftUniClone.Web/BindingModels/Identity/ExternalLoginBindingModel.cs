namespace SoftUniClone.Web.BindingModels.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
