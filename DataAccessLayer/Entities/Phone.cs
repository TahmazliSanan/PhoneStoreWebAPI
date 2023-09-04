namespace DataAccessLayer.Entities
{
    public class Phone : EntityBase
    {
        public string BrandName { get; set; }
        public string BrandModel { get; set; }
        public double Price { get; set; }
        public string CityName { get; set; }
        public DateTime DateOfSharing { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
    }
}