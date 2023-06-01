using static Rank.Code.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rank.Model
{
    [Table("Category")]
    
    public class Category
    {


        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Details { get; set; }



        [Required, Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Required, Display(Name = "Update Date")]
        public DateTime UpdateDate { get; set; }
        [Required, Display(Name = "User")]
        public string UserId { get; set; }
        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        [Required]
        public Status statusId { get; set; }

    }
}
