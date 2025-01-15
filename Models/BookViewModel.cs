using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace biblioteka.Models
{
    public enum Category
    {
        Planned,
        Reading,
        Read
    }

    public class BookViewModel
    {

        [HiddenInput]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Title is missing!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is missing!")]
        public string Author { get; set; }

        public Category Status { get; set; }
    }
}
