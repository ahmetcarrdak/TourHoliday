using System;
using System.ComponentModel.DataAnnotations;

namespace TourHoliday.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}