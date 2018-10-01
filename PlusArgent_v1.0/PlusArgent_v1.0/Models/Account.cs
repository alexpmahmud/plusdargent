using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlusArgent_v1._0.Utils;

namespace PlusArgent_v1._0.Models
{
    public class Account
    {

        [Column("IdAccount")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAccount { get; set; }

        [Required(ErrorMessage = TextMessages.MsgRequired)]
        [MaxLength(255, ErrorMessage = TextMessages.MsgLengthMax)]
        [Display(Name = TextDisplay.Description)]
        public string Description { get; set; }
      

        [Required(ErrorMessage = TextMessages.MsgRequired)]
        [Display(Name = TextDisplay.Type)]
        public Enums.AccountTypes Type { get; set; }

        [Display(Name = TextDisplay.DateDue)]
        [Range(1,31,ErrorMessage = TextMessages.MsgRange)]
        public int? DateDue { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }


        [NotMapped]
        public virtual ICollection<Transaction> Transactions { get; set; }

        [NotMapped]
        public virtual ICollection<Book> Books { get; set; }

    }
}