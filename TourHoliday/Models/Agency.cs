using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TourHoliday.Models
{
    public class Agency
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string password { get; set; }
        [Required]
        [Column(TypeName = "jsonb")]
        public string ContactInformation { get; set; } // Stored as JSON

        [Required]
        [Column(TypeName = "jsonb")]
        public string AddedTours { get; set; } // Stored as JSON array of Tour IDs

        [Required]
        [Column(TypeName = "jsonb")]
        public string AppliedTours { get; set; } // Stored as JSON array of Tour IDs

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(50)]
        public int Status { get; set; } = 0;

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}