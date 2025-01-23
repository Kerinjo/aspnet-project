using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Data.Entities
{
    [Table("review")]
    public class ReviewEntity
    {
        [Key]
        public int Id { get; set; }

        public int UserID { get; set; }
        public int MediaID { get; set; }

        public string Content { get; set; }
        public Rating? Rating { get; set; }
    }
}