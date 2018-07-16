namespace BookLibrary.Web.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddBorrowerBindingModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
