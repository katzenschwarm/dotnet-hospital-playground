using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities
{
    [Table(nameof(Patient))]
    public class Patient : BaseEntity<int>
    {
        [Column(TypeName = "varchar(64)")]
        [MaxLength(64)]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(128)")]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Column(TypeName = "varchar(255)")]
        [MaxLength(255)]
        [Required]
        public string Disease { get; set; }

        public Room? Room { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
