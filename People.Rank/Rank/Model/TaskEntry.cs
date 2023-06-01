using static Rank.Code.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rank.Model
{

    [Table("TaskEntry")]
    public class TaskEntry
    {

        public int Id { get; set; }


        [Required, Display (Name ="People ID")]
        public int peopleId { get; set; } // Relation

        [Required, Display(Name = "Category ID")]
        public int CategoryId { get; set; } // Relation

        [Required]
        public TaskType TaskTypeId { get; set; }  


        
        public string Note { get; set; }
        [Required]
        public int Mark{ get; set; }
        
        public string Details { get; set; }



        [Required, Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; }

        [Required, Display(Name = "Update Date")]
        public DateTime UpdateDate { get; set; }
        [Required, Display(Name = "User")]
        public string UserId { get; set; }
        [Display(Name = "File")]
        public string FilePath { get; set; }

        [Required]
        public Status statusId { get; set; }


        public virtual People People { get; set; }
        public virtual Category Category { get; set; }  

    }
}
