using System.ComponentModel.DataAnnotations;

namespace CleanCityAPI.Models.DTOs
{
    public class OperatorUpdateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
