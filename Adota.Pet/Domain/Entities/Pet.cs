namespace Adota.Pet.Domain.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt {get; set;}
        public string Name { get; set; }
        public string Type {get; set;}
    }
}
