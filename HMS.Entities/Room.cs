using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Entities
{
    [Table(nameof(Room))]
    public class Room : BaseEntity<int>
    {
        [Column(TypeName = "varchar(32)")]
        [MaxLength(32)]
        [Required]
        public string RoomNumber { get; set; }

        public ICollection<Patient> Patients { get; set; }

        public Doctor? Doctor { get; set; }
    }
}
