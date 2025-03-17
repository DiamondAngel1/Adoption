using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Animal.Infrastructure.Entities{
    [Table("tbl_shelter-locations")]
    public class ShelterLocation{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }= string.Empty;
        [Required]
        public string Adress { get; set; } = string.Empty;
        [StringLength(20)]
        public string? Phone { get; set; }

        public ICollection<AnimalEntity> Animals { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}