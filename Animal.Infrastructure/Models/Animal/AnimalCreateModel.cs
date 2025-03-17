namespace Animal.Infrastructure.Models.Animal
{
    /// <summary>
    /// Модель для створення тварини
    /// </summary>
    public class AnimalCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SpecieId { get; set; }
    }
}
