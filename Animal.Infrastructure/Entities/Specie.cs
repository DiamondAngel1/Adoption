using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Animal.Infrastructure.Entities
{
    [Table("tbl_species")]
    public class Specie
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<AnimalEntity> Animals { get; set; } = [];
    }
}
