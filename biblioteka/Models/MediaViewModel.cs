using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace biblioteka.Models;
public class MediaViewModel
{

    [HiddenInput]
    public int? Id { get; set; }

    [Required(ErrorMessage = "Title is missing!")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Author is missing!")]
    public string Author { get; set; }

    public Status? Status { get; set; }

    public Category? Category { get; set; }

}

