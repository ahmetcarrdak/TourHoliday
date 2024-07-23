using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourHoliday.Models
{
    public class AgencySaleTour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        public Agency Agency { get; set; }

        [Required]
        public int TourId { get; set; }

        [ForeignKey("TourId")]
        public Tour Tour { get; set; }
        
        public int Status { get; set; } = 0;

        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}