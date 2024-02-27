using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Car
    {
        public int CartId { get; set; }

        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Model { get; set; }
        public int? Price { get; set; }
        public int? Mileage { get; set; }
        public string? Status { get; set; }
    }
}