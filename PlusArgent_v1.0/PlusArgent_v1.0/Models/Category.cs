using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusArgent_v1._0.Models
{
    public class Category
    {
        [Column("IdCategory")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCategory { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }



        public enum CategoryTypes
        {
            [Display(Name = "System")]
            System = 1,
            [Display(Name = "User")]
            User = 2
        }

        [Required]
        [Display(Name = "Type")]
        public CategoryTypes Type { get; set; }


        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }


        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

    }
}