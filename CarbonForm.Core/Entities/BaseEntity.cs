namespace CarbonForm.Core.Entities
{
    // Temel Varlık Sınıfı
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
