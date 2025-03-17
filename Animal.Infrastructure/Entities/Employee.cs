using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Animal.Infrastructure.Entities{
    [Table("employees")]
    public class Employee{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Required, StringLength(100)]
        public string LastName { get; set; } = null!;
        [StringLength(100)]
        public string? Position { get; set; }
        public DateOnly HireDate { get; set; }
        [ForeignKey("ShelterLocation")]
        public int? ShelterLocationId { get; set; }
        public ShelterLocation? ShelterLocation { get; set; }
        public ICollection<AnimalEntity> Animals { get; set; }
    }
}