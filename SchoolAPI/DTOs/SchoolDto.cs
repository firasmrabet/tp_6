using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.DTOs
{
    public class SchoolDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Range(0, 5)]
        public double Rating { get; set; }
    }
}

