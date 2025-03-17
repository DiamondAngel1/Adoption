using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal.Infrastructure.Entities{
    [Table("medical_records")]
    public class MedicalRecord{
        [Key]
        public int Id { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public AnimalEntity Animal { get; set; } = default;
        public DateOnly CheckupDate { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        [StringLength(255)]
        public string? VetName { get; set; }
        public ICollection<AnimalEntity> Animals { get; set; }
    }
}
