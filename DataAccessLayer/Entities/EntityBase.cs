namespace DataAccessLayer.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public int CreateId { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdateId { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}