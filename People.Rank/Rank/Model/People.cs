using System.ComponentModel.DataAnnotations;

namespace Rank.Model
{
    public class People
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required, Display(Name = "Phone Number")]

        public string PhoneNumber { get; set; }
        public string Details { get; set; }
        [Required, Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }
        [Required, Display(Name = "Update Date")]
        public DateTime UpdateDate { get; set; }
        [Required, Display(Name ="User")]
        public string UserId { get; set; }
        [Display(Name="Picture")]
        public string PicturePath { get; set; }
      //  [Required]
       // public Status statusId { get; set; }

        


    }
}
