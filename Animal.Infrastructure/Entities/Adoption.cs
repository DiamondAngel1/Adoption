using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Infrastructure.Entities
{
    [Table("adoptions")]
    public class Adoption
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public AnimalEntity Animal { get; set; } = default!;
        [ForeignKey("Adopter")]
        public int AdopterId { get; set;}
        public Adopter Adopter { get; set; } = default!;
        public DateOnly AdoptionDate { get; set; }
        public ICollection<AnimalEntity> Animals { get; set; }
    }
}
