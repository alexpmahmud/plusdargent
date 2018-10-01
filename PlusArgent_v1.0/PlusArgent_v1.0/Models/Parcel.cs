using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusArgent_v1._0.Models
{
    public class Parcel
    {

        [Column("IdParcel")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdParcel { get; set; }

        [Required]
        public int ParcelNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PayDay { get; set; }

        public int IdBook { get; set; }
        [ForeignKey("IdBook")]
        public virtual Book Book { get; set; }


    }
}