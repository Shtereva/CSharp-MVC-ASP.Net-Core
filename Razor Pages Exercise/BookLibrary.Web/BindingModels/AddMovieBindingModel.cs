namespace BookLibrary.Web.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddMovieBindingModel
    {
        [Required(ErrorMessage = "Title field is required")]
        [MaxLength(100, ErrorMessage = "Title can't be grater than 100 characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "Image Url")]
        [Url]
        public string CoverImg { get; set; }

        [Required(ErrorMessage = "Director field is required")]
        [MaxLength(100, ErrorMessage = "Name can't be grater than 100 characters")]
        [Display(Name = "Director")]
        public string Director { get; set; }
    }
}
