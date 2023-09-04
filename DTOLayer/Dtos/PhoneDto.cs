using System.ComponentModel.DataAnnotations;

namespace DTOLayer.Dtos
{
    public class PhoneDto : DtoBase
    {
        [Required(ErrorMessage = "Brand name cannot be empty!")]
        public string BrandName { get; set; }
        [Required(ErrorMessage = "Brand model cannot be empty!")]
        public string BrandModel { get; set; }
        [Required(ErrorMessage = "Price cannot be empty!")]
        [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative number!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "City name cannot be empty!")]
        public string CityName { get; set; }
        public string? ImagePath { get; set; }
    }
}