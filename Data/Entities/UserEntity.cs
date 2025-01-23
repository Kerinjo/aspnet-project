using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("user")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<MediaEntity>? Media { get; set; }

        [Required]
        public ICollection<ReviewEntity>? Reviews { get; set; }
    }
}