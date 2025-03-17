using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Animal.Infrastructure.Entities{
    [Table("adopters")]
    public class Adopter{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string FirstName { get; set; } = null!;
        [Required, StringLength(100)]
        public string LastName { get; set; } = null!;
        [Required, StringLength(20)]
        public string Phone { get; set; } = null!;
        [StringLength(100)]
        public string? Email { get; set; }
        public string? Address { get; set; }
        public ICollection<AnimalEntity> Animals { get; set; }
    }
}