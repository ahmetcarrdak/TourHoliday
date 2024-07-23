using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourHoliday.Models
{
    public class CountryCurrency
    {
        [Key]
        [MaxLength(2)]
        public string CountryCode { get; set; }

        [Required]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string CurrencySymbol { get; set; }
    }
}