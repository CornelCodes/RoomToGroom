using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("Pets")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PetId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Breed { get; set; }
        public long CustomerId { get; set; }
        public string TagSerialNumber { get; set; }
        public string VisualDescription { get; set; }
        public string Allergies { get; set; }

    }
}
