using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Data.Entities
{
    [Table("media")]
    public class MediaEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Title { get; set; }

        [MaxLength(100)]
        [Required]
        public string Author { get; set; }

        [Required]
        public Status? Status { get; set; }

        [Required]
        public Category? Category { get; set; }
    }
}
