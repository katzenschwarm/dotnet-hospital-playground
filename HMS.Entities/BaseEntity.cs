using System.ComponentModel.DataAnnotations;

namespace HMS.Entities
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
