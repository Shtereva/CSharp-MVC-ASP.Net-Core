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

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; } = DateTime.Today;

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
    }
}
