using System;
using System.ComponentModel.DataAnnotations;

namespace TourHoliday.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }  // Şifreyi düz metin olarak saklıyoruz

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int Status { get; set; } = 0;
    }
}