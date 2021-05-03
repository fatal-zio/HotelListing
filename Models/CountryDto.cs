using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CountryDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Country name is too long.")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Short Name is too long. Must be 2 characters.")]
        public string ShortName { get; set; }
        public IList<HotelDto> Hotels { get; set; }
    }
}
