namespace BookLibrary.Web.BindingModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BorrowBookBindingModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
    }
}
