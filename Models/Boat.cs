using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LmycAPI.Models
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }
        [Required]
        [Display(Name = "Boats Name")]
        public string BoatName { get; set; }
        [Required]
        [Display(Name = "Boats Picture")]
        public string Picture { get; set; }
        [Required]
        [Display(Name = "Feet (In Inches)")]
        public int FeetInInches { get; set; }
        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }
        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime RecordCreationDate { get; set; }

        [ForeignKey("User")]
        [Column("Id")]
        public string CreatedBy { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}