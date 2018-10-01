using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using PlusArgent_v1._0.Utils;

namespace PlusArgent_v1._0.Models
{
    public class User
    {

        [Column("IdUser")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }


        [Display(Name = TextDisplay.FullName)]
        [Required(ErrorMessage = TextMessages.MsgRequired)]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Display(Name = TextDisplay.Email)]
        [Required(ErrorMessage = TextMessages.MsgRequired)]
        [MaxLength(100, ErrorMessage = TextMessages.MsgLengthMax)]
        [EmailAddress(ErrorMessage = TextMessages.MsgEmailError)]
        public string Email { get; set; }


        [Display(Name = TextDisplay.Password)]
        [Required(ErrorMessage = TextMessages.MsgRequired)]
        [StringLength(10, ErrorMessage = TextMessages.MsgLengthMinMax , MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = TextDisplay.Photo)]
        [MaxLength(255)]
        public string Photo { get; set; }

        [NotMapped]
        public virtual ICollection<Account> Accounts { get; set; }

        [NotMapped]
        public virtual ICollection<Category> Categories { get; set; }

        [Display(Name = TextDisplay.PasswordConfirm)]
        [NotMapped]
        [Compare("Password", ErrorMessage = TextMessages.MsgPasswordConfirm)]
        public string ConfirmPassword { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        [NotMapped]
        public string EmailOld { get; set; }

    }
}