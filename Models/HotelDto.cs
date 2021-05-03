using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class HotelDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Hotel Name is too long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Address is too long.")]
        public string Address { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }
        public CountryDto Country { get; set; }
    }
}
