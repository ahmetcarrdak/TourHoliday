using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourHoliday.Models
{
    public class Tour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AddedById { get; set; } // User ID

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Type { get; set; } // One-day or Multi-day

        public string Details { get; set; }

        [MaxLength(255)]
        public string Categories { get; set; } // Comma-separated string for simplicity

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        
        [ForeignKey("CountryCode")]
        public CountryCurrency CountryCurrency { get; set; }

        public int Status { get; set; } = 0;
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}