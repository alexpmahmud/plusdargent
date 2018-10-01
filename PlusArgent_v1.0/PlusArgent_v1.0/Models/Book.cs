using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlusArgent_v1._0.Models
{
    public class Book
    {

        [Column("IdBook")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBook { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public enum BookRepeatPeriod
        {
            [Display(Name = " ")]
            NoRepeat = 0,
            [Display(Name = "Day")]
            Day = 1,
            [Display(Name = "Week")]
            Week = 2,
            [Display(Name = "Bi-Week")]
            BiWeek = 3,
            [Display(Name = "Month")]
            Month = 4,
            [Display(Name = "Trimester")]
            Trimester = 5,
            [Display(Name = "Semester")]
            Semester = 6,
            [Display(Name = "Annual")]
            Annual = 7
        }

        [Required]
        [Display(Name = "Repeat Period")]
        public BookRepeatPeriod RepeatPeriod { get; set; }

        [MaxLength(1)]
        public string Type { get; set; }

        public int IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public virtual Category Category { get; set; }

        public int IdAccount { get; set; }
        [ForeignKey("IdAccount")]
        public virtual Account Account { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Parcel> Parcels { get; set; }


        [NotMapped]
        public string TypeHidden { get; set; }

        [NotMapped]
        public int Repeat { get; set; }

        [NotMapped]
        public int NParcels { get; set; }
    
        [NotMapped]
        public int isPay { get; set; }

        [NotMapped]
        public int IdAccountHidden { get; set; }
        
        [NotMapped]
        public BookRepeatPeriod RepeatPeriodHidden { get; set; }

        [NotMapped]
        public int NParcelsHidden { get; set; }


    }
}