using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusArgent_v1._0.Models
{
    public class Transaction
    {

        [Column("IdTransaction")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTransaction { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int IdAccount { get; set; }
        [ForeignKey("IdAccount")]
        public virtual Account Account { get; set; }

        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; }


    }
}